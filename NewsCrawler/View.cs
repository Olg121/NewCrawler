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
    public partial class View : Form
    {
        public View()
        {
            InitializeComponent();
            NLicense license = new NLicense("1c0b8d26-0300-0d7a-3b00-1aa02e450200");

            NLicenseManager.Instance.SetLicense(license);
            NLicenseManager.Instance.LockLicense = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NBasicShapesFactory basicShapesFactory = new NBasicShapesFactory();
            basicShapesFactory.DefaultSize = new NSizeF(80, 80);

            string text = textBox1.Text;
            graphBuilder builder = new graphBuilder();
            List<graphBuilder.graph> lst;
            lst = builder.GetGraph(text);


            List<NPerson> persons = new List<NPerson>();

            for (int i = 0; i < lst.Count; i++)
            {
                NPerson buf = new NPerson(lst[i].name, basicShapesFactory.CreateShape(BasicShapes.Circle));
                if (lst[i].iancestor >= 0 && lst[i].iancestor <= lst.Count)
                    buf.anc = persons[lst[i].iancestor];
                buf.num = i;
                persons.Add(buf);
            }

            int k;
            for (int i = 0; i < lst.Count; i++)
            {
                NPerson buf = persons[i];
                for (int j = 0; j < lst[i].contacts.Count; j++)
                {
                    k = lst[i].contacts[j].iName;
                    if (k < persons.Count)
                        buf.m_Friends.Add(persons[k]);
                }
            }

            for (int i = 0; i < persons.Count; i++)
            {
                nDrawingDocument1.ActiveLayer.AddChild(persons[i].m_Shape);
            }


            for (int i = 0; i < persons.Count; i++)
            {


                for (int j = 0; j < persons[i].m_Friends.Count; j++)
                    if(persons[i].num < persons[i].m_Friends[j].num)
                {
                    NRoutableConnector connector = new NRoutableConnector();
                    nDrawingDocument1.ActiveLayer.AddChild(connector);
                    connector.FromShape = persons[i].m_Shape;
                    connector.ToShape = persons[i].m_Friends[j].m_Shape; 

                    connector.LayoutData.SpringStiffness = 50;
                    connector.LayoutData.SpringLength = 1000;
                    connector.Style.StrokeStyle = new NStrokeStyle(1, Color.Coral);

                        ; 


                }
            }
            NNodeList shapes = nDrawingDocument1.ActiveLayer.Children(NFilters.Shape2D);
            NSpringLayout layout = new NSpringLayout();
         //   layout.MagneticFieldForce.DistancePower = 20;
           // layout.GravityForce.ActivationPass = 10;
            //layout.MagneticFieldForce.ActivationPass = 0;
            //layout.Environment.MaxLocalTemperature = 30;
            
           layout.ElectricalForce.Enabled = true;
           layout.MagneticFieldForce.Enabled = true; 
            // create a layout context
            NLayoutContext layoutContext = new NLayoutContext();
            layoutContext.GraphAdapter = new NShapeGraphAdapter();
            layoutContext.BodyAdapter = new NShapeBodyAdapter(nDrawingDocument1);
            layoutContext.BodyContainerAdapter = new NDrawingBodyContainerAdapter(nDrawingDocument1);
  
         //   layout the shapes
            if (layout != null)
                layout.Layout(shapes, layoutContext);
           
            nDrawingDocument1.SizeToContent();
        }
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

}

