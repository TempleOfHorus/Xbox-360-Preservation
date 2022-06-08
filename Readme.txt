I have written two programs to help preserve xbox 360 digital content. I know xcp files are encrypted and currently unusable, but I hope one day we will be able to decrypt them.
Xbox 360 Content Preservation program is for downloading files of a specified xbox 360 game using hex title id. I have implemented few tricks to obtain contentId for delisted/unreleased content, which mostly works for older titles.
Xbox 360 Content Preservation Database program is to make backup of marketplace-xb.xboxlive.com site. 
Backup of marketplace-xb.xboxlive.com [19.5.2022]: https://archive.org/details/database-of-marketplace-xb.xboxlive.com-19.5.2022.-7z
Note: All delisted/unreleased content before backup date doesn't contain contentId. Windows games contentIds are in store 3.

There is also one trick to obtain contentId of delisted/unreleased content using hexOfferId by guessing hexOfferId, but you need to do it manually and it mostly works for older titles. For example for Tomb Raider Underworld (JP):
1. http://marketplace-xb.xboxlive.com/marketplacecatalog/v1/product/ja-jp?pagenum=1&pagesize=100&postcsv=true&tiers=2.3&hexoffers=0x534307ec0bbf0001
hexoffers=0x534307ec0bbf0001
2. http://marketplace-xb.xboxlive.com/marketplacecatalog/v1/product/ja-jp?pagenum=1&pagesize=100&postcsv=true&tiers=2.3&hexoffers=0x534307ec0bbf0005
hexoffers=0x534307ec0bbf0005
You can see hexoffers are same except last number in the first string. What you can do is to try change this number (for example to number 4):
hexoffers=0x534307ec0bbf0004
You get link: http://marketplace-xb.xboxlive.com/marketplacecatalog/v1/product/ja-jp?pagenum=1&pagesize=100&postcsv=true&tiers=2.3&hexoffers=0x534307ec0bbf0004
And this is the trick how you can get contentId for some delisted/unreleased content by guessing hexOfferId.
Another example, same game:
0x534407fa0ccf0001
0x534407fa0ccf0002
0x534407fa0ccf0005