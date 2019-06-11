using Nevron;
using Nevron.Diagram;
using Nevron.Diagram.DataStructures;
using Nevron.Diagram.Filters;
using Nevron.Diagram.Layout;
using Nevron.Diagram.Shapes;
using Nevron.Dom;
using Nevron.GraphicsCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsCrawler
{
    public partial class GraphViewer : Form
    {
        public GraphViewer()
        {
            InitializeComponent();
        }

        public class NPerson
        {
            public NPerson(string name, NShape shape)
            {
                m_Shape = shape;
                m_Shape.Text = name;
                m_Name = name;
                m_Friends = new List<NPerson>();
            }
            public NPerson anc; 
            public NShape m_Shape;
            public string m_Name;
            public List<NPerson> m_Friends;
            public int num; 
        }


        private void GraphViewer_Load(object sender, EventArgs e)
        {
            NLicense license = new NLicense("1c0b8d26-0300-0d7a-3b00-1aa02e450200");

            NLicenseManager.Instance.SetLicense(license);
            NLicenseManager.Instance.LockLicense = true;
            NBasicShapesFactory basicShapesFactory = new NBasicShapesFactory(); // фактори 
                      basicShapesFactory.DefaultSize = new NSizeF(80, 80); // размеры
              
              NShape shape = basicShapesFactory.CreateShape(BasicShapes.Circle); // 
              NShape shape1 = basicShapesFactory.CreateShape(BasicShapes.Circle);
            nDrawingDocument1.ActiveLayer.AddChild(shape);
            nDrawingDocument1.ActiveLayer.AddChild(shape1);
            NLineShape connector = new NLineShape();
                               nDrawingDocument1.ActiveLayer.AddChild(connector);
              
                   connector.FromShape = shape;
                               connector.ToShape = shape1;
              
                   connector.LayoutData.SpringStiffness = 2;
                               connector.LayoutData.SpringLength = 100;
                               connector.Style.StrokeStyle = new NStrokeStyle(2, Color.Coral);


            NNodeList shapes = nDrawingDocument1.ActiveLayer.Children(NFilters.Shape2D);
            NSpringLayout layout = new NSpringLayout();
            // create a layout context
            NLayoutContext layoutContext = new NLayoutContext();
            layoutContext.GraphAdapter = new NShapeGraphAdapter();
            layoutContext.BodyAdapter = new NShapeBodyAdapter(nDrawingDocument1);
            layoutContext.BodyContainerAdapter = new NDrawingBodyContainerAdapter(nDrawingDocument1);

            // layout the shapes
            if (layout != null)
                layout.Layout(shapes, layoutContext);

            // resize document to fit all shapes
            nDrawingDocument1.SizeToContent();
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NBasicShapesFactory basicShapesFactory = new NBasicShapesFactory();
            basicShapesFactory.DefaultSize = new NSizeF(5, 5);

            string name = textBox1.Text;
            List<graphBuilder.graph> graphList;
            graphBuilder A = new graphBuilder();
            graphList = A.GetGraph(name);
            List<NPerson> persons = new List<NPerson>();

            for (int i = 0;i <graphList.Count; i++)
            {
                NPerson buf = new NPerson(graphList[i].name, basicShapesFactory.CreateShape(BasicShapes.Circle));
                if(graphList[i].iancestor >= 0 && graphList[i].iancestor <= graphList.Count)
                buf.anc = persons[graphList[i].iancestor];
                buf.num = i; 
                persons.Add(buf); 
            }
            int k; 
            for (int i = 0; i < graphList.Count; i++)
            {
                NPerson buf = persons[i];
                for (int j = 0; j < graphList[i].contacts.Count; j++)
                {
                    k = graphList[i].contacts[j].iName;
                    if(k <persons.Count)
                    buf.m_Friends.Add(persons[k]);
                }
            }
                


            //for(int i = 0; i<persons.Count; i++)
            //{
            //    nDrawingDocument1.ActiveLayer.AddChild(persons[i].m_Shape);
            //}


            // get the shapes to layout

            //for (int i = 0; i < persons.Count; i++)
            //{


            //for (int j = 0; j < persons[0].m_Friends.Count; j++)
            //{
            NShape shape = basicShapesFactory.CreateShape(BasicShapes.Circle);  
            NShape shape1 = basicShapesFactory.CreateShape(BasicShapes.Circle);
            nDrawingDocument1.ActiveLayer.AddChild(shape);
            nDrawingDocument1.ActiveLayer.AddChild(shape1);
            NLineShape connector = new NLineShape();
            nDrawingDocument1.ActiveLayer.AddChild(connector);
            connector.FromShape = shape;
                    connector.ToShape = shape1;

                    connector.LayoutData.SpringStiffness = 2;
                    connector.LayoutData.SpringLength = 20;
                    connector.Style.StrokeStyle = new NStrokeStyle(2, Color.Coral);

                   

            //    //}
            //}

            NShape shape2 = basicShapesFactory.CreateShape(BasicShapes.Circle); // 
            NShape shape3 = basicShapesFactory.CreateShape(BasicShapes.Circle);
            nDrawingDocument1.ActiveLayer.AddChild(shape2);
            nDrawingDocument1.ActiveLayer.AddChild(shape3);
            NLineShape connector1 = new NLineShape();
            nDrawingDocument1.ActiveLayer.AddChild(connector1);

            connector1.FromShape = shape2;
            connector1.ToShape = shape3;

            connector1.LayoutData.SpringStiffness = 2;
            connector1.LayoutData.SpringLength = 100;
            connector1.Style.StrokeStyle = new NStrokeStyle(2, Color.Coral);


            NNodeList shapes = nDrawingDocument1.ActiveLayer.Children(NFilters.Shape2D);
            NSpringLayout layout = new NSpringLayout();
            // create a layout context
            NLayoutContext layoutContext = new NLayoutContext();
            layoutContext.GraphAdapter = new NShapeGraphAdapter();
            layoutContext.BodyAdapter = new NShapeBodyAdapter(nDrawingDocument1);
            layoutContext.BodyContainerAdapter = new NDrawingBodyContainerAdapter(nDrawingDocument1);

            // layout the shapes
            if (layout != null)
                layout.Layout(shapes, layoutContext);

            // resize document to fit all shapes
            nDrawingDocument1.SizeToContent();
        }

       

    }
}
