﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home_Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnTrainingPrograms_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Home/Default.aspx");
    }

    protected void btnTrainingEvaluation_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Home/Training Evaluation/DefaultEvaluation.aspx");
    }
}