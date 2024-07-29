namespace PhilaniBiography.Helpers
{
    public class MailTemplate
    {

        public static string generateTemplate(string mailMessage)
        {
            string body = $@"<div align='center' style='background-color: #f8f9fa; border: 1px solid #ddd;'>

            </div>
                <table cellpadding='0' cellspacing='0' border='0' style='padding:0px;margin:0px;width:100%;border-bottom-color:transparent;border-bottom:none' id='templateContainer'>
   
                    <tr><td colspan='3' id='bodyCell' style='padding:0px;margin:0px;font-size:20px;height:20px;' height='20'>&nbsp;</td></tr>

                    <tr>
                        <td class='bodyContent'>

                         {mailMessage}


                        </td>
                    </tr>
                </table>
            <div class='footerContent'style='text-align:center; background-color: #fff'>
 
                        -----------------------------------  <br />
     
                  <a href = '  '> Visit our website</a>
       
                       <br/>
                       Copyright © Philani Bio, All rights reserved.
      
    </div>
    <div style='font-size:10px;color:#959595;text-align:center;'>
        You are receiving this email as either you opted to receive it, it is a system announcement or it is related to a product or service rendered by Philani Bio.<br>System announcements are sent regardless of newsletter subscription status.<br>

    </div>";
            string temp = @"
          <head>          
        <style type=""text/css"">
           .button a {
                color: black;
                text-decoration: none;
              }
            .button {
         background-color: #1c87c9;
         border: none;
         color: white !important;
         border: solid #1c87c9;border-width: 20px 20px;
         text-align: center;
         width:200px;
         text-decoration: none !important;
         display: inline-block;
         font-size: 20px;
         margin: 4px 2px;
         cursor: pointer;
         }
            
 img {
            border: 0;
            height: auto;
            outline: 0;
            text-decoration: dotted
        }

.dx-mention{
  font-weight:bolder;
}

        table {
            border-collapse: collapse !important
        }

        #bodyCell,
        #bodyTable,
        body {
            height: 100% !important;
            margin: 0;
            padding: 0;
        }

        #bodyCell {
            padding: 20px;
        }

        #templateContainer {
            background-color: #fff
        }

        #bodyTable,
        body {
            background-color: #FAFAFA
        }


        .headerContent {
            background-color: #f8f8f8;
            border-bottom: 1px solid #ddd;
            color: #505050;
            font-family: Helvetica;
            font-size: 20px;
            font-weight: 700;
            line-height: 100%;
            text-align: left;
            vertical-align: middle;
            padding: 0
        }

        .bodyContent {
            font-family: Helvetica;
            line-height: 150%;
            text-align: left;
        }


            .bodyContent a {
                word-break: break-all
            }

        .headerContent a .yshortcuts,
        .headerContent a:link,
        .headerContent a:visited {
            color: #1f5d8c;
            font-weight: 400;
            text-decoration: underline
        }



        #templateBody {
            background-color: #fff
        }

        .bodyContent {
            color: #505050;
            font-size: 14px;
            padding-left: 20px;
            padding-right: 20px;
        }

            .bodyContent a .yshortcuts,
            .bodyContent a:link,
            .bodyContent a:visited {
                color: #1f5d8c;
                font-weight: 400;
                text-decoration: underline
            }

            .bodyContent a:hover {
                text-decoration: none
            }

            .bodyContent img {
                display: inline;
                height: auto;
            }

        .footerContent a .yshortcuts,
        .footerContent a:link,
        .footerContent a:visited {
            color: #1f5d8c;
            font-weight: 400;
            text-decoration: underline
        }

        .footerContent a:hover {
            text-decoration: none
        }
        .footerContent {
            font-family: Helvetica;
            line-height: 150%;
            padding-top:1rem;
            padding-bottom:1rem;
        }

        </style>
    </head>" + body;

            return temp;
        }


    }
}
