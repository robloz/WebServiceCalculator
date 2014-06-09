using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace kudvenkat
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void SetCalculations(kudvenkat.ServiceReference1.WebServiceCalculatorSoapClient client)
        {


            GVCalculation.DataSource = client.GetLogOperations();
            GVCalculation.DataBind();
            GVCalculation.HeaderRow.Cells[0].Text = "Results";
        }

        private void CalculateOperationView(ServiceReference1.EnumOperationBi operation)
        {
            kudvenkat.ServiceReference1.WebServiceCalculatorSoapClient client2 = new ServiceReference1.WebServiceCalculatorSoapClient();
            float restul = client2.ExecuteOperation((float)Convert.ToDouble(TextFirstNumber.Text), (float)Convert.ToDouble(TextSecondNumber.Text), operation);

            LabelResult.Text = restul.ToString();

            SetCalculations(client2);

        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            CalculateOperationView(ServiceReference1.EnumOperationBi.Add);
        }

        protected void ButtonSub_Click(object sender, EventArgs e)
        {
            CalculateOperationView(ServiceReference1.EnumOperationBi.Sub);
        }

        protected void ButtonMul_Click(object sender, EventArgs e)
        {
            CalculateOperationView(ServiceReference1.EnumOperationBi.Mul);
        }

        protected void ButtonDiv_Click(object sender, EventArgs e)
        {
            CalculateOperationView(ServiceReference1.EnumOperationBi.Div);
        }
        
    }
}