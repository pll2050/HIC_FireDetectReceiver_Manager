using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkModel;
using Utils;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace HIC_FireDetectReceiver_Manager.Src
{
    public class DrawModel : AbstractModelBase
    {
        #region Internal Data Members

        public NetworkViewModel network = null;

        #endregion Internal Data Members

        public DrawModel()
        {
            PopulateWithTestData();
        }

        public NetworkViewModel Network
        {
            get
            {
                return network;
            }
            set
            {
                network = value;

                OnPropertyChanged("Network");
            }
        }

        public ConnectionViewModel ConnectionDragStarted(ConnectorViewModel draggedOutConnector, Point curDragPoint)
        {
            if (draggedOutConnector.AttachedConnection != null)
            {
                this.Network.Connections.Remove(draggedOutConnector.AttachedConnection);
            }

            var connection = new ConnectionViewModel();

            connection.SourceConnector = draggedOutConnector;

            connection.DestConnectorHotspot = curDragPoint;

            this.Network.Connections.Add(connection);

            return connection;
        }

        public void ConnectionDragging(ConnectionViewModel connection, Point curDragPoint)
        {
            connection.DestConnectorHotspot = curDragPoint;
        }

        public void ConnectionDragCompleted(ConnectionViewModel newConnection, ConnectorViewModel connectorDraggedOut, ConnectorViewModel connectorDraggedOver)
        {
            if (connectorDraggedOver == null)
            {
                this.Network.Connections.Remove(newConnection);
                return;
            }

            var existingConnection = connectorDraggedOver.AttachedConnection;
            if (existingConnection != null)
            {
                this.Network.Connections.Remove(existingConnection);
            }

            newConnection.DestConnector = connectorDraggedOver;
        }

        public void DeleteSelectedNodes()
        {
            var nodesCopy = this.Network.Nodes.ToArray();

            foreach (var node in nodesCopy)
            {
                if (node.IsSelected)
                {
                    DeleteNode(node);
                }
            }
        }

        public void DeleteNode(NodeViewModel node)
        {
            this.Network.Connections.RemoveRange(node.AttachedConnections);

            this.Network.Nodes.Remove(node);
        }

        //public NodeViewModel CreateNode(string name, Point nodeLocation)
        //{
        //    var node = new NodeViewModel(name);
        //    node.X = nodeLocation.X;
        //    node.Y = nodeLocation.Y;

        //    node.Connectors.Add(new ConnectorViewModel());
        //    node.Connectors.Add(new ConnectorViewModel());
        //    node.Connectors.Add(new ConnectorViewModel());
        //    node.Connectors.Add(new ConnectorViewModel());

        //    this.Network.Nodes.Add(node);

        //    return node;
        //}
        public NodeViewModel CreateDetector(string name, Point nodeLocation)
        {
            var node = new NodeViewModel(name);
            node.X = nodeLocation.X;
            node.Y = nodeLocation.Y;

            node.Connectors.Add(new ConnectorViewModel());
            node.Connectors.Add(new ConnectorViewModel());
            node.Connectors.Add(new ConnectorViewModel());
            node.Connectors.Add(new ConnectorViewModel());

            this.Network.Nodes.Add(node);

            return node;
        }
        public NodeViewModel CreateRepeater(string name, Point nodeLocation)
        {
            var node = new NodeViewModel(name);
            node.X = nodeLocation.X;
            node.Y = nodeLocation.Y;

            node.Connectors.Add(new ConnectorViewModel());
            node.Connectors.Add(new ConnectorViewModel());
            node.Connectors.Add(new ConnectorViewModel());
            node.Connectors.Add(new ConnectorViewModel());

            this.Network.Nodes.Add(node);

            return node;
        }
        public NodeViewModel CreateReceiver(string name, Point nodeLocation)
        {
            var node = new NodeViewModel(name);
            node.X = nodeLocation.X;
            node.Y = nodeLocation.Y;

            node.Connectors.Add(new ConnectorViewModel());
            node.Connectors.Add(new ConnectorViewModel());
            node.Connectors.Add(new ConnectorViewModel());
            node.Connectors.Add(new ConnectorViewModel());

            this.Network.Nodes.Add(node);

            return node;
        }
        #region Private Methods

        private void PopulateWithTestData()
        {
            this.Network = new NetworkViewModel();

            var node1 = CreateDetector("Node1", new Point(10, 10));
            var node2 = CreateDetector("Node2", new Point(200, 10));

            var connection = new ConnectionViewModel();
            connection.SourceConnector = node1.Connectors[1];
            connection.DestConnector = node2.Connectors[3];

            this.Network.Connections.Add(connection);
        }

        #endregion Private Methods
    }

    public class Arrow : Shape
    {
        #region Dependency Property/Event Definitions

        public static readonly DependencyProperty ArrowHeadLengthProperty =
            DependencyProperty.Register("ArrowHeadLength", typeof(double), typeof(Arrow),
                new FrameworkPropertyMetadata(20.0, FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty ArrowHeadWidthProperty =
            DependencyProperty.Register("ArrowHeadWidth", typeof(double), typeof(Arrow),
                new FrameworkPropertyMetadata(12.0, FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty DotSizeProperty =
            DependencyProperty.Register("DotSize", typeof(double), typeof(Arrow),
                new FrameworkPropertyMetadata(3.0, FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty StartProperty =
            DependencyProperty.Register("Start", typeof(Point), typeof(Arrow),
                new FrameworkPropertyMetadata(new Point(0.0, 0.0), FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty EndProperty =
            DependencyProperty.Register("End", typeof(Point), typeof(Arrow),
                new FrameworkPropertyMetadata(new Point(0.0, 0.0), FrameworkPropertyMetadataOptions.AffectsRender));

        #endregion Dependency Property/Event Definitions

        public double ArrowHeadLength
        {
            get
            {
                return (double)GetValue(ArrowHeadLengthProperty);
            }
            set
            {
                SetValue(ArrowHeadLengthProperty, value);
            }
        }

        public double ArrowHeadWidth
        {
            get
            {
                return (double)GetValue(ArrowHeadWidthProperty);
            }
            set
            {
                SetValue(ArrowHeadWidthProperty, value);
            }
        }

        public double DotSize
        {
            get
            {
                return (double)GetValue(DotSizeProperty);
            }
            set
            {
                SetValue(DotSizeProperty, value);
            }
        }

        public Point Start
        {
            get
            {
                return (Point)GetValue(StartProperty);
            }
            set
            {
                SetValue(StartProperty, value);
            }
        }

        public Point End
        {
            get
            {
                return (Point)GetValue(EndProperty);
            }
            set
            {
                SetValue(EndProperty, value);
            }
        }

        #region Private Methods

        protected override Geometry DefiningGeometry
        {
            get
            {
                LineGeometry geometry = new LineGeometry();
                geometry.StartPoint = this.Start;
                geometry.EndPoint = this.End;

                GeometryGroup group = new GeometryGroup();
                group.Children.Add(geometry);

                GenerateArrowHeadGeometry(group);
                
                return group;
            }
        }

        private void GenerateArrowHeadGeometry(GeometryGroup geometryGroup)
        {
            EllipseGeometry ellipse = new EllipseGeometry(this.Start, DotSize, DotSize);
            geometryGroup.Children.Add(ellipse);

            Vector startDir = this.End - this.Start;
            startDir.Normalize();
            Point basePoint = this.End - (startDir * ArrowHeadLength);
            Vector crossDir = new Vector(-startDir.Y, startDir.X);

            Point[] arrowHeadPoints = new Point[3];
            arrowHeadPoints[0] = this.End;
            arrowHeadPoints[1] = basePoint - (crossDir * (ArrowHeadWidth / 2));
            arrowHeadPoints[2] = basePoint + (crossDir * (ArrowHeadWidth / 2));

            PathFigure arrowHeadFig = new PathFigure();
            arrowHeadFig.IsClosed = true;
            arrowHeadFig.IsFilled = true;
            arrowHeadFig.StartPoint = arrowHeadPoints[0];
            arrowHeadFig.Segments.Add(new LineSegment(arrowHeadPoints[1], true));
            arrowHeadFig.Segments.Add(new LineSegment(arrowHeadPoints[2], true));

            PathGeometry pathGeometry = new PathGeometry();
            pathGeometry.Figures.Add(arrowHeadFig);

            geometryGroup.Children.Add(pathGeometry);
        }

        #endregion Private Methods
    }
}
