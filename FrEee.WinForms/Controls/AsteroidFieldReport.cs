using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FrEee.Game.Objects.Space;
using FrEee.Utility.Extensions;
using FrEee.Utility;

namespace FrEee.WinForms.Controls
{
	public partial class AsteroidFieldReport : UserControl
	{
		public AsteroidFieldReport()
		{
			InitializeComponent();
		}

		public AsteroidFieldReport(AsteroidField asteroidField)
			: this()
		{
			AsteroidField = asteroidField;
		}

		private AsteroidField asteroidField;

		/// <summary>
		/// The asteroid field for which to display a report.
		/// </summary>
		public AsteroidField AsteroidField
		{
			get { return asteroidField; }
			set
			{
				asteroidField = value;
				Invalidate();
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if (AsteroidField == null)
				Visible = false;
			else
			{
				Visible = true;

				picOwnerFlag.Image = null; // TODO - load owner flag
				picPortrait.Image = AsteroidField.Portrait;

				txtName.Text = AsteroidField.Name;
				txtSizeSurface.Text = AsteroidField.Size + " " + AsteroidField.Surface + " Asteroid Field";
				txtAtmosphere.Text = AsteroidField.Atmosphere;
				txtConditions.Text = ""; // TODO - load conditions

				txtValueMinerals.Text = AsteroidField.ResourceValue[Resource.Minerals].ToUnitString();
				txtValueOrganics.Text = AsteroidField.ResourceValue[Resource.Organics].ToUnitString();
				txtValueRadioactives.Text = AsteroidField.ResourceValue[Resource.Radioactives].ToUnitString();

				txtDescription.Text = AsteroidField.Description;

				abilityTreeView.Abilities = AsteroidField.UnstackedAbilities.StackToTree();
				abilityTreeView.IntrinsicAbilities = AsteroidField.IntrinsicAbilities;
			}

			base.OnPaint(e);
		}

		private void picPortrait_Click(object sender, System.EventArgs e)
		{
			picPortrait.ShowFullSize(AsteroidField.Name);
		}
	}
}
