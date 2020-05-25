<?php

 require('../dbconnect.php');

 $query=mysql_query("SELECT * FROM registry",$db);

 while($row=mysql_fetch_assoc($query)) {

  $reg[$row['regkey']]=$row['value'];

 }

 mysql_close($db);

?>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head>

<title>Sedos - The City of London's Premier Amateur Theatre Company</title>

<meta name="description" content="Established in 1905. The City of London's premier amateur theatre company. With a membership of 200+, a programme of 8-10 challenging fringe theatre productions every year and reputations for West End quality in every production, Sedos are proud of their claim to be the premier amateur theatre group in London. www.sedos.co.uk" />

<meta name="keywords" content="sedos, london, drama, society, musical, theatre, amateur, amdram, company, musicals, dramatics, central london, society, operatic, shakespeare, sondheim, city of london, stock exchange, bridewell, premier, play" />

<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />

<link href="css/style_web.css" rel="stylesheet" type="text/css" media="screen" />

<style type="text/css">

<!--

#homeBox1 {

	width: 702px;

	height: 407px;

	float: left;

	background-image: url(images/leftimg.jpg);

	background-repeat: no-repeat;

	background-position: top left;

	margin-bottom: 2px;

}

#homeBox1 p.buttons {

	padding: 346px 0 0 20px;

}

#homeBox1 p.buttons img {

	margin: 5px 0 0 25;

}

#homeBox1 a, #homeBox2 a {

	background-color: transparent;

}

#homeBox2 {

	width: 240px;

	height: 407px;

	float: left;

	background-image: url(bg/midimg.jpg);

	background-repeat: no-repeat;

	background-position: top left;

	margin-bottom: 2px;

	font-family: Arial, Helvetica, sans-serif;

}

#homeBox2 p {

	padding: 10px 8px 0 10px;

}

#homeBox2 h2 {

	padding: 10px 8px 0 10px;

}

#homeBox3 {

	width: 246px;

	height: 407px;

	float: left;

	background-color: #044484;

	margin-bottom: 2px;

}

#homeBox3 h2, #homeBox3 p {

	color: #FFF;

	padding: 10px 8px 0 10px;

}

.style47 {

  font-size: 16px;

  font-weight: bold;

}

.style70 {

  font-weight: bold;

  font-size: 12px;

}

a:link {

  color: #999999;

}

.style37 {

  color: #FFFFFF;

  font-size: 15px;

}

