using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using DevExpress.Map;
using DevExpress.Xpf.Map;

namespace VectorTileProvider {
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();
		}
		void Grid_SizeChanged(object sender, SizeChangedEventArgs e) {
			UpdateClip(e.NewSize.Width);
		}
		void Layer_ViewportChanged(object sender, ViewportChangedEventArgs e) {
			UpdateClip(this.leftPanel.ActualWidth);
		}
		void UpdateClip(double width) {
			CoordPoint newSplit = this.map.ScreenPointToCoordPoint(new Point(width, 0));
			double splitLongitude = newSplit.GetX();
			this.left.Bounds = new CoordPointCollection() {
				new GeoPoint(-90, -180),
				new GeoPoint(90, -180),
				new GeoPoint(90, splitLongitude),
				new GeoPoint(-90, splitLongitude)
			};
			this.right.Bounds = new CoordPointCollection(){
				new GeoPoint(-90, 180),
				new GeoPoint(90, 180),
				new GeoPoint(90, splitLongitude),
				new GeoPoint(-90, splitLongitude)
			};
		}
	}
}
