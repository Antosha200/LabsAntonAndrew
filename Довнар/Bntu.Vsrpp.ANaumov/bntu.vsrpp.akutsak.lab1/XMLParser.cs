using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Bntu.Vsrpp.Akutsak.Сore;

namespace Bntu.Vsrpp.Akutsak.lab1
{
    public partial class XMLParser : Form
    {
        public string filePath { get; private set; }
        private XMLOperations operations;
        private XDocument xDoc = new XDocument();
        List<XElement> items = new List<XElement>();
        public XMLParser()
        {
            InitializeComponent();            
        }

        private void btnGetElementCount_Click(object sender, EventArgs e)
        {
            lblElementCount.Text = items.Count.ToString();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            ofd.Filter = "XML Files(*.xml) | *.xml";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName;
                xDoc = XDocument.Load(filePath);
                operations = new XMLOperations();
                items = operations.GetXElements(filePath);
                if (cbOperationChoosing.Items.Count != 0)
                    cbOperationChoosing.Items.Clear();
                cbOperationChoosing.Items.AddRange(new string[] { "Avg value", "Min value", "Max value",
                    "Avg string length", "Min string length", "Max string length" });
            }
        }

        private void cbOperationChoosing_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbParameterChoosing.Items.Clear();
            cbParameterChoosing.ResetText();
            cbParameterChoosing.Items.AddRange(operations.
                GetPossibleParameters(cbOperationChoosing.SelectedItem.ToString(), items).ToArray());
        }

        private void btnDo_Click(object sender, EventArgs e)
        {
            switch (cbOperationChoosing.SelectedItem.ToString())
            {
                case "Max value":
                    lblResult.Text = operations.GetMaxValue(cbParameterChoosing.SelectedItem.ToString(), items).ToString();
                    break;
                case "Min value":
                    lblResult.Text = operations.GetMinValue(cbParameterChoosing.SelectedItem.ToString(), items).ToString();
                    break;
                case "Avg value":
                    lblResult.Text = operations.GetAvgValue(cbParameterChoosing.SelectedItem.ToString(), items).ToString();
                    break;
                case "Max string length":
                    lblResult.Text = operations.GetMaxStringLength(cbParameterChoosing.SelectedItem.ToString(), items).ToString();
                    break;
                case "Min string length":
                    lblResult.Text = operations.GetMinStringLength(cbParameterChoosing.SelectedItem.ToString(), items).ToString();
                    break;
                case "Avg string length":
                    lblResult.Text = operations.GetAvgStringLength(cbParameterChoosing.SelectedItem.ToString(), items).ToString();
                    break;
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            operations.ModifyElements(items, xDoc);            
        }
    }
}
