' Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x407 dokumentiert.

Imports Windows.Globalization
Imports Windows.Media.SpeechRecognition
Imports Windows.UI.Popups
''' <summary>
''' Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
''' </summary>
Public NotInheritable Class MainPage
    Inherits Page
    Public Property myNotizen As New NotizenVM

    Private Async Function Button_ClickAsync(sender As Object, e As RoutedEventArgs) As Task
        Dim sr = New SpeechRecognizer(New Language("de-de"))
        'Dim srtc = New SpeechRecognitionTopicConstraint(SpeechRecognitionScenario.Dictation, "dictation")
        'sr.Constraints.Add(srtc)
        Await sr.CompileConstraintsAsync()
        Dim srResult = Await sr.RecognizeWithUIAsync()


        'Dim messageDialog = New MessageDialog(srResult.Text, "Text spoken")
        'Await messageDialog.ShowAsync()

    End Function

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Dim ef = New DataModel1
        ef.Notiz.Add(New Notiz() With {.ID = 0, .Datum = Date.Now, .Text = "INIT"})
        ef.SaveChanges()
    End Sub

    Private Sub MainPage_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        myNotizen.load()
        Me.DataContext = myNotizen
    End Sub

    Private Sub SwipeItem_Invoked(sender As SwipeItem, args As SwipeItemInvokedEventArgs)

        Dim i = myNotizen.Notizen.IndexOf(args.SwipeControl.DataContext)
        myNotizen.Notizen.RemoveAt(i)

        ' myNotizen.delete(args)
    End Sub
End Class
