<!doctype html>

<html lang="en">
<head>
  <meta charset="utf-8">
  <title>PHP Website</title>
</head>

<body>
  <h1>
  <?php 

    $ip =getenv("REMOTE_ADDR");

    echo "IP address running in docker: $ip";

    $i = 0;
    while($i < 5)
    {
      $i++;
      echo "<div>some php code: $i </div>";
    }
  
  ?>
  

</h1>
   <img src="images/php.png" />

  <iframe src="https://www.liverpoolfc.com/" height="600" width="800" />

</body>
</html>