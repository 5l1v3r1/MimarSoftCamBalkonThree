- PDF �al���yor

- PDF dosyalari GitHub'tan d���ld�
- Product Class'�na PathPDF Field'� eklendi
- ProductTypeId Byte'tan short'a �ekildi
- DataAccess katman�nda RepositoryContext teke d���r�ld�
- Framework versiyon uyumlulu�u sa�land�
** Scaffolding �al��m�yor gerekli Frameworkler d�zenlenecek
#                                       07 May�s 2021
#                                       Orguntay 

    ESK�YEN D�KKAT!
    
    RepositoryDataContext de bulunan t�m entity'ler i�in index Details Create ve 
 Edit olmak �zere d�rder adet view cshtml sayfalar� ve o sayfalara y�nlendirme 
 g�revi yapan controllerlar� eklendi.

    Nuget y�klemelerinin framworklerin versiyon uyumlulu�u en g�ncele yak�n �ekilde d�zenlendi.

    index viewlerinde Model nulable kontrolu yap�ld�.

    T�m view sayfalar�n�n �al��mas� kontrol edildi.

    PDF ��kt�s� kontrol edildi. PDF klasorunden .pdf dosyalar� silindi.

    Yap�lan i�lemlerin do�r�ulu�pu anoyland�..

    Clean Code �al��t�r�larak t�m dosyalar d�zenlendi.

    gitignore dosyas�nda pdf files ignore edildi.

    NOT : 3 adet User tablolar� hari� tutuldu. AspNetUser tablosuna eklenen Fieldlar�n 
yanl�� yere eklendi�i ve User class'�na eklenmesi gerekti�i d���n�l�yor.

    Ayr�ca 3 adet User  entitylerinin de Core katman�nda de�il Entities katman�nda 
 olmas� gerekti�i bir �nceki projede yap�lan d�zeltmelere istinaden d���n�l�yor.
 
                                                              3 May�s 2021 07:44 
                                                              Orguntay

 ######################################################################
 # GIT REPOSITORY DE KALAN FAKAT IGNORE EDILMIS DOSYALARI SILMEK ICIN #
 ######################################################################
 git rm -r --cached . 
 git add .
 git commit -m 'Removed all files that are in the .gitignore' 
 git push origin master