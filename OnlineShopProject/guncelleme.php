<?php
include("Link.php");



$urunismi_err="";
$urunfiyati_err="";
$urunsayisi_err ="";
$urunid_err="";
$olmus ="";
$olmamis="";


if(isset($_POST["geri"]))
{
    header("location:adminpanel.php");
}

if(isset($_POST["ekle"]))
{
    //Ürün id
    if (empty($_POST["urunid"])) 
    {
        $urunid_err=" Ürün id boş geçilmez";
    }
    else
    {
        $urunid = $_POST["urunid"];
    }



    //Ürün ismi
    if (empty($_POST["urunismi"])) 
    {
        $urunismi_err=" Ürün adı boş geçilmez";
    }
    else if (strlen($_POST["urunismi"])<6)
    {
        $urunismi_err="Ürün adı en az 6 karakterden oluşmalıdır";
    }
    else
    {
        $urunismi = $_POST["urunismi"];
    }


    //ürün fiyatı

    if (empty($_POST["urunfiyati2"])) 
    {
        $urunfiyati_err = "Fiyat boş bırakılamaz";
    }
    else
    {
        $urunfiyati = $_POST["urunfiyati2"];
    }

   
 //Ürün sayısı
    if(empty($_POST["urunsayisi"]))
    {
        $urunsayisi_err ="Sayı kısmı boş geçilmez";
     
    }
    else
    {
        $urunsayisi = $_POST["urunsayisi"];
    }


    if(isset($urunismi) && isset($urunfiyati) && isset($urunsayisi) && isset($urunid))
    {
    $stmt = $link->prepare("CALL Urun_Guncelleme(?,?,?,?)");
    $stmt->execute([$urunid,$urunismi, $urunfiyati, $urunsayisi]);
     
    if ($stmt) 
    {
        $olmus="Ürün Başarıyla Güncellendi Eklendi";
        $_POST=array();
    }
    else 
    {
        $olmamis ="Error".mysqli_error($link);
    }
   

    mysqli_close($link);

     }
}

?>


<!doctype html>
<html lang="en">
  <head>
    <style>
        .buttongreen {
    width: 100%;
    padding: 10px;
    border: none;
    border-radius: 40px;
    color: white;
    font-weight: bold;
    cursor: pointer;
    text-align: center;
    background-color: #28a745;
}
    </style>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Ürün Güncelle</title>
    <link rel="shortcut icon" type="x-icon" href="icons\packicon.png">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
    <link rel="stylesheet" type="text/css" href="styles.css">
  </head>
  <body>
    <div class="container">
        
            <form action="guncelleme.php" method="POST" class="form-container">

            <div>
                    <label for="exampleInputEmail1" class="form-label">Ürün Id:</label>
                    <input type="number" class="form-control       <?php 
                    if (!empty($urunfiyati_err))
                    {
                        echo "is-invalid";
                    }
                    
                    ?>
                    " id="exampleInputEmail1" name ="urunid">
                    <div class="invalid-feedback">
                     <?php echo $urunfiyati_err;?>
                    </div>
                </div>

                <div>
                    <label for="exampleInputEmail1" class="form-label">Ürün ismi:</label>
                    <input type="text" class="form-control       <?php 
                    if (!empty($urunismi_err))
                    {
                        echo "is-invalid";
                    }
                    
                    ?>
                    " id="exampleInputEmail1" name = "urunismi" >
              
                    <div class="invalid-feedback">
                     <?php echo $urunismi_err; ?>
                    </div>
                </div>

                <div>
                    <label for="exampleInputEmail1" class="form-label">Ürün Fiyatı:</label>
                    <input type="number" class="form-control       <?php 
                    if (!empty($urunfiyati_err))
                    {
                        echo "is-invalid";
                    }
                    
                    ?>
                    " id="exampleInputEmail1" name ="urunfiyati2">
                    <div class="invalid-feedback">
                     <?php echo $urunfiyati_err;?>
                    </div>
                </div>

                <div>
                    <label for="exampleInputPassword1" class="form-label">Ürün Sayısı:</label>
                    <input type="number" class="form-control       <?php 
                    if ( !empty($urunsayisi_err))
                    {
                        echo "is-invalid";
                    }
                    
                    ?>
                    " id="exampleInputPassword1" name = "urunsayisi">
                    <div class="invalid-feedback">
                     <?php echo $urunsayisi_err ?>
                    </div>
                </div>

                <button type="submit" name= "ekle" class ="buttongreen">Güncelle</button>
                <button type="submit" name= "geri" class ="button button-red">Geri Dön</button>
            </form>
            <?php if($olmus): ?>
                <div class="alert alert-success mt-3" role="alert">
                    <?php echo $olmus;?>
                </div>
                <?php endif;?>
            <?php if($olmamis): ?>
            <div class="alert alert-danger mt-3" role="alert">
                <?php echo $olmamis;?>
            </div>
                <?php endif;?>
        
    </div>
    
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
  </body>
</html>