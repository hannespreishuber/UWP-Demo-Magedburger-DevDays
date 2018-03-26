Imports Microsoft.EntityFrameworkCore
Imports VoiceLab

Public Class DataModel1
    Inherits DbContext


    Public Overridable Property Notiz As DbSet(Of Notiz)



    Protected Overrides Sub OnModelCreating(modelBuilder As ModelBuilder)
        modelBuilder.Entity(Of Notiz)()
        MyBase.OnModelCreating(modelBuilder)
    End Sub

    Protected Overrides Sub OnConfiguring(optionsBuilder As DbContextOptionsBuilder)
        optionsBuilder.UseSqlServer(ctype(App.Current,App).connectionString)
        MyBase.OnConfiguring(optionsBuilder)
    End Sub
End Class
