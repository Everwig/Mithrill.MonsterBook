# Mithrill.MonsterBook

## Purpose
Purpose of this project is teach some basic programming to a friend and to have fun. Also if/when it will be completed it will greatly help create creatures for our pen and paper rpg called Mithrill: http://mithrill.tk. It's in Hungarian so sorry for non-native speakers.
We don't plan to translate it to English or to other language at the moment, but we are open to it if you're intersted, just send a message through the website: http://mithrill.tk/index.php?route=information/contact.

## To Create Db
1. Setup MSSQL Express
2. Run Update-Database -StartupProject EntityFramework.MonsterBook

## How to add new migration
1. Add-Migration <NameOfMigration> -StartupProject EntityFramework.MonsterBook
2. Script-Migration -To <NameOfMigration> -From <NameOfPreviousMigration> -Output Scripts/#_<NameOfMigration> -StartupProject EntityFramework.MonsterBook
3. Script-Migration -From <NameOfMigration> -To <NameOfPreviousMigration> -Output Scripts/Rollback/#_<NameOfMigration>_rollback -StartupProject EntityFramework.MonsterBook