.style39 {font-size: 16px; font-weight: bold; color: #044484; }

.style84 {

  font-size: 16px

}

.style102 {font-size: 13px}

.style126 {

  font-family: Arial, Helvetica, sans-serif;

  font-size: 15px;

  color: #FFFFFF;

}
.style130 {font-weight: bold}
.style131 {font-weight: bold}

-->

</style>
</head>

<body>

<div id="container">

		<div id="content"><a href="/secure/boxoffice/production.php"></a>

		  <div class="clear">

		    <table width="948" border="0" cellpadding="1" cellspacing="1">

  <tr valign="top">

    <td width="748" height="400" valign="top"><div align="left"></div>



      <a href="2020/isolation.htm"><img src="ISOLATIONLANDSCAPE.001.jpeg" width="740" height="525" border="0" /></a></td>

    <td width="193" colspan="2" valign="top" bgcolor="#044484"><div align="center" class="style126">

      <p style="margin-bottom: 0"><br />
        </p>
      <p style="margin-top: 0; margin-bottom: 0;"><span class="style102">Following government advice about Coronavirus, all of Sedos' physical events and productions have now been postponed. However, some of our activities have moved online</span>.</p>
      <p style="margin-top: 0; margin-bottom: 0;"><strong>Join the Trustee &amp; Management Committee<br />
        </strong><span class="style102">Deadline for applications<br />
          Friday 
          1 May<br />
          <a href="members/index.htm"><strong>Find out more</strong></a></span>.</p>
      <p style="margin-top: 0; margin-bottom: 0;"><strong>Virtual AGM and Quiz<br />
        </strong><span class="style102">Save the date Thursday 4 June</span></p>
      <p style="margin-top: 0; margin-bottom: 0;"><strong>Sedance Goes Online<br />
      </strong><span class="style102">Every Monday</span><br />
      <a href="https://www.facebook.com/groups/328763023951811/" target="_blank" class="style102">Find out more      </a><br />
      </p>
      <p style="margin-top: 0; margin-bottom: 0;"><strong>Zoom Your Own... Improv!<br />
      </strong><span class="style102">Every Wednesday</span><br />
      <span class="style102"><a href="https://www.facebook.com/bananahutgang/" target="_blank">Find out more</a> </span><br />
      </p>
    </div>      </td>
  </tr>
</table>

  <table width="860" cellspacing="12" cellpadding="12" border="0">

  <tr valign="top">

    <td valign="top"><span class="style47" style="margin-top: 0; margin-bottom: 0;">Postponed</span></td>

    <td valign="top">&nbsp;</td>

    <td valign="top"><span class="style47" style="margin-top: 0; margin-bottom: 0;">Get Involved</span></td>

    <td valign="top">&nbsp;</td>

    <td valign="top"><span class="style47" style="margin-top: 0; margin-bottom: 0;">Explore Sedos</span></td>

  </tr>

  <tr valign="top">


    <td width="142" valign="top"><a href="2020/opheliathinksharder.htm"><img src="images/Ophelia-hpteaser-v2.jpg" width="165" height="94" border="0" /></a></td>

    <td width="142" valign="top"><a href="2020/working.htm"><img src="images/Working-hpteaser.jpg" width="165" height="94" border="0" /></a></td>

    <td width="156" valign="top"><a href="https://sedos.co.uk/whatson/memberevents.htm"><img src="images/MemberEvents-homepage.jpg" width="180" height="94" border="0" /></a></td>

    <td width="156" valign="top"><a href="aboutus/reviews.htm"><img src="images/2016reviewsbutton_000.jpg" width="180" height="94" border="0" /></a></td>

    <td width="164" valign="top"><a href="archive/index.htm"><img src="images/2016archivebutton.jpg" width="190" height="94" border="0" /></a></td>

  </tr>

  <tr valign="top">

    <td> <span class="style84"><strong><a href="2020/opheliathinksharder.htm">Ophelia Thinks Harder </a></strong></span></td>

    <td><span class="style47"><a href="2020/working.htm">Working: a musical</a></span></td>

    <td valign="top"><p class="style47" style="margin-top: 0; margin-bottom: 0"><a href="https://sedos.co.uk/whatson/memberevents.htm">Member Events</a><br />

        <span class="style102"><a href="https://sedos.co.uk/sedance.htm">Sedance</a> / <a href="https://sedos.co.uk/whatson/simprov.htm">Simprov</a></span><a href="https://sedos.co.uk/whatson/memberevents.htm"><br />

        </a></p>      </td>

    <td valign="top"><span class="style47"><a href="aboutus/reviews.htm">Reviews</a></span></td>

    <td valign="top"><span class="style47"><a href="archive/index.htm">Archive</a></span></td>

  </tr>

  <tr valign="top">

    <td width="156" valign="top">A riotous reworking of Shakespeare's Hamlet - with serious themes, nevertheless.</td>

    <td width="142" valign="top">The hopes, dreams, joys and concerns of the average working American are the focus of this unique, extraordinary musical.</td>

    <td width="156" valign="top">Sedos also offers a range of events for our membership throughout the year. These include one-off events, but we also offer two regular activities: Sedance and Simprov.</td>

    <td width="156" valign="top">Don&rsquo;t take our word for how good Sedos productions are, check out some of the things the press has said about our productions.</td>

    <td width="164" valign="top">With a history of over a hundred years of London theatre, the Sedos archives are full to bursting.</td>

  </tr>

  <tr valign="top">

    <td><span class="style47">2020 Season</span></td>

    <td valign="top">&nbsp;</td>

    <td><span class="style47">Backstage</span></td>

    <td valign="top"><span class="style47">Watch Sedos</span></td>

    <td valign="top">&nbsp;</td>

  </tr>

  <tr valign="top">

    <td height="32" colspan="2" valign="top"><p class="style102" style="margin-top: 0; margin-bottom: 0"><strong><a href="2020/musicalofmusicals.htm">The Musical Of Musicals (The Musical) | 25-29 Feb</a></strong><br />
        <a href="2020/isolation.htm"><strong>Isolation | 20 Mar-19 Apr</strong></a> <br />
        <span class="style130"><a href="2020/opheliathinksharder.htm">Ophelia Thinks Harder</a></span><strong><a href="2020/opheliathinksharder.htm"> | 31 Mar-4 Apr</a></strong> (postponed)<br />
        <strong>Members' Week: Sister Act</strong> | 3 May <span class="style102" style="margin-top: 0; margin-bottom: 0">(postponed)</span><br />
        <strong><span class="style102" style="margin-top: 0; margin-bottom: 0"><strong>Members' Week: </strong></span>Improv</strong> | 5-7 May <span class="style102" style="margin-top: 0; margin-bottom: 0">(postponed)</span><br />
        <strong><span class="style102" style="margin-top: 0; margin-bottom: 0"><strong>Members' Week: </strong></span>Play In A Day</strong> | 8 May <span class="style102" style="margin-top: 0; margin-bottom: 0">(postponed)</span><br />
        <a href="2020/working.htm"><strong>Working: a musical | 12-16 May </strong></a>(postponed)<br />
        <span class="style131"><a href="2020/LoveValourCompassion.htm">Love! Valour! Compassion! </a></span><strong><a href="2020/LoveValourCompassion.htm">| 7-11 Jul </a></strong>(postponed)<br />
        <strong>Edinburgh Fringe | Choose Your Own&hellip; Improv!</strong> | <span class="style102" style="margin-top: 0; margin-bottom: 0">(postponed)</span><br />
        <strong>A Midsummer Night&rsquo;s Dream |</strong> 16-26 Sep<br />
        <strong>Something Just Like This </strong>| 20 Sep<br />
        <strong>The Mystery Of Edwin Drood</strong> | 27-31 Oct <br />
        <strong>Amadeus</strong> | 25 Nov-5 Dec</p>      
      </td>

    <td valign="top"><span style="margin-top: 0; margin-bottom: 0"><span class="style70"><a href="aboutus/reviews.htm">Reviews</a><br />

          <a href="https://sedos.co.uk/aboutus/howweoperate.htm">How We Operate&nbsp; </a><br />

  <a href="aboutus/faq.htm">Frequently Asked Questions</a>&nbsp;<br />

  <a href="aboutus/joinus.htm">Join Us</a>&nbsp; <br />

  <a href="audition/index.htm">Auditions</a><br />

          <a href="sponsor/index.htm">Sponsor Us</a>  <br />

          <a href="general/contact.htm">Contact Us</a><br />

          <a href="https://www.google.com/maps/d/viewer?ie=UTF&amp;msa=0&amp;mid=z0sTOBnawbGo.kkLpHsEp5bDM" target="_blank">Venues Map</a> <br />

          <a href="archive/index.htm">Archive</a></span></span></td>

    <td colspan="2" rowspan="3" valign="top"><a target="_blank"> <a data-flickr-embed="true"  href="https://www.flickr.com/photos/sedos/albums/72157674285698501" title="Candide - 2016"><img src="https://c5.staticflickr.com/6/5514/30248858300_ef14b7c04b.jpg" alt="Candide - 2016" width="375" height="275" border="0" /></a>

      <script async="async" src="//embedr.flickr.com/assets/client-code.js" charset="utf-8"></script>

      <script async="async" src="//embedr.flickr.com/assets/client-code.js" charset="utf-8"></script>

<script async="async" src="//embedr.flickr.com/assets/client-code.js" charset="utf-8"></script>

<script async="async" src="//embedr.flickr.com/assets/client-code.js" charset="utf-8"></script>

      <script async="async" src="//embedr.flickr.com/assets/client-code.js" charset="utf-8"></script>

<script async="async" src="//embedr.flickr.com/assets/client-code.js" charset="utf-8"></script>

      <script async="async" src="//embedr.flickr.com/assets/client-code.js" charset="utf-8"></script>

      <script async="async" src="//embedr.flickr.com/assets/client-code.js" charset="utf-8"></script>

<script async="async" src="//embedr.flickr.com/assets/client-code.js" charset="utf-8"></script>

<script async="async" src="//embedr.flickr.com/assets/client-code.js" charset="utf-8"></script></td>

  </tr>

  <tr valign="top">

    <td height="19"><span class="style47" style="margin-top: 0; margin-bottom: 0;">Connect With Sedos</span></td>

    <td height="19" colspan="2">&nbsp;</td>

    </tr>

  <tr valign="top">

    <td height="77" colspan="3" valign="top"><table width="525" border="0" cellpadding="0" cellspacing="0">

      <tr valign="top">

        <td width="272" height="70" valign="top"><div align="left">          <a target="_blank"></a><span class="style37"><span class="style39">Have you joined our online community yet?</span></span></div></td>

        <td width="50" valign="top"><a href="http://www.facebook.com/sedostheatre" target="_blank"><img src="images/FB-f-Logo__blue_60.png" width="45" height="45" hspace="5" vspace="5" border="0" /></a></td>

        <td width="51"><a href="http://www.facebook.com/sedostheatre" target="_blank"></a><a href="http://twitter.com/sedos" target="_blank"><img src="images/Twitter_Social_Icon_Rounded_Square_Color-60.png" width="45" height="45" hspace="5" vspace="5" border="0" /></a></td>

        <td width="50"><a href="https://www.instagram.com/sedoslondon/" target="_blank"><img src="images/Instagram-60.png" width="45" height="45" hspace="5" vspace="5" border="0" /></a></td>

        <td width="51"><a href="https://www.flickr.com/photos/sedos/collections/" target="_blank"></a><a href="http://www.youtube.com/sedosvideo" target="_blank"><img src="images/YouTube_60.png" width="45" height="45" hspace="5" vspace="5" border="0" /></a></td>

        <td width="51"><a href="http://twitter.com/sedos" target="_blank"></a><a href="https://www.flickr.com/photos/sedos/collections/" target="_blank"><img src="images/flickr_60.png" width="45" height="45" hspace="5" vspace="5" border="0" /></a></td>

      </tr>

    </table></td>

    </tr>



  <tr valign="top">

    <td height="19" valign="top" class="style47">National Operatic &amp; Dramatic Society</td>

    <td height="19" valign="top"><span class="style47">Bridewell Theatre</span></td>

    <td height="19" valign="top"><span class="style47" style="margin-top: 0; margin-bottom: 0;">Become a Member</span></td>

    <td colspan="2" valign="top"><span class="style47" style="margin-top: 0; margin-bottom: 0;">Keep Up To Date With Sedos</span></td>

  </tr>

  <tr valign="top">

    <td height="32" valign="top"><a href="https://www.noda.org.uk/" target="_blank"><img src="images/NODA_Logo.gif" width="165" height="94" border="0" /></a></td>

    <td height="32" valign="top"><a href="http://www.sbf.org.uk/whats-on/category/theatre/" target="_blank"><img src="images/sedos-resident_4_2.gif" width="165" height="94" border="0" /></a></td>

    <td height="32" valign="top"><a href="aboutus/joinus.htm"><img src="images/JoinUs-button-183x94.jpg" width="183" height="94" border="0" /></a></td>

    <td valign="top"><a href="http://visitor.r20.constantcontact.com/d.jsp?llr=7yoblmeab&amp;p=oi&amp;m=1104220830492&amp;sit=yqu4b8vfb&amp;f=4cc31fd7-b79d-4c4e-a679-b7da2f2904ac" target="_blank"><img src="images/Signuptoournewsletter.jpg" width="180" height="94" border="0" /></a></td>

    <td valign="top"><a href="general/contact.htm"><img src="images/contactus.jpg" width="190" height="94" border="0" /></a></td>

  </tr>

</table>

          </div>

		  <div id="footer">

				<ul style="margin-bottom: 0">

				  <li><a target="_blank">Copyright Sedos </a><?php echo date('Y'); ?></li>
<li>.<a href="general/accessibility.htm">Accessibility</a></li>
<li>.<a href="general/privacy.htm">Privacy Policy</a></li>
<li>.<a href="general/terms.htm">Terms &amp; Conditions</a></li>
<li>.<a href="general/sitemap.htm">Sitemap</a></li>
<li>.<a href="general/contact.htm">Contact Us</a></li>
<li> - Sedos is a registered charity No. 1173896</li>
</ul>

				<p style="margin-top: 0; margin-bottom: 0;"><a href="http://www.webheads.co.uk/" target="_blank">Web Design Agency</a> - <a href="http://www.webheads.co.uk/" target="_blank">WebHeads - WDC Agency</a></p>

</div>

  </div>

      <div id="header">

    		<div id="logo"><a href="./"><img src="images/sedos_logoandtext-new3.gif" width="419" height="86" border="0" /></a></div>

   		  <ul style="margin-top: 0; margin-bottom: 0;"><li><a href="#"><img src="images/menu_over_01.gif" alt="Home" width="53" height="25" border="0" /></a><a href="whatson/index.htm"><img src="images/menu_02.gif" alt="Whats On" width="94" height="25" border="0" /></a><a href="/secure/boxoffice/production.php"><img src="images/menu_03.gif" alt="Box Office" width="97" height="25" border="0" /></a><a href="aboutus/index.htm"><img src="images/menu_04.gif" alt="About Us" width="90" height="25" border="0" /></a><a href="members/index.htm"><img src="archive/images/menu_10_news.gif" width="55" height="25" border="0" /></a></li>

				<li></li>

	  </ul>

  </div>

        <a href="./" class="style84"><img src="images/sedos_logoandtext-new3.gif" width="419" height="86" border="0" /></a></div>

<script>

  (function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){

  (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),

  m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)

  })(window,document,'script','https://www.google-analytics.com/analytics.js','ga');



  ga('create', 'UA-87589923-1', 'auto');

  ga('send', 'pageview');



</script>

</body>
</html>

