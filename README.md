- PDF çalýþýyor

- PDF dosyalari GitHub'tan düþüldü
- Product Class'ýna PathPDF Field'ý eklendi
- ProductTypeId Byte'tan short'a çekildi
- DataAccess katmanýnda RepositoryContext teke düþürüldü
- Framework versiyon uyumluluðu saðlandý
** Scaffolding çalýþmýyor gerekli Frameworkler düzenlenecek
#                                       07 Mayýs 2021
#                                       Orguntay 

    ESKÝYEN DÝKKAT!
    
    RepositoryDataContext de bulunan tüm entity'ler için index Details Create ve 
 Edit olmak üzere dörder adet view cshtml sayfalarý ve o sayfalara yönlendirme 
 görevi yapan controllerlarý eklendi.

    Nuget yüklemelerinin framworklerin versiyon uyumluluðu en güncele yakýn þekilde düzenlendi.

    index viewlerinde Model nulable kontrolu yapýldý.

    Tüm view sayfalarýnýn çalýþmasý kontrol edildi.

    PDF çýktýsý kontrol edildi. PDF klasorunden .pdf dosyalarý silindi.

    Yapýlan iþlemlerin doðrýuluðpu anoylandý..

    Clean Code çalýþtýrýlarak tüm dosyalar düzenlendi.

    gitignore dosyasýnda pdf files ignore edildi.

    NOT : 3 adet User tablolarý hariç tutuldu. AspNetUser tablosuna eklenen Fieldlarýn 
yanlýþ yere eklendiði ve User class'ýna eklenmesi gerektiði düþünülüyor.

    Ayrýca 3 adet User  entitylerinin de Core katmanýnda deðil Entities katmanýnda 
 olmasý gerektiði bir önceki projede yapýlan düzeltmelere istinaden düþünülüyor.
 
                                                              3 Mayýs 2021 07:44 
                                                              Orguntay

 ######################################################################
 # GIT REPOSITORY DE KALAN FAKAT IGNORE EDILMIS DOSYALARI SILMEK ICIN #
 ######################################################################
 git rm -r --cached . 
 git add .
 git commit -m 'Removed all files that are in the .gitignore' 
 git push origin master