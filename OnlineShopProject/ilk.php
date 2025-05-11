<?php
//Selahattin Eyüp Altaş 2312506043

if (isset($_POST["kayitol"])) 
{
    header("location:Membership.php");
}

if (isset($_POST["girisyap"])) 
{
    header("location:Login.php");
}

if (isset($_POST["admingiris"])) 
{
    header("location:adminpanel.php");
}


?>


<!doctype html>
<html lang="en">
  <head>
    
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Giriş</title>
    <link rel="shortcut icon" type="x-icon" href="icons\homeicon.png">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
    <link rel="stylesheet" type="text/css" href="styles.css">
    
  </head>
  <body>
    <div class="container p-5">
        <div class="card p-5">
            <form action="ilk.php" method="POST">
            <h1>Hoşgeldiniz</h1>

            <div class="col-md-12 text-center">
                <button type="submit" name= "kayitol" class="button button-green ">Kayıt Ol</button>
                <button type="submit" name= "girisyap" class="button button-blue">Giriş Yap</button>
                <button type="submit" name= "admingiris" class="button button-red">Admin giriş</button>
            </div>

            </form>
        </div>
    </div>
    
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>

  </body>
</html>


