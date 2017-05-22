using PetronTrainingPortal.App_Code;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_LocalTraining : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using (var context = new DatabaseContext())
        {
            menuPanel.Controls.Clear();
            var trainingList = context.Trainings.Where(c => c.TrainingType == "Local").OrderByDescending(c => c.DateStart).ToList();
            foreach (var item in trainingList)
            {

                HtmlGenericControl mainDiv = new HtmlGenericControl("Div");
                mainDiv.Attributes.Add("style", "commentBody");
                mainDiv.ID = "createDiv";
                mainDiv.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#edcbca");
                mainDiv.Style.Add(HtmlTextWriterStyle.Color, "Black");
                mainDiv.Style.Add(HtmlTextWriterStyle.Height, "100px");
                mainDiv.Style.Add(HtmlTextWriterStyle.MarginLeft, "25px");
                mainDiv.Style.Add(HtmlTextWriterStyle.MarginTop, "25px");

                // create three labels and add them to the mainDiv
                // 1,2,3 are the ordinal positions of the column names, this may need corrected since I have no idea what your table looks like.
                string header = string.Empty;
                string startMonth = string.Empty;
                string extension = string.Empty;
                int startDay = 0;
                string dateEnd = string.Empty;

                startMonth = DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(item.DateStart.Date.Month);
                startDay = item.DateStart.Date.Day;
                dateEnd = item.DateEnd.Date.ToString("MMMM dd, yyyy");
                header = item.TrainingCode + ":" + item.TrainingTitle + "(" + startMonth + " " + startDay + "-" + dateEnd + ")";

                HtmlGenericControl lblHeader = new HtmlGenericControl("Label");
                lblHeader.ID = "createDiv";
                lblHeader.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#edcbca");
                lblHeader.Style.Add(HtmlTextWriterStyle.Color, "#a40519");
                lblHeader.Style.Add(HtmlTextWriterStyle.Height, "100px");
                lblHeader.Style.Add(HtmlTextWriterStyle.MarginLeft, "25px");
                lblHeader.Style.Add(HtmlTextWriterStyle.MarginTop, "15px");
                lblHeader.InnerHtml = header;
                mainDiv.Controls.Add(lblHeader);
                mainDiv.Controls.Add(new LiteralControl("<br />"));

                HtmlGenericControl lblVenue = new HtmlGenericControl("Label");
                lblVenue.ID = "createDiv";
                lblVenue.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#edcbca");
                lblVenue.Style.Add(HtmlTextWriterStyle.Color, "Black");
                lblVenue.Style.Add(HtmlTextWriterStyle.MarginLeft, "25px");
                lblVenue.InnerHtml = "Training Venue:";
                mainDiv.Controls.Add(lblVenue);

                HtmlGenericControl txtVenue = new HtmlGenericControl("Label");
                txtVenue.ID = "createDiv";
                txtVenue.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#edcbca");
                txtVenue.Style.Add(HtmlTextWriterStyle.Color, "Black");
                txtVenue.Style.Add(HtmlTextWriterStyle.MarginLeft, "25px");
                txtVenue.InnerHtml = item.Venue;
                mainDiv.Controls.Add(txtVenue);
                mainDiv.Controls.Add(new LiteralControl("<br />"));

                HtmlGenericControl lblFacilitator = new HtmlGenericControl("Label");
                lblFacilitator.ID = "createDiv";
                lblFacilitator.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#edcbca");
                lblFacilitator.Style.Add(HtmlTextWriterStyle.Color, "Black");
                lblFacilitator.Style.Add(HtmlTextWriterStyle.MarginLeft, "25px");
                lblFacilitator.InnerHtml = "Facilitator:";
                mainDiv.Controls.Add(lblFacilitator);

                HtmlGenericControl txtFacilitator = new HtmlGenericControl("Label");
                txtFacilitator.ID = "createDiv";
                txtFacilitator.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#edcbca");
                txtFacilitator.Style.Add(HtmlTextWriterStyle.Color, "Black");
                txtFacilitator.Style.Add(HtmlTextWriterStyle.MarginLeft, "25px");
                txtFacilitator.InnerHtml = item.TrainingProvider;
                mainDiv.Controls.Add(txtFacilitator);
                mainDiv.Controls.Add(new LiteralControl("<br />"));

                HtmlGenericControl secondDiv = new HtmlGenericControl("Div");
                secondDiv.Attributes.Add("style", "commentBody");
                secondDiv.ID = "secondDiv";
                secondDiv.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#edcbca");
                secondDiv.Style.Add(HtmlTextWriterStyle.Color, "Black");
                secondDiv.Style.Add(HtmlTextWriterStyle.MarginLeft, "25px");

                LinkButton lnkCourseOutline = new LinkButton();
                lnkCourseOutline.Text = "Course Outline";
                lnkCourseOutline.ID = item.CourseOutline;
                lnkCourseOutline.Click += new System.EventHandler(lnkCourseOutline_Click);
                secondDiv.Controls.Add(lnkCourseOutline);
                secondDiv.Controls.Add(new Label() { Text = " | " });

                LinkButton lnkBackground = new LinkButton();
                lnkBackground.Text = "Backgound";
                lnkBackground.ID = item.Background;
                lnkBackground.Click += new System.EventHandler(lnkBackground_Click);
                secondDiv.Controls.Add(lnkBackground);
                secondDiv.Controls.Add(new Label() { Text = " | " });


                LinkButton lnkCourseFee = new LinkButton();
                lnkCourseFee.Text = "Course Fee";
                lnkCourseFee.ID = item.CourseFee;
                lnkCourseFee.Click += new System.EventHandler(lnkCourseFee_Click);
                secondDiv.Controls.Add(lnkCourseFee);
                mainDiv.Controls.Add(secondDiv);

                HtmlGenericControl lblStatus = new HtmlGenericControl("Label");
                lblStatus.ID = "createDiv";
                lblStatus.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#edcbca");
                lblStatus.Style.Add(HtmlTextWriterStyle.Color, "Black");
                lblStatus.Style.Add(HtmlTextWriterStyle.MarginLeft, "25px");
                lblStatus.InnerHtml = "Status:";
                mainDiv.Controls.Add(lblStatus);

                HtmlGenericControl txtStatus = new HtmlGenericControl("Label");
                txtStatus.ID = "createDiv";
                txtStatus.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#edcbca");
                txtStatus.Style.Add(HtmlTextWriterStyle.Color, "Black");
                txtStatus.Style.Add(HtmlTextWriterStyle.MarginLeft, "25px");
                txtStatus.InnerHtml = item.Status;
                mainDiv.Controls.Add(txtStatus);
                mainDiv.Controls.Add(new LiteralControl("<br />"));

                //mainDiv.Controls.Add(secondDiv);

                HtmlGenericControl lowerDiv = new HtmlGenericControl("Div");
                lowerDiv.Attributes.Add("style", "commentBody");
                lowerDiv.ID = "createDiv";

                lowerDiv.Style.Add(HtmlTextWriterStyle.BackgroundColor, "White");
                lowerDiv.Style.Add(HtmlTextWriterStyle.Color, "Black");
                mainDiv.Controls.Add(lowerDiv);

                HtmlGenericControl blueDiv = new HtmlGenericControl("Div");
                blueDiv.Attributes.Add("style", "commentBody");
                blueDiv.ID = "createDiv";
                blueDiv.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#abaefd");
                blueDiv.Style.Add(HtmlTextWriterStyle.Color, "Black");
                blueDiv.Style.Add(HtmlTextWriterStyle.MarginLeft, "40px");
                lowerDiv.Controls.Add(blueDiv);

                Label lbl = new Label();
                lbl.ForeColor = Color.White;
                lbl.Font.Size = FontUnit.Small;
                lbl.Style[HtmlTextWriterStyle.MarginRight] = "30px";
                //link.Click += new System.EventHandler(LinkButtonTest_Click);
                blueDiv.Controls.Add(lbl);

                // add the mainDiv to the page somehow, these can be added to any HTML control that can act as a container. I would suggest a plain old mainDiv.
                menuPanel.Controls.Add(mainDiv);
            }
        }
    }

    protected void lnkCourseFee_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton clickedButton = (LinkButton)sender;
            string myTitle = "Course Fee";
            string myMessage = clickedButton.ID;

            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "sweetAlertMessage('" + myTitle + "','" + myMessage + "');", true);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "sweetAlertWarning('" + ex.Message + "');", true);
        }
    }

    protected void lnkCourseOutline_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton clickedButton = (LinkButton)sender;
            string myTitle = "Course Outline";
            string myMessage = clickedButton.ID;

            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "sweetAlertMessage('" + myTitle + "','" + myMessage + "');", true);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "sweetAlertWarning('" + ex.Message + "');", true);
        }
    }

    protected void lnkBackground_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton clickedButton = (LinkButton)sender;
            string myTitle = "Background";
            string myMessage = clickedButton.ID;

            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "sweetAlertMessage('" + myTitle + "','" + myMessage + "');", true);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "sweetAlertWarning('" + ex.Message + "');", true);
        }
    }
}
