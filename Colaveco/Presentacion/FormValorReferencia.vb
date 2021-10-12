Public Class FormValorReferencia
#Region "Atributos"
    Private _usuario As dUsuario
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property
#End Region
#Region "Constructores"
    Public Sub New(ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u

        limpiar()
        cargarlista()

    End Sub

#End Region
    Private Sub limpiar()
        Text1.Text = ""
        Text2.Text = ""
        Text3.Text = ""
        Text4.Text = ""
        Text5.Text = ""
        Text6.Text = ""
        Text7.Text = ""
        Text8.Text = ""
        Text9.Text = ""
        Text10.Text = ""
        Text11.Text = ""
        RadioCelulas.Checked = True
    End Sub
    Private Sub limpiar2()
        Text1.Text = ""
        Text2.Text = ""
        Text3.Text = ""
        Text4.Text = ""
        Text5.Text = ""
        Text6.Text = ""
        Text7.Text = ""
        Text8.Text = ""
        Text9.Text = ""
        Text10.Text = ""
        Text11.Text = ""
    End Sub

    Private Sub cargarlista()
        If RadioCelulas.Checked = True Then
            Dim vr As New dValorReferencia
            Dim lista As New ArrayList
            lista = vr.listarcelulas
            Dim valor(10) As Double
            Dim x As Integer = 0
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each vr In lista
                        valor(x) = vr.CELULAS
                        x = x + 1
                    Next

                End If
            End If
            limpiar2()
            Text1.Text = valor(0)
            Text2.Text = valor(1)
            Text3.Text = valor(2)
            Text4.Text = valor(3)
            Text5.Text = valor(4)
            Text6.Text = valor(5)
            Text7.Text = valor(6)
            Text8.Text = valor(7)
            Text9.Text = valor(8)
            Text10.Text = valor(9)
            Text11.Text = valor(10)

        ElseIf RadioGrasa.Checked = True Then
            Dim vr As New dValorReferencia
            Dim lista As New ArrayList
            lista = vr.listargrasa
            Dim valor(10) As Double
            Dim x As Integer = 0
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each vr In lista
                        valor(x) = vr.GRASA
                        x = x + 1
                    Next

                End If
            End If
            limpiar2()
            Text1.Text = valor(0)
            Text2.Text = valor(1)
            Text3.Text = valor(2)
            Text4.Text = valor(3)
            Text5.Text = valor(4)
            Text6.Text = valor(5)
            Text7.Text = valor(6)
            Text8.Text = valor(7)
            Text9.Text = valor(8)
            Text10.Text = valor(9)
            Text11.Text = valor(10)

        ElseIf RadioProteinas.Checked = True Then
            Dim vr As New dValorReferencia
            Dim lista As New ArrayList
            lista = vr.listarproteina
            Dim valor(10) As Double
            Dim x As Integer = 0
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each vr In lista
                        valor(x) = vr.PROTEINA
                        x = x + 1
                    Next

                End If
            End If
            limpiar2()
            Text1.Text = valor(0)
            Text2.Text = valor(1)
            Text3.Text = valor(2)
            Text4.Text = valor(3)
            Text5.Text = valor(4)
            Text6.Text = valor(5)
            Text7.Text = valor(6)
            Text8.Text = valor(7)
            Text9.Text = valor(8)
            Text10.Text = valor(9)
            Text11.Text = valor(10)
        ElseIf RadioLactosa.Checked = True Then
            Dim vr As New dValorReferencia
            Dim lista As New ArrayList
            lista = vr.listarlactosa
            Dim valor(10) As Double
            Dim x As Integer = 0
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each vr In lista
                        valor(x) = vr.LACTOSA
                        x = x + 1
                    Next

                End If
            End If
            limpiar2()
            Text1.Text = valor(0)
            Text2.Text = valor(1)
            Text3.Text = valor(2)
            Text4.Text = valor(3)
            Text5.Text = valor(4)
            Text6.Text = valor(5)
            Text7.Text = valor(6)
            Text8.Text = valor(7)
            Text9.Text = valor(8)
            Text10.Text = valor(9)
            Text11.Text = valor(10)
        ElseIf RadioST.Checked = True Then
            Dim vr As New dValorReferencia
            Dim lista As New ArrayList
            lista = vr.listarst
            Dim valor(10) As Double
            Dim x As Integer = 0
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each vr In lista
                        valor(x) = vr.ST
                        x = x + 1
                    Next

                End If
            End If
            limpiar2()
            Text1.Text = valor(0)
            Text2.Text = valor(1)
            Text3.Text = valor(2)
            Text4.Text = valor(3)
            Text5.Text = valor(4)
            Text6.Text = valor(5)
            Text7.Text = valor(6)
            Text8.Text = valor(7)
            Text9.Text = valor(8)
            Text10.Text = valor(9)
            Text11.Text = valor(10)
        ElseIf RadioCrioscopia.Checked = True Then
            Dim vr As New dValorReferencia
            Dim lista As New ArrayList
            lista = vr.listarcrioscopia
            Dim valor(10) As Double
            Dim x As Integer = 0
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each vr In lista
                        valor(x) = vr.CRIOSCOPIA
                        x = x + 1
                    Next

                End If
            End If
            limpiar2()
            Text1.Text = valor(0)
            Text2.Text = valor(1)
            Text3.Text = valor(2)
            Text4.Text = valor(3)
            Text5.Text = valor(4)
            Text6.Text = valor(5)
            Text7.Text = valor(6)
            Text8.Text = valor(7)
            Text9.Text = valor(8)
            Text10.Text = valor(9)
            Text11.Text = valor(10)
        ElseIf RadioUrea.Checked = True Then
            Dim vr As New dValorReferencia
            Dim lista As New ArrayList
            lista = vr.listarurea
            Dim valor(10) As Double
            Dim x As Integer = 0
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each vr In lista
                        valor(x) = vr.UREA
                        x = x + 1
                    Next

                End If
            End If
            limpiar2()
            Text1.Text = valor(0)
            Text2.Text = valor(1)
            Text3.Text = valor(2)
            Text4.Text = valor(3)
            Text5.Text = valor(4)
            Text6.Text = valor(5)
            Text7.Text = valor(6)
            Text8.Text = valor(7)
            Text9.Text = valor(8)
            Text10.Text = valor(9)
            Text11.Text = valor(10)
        ElseIf RadioProteinaV.Checked = True Then
            Dim vr As New dValorReferencia
            Dim lista As New ArrayList
            lista = vr.listarproteinav
            Dim valor(10) As Double
            Dim x As Integer = 0
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each vr In lista
                        valor(x) = vr.PROTEINAV
                        x = x + 1
                    Next

                End If
            End If
            limpiar2()
            Text1.Text = valor(0)
            Text2.Text = valor(1)
            Text3.Text = valor(2)
            Text4.Text = valor(3)
            Text5.Text = valor(4)
            Text6.Text = valor(5)
            Text7.Text = valor(6)
            Text8.Text = valor(7)
            Text9.Text = valor(8)
            Text10.Text = valor(9)
            Text11.Text = valor(10)
        ElseIf RadioCaseina.Checked = True Then
            Dim vr As New dValorReferencia
            Dim lista As New ArrayList
            lista = vr.listarcaseina
            Dim valor(10) As Double
            Dim x As Integer = 0
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each vr In lista
                        valor(x) = vr.CASEINA
                        x = x + 1
                    Next

                End If
            End If
            limpiar2()
            Text1.Text = valor(0)
            Text2.Text = valor(1)
            Text3.Text = valor(2)
            Text4.Text = valor(3)
            Text5.Text = valor(4)
            Text6.Text = valor(5)
            Text7.Text = valor(6)
            Text8.Text = valor(7)
            Text9.Text = valor(8)
            Text10.Text = valor(9)
            Text11.Text = valor(10)
        ElseIf RadioDensidad.Checked = True Then
            Dim vr As New dValorReferencia
            Dim lista As New ArrayList
            lista = vr.listardensidad
            Dim valor(10) As Double
            Dim x As Integer = 0
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each vr In lista
                        valor(x) = vr.DENSIDAD
                        x = x + 1
                    Next

                End If
            End If
            limpiar2()
            Text1.Text = valor(0)
            Text2.Text = valor(1)
            Text3.Text = valor(2)
            Text4.Text = valor(3)
            Text5.Text = valor(4)
            Text6.Text = valor(5)
            Text7.Text = valor(6)
            Text8.Text = valor(7)
            Text9.Text = valor(8)
            Text10.Text = valor(9)
            Text11.Text = valor(10)
        ElseIf RadioPH.Checked = True Then
            Dim vr As New dValorReferencia
            Dim lista As New ArrayList
            lista = vr.listarph
            Dim valor(10) As Double
            Dim x As Integer = 0
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each vr In lista
                        valor(x) = vr.PH
                        x = x + 1
                    Next

                End If
            End If
            limpiar2()
            Text1.Text = valor(0)
            Text2.Text = valor(1)
            Text3.Text = valor(2)
            Text4.Text = valor(3)
            Text5.Text = valor(4)
            Text6.Text = valor(5)
            Text7.Text = valor(6)
            Text8.Text = valor(7)
            Text9.Text = valor(8)
            Text10.Text = valor(9)
            Text11.Text = valor(10)
        ElseIf RadioCitratos.Checked = True Then
            Dim vr As New dValorReferencia
            Dim lista As New ArrayList
            lista = vr.listarcitratos
            Dim valor(10) As Double
            Dim x As Integer = 0
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each vr In lista
                        valor(x) = vr.CITRATOS
                        x = x + 1
                    Next

                End If
            End If
            limpiar2()
            Text1.Text = valor(0)
            Text2.Text = valor(1)
            Text3.Text = valor(2)
            Text4.Text = valor(3)
            Text5.Text = valor(4)
            Text6.Text = valor(5)
            Text7.Text = valor(6)
            Text8.Text = valor(7)
            Text9.Text = valor(8)
            Text10.Text = valor(9)
            Text11.Text = valor(10)
        End If
    End Sub

    Private Sub RadioCelulas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioCelulas.CheckedChanged
        cargarlista()
    End Sub

    Private Sub RadioGrasa_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioGrasa.CheckedChanged
        cargarlista()
    End Sub

    Private Sub RadioProteinas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioProteinas.CheckedChanged
        cargarlista()
    End Sub

    Private Sub RadioLactosa_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioLactosa.CheckedChanged
        cargarlista()
    End Sub

    Private Sub RadioST_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioST.CheckedChanged
        cargarlista()
    End Sub

    Private Sub RadioCrioscopia_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioCrioscopia.CheckedChanged
        cargarlista()
    End Sub

    Private Sub RadioUrea_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioUrea.CheckedChanged
        cargarlista()
    End Sub

    Private Sub RadioProteinaV_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioProteinaV.CheckedChanged
        cargarlista()
    End Sub

    Private Sub RadioCaseina_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioCaseina.CheckedChanged
        cargarlista()
    End Sub

    Private Sub RadioDensidad_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioDensidad.CheckedChanged
        cargarlista()
    End Sub

    Private Sub RadioPH_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioPH.CheckedChanged
        cargarlista()
    End Sub

    Private Sub RadioCitratos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioCitratos.CheckedChanged
        cargarlista()
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        guardar()
    End Sub
    Private Sub guardar()
        Dim vr As New dValorReferencia
        Dim vr1 As Double = 0
        Dim vr2 As Double = 0
        Dim vr3 As Double = 0
        Dim vr4 As Double = 0
        Dim vr5 As Double = 0
        Dim vr6 As Double = 0
        Dim vr7 As Double = 0
        Dim vr8 As Double = 0
        Dim vr9 As Double = 0
        Dim vr10 As Double = 0
        Dim vr11 As Double = 0
        If Text1.Text.Length > 0 Then
            vr1 = Text1.Text.Trim
        End If
        If Text2.Text.Length > 0 Then
            vr2 = Text2.Text.Trim
        End If
        If Text3.Text.Length > 0 Then
            vr3 = Text3.Text.Trim
        End If
        If Text4.Text.Length > 0 Then
            vr4 = Text4.Text.Trim
        End If
        If Text5.Text.Length > 0 Then
            vr5 = Text5.Text.Trim
        End If
        If Text6.Text.Length > 0 Then
            vr6 = Text6.Text.Trim
        End If
        If Text7.Text.Length > 0 Then
            vr7 = Text7.Text.Trim
        End If
        If Text8.Text.Length > 0 Then
            vr8 = Text8.Text.Trim
        End If
        If Text9.Text.Length > 0 Then
            vr9 = Text9.Text.Trim
        End If
        If Text10.Text.Length > 0 Then
            vr10 = Text10.Text.Trim
        End If
        If Text11.Text.Length > 0 Then
            vr11 = Text11.Text.Trim
        End If

        If RadioCelulas.Checked = True Then
            
            vr.CELULAS = vr1
            vr.ID = 1
            vr.modificarcelulas(Usuario)
            vr.CELULAS = vr2
            vr.ID = 2
            vr.modificarcelulas(Usuario)
            vr.CELULAS = vr3
            vr.ID = 3
            vr.modificarcelulas(Usuario)
            vr.CELULAS = vr4
            vr.ID = 4
            vr.modificarcelulas(Usuario)
            vr.CELULAS = vr5
            vr.ID = 5
            vr.modificarcelulas(Usuario)
            vr.CELULAS = vr6
            vr.ID = 6
            vr.modificarcelulas(Usuario)
            vr.CELULAS = vr7
            vr.ID = 7
            vr.modificarcelulas(Usuario)
            vr.CELULAS = vr8
            vr.ID = 8
            vr.modificarcelulas(Usuario)
            vr.CELULAS = vr9
            vr.ID = 9
            vr.modificarcelulas(Usuario)
            vr.CELULAS = vr10
            vr.ID = 10
            vr.modificarcelulas(Usuario)
            vr.CELULAS = vr11
            vr.ID = 11
            vr.modificarcelulas(Usuario)

        ElseIf RadioGrasa.Checked = True Then
            vr.GRASA = vr1
            vr.ID = 1
            vr.modificargrasa(Usuario)
            vr.GRASA = vr2
            vr.ID = 2
            vr.modificargrasa(Usuario)
            vr.GRASA = vr3
            vr.ID = 3
            vr.modificargrasa(Usuario)
            vr.GRASA = vr4
            vr.ID = 4
            vr.modificargrasa(Usuario)
            vr.GRASA = vr5
            vr.ID = 5
            vr.modificargrasa(Usuario)
            vr.GRASA = vr6
            vr.ID = 6
            vr.modificargrasa(Usuario)
            vr.GRASA = vr7
            vr.ID = 7
            vr.modificargrasa(Usuario)
            vr.GRASA = vr8
            vr.ID = 8
            vr.modificargrasa(Usuario)
            vr.GRASA = vr9
            vr.ID = 9
            vr.modificargrasa(Usuario)
            vr.GRASA = vr10
            vr.ID = 10
            vr.modificargrasa(Usuario)
            vr.GRASA = vr11
            vr.ID = 11
            vr.modificargrasa(Usuario)

        ElseIf RadioProteinas.Checked = True Then
            vr.PROTEINA = vr1
            vr.ID = 1
            vr.modificarproteina(Usuario)
            vr.PROTEINA = vr2
            vr.ID = 2
            vr.modificarproteina(Usuario)
            vr.PROTEINA = vr3
            vr.ID = 3
            vr.modificarproteina(Usuario)
            vr.PROTEINA = vr4
            vr.ID = 4
            vr.modificarproteina(Usuario)
            vr.PROTEINA = vr5
            vr.ID = 5
            vr.modificarproteina(Usuario)
            vr.PROTEINA = vr6
            vr.ID = 6
            vr.modificarproteina(Usuario)
            vr.PROTEINA = vr7
            vr.ID = 7
            vr.modificarproteina(Usuario)
            vr.PROTEINA = vr8
            vr.ID = 8
            vr.modificarproteina(Usuario)
            vr.PROTEINA = vr9
            vr.ID = 9
            vr.modificarproteina(Usuario)
            vr.PROTEINA = vr10
            vr.ID = 10
            vr.modificarproteina(Usuario)
            vr.PROTEINA = vr11
            vr.ID = 11
            vr.modificarproteina(Usuario)
        ElseIf RadioLactosa.Checked = True Then
            vr.LACTOSA = vr1
            vr.ID = 1
            vr.modificarlactosa(Usuario)
            vr.LACTOSA = vr2
            vr.ID = 2
            vr.modificarlactosa(Usuario)
            vr.LACTOSA = vr3
            vr.ID = 3
            vr.modificarlactosa(Usuario)
            vr.LACTOSA = vr4
            vr.ID = 4
            vr.modificarlactosa(Usuario)
            vr.LACTOSA = vr5
            vr.ID = 5
            vr.modificarlactosa(Usuario)
            vr.LACTOSA = vr6
            vr.ID = 6
            vr.modificarlactosa(Usuario)
            vr.LACTOSA = vr7
            vr.ID = 7
            vr.modificarlactosa(Usuario)
            vr.LACTOSA = vr8
            vr.ID = 8
            vr.modificarlactosa(Usuario)
            vr.LACTOSA = vr9
            vr.ID = 9
            vr.modificarlactosa(Usuario)
            vr.LACTOSA = vr10
            vr.ID = 10
            vr.modificarlactosa(Usuario)
            vr.LACTOSA = vr11
            vr.ID = 11
            vr.modificarlactosa(Usuario)
        ElseIf RadioST.Checked = True Then
            vr.ST = vr1
            vr.ID = 1
            vr.modificarst(Usuario)
            vr.ST = vr2
            vr.ID = 2
            vr.modificarst(Usuario)
            vr.ST = vr3
            vr.ID = 3
            vr.modificarst(Usuario)
            vr.ST = vr4
            vr.ID = 4
            vr.modificarst(Usuario)
            vr.ST = vr5
            vr.ID = 5
            vr.modificarst(Usuario)
            vr.ST = vr6
            vr.ID = 6
            vr.modificarst(Usuario)
            vr.ST = vr7
            vr.ID = 7
            vr.modificarst(Usuario)
            vr.ST = vr8
            vr.ID = 8
            vr.modificarst(Usuario)
            vr.ST = vr9
            vr.ID = 9
            vr.modificarst(Usuario)
            vr.ST = vr10
            vr.ID = 10
            vr.modificarst(Usuario)
            vr.ST = vr11
            vr.ID = 11
            vr.modificarst(Usuario)
        ElseIf RadioCrioscopia.Checked = True Then
            vr.CRIOSCOPIA = vr1
            vr.ID = 1
            vr.modificarcrioscopia(Usuario)
            vr.CRIOSCOPIA = vr2
            vr.ID = 2
            vr.modificarcrioscopia(Usuario)
            vr.CRIOSCOPIA = vr3
            vr.ID = 3
            vr.modificarcrioscopia(Usuario)
            vr.CRIOSCOPIA = vr4
            vr.ID = 4
            vr.modificarcrioscopia(Usuario)
            vr.CRIOSCOPIA = vr5
            vr.ID = 5
            vr.modificarcrioscopia(Usuario)
            vr.CRIOSCOPIA = vr6
            vr.ID = 6
            vr.modificarcrioscopia(Usuario)
            vr.CRIOSCOPIA = vr7
            vr.ID = 7
            vr.modificarcrioscopia(Usuario)
            vr.CRIOSCOPIA = vr8
            vr.ID = 8
            vr.modificarcrioscopia(Usuario)
            vr.CRIOSCOPIA = vr9
            vr.ID = 9
            vr.modificarcrioscopia(Usuario)
            vr.CRIOSCOPIA = vr10
            vr.ID = 10
            vr.modificarcrioscopia(Usuario)
            vr.CRIOSCOPIA = vr11
            vr.ID = 11
            vr.modificarcrioscopia(Usuario)
        ElseIf RadioUrea.Checked = True Then
            vr.UREA = vr1
            vr.ID = 1
            vr.modificarurea(Usuario)
            vr.UREA = vr2
            vr.ID = 2
            vr.modificarurea(Usuario)
            vr.UREA = vr3
            vr.ID = 3
            vr.modificarurea(Usuario)
            vr.UREA = vr4
            vr.ID = 4
            vr.modificarurea(Usuario)
            vr.UREA = vr5
            vr.ID = 5
            vr.modificarurea(Usuario)
            vr.UREA = vr6
            vr.ID = 6
            vr.modificarurea(Usuario)
            vr.UREA = vr7
            vr.ID = 7
            vr.modificarurea(Usuario)
            vr.UREA = vr8
            vr.ID = 8
            vr.modificarurea(Usuario)
            vr.UREA = vr9
            vr.ID = 9
            vr.modificarurea(Usuario)
            vr.UREA = vr10
            vr.ID = 10
            vr.modificarurea(Usuario)
            vr.UREA = vr11
            vr.ID = 11
            vr.modificarurea(Usuario)
        ElseIf RadioProteinaV.Checked = True Then
            vr.PROTEINAV = vr1
            vr.ID = 1
            vr.modificarproteinav(Usuario)
            vr.PROTEINAV = vr2
            vr.ID = 2
            vr.modificarproteinav(Usuario)
            vr.PROTEINAV = vr3
            vr.ID = 3
            vr.modificarproteinav(Usuario)
            vr.PROTEINAV = vr4
            vr.ID = 4
            vr.modificarproteinav(Usuario)
            vr.PROTEINAV = vr5
            vr.ID = 5
            vr.modificarproteinav(Usuario)
            vr.PROTEINAV = vr6
            vr.ID = 6
            vr.modificarproteinav(Usuario)
            vr.PROTEINAV = vr7
            vr.ID = 7
            vr.modificarproteinav(Usuario)
            vr.PROTEINAV = vr8
            vr.ID = 8
            vr.modificarproteinav(Usuario)
            vr.PROTEINAV = vr9
            vr.ID = 9
            vr.modificarproteinav(Usuario)
            vr.PROTEINAV = vr10
            vr.ID = 10
            vr.modificarproteinav(Usuario)
            vr.PROTEINAV = vr11
            vr.ID = 11
            vr.modificarproteinav(Usuario)
        ElseIf RadioCaseina.Checked = True Then
            vr.CASEINA = vr1
            vr.ID = 1
            vr.modificarcaseina(Usuario)
            vr.CASEINA = vr2
            vr.ID = 2
            vr.modificarcaseina(Usuario)
            vr.CASEINA = vr3
            vr.ID = 3
            vr.modificarcaseina(Usuario)
            vr.CASEINA = vr4
            vr.ID = 4
            vr.modificarcaseina(Usuario)
            vr.CASEINA = vr5
            vr.ID = 5
            vr.modificarcaseina(Usuario)
            vr.CASEINA = vr6
            vr.ID = 6
            vr.modificarcaseina(Usuario)
            vr.CASEINA = vr7
            vr.ID = 7
            vr.modificarcaseina(Usuario)
            vr.CASEINA = vr8
            vr.ID = 8
            vr.modificarcaseina(Usuario)
            vr.CASEINA = vr9
            vr.ID = 9
            vr.modificarcaseina(Usuario)
            vr.CASEINA = vr10
            vr.ID = 10
            vr.modificarcaseina(Usuario)
            vr.CASEINA = vr11
            vr.ID = 11
            vr.modificarcaseina(Usuario)
        ElseIf RadioDensidad.Checked = True Then
            vr.DENSIDAD = vr1
            vr.ID = 1
            vr.modificardensidad(Usuario)
            vr.DENSIDAD = vr2
            vr.ID = 2
            vr.modificardensidad(Usuario)
            vr.DENSIDAD = vr3
            vr.ID = 3
            vr.modificardensidad(Usuario)
            vr.DENSIDAD = vr4
            vr.ID = 4
            vr.modificardensidad(Usuario)
            vr.DENSIDAD = vr5
            vr.ID = 5
            vr.modificardensidad(Usuario)
            vr.DENSIDAD = vr6
            vr.ID = 6
            vr.modificardensidad(Usuario)
            vr.DENSIDAD = vr7
            vr.ID = 7
            vr.modificardensidad(Usuario)
            vr.DENSIDAD = vr8
            vr.ID = 8
            vr.modificardensidad(Usuario)
            vr.DENSIDAD = vr9
            vr.ID = 9
            vr.modificardensidad(Usuario)
            vr.DENSIDAD = vr10
            vr.ID = 10
            vr.modificardensidad(Usuario)
            vr.DENSIDAD = vr11
            vr.ID = 11
            vr.modificardensidad(Usuario)
        ElseIf RadioPH.Checked = True Then
            vr.PH = vr1
            vr.ID = 1
            vr.modificarph(Usuario)
            vr.PH = vr2
            vr.ID = 2
            vr.modificarph(Usuario)
            vr.PH = vr3
            vr.ID = 3
            vr.modificarph(Usuario)
            vr.PH = vr4
            vr.ID = 4
            vr.modificarph(Usuario)
            vr.PH = vr5
            vr.ID = 5
            vr.modificarph(Usuario)
            vr.PH = vr6
            vr.ID = 6
            vr.modificarph(Usuario)
            vr.PH = vr7
            vr.ID = 7
            vr.modificarph(Usuario)
            vr.PH = vr8
            vr.ID = 8
            vr.modificarph(Usuario)
            vr.PH = vr9
            vr.ID = 9
            vr.modificarph(Usuario)
            vr.PH = vr10
            vr.ID = 10
            vr.modificarph(Usuario)
            vr.PH = vr11
            vr.ID = 11
            vr.modificarph(Usuario)
        ElseIf RadioCitratos.Checked = True Then
            vr.CITRATOS = vr1
            vr.ID = 1
            vr.modificarcitratos(Usuario)
            vr.CITRATOS = vr2
            vr.ID = 2
            vr.modificarcitratos(Usuario)
            vr.CITRATOS = vr3
            vr.ID = 3
            vr.modificarcitratos(Usuario)
            vr.CITRATOS = vr4
            vr.ID = 4
            vr.modificarcitratos(Usuario)
            vr.CITRATOS = vr5
            vr.ID = 5
            vr.modificarcitratos(Usuario)
            vr.CITRATOS = vr6
            vr.ID = 6
            vr.modificarcitratos(Usuario)
            vr.CITRATOS = vr7
            vr.ID = 7
            vr.modificarcitratos(Usuario)
            vr.CITRATOS = vr8
            vr.ID = 8
            vr.modificarcitratos(Usuario)
            vr.CITRATOS = vr9
            vr.ID = 9
            vr.modificarcitratos(Usuario)
            vr.CITRATOS = vr10
            vr.ID = 10
            vr.modificarcitratos(Usuario)
            vr.CITRATOS = vr11
            vr.ID = 11
            vr.modificarcitratos(Usuario)
        End If
        MsgBox("Registro guardado!")

    End Sub
End Class