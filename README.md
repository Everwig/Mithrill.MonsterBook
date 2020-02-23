# Mithrill.MonsterBook

## To Create Db
1.) Setup MSSQL Express
2.) Run Update-Database -StartupProject EntityFramework.MonsterBook

## How to add new migration
1.) Add-Migration <NameOfMigration> -StartupProject EntityFramework.MonsterBook
2.) Script-Migration -To <NameOfMigration> -From <NameOfPreviousMigration> -Output Scripts/#_<NameOfMigration> -StartupProject EntityFramework.MonsterBook
3.) Script-Migration -From <NameOfMigration> -To <NameOfPreviousMigration> -Output Scripts/Rollback/#_<NameOfMigration>_rollback -StartupProject EntityFramework.MonsterBook