﻿using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

using FrEee.Modding;
using FrEee.Modding.Templates;
using FrEee.Modding.Loaders;
using FrEee.Game.Objects.Technology;
using FrEee.Game.Objects.Vehicles;
using FrEee.Game.Objects.Space;
using FrEee.Game.Objects.Civilization;
using FrEee.Game.Objects.Abilities;
using FrEee.Game.Objects;
using FrEee.Modding.Enumerations;
using FrEee.Game.Interfaces;
using FrEee.Game.Objects.Combat2;
using FrEee.Utility.Extensions;

using NewtMath.f16;

namespace FrEee.Tests.Game.Objects.Combat2
{



    public static class testships2
    {
        public static Dictionary<string, ComponentTemplate> Components(Galaxy gal)
        {

            Mod mod = Mod.Load(null); 
            Dictionary<string, ComponentTemplate> components = new Dictionary<string, ComponentTemplate>();

            ComponentTemplate armor = mod.ComponentTemplates.FindByName("Armor I");
            gal.AssignID(armor);
            components.Add("AMR", armor);

            ComponentTemplate bridge = mod.ComponentTemplates.FindByName("Bridge");
            gal.AssignID(bridge);
            components.Add("BDG", bridge);


            var lifesuport = mod.ComponentTemplates.FindByName("Life Support");
            gal.AssignID(lifesuport);
            components.Add("LS", lifesuport);

            var crewQuarters = mod.ComponentTemplates.FindByName("Crew Quarters");
            gal.AssignID(crewQuarters);
            components.Add("CQ", crewQuarters);

            var engine = mod.ComponentTemplates.FindByName("Ion Engine I");
            gal.AssignID(engine);
            components.Add("Engn", engine);

            var cannon = mod.ComponentTemplates.FindByName("Depleted Uranium Cannon I");
            gal.AssignID(cannon);
            components.Add("Wpn_DF", cannon);

            var laser = mod.ComponentTemplates.FindByName("Anti - Proton Beam I");
            gal.AssignID(laser);
            components.Add("Wpn_BEAM", laser);

            var missleLauncher = mod.ComponentTemplates.FindByName("Capital Ship Missile I");
            gal.AssignID(missleLauncher);
            components.Add("Wpn_SK", missleLauncher);

            return components;
        }

        public static Empire empire(string name, Culture culture, Race race)
        {
            Empire emp = new Empire();
            emp.Name = name;
            emp.Culture = culture;
            emp.PrimaryRace = race;

            return emp;
        }

        public static Design<Ship> EscortDUC(Galaxy gal, Empire emp, Dictionary<string, ComponentTemplate> components)
        {
            Mod mod = Mod.Load(null); 
            Design<Ship> design = new Design<Ship>();
            gal.AssignID(design);
            design.Owner = emp;

            List<MountedComponentTemplate> mctlist = genericlistofcomponents(design, components);

            mctlist.Add(new MountedComponentTemplate(design, components["Wpn_DF"], null));
            mctlist.Add(new MountedComponentTemplate(design, components["AMR"], null));

            foreach (var mct in mctlist)
                design.Components.Add(mct);

            design.Hull = (Hull<Ship>)mod.Hulls.FindByName("Escort");
            design.Strategy = new StragegyObject_Default();
            //designs.Add(design);
            return design;
        }

        public static List<MountedComponentTemplate> genericlistofcomponents(Design<Ship> design, Dictionary<string, ComponentTemplate> components)
        {
            List<MountedComponentTemplate> mctlist = new List<MountedComponentTemplate>();
            mctlist.Add(new MountedComponentTemplate(design, components["BDG"], null));
            mctlist.Add(new MountedComponentTemplate(design, components["LS"], null));
            mctlist.Add(new MountedComponentTemplate(design, components["CQ"], null));
            mctlist.Add(new MountedComponentTemplate(design, components["Engn"], null));
            mctlist.Add(new MountedComponentTemplate(design, components["Engn"], null));
            mctlist.Add(new MountedComponentTemplate(design, components["Engn"], null));
            mctlist.Add(new MountedComponentTemplate(design, components["Engn"], null));
            mctlist.Add(new MountedComponentTemplate(design, components["Engn"], null));

            return mctlist;
        }

        public static SpaceVehicle testShip(SimulatedEmpire emp, Design<Ship> design, int ID)
        {
            SimulatedSpaceObject simveh = new SimulatedSpaceObject((SpaceVehicle)design.Instantiate());
            simveh.SpaceObject.ID = ID;
            SpaceVehicle spaceveh = (SpaceVehicle)simveh.SpaceObject;
            spaceveh.Owner = emp.Empire;
            emp.SpaceObjects.Add(simveh);
            return spaceveh;
        }
    }

    


