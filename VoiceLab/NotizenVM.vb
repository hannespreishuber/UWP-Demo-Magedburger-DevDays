Imports Windows.Globalization
Imports Windows.Media.SpeechRecognition

Public Class NotizenVM
    Public Notizen As New ObservableCollection(Of Notiz)
    Public Sub load()
        Dim ef = New DataModel1
        For Each item In ef.Notiz
            Notizen.Add(item)
        Next


    End Sub

    Public Async Sub Record()
        Dim sr = New SpeechRecognizer(New Language("de-de"))
        Await sr.CompileConstraintsAsync()
        Dim srResult = Await sr.RecognizeWithUIAsync()
        Dim ef = New DataModel1
        Dim n = New Notiz() With {.ID = 0, .Datum = Date.Now, .Text = srResult.Text}
        ef.Notiz.Add(n)
        ef.SaveChanges()
        Notizen.Add(n)

    End Sub
    Public Sub delete()

    End Sub


End Class
