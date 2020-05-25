<?php
if ($_GET['randomId'] != "WKj8huZ0BKuYrOwcJM5ilYPqlfbaXacnyu5_3X6ILKYMcBFeYrdvrqkuMqGNkZKX") {
    echo "Access Denied";
    exit();
}

// display the HTML code:
echo stripslashes($_POST['wproPreviewHTML']);

?>  