    [TestClass]
    public class CombatVehicleTests
    {
        Galaxy gal = new Galaxy();
        StarSystem sys = new StarSystem(1);
        Sector location;
        Battle_Space battle;
        
        public void setupEnvironment()
        {
            location = new Sector(sys, new System.Drawing.Point());
            
            SimulatedEmpire simemp = new SimulatedEmpire(testships2.empire("TestEmpOne", new Culture(), new Race()));
            Design<Ship> design = testships2.EscortDUC(gal, simemp.Empire, testships2.Components(gal));
            SpaceVehicle sv = testships2.testShip(simemp, design, 100);
            location.Place(sv);

            battle = new Battle_Space(location);
        }

        [TestMethod]
        public void Combat_Nav10()
        {

            setupEnvironment();
            Console.WriteLine("Nav test 0");

            battle.Start();

            Compass startHeading = new Compass(0, false);
            Compass angletoWaypoint = new Compass(0, false);
            PointXd waypntloc = new PointXd(0, 1000, 0);
            PointXd waypndVel = new PointXd(0, 1000, 0);
            combatWaypoint waypoint = new combatWaypoint(waypntloc, waypndVel);

            bool expectedToWaypoint = true;
            Compass expectedHeading = new Compass(0);
            Tuple<Compass, bool> expectednav = new Tuple<Compass, bool>(expectedHeading, expectedToWaypoint);
            CombatVehicle testComObj = battle.CombatVehicles.ToArray()[0];
            testComObj.cmbt_loc = new PointXd(0, 0, 0);
            testComObj.cmbt_vel = new PointXd(0, 0, 0);
            testComObj.cmbt_head = new Compass(startHeading.Degrees, false);
            Tuple<Compass, bool> nav = testComObj.testNav(angletoWaypoint);
            battle.End(1);
            Assert.AreEqual(expectednav.Item1.Degrees, nav.Item1.Degrees);
            Assert.AreEqual(expectednav.Item2, nav.Item2);
        }

        [TestMethod]
        public void Combat_Nav11()
        {

            setupEnvironment();
            Console.WriteLine("Nav test 11");

            battle.Start();

            Compass startHeading = new Compass(0, false);
            Compass angletoWaypoint = new Compass(180, false);
            PointXd waypntloc = new PointXd(0, -1000, 0);
            PointXd waypndVel = new PointXd(0, 0, 0);
            combatWaypoint waypoint = new combatWaypoint(waypntloc, waypndVel);

            bool expectedToWaypoint = true;
            Compass expectedHeading = new Compass(180, false);
            Tuple<Compass, bool> expectednav = new Tuple<Compass, bool>(expectedHeading, expectedToWaypoint);
            CombatVehicle testComObj = battle.CombatVehicles.ToArray()[0];
            testComObj.cmbt_loc = new PointXd(0, 0, 0);
            testComObj.cmbt_vel = new PointXd(0, 0, 0);
            testComObj.cmbt_head = new Compass(startHeading.Degrees, false);
            Tuple<Compass, bool> nav = testComObj.testNav(angletoWaypoint);
            battle.End(1);
            Assert.AreEqual(expectednav.Item1.Degrees, nav.Item1.Degrees);
            Assert.AreEqual(expectednav.Item2, nav.Item2);
        }

        [TestMethod]
        public void Combat_Nav12()
        {

            setupEnvironment();
            Console.WriteLine("Nav test 12");

            battle.Start();

            Compass startHeading = new Compass(0, false);
            Compass angletoWaypoint = new Compass(0, false);
            PointXd waypntloc = new PointXd(0, 10, 0);
            PointXd waypndVel = new PointXd(0, 0, 0);
            combatWaypoint waypoint = new combatWaypoint(waypntloc, waypndVel);

            bool expectedToWaypoint = false;
            Compass expectedHeading = new Compass(180, false);
            Tuple<Compass, bool> expectednav = new Tuple<Compass, bool>(expectedHeading, expectedToWaypoint);
            CombatVehicle testComObj = battle.CombatVehicles.ToArray()[0];
            testComObj.cmbt_loc = new PointXd(0, 0, 0);
            testComObj.cmbt_vel = new PointXd(0, 5, 0);
            testComObj.maxRotate = new Compass(45, false);
            testComObj.cmbt_head = new Compass(startHeading.Degrees, false);
            Tuple<Compass, bool> nav = testComObj.testNav(angletoWaypoint);
            battle.End(1);
            Assert.AreEqual(expectednav.Item1.Degrees, nav.Item1.Degrees);
            Assert.AreEqual(expectednav.Item2, nav.Item2);
        }

    }
}
