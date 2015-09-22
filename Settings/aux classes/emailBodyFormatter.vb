Public Class emailBodyFormatter
    Public Shared Function getNewsletterFormatWithButton(logoURL As String, title As String, bodyText As String, buttonName As String, buttonUrl As String, footer As String) As String
        Dim cos As String = ""

        cos += "<html xmlns:v=""urn:schemas-microsoft-com:vml"" xmlns:o=""urn:schemas-microsoft-com:office:office"" xmlns:w=""urn:schemas-microsoft-com:office:word"" xmlns:m=""http://schemas.microsoft.com/office/2004/12/omml"" xmlns=""http://www.w3.org/TR/REC-html40""><head><meta http-equiv=Content-Type content=""text/html; charset=iso-8859-1""><meta name=Generator content=""Microsoft Word 14 (filtered medium)""><!--[if !mso]><style>v\:* {behavior:url(#default#VML);}"
        cos += "o\:* {behavior:url(#default#VML);}"
        cos += "w\:* {behavior:url(#default#VML);}"
        cos += ".shape {behavior:url(#default#VML);}"
        cos += "</style><![endif]--><style><!--"
        cos += "/* Font Definitions */"
        cos += "@font-face"
        cos += "	{font-family:Helvetica;"
        cos += "	panose-1:2 11 6 4 2 2 2 2 2 4;}"
        cos += "@font-face"
        cos += "	{font-family:Helvetica;"
        cos += "	panose-1:2 11 6 4 2 2 2 2 2 4;}"
        cos += "@font-face"
        cos += "	{font-family:Calibri;"
        cos += "	panose-1:2 15 5 2 2 2 4 3 2 4;}"
        cos += "@font-face"
        cos += "	{font-family:Tahoma;"
        cos += "	panose-1:2 11 6 4 3 5 4 4 2 4;}"
        cos += "/* Style Definitions */"
        cos += "p.MsoNormal, li.MsoNormal, div.MsoNormal"
        cos += "	{margin:0cm;"
        cos += "	margin-bottom:.0001pt;"
        cos += "	font-size:11.0pt;"
        cos += "	font-family:""Calibri"",""sans-serif"";"
        cos += "	mso-fareast-language:EN-US;}"
        cos += "a:link, span.MsoHyperlink"
        cos += "	{mso-style-priority:99;"
        cos += "	color:blue;"
        cos += "	text-decoration:underline;}"
        cos += "a:visited, span.MsoHyperlinkFollowed"
        cos += "	{mso-style-priority:99;"
        cos += "	color:purple;"
        cos += "	text-decoration:underline;}"
        cos += "p.MsoAcetate, li.MsoAcetate, div.MsoAcetate"
        cos += "	{mso-style-priority:99;"
        cos += "	mso-style-link:""Texto de globo Car"";"
        cos += "	margin:0cm;"
        cos += "	margin-bottom:.0001pt;"
        cos += "	font-size:8.0pt;"
        cos += "	font-family:""Tahoma"",""sans-serif"";"
        cos += "	mso-fareast-language:EN-US;}"
        cos += "span.EstiloCorreo17"
        cos += "	{mso-style-type:personal-compose;"
        cos += "	font-family:""Calibri"",""sans-serif"";"
        cos += "	color:windowtext;}"
        cos += "span.TextodegloboCar"
        cos += "	{mso-style-name:""Texto de globo Car"";"
        cos += "	mso-style-priority:99;"
        cos += "	mso-style-link:""Texto de globo"";"
        cos += "	font-family:""Tahoma"",""sans-serif"";}"
        cos += ".MsoChpDefault"
        cos += "	{mso-style-type:export-only;"
        cos += "	font-family:""Calibri"",""sans-serif"";"
        cos += "	mso-fareast-language:EN-US;}"
        cos += "@page WordSection1"
        cos += "	{size:612.0pt 792.0pt;"
        cos += "	margin:70.85pt 3.0cm 70.85pt 3.0cm;}"
        cos += "div.WordSection1"
        cos += "	{page:WordSection1;}"
        cos += "--></style><!--[if gte mso 9]><xml>"
        cos += "<o:shapedefaults v:ext=""edit"" spidmax=""1026"" />"
        cos += "</xml><![endif]--><!--[if gte mso 9]><xml>"
        cos += "<o:shapelayout v:ext=""edit"">"
        cos += "<o:idmap v:ext=""edit"" data=""1"" />"
        cos += "</o:shapelayout></xml><![endif]--></head><body lang=ES link=blue vlink=purple><div class=WordSection1><table class=MsoNormalTable border=0 cellspacing=0 cellpadding=0 width=""100%"" style='width:100.0%;background:#E8E9E3;border-collapse:collapse'><tr><td valign=top style='padding:0cm 0cm 0cm 0cm'><div align=center><table class=MsoNormalTable border=0 cellspacing=0 cellpadding=0 width=""100%"" style='width:100.0%;background:#E8E9E3;border-collapse:collapse'><tr><td valign=top style='padding:7.5pt 7.5pt 7.5pt 7.5pt'><div align=center><table class=MsoNormalTable border=0 cellspacing=0 cellpadding=0 width=320 style='width:240.0pt;border-collapse:collapse'><tr><td valign=top style='padding:0cm 0cm 0cm 0cm'><p class=MsoNormal align=center style='text-align:center;line-height:9.75pt'><span style='font-size:8.5pt;font-family:""Helvetica"",""sans-serif"";color:#606060;mso-fareast-language:ES'>Confirmar cuenta de AKIS Irrigation</span><span style='font-size:8.5pt;font-family:""Helvetica"",""sans-serif"";color:#606060;mso-fareast-language:ES'><o:p></o:p></span></p></td></tr></table></div></td></tr></table></div><p class=MsoNormal align=center style='text-align:center'><span style='font-size:13.5pt;color:black;mso-fareast-language:ES'><o:p>&nbsp;</o:p></span></p><div align=center><table class=MsoNormalTable border=0 cellspacing=0 cellpadding=0 width=""100%"" style='width:100.0%;border-collapse:collapse'><tr><td valign=top style='padding:0cm 0cm 0cm 0cm'><div align=center><table class=MsoNormalTable border=0 cellspacing=0 cellpadding=0 width=""100%"" style='width:100.0%;background:#FAFAFA;border-collapse:collapse'><tr><td valign=top style='padding:0cm 0cm 0cm 0cm'><div align=center><table class=MsoNormalTable border=0 cellspacing=0 cellpadding=0 width=363 style='width:272.35pt;border-collapse:collapse'><tr style='height:45.85pt'><td style='padding:15.0pt 0cm 15.0pt 0cm;height:45.85pt'><p class=MsoNormal align=center style='text-align:center;line-height:13.5pt'><b><span style='font-size:13.5pt;font-family:""Helvetica"",""sans-serif"";color:#3F3F38;mso-fareast-language:ES'><img width=312 height=80 src='" + _
        logoURL
        cos += "'></span></b><b><span style='font-size:13.5pt;font-family:""Helvetica"",""sans-serif"";color:#3F3F38;mso-fareast-language:ES'><o:p></o:p></span></b></p></td></tr></table></div></td></tr></table></div></td></tr><tr><td valign=top style='padding:0cm 0cm 0cm 0cm'><div align=center><table class=MsoNormalTable border=0 cellspacing=0 cellpadding=0 width=""100%"" style='width:100.0%;background:#FAFAFA;border-collapse:collapse'><tr><td valign=top style='padding:15.0pt 15.0pt 15.0pt 15.0pt'><div align=center><table class=MsoNormalTable border=0 cellspacing=0 cellpadding=0 width=473 style='width:354.45pt;background:white;border-collapse:collapse'><tr style='height:144.0pt'><td valign=top style='border:none;border-bottom:solid #CCCCCC 1.0pt;padding:15.0pt 15.0pt 15.0pt 15.0pt;height:144.0pt'><div align=center><table class=MsoNormalTable border=0 cellspacing=0 cellpadding=0 width=""95%"" style='width:95.6%;border-collapse:collapse'><tr style='height:87.9pt'><td valign=top style='padding:0cm 0cm 0cm 0cm;height:87.9pt'><p class=MsoNormal align=center style='margin-bottom:7.5pt;text-align:center;line-height:18.0pt'><b><span style='font-size:18.0pt;font-family:""Helvetica"",""sans-serif"";color:#3F3F38;mso-fareast-language:ES'>" + _
            title + "<o:p></o:p></span></b></p><p class=MsoNormal style='line-height:16.5pt'><span style='font-size:11.5pt;font-family:""Helvetica"",""sans-serif"";color:#202020;mso-fareast-language:ES'>" + _
            bodyText + "</span><span style='font-size:11.5pt;font-family:""Helvetica"",""sans-serif"";color:#202020;mso-fareast-language:ES'><o:p></o:p></span></p></td></tr><tr style='height:42.2pt'><td valign=top style='padding:15.0pt 0cm 0cm 0cm;height:42.2pt'><div align=center><table class=MsoNormalTable border=0 cellspacing=0 cellpadding=0 width=""100%"" style='width:100.0%;background:#23B3B4;border-collapse:collapse'><tr style='height:14.55pt'><td style='background:#1B8CC8;padding:15.0pt 15.0pt 15.0pt 15.0pt;height:14.55pt'><p class=MsoNormal align=center style='text-align:center;line-height:13.5pt'><span style='mso-fareast-language:ES'><a href=""" + _
            buttonUrl + """ target=""_blank""><b><span style='font-size:13.5pt;font-family:""Helvetica"",""sans-serif"";color:white;text-decoration:none'>" + _
            buttonName + "</span></b></a></span><b><span style='font-size:13.5pt;font-family:""Helvetica"",""sans-serif"";color:white;mso-fareast-language:ES'><o:p></o:p></span></b></p></td></tr></table></div></td></tr></table></div></td></tr></table></div></td></tr></table></div></td></tr><tr><td valign=top style='padding:0cm 0cm 0cm 0cm'><div align=center><table class=MsoNormalTable border=0 cellspacing=0 cellpadding=0 width=""100%"" style='width:100.0%;border-collapse:collapse'><tr><td valign=top style='padding:30.0pt 30.0pt 30.0pt 30.0pt'><div align=center><table class=MsoNormalTable border=0 cellspacing=0 cellpadding=0 width=320 style='width:240.0pt;border-collapse:collapse'><tr><td valign=top style='padding:0cm 0cm 0cm 0cm'><table class=MsoNormalTable border=0 cellspacing=0 cellpadding=0 width=575 style='width:431.05pt;border-collapse:collapse'><tr style='height:7.25pt'><td style='background:#FAFAFA;padding:7.5pt 7.5pt 7.5pt 7.5pt;height:7.25pt'><p class=MsoNormal align=center style='text-align:center;line-height:11.25pt'><span style='font-size:9.0pt;font-family:""Arial"",""sans-serif"";color:#1B8CC8;mso-fareast-language:ES'>&nbsp;</span><span style='mso-fareast-language:ES'><a href=""https://twitter.com/AKISint""><span style='font-size:9.0pt;font-family:""Arial"",""sans-serif"";color:#1B8CC8'>Síguenos en twitter&nbsp;</span></a></span><span style='font-size:9.0pt;font-family:""Arial"",""sans-serif"";color:#707070;mso-fareast-language:ES'> <o:p></o:p></span></p></td></tr><tr style='height:86.95pt'><td style='background:white;padding:7.5pt 7.5pt 7.5pt 7.5pt;height:86.95pt'><p class=MsoNormal style='line-height:11.25pt'><span style='font-size:8.0pt;font-family:""Arial"",""sans-serif"";color:gray;mso-fareast-language:ES'>" + _
            footer + "</span></p></td></tr></table></td></tr><tr><td valign=top style='padding:15.0pt 0cm 0cm 0cm'></td></tr></table></div></td></tr></table></div></td></tr></table></div><p class=MsoNormal align=center style='text-align:center'><span style='font-size:12.0pt;font-family:""Times New Roman"",""serif"";color:#1F497D;mso-fareast-language:ES'><o:p></o:p></span></p></td></tr></table><p class=MsoNormal><span style='mso-fareast-language:ES'><o:p>&nbsp;</o:p></span></p><p class=MsoNormal><o:p>&nbsp;</o:p></p></div></body></html>"


        Return cos


    End Function
End Class
