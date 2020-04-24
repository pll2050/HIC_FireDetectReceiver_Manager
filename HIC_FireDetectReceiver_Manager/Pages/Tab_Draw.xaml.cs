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

using NetworkUI;
using System.Diagnostics;
using System.Windows.Controls.Primitives;
using Utils;
using NetworkModel;
using System.Collections;

namespace HIC_FireDetectReceiver_Manager.Pages
{
    /// <summary>
    /// Tab_Draw.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Tab_Draw : Page
    {
        public Tab_Draw()
        {
            InitializeComponent();
        }

        public Src.DrawModel ViewModel
        {
            get
            {
                return (Src.DrawModel)this.DataContext;
            }
        }

        private void networkControl_ConnectionDragStarted(object sender, ConnectionDragStartedEventArgs e)
        {
            var draggedOutConnector = (ConnectorViewModel)e.ConnectorDraggedOut;
            var curDragPoint = Mouse.GetPosition(networkControl);

            var connection = this.ViewModel.ConnectionDragStarted(draggedOutConnector, curDragPoint);

            e.Connection = connection;
        }

        private void networkControl_ConnectionDragging(object sender, ConnectionDraggingEventArgs e)
        {
            var curDragPoint = Mouse.GetPosition(networkControl);
            var connection = (ConnectionViewModel)e.Connection;
            this.ViewModel.ConnectionDragging(connection, curDragPoint);
        }

        private void networkControl_ConnectionDragCompleted(object sender, ConnectionDragCompletedEventArgs e)
        {
            var connectorDraggedOut = (ConnectorViewModel)e.ConnectorDraggedOut;
            var connectorDraggedOver = (ConnectorViewModel)e.ConnectorDraggedOver;
            var newConnection = (ConnectionViewModel)e.Connection;
            this.ViewModel.ConnectionDragCompleted(newConnection, connectorDraggedOut, connectorDraggedOver);
        }

        private void DeleteSelectedNodes_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.ViewModel.DeleteSelectedNodes();
        }

        private void CreateDetector_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Point newNodeLocation = Mouse.GetPosition(networkControl);
            this.ViewModel.CreateDetector("New Node!", newNodeLocation);
        }
        private void CreateRepeater_Executed(object sender, ExecutedRoutedEventArgs e)
        {
        }
        private void CreateReceiver_Executed(object sender, ExecutedRoutedEventArgs e)
        {
        }

    }
}
