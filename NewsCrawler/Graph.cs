using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nevron.Diagram;
using Nevron.Diagram.DataStructures;
using Nevron.Diagram.Filters;
using Nevron.Diagram.Layout;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.WinForm;
using Nevron.Dom;
using Nevron.GraphicsCore;

namespace NewsCrawler
{
    public partial class Graph : Form
    {
    

        private NSpringLayout m_Layout = new NSpringLayout();


        public Graph()
        {
            InitializeComponent();
            
            // hook the iteration completed event
            m_Layout.IterationCompleted += new GraphLayoutCancelEventHandler(layout_IterationCompleted);

            // select it in the property grid
            propertyGrid1.SelectedObject = m_Layout;

            view.BeginInit();
            view.Grid.Visible = false;
            view.GlobalVisibility.ShowPorts = false;
            view.GlobalVisibility.ShowArrowheads = false;
            view.ViewLayout = ViewLayout.Fit;

            // init document
            document.BeginInit();
            InitDocument();
            document.EndInit();

            // end view init
            view.EndInit();
        }

        private void Graph_Load(object sender, EventArgs e)
        {
           
        }

        public class NPerson
        {
            public NPerson(string name, NShape shape)
            {
                m_Shape = shape;
                m_Shape.Text = name;
                m_Name = name;
                m_SameArticle = new List<NPerson>();
            }

            public NShape m_Shape;
            public string m_Name;
            public List<NPerson> m_SameArticle;
        }

        private void CreatePredefinedGraph()
        {
            // we will be using basic shapes for this example
            NBasicShapesFactory basicShapesFactory = new NBasicShapesFactory();
            basicShapesFactory.DefaultSize = new NSizeF(80, 80);

            List<NPerson> persons = new List<NPerson>();
            var nameList = Database.GetNames();

            foreach (var name in nameList)
                persons.Add(new NPerson(name, basicShapesFactory.CreateShape(BasicShapes.Circle)));

            

            // create the person vertices
            for (int i = 0; i < persons.Count; i++)
            {
                document.ActiveLayer.AddChild(persons[i].m_Shape);
            }

            foreach (var person in persons)
            {
                var urlList = Database.GetUrlsByName(person.m_Name);
                foreach (var url in urlList)
                {
                    var nameListByUrl = Database.GetNamesByUrl(url);
                    foreach (var name in nameListByUrl)
                    {
                        NPerson foundedPerson;
                        if (name != person.m_Name)
                        {
                            foundedPerson = persons.Find(x => x.m_Name == name);
                            if (!foundedPerson.m_SameArticle.Contains(person))
                                person.m_SameArticle.Add(foundedPerson);
                        }
                    }
                }
            }


            for (int i = 0; i < persons.Count; i++)
            {
                NPerson currentPerson = persons[i];
                for (int j = 0; j < currentPerson.m_SameArticle.Count; j++)
                {
                    NLineShape connector = new NLineShape();
                    document.ActiveLayer.AddChild(connector);

                    connector.FromShape = currentPerson.m_Shape;
                    connector.ToShape = currentPerson.m_SameArticle[j].m_Shape;

                    connector.LayoutData.SpringStiffness = 1;
                    connector.LayoutData.SpringLength = 200;
                    connector.Style.StrokeStyle = new NStrokeStyle(2, Color.Green);
                }
            }


            // layout
            //LayoutButton1.PerformClick();
        }

      

        private void InitDocument()
        {
            // we do not need history for this example
            document.HistoryService.Pause();

            CreatePredefinedGraph();

            // resize document to fit all shapes
            LayoutButton1.PerformClick();
            document.SizeToContent();
        }

        private void layout_IterationCompleted(NGraphLayoutCancelEventArguments args)
        {
            if (UpdateDrawingWhileLayouting.Checked)
            {
                bool refreshLocked = view.LockRefresh;
                if (refreshLocked)
                {
                    view.LockRefresh = false;
                }

                NShapeBodyAdapter shapeBodyAdaptor = new NShapeBodyAdapter(document);

                IEnumerator<NGraphPart> en = args.Graph.GetPartsEnumerator();
                while (en.MoveNext())
                {
                    NGraphVertex vertex = en.Current as NGraphVertex;
                    if (vertex != null)
                    {
                        NBody2D body = vertex.Tag as NBody2D;
                        shapeBodyAdaptor.UpdateObjectFromBody2D(body);
                    }
                }

                document.SizeToContent();

                view.Invalidate();
                view.Update();

                if (refreshLocked)
                {
                    view.LockRefresh = true;
                }

                Application.DoEvents();
            }
        }

        private void LayoutButton1_Click(object sender, EventArgs e)
        {
            // get the shapes to layout
            NNodeList shapes = document.ActiveLayer.Children(NFilters.Shape2D);
            
            m_Layout.ElectricalForce.Enabled = true;
            m_Layout.MagneticFieldForce.Enabled = true;

            // create a layout context
            NLayoutContext layoutContext = new NLayoutContext();
            layoutContext.GraphAdapter = new NShapeGraphAdapter();
            layoutContext.BodyAdapter = new NShapeBodyAdapter(document);
            layoutContext.BodyContainerAdapter = new NDrawingBodyContainerAdapter(document);




            try
            {
                // layout the shapes
                if (m_Layout != null)
                    m_Layout.Layout(shapes, layoutContext);
            }
            catch
            { }
            // resize document to fit all shapes
            document.SizeToContent();
        }

        private void nPanAndZoomControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
