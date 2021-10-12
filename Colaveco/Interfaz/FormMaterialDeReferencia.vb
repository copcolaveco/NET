Public Class FormMaterialDeReferencia
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
        limpiar2()
        TextOperador.Text = Usuario.NOMBRE
        RadioPasada1.Checked = True
        RadioCelulas.Checked = True
        cargarlista()
    End Sub

#End Region
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
            TextVR1.Text = valor(0)
            TextVR2.Text = valor(1)
            TextVR3.Text = valor(2)
            TextVR4.Text = valor(3)
            TextVR5.Text = valor(4)
            TextVR6.Text = valor(5)
            TextVR7.Text = valor(6)
            TextVR8.Text = valor(7)
            TextVR9.Text = valor(8)
            TextVR10.Text = valor(9)
            TextVR11.Text = valor(10)

            TextDM1.Text = 0
            TextDM2.Text = 0
            TextDM3.Text = 0
            TextDM4.Text = 0
            TextDM5.Text = 0
            TextDM6.Text = 0
            TextDM7.Text = 0
            TextDM8.Text = 0
            TextDM9.Text = 0
            TextDM10.Text = 0
            TextDM11.Text = 0


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
            TextVR1.Text = valor(0)
            TextVR2.Text = valor(1)
            TextVR3.Text = valor(2)
            TextVR4.Text = valor(3)
            TextVR5.Text = valor(4)
            TextVR6.Text = valor(5)
            TextVR7.Text = valor(6)
            TextVR8.Text = valor(7)
            TextVR9.Text = valor(8)
            TextVR10.Text = valor(9)
            TextVR11.Text = valor(10)

            TextDM1.Text = 0.07
            TextDM2.Text = 0.07
            TextDM3.Text = 0.07
            TextDM4.Text = 0.07
            TextDM5.Text = 0.07
            TextDM6.Text = 0.07
            TextDM7.Text = 0.07
            TextDM8.Text = 0.07
            TextDM9.Text = 0.07
            TextDM10.Text = 0.07
            TextDM11.Text = 0.07

        ElseIf RadioProteina.Checked = True Then
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
            TextVR1.Text = valor(0)
            TextVR2.Text = valor(1)
            TextVR3.Text = valor(2)
            TextVR4.Text = valor(3)
            TextVR5.Text = valor(4)
            TextVR6.Text = valor(5)
            TextVR7.Text = valor(6)
            TextVR8.Text = valor(7)
            TextVR9.Text = valor(8)
            TextVR10.Text = valor(9)
            TextVR11.Text = valor(10)

            TextDM1.Text = 0.07
            TextDM2.Text = 0.07
            TextDM3.Text = 0.07
            TextDM4.Text = 0.07
            TextDM5.Text = 0.07
            TextDM6.Text = 0.07
            TextDM7.Text = 0.07
            TextDM8.Text = 0.07
            TextDM9.Text = 0.07
            TextDM10.Text = 0.07
            TextDM11.Text = 0.07

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
            TextVR1.Text = valor(0)
            TextVR2.Text = valor(1)
            TextVR3.Text = valor(2)
            TextVR4.Text = valor(3)
            TextVR5.Text = valor(4)
            TextVR6.Text = valor(5)
            TextVR7.Text = valor(6)
            TextVR8.Text = valor(7)
            TextVR9.Text = valor(8)
            TextVR10.Text = valor(9)
            TextVR11.Text = valor(10)

            TextDM1.Text = 0.07
            TextDM2.Text = 0.07
            TextDM3.Text = 0.07
            TextDM4.Text = 0.07
            TextDM5.Text = 0.07
            TextDM6.Text = 0.07
            TextDM7.Text = 0.07
            TextDM8.Text = 0.07
            TextDM9.Text = 0.07
            TextDM10.Text = 0.07
            TextDM11.Text = 0.07

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
            TextVR1.Text = valor(0)
            TextVR2.Text = valor(1)
            TextVR3.Text = valor(2)
            TextVR4.Text = valor(3)
            TextVR5.Text = valor(4)
            TextVR6.Text = valor(5)
            TextVR7.Text = valor(6)
            TextVR8.Text = valor(7)
            TextVR9.Text = valor(8)
            TextVR10.Text = valor(9)
            TextVR11.Text = valor(10)

            TextDM1.Text = 0.1
            TextDM2.Text = 0.1
            TextDM3.Text = 0.1
            TextDM4.Text = 0.1
            TextDM5.Text = 0.1
            TextDM6.Text = 0.1
            TextDM7.Text = 0.1
            TextDM8.Text = 0.1
            TextDM9.Text = 0.1
            TextDM10.Text = 0.1
            TextDM11.Text = 0.1

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
            TextVR1.Text = valor(0)
            TextVR2.Text = valor(1)
            TextVR3.Text = valor(2)
            TextVR4.Text = valor(3)
            TextVR5.Text = valor(4)
            TextVR6.Text = valor(5)
            TextVR7.Text = valor(6)
            TextVR8.Text = valor(7)
            TextVR9.Text = valor(8)
            TextVR10.Text = valor(9)
            TextVR11.Text = valor(10)

            TextDM1.Text = 5
            TextDM2.Text = 5
            TextDM3.Text = 5
            TextDM4.Text = 5
            TextDM5.Text = 5
            TextDM6.Text = 5
            TextDM7.Text = 5
            TextDM8.Text = 5
            TextDM9.Text = 5
            TextDM10.Text = 5
            TextDM11.Text = 5

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
            TextVR1.Text = valor(0)
            TextVR2.Text = valor(1)
            TextVR3.Text = valor(2)
            TextVR4.Text = valor(3)
            TextVR5.Text = valor(4)
            TextVR6.Text = valor(5)
            TextVR7.Text = valor(6)
            TextVR8.Text = valor(7)
            TextVR9.Text = valor(8)
            TextVR10.Text = valor(9)
            TextVR11.Text = valor(10)

            TextDM1.Text = 4
            TextDM2.Text = 4
            TextDM3.Text = 4
            TextDM4.Text = 4
            TextDM5.Text = 4
            TextDM6.Text = 4
            TextDM7.Text = 4
            TextDM8.Text = 4
            TextDM9.Text = 4
            TextDM10.Text = 4
            TextDM11.Text = 4

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
            TextVR1.Text = valor(0)
            TextVR2.Text = valor(1)
            TextVR3.Text = valor(2)
            TextVR4.Text = valor(3)
            TextVR5.Text = valor(4)
            TextVR6.Text = valor(5)
            TextVR7.Text = valor(6)
            TextVR8.Text = valor(7)
            TextVR9.Text = valor(8)
            TextVR10.Text = valor(9)
            TextVR11.Text = valor(10)

            TextDM1.Text = 0.07
            TextDM2.Text = 0.07
            TextDM3.Text = 0.07
            TextDM4.Text = 0.07
            TextDM5.Text = 0.07
            TextDM6.Text = 0.07
            TextDM7.Text = 0.07
            TextDM8.Text = 0.07
            TextDM9.Text = 0.07
            TextDM10.Text = 0.07
            TextDM11.Text = 0.07

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
            TextVR1.Text = valor(0)
            TextVR2.Text = valor(1)
            TextVR3.Text = valor(2)
            TextVR4.Text = valor(3)
            TextVR5.Text = valor(4)
            TextVR6.Text = valor(5)
            TextVR7.Text = valor(6)
            TextVR8.Text = valor(7)
            TextVR9.Text = valor(8)
            TextVR10.Text = valor(9)
            TextVR11.Text = valor(10)

            TextDM1.Text = 0.07
            TextDM2.Text = 0.07
            TextDM3.Text = 0.07
            TextDM4.Text = 0.07
            TextDM5.Text = 0.07
            TextDM6.Text = 0.07
            TextDM7.Text = 0.07
            TextDM8.Text = 0.07
            TextDM9.Text = 0.07
            TextDM10.Text = 0.07
            TextDM11.Text = 0.07

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
            TextVR1.Text = valor(0)
            TextVR2.Text = valor(1)
            TextVR3.Text = valor(2)
            TextVR4.Text = valor(3)
            TextVR5.Text = valor(4)
            TextVR6.Text = valor(5)
            TextVR7.Text = valor(6)
            TextVR8.Text = valor(7)
            TextVR9.Text = valor(8)
            TextVR10.Text = valor(9)
            TextVR11.Text = valor(10)

            TextDM1.Text = 0.03
            TextDM2.Text = 0.03
            TextDM3.Text = 0.03
            TextDM4.Text = 0.03
            TextDM5.Text = 0.03
            TextDM6.Text = 0.03
            TextDM7.Text = 0.03
            TextDM8.Text = 0.03
            TextDM9.Text = 0.03
            TextDM10.Text = 0.03
            TextDM11.Text = 0.03

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
            TextVR1.Text = valor(0)
            TextVR2.Text = valor(1)
            TextVR3.Text = valor(2)
            TextVR4.Text = valor(3)
            TextVR5.Text = valor(4)
            TextVR6.Text = valor(5)
            TextVR7.Text = valor(6)
            TextVR8.Text = valor(7)
            TextVR9.Text = valor(8)
            TextVR10.Text = valor(9)
            TextVR11.Text = valor(10)

            TextDM1.Text = 0.05
            TextDM2.Text = 0.05
            TextDM3.Text = 0.05
            TextDM4.Text = 0.05
            TextDM5.Text = 0.05
            TextDM6.Text = 0.05
            TextDM7.Text = 0.05
            TextDM8.Text = 0.05
            TextDM9.Text = 0.05
            TextDM10.Text = 0.05
            TextDM11.Text = 0.05

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
            TextVR1.Text = valor(0)
            TextVR2.Text = valor(1)
            TextVR3.Text = valor(2)
            TextVR4.Text = valor(3)
            TextVR5.Text = valor(4)
            TextVR6.Text = valor(5)
            TextVR7.Text = valor(6)
            TextVR8.Text = valor(7)
            TextVR9.Text = valor(8)
            TextVR10.Text = valor(9)
            TextVR11.Text = valor(10)

            TextDM1.Text = 0.01
            TextDM2.Text = 0.01
            TextDM3.Text = 0.01
            TextDM4.Text = 0.01
            TextDM5.Text = 0.01
            TextDM6.Text = 0.01
            TextDM7.Text = 0.01
            TextDM8.Text = 0.01
            TextDM9.Text = 0.01
            TextDM10.Text = 0.01
            TextDM11.Text = 0.01

        End If
    End Sub
    Private Sub limpiar()
        TextL1.Text = ""
        TextL2.Text = ""
        TextL3.Text = ""
        TextL4.Text = ""
        TextL5.Text = ""
        TextL6.Text = ""
        TextL7.Text = ""
        TextL8.Text = ""
        TextL9.Text = ""
        TextL10.Text = ""
        TextL11.Text = ""

        TextD1.Text = ""
        TextD2.Text = ""
        TextD3.Text = ""
        TextD4.Text = ""
        TextD5.Text = ""
        TextD6.Text = ""
        TextD7.Text = ""
        TextD8.Text = ""
        TextD9.Text = ""
        TextD10.Text = ""
        TextD11.Text = ""

        TextDM1.Text = ""
        TextDM2.Text = ""
        TextDM3.Text = ""
        TextDM4.Text = ""
        TextDM5.Text = ""
        TextDM6.Text = ""
        TextDM7.Text = ""
        TextDM8.Text = ""
        TextDM9.Text = ""
        TextDM10.Text = ""
        TextDM11.Text = ""

        TextP1.Text = ""
        TextP2.Text = ""
        TextP3.Text = ""
        TextP4.Text = ""
        TextP5.Text = ""
        TextP6.Text = ""
        TextP7.Text = ""
        TextP8.Text = ""
        TextP9.Text = ""
        TextP10.Text = ""
        TextP11.Text = ""

        TextR1.BackColor = Color.Green
        TextR2.BackColor = Color.Green
        TextR3.BackColor = Color.Green
        TextR4.BackColor = Color.Green
        TextR5.BackColor = Color.Green
        TextR6.BackColor = Color.Green
        TextR7.BackColor = Color.Green
        TextR8.BackColor = Color.Green
        TextR9.BackColor = Color.Green
        TextR10.BackColor = Color.Green
        TextR11.BackColor = Color.Green


    End Sub
    Private Sub limpiar2()
        TextVR1.Text = ""
        TextVR2.Text = ""
        TextVR3.Text = ""
        TextVR4.Text = ""
        TextVR5.Text = ""
        TextVR6.Text = ""
        TextVR7.Text = ""
        TextVR8.Text = ""
        TextVR9.Text = ""
        TextVR10.Text = ""
        TextVR11.Text = ""
    End Sub
    Private Sub ButtonValorReferencia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonValorReferencia.Click

        Dim v As New FormValorReferencia(Usuario)
        v.ShowDialog()
        RadioCelulas.Checked = True
        cargarlista()
    End Sub

    Private Sub RadioCelulas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioCelulas.CheckedChanged
        cargarlista()
    End Sub

    Private Sub RadioGrasa_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioGrasa.CheckedChanged
        cargarlista()
    End Sub

    Private Sub RadioProteina_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioProteina.CheckedChanged
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

    Private Sub ButtonNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo.Click
        limpiar()
        RadioCelulas.Checked = True
        cargarlista()
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        guardar()
    End Sub
    Private Sub guardar()
        Dim fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        Dim fec As String
        fec = Format(fecha, "yyyy-MM-dd")
        Dim operador As String = TextOperador.Text.Trim
        If ComboEquipo.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el equipo", MsgBoxStyle.Exclamation, "Atención") : ComboEquipo.Focus() : Exit Sub
        Dim equipo As String = ComboEquipo.Text
        Dim item As String = ""
        Dim resultado As String = ""
        Dim pasada As Integer = 0
        If RadioPasada1.Checked = True Then
            pasada = 1
        Else
            pasada = 2
        End If
        Dim r1 As Double = 0
        Dim r2 As Double = 0
        Dim r3 As Double = 0
        Dim r4 As Double = 0
        If RadioCelulas.Checked = True Then
            item = "celulas"
        ElseIf RadioGrasa.Checked = True Then
            item = "grasa"
        ElseIf RadioProteina.Checked = True Then
            item = "proteina"
        ElseIf RadioLactosa.Checked = True Then
            item = "lactosa"
        ElseIf RadioST.Checked = True Then
            item = "st"
        ElseIf RadioCrioscopia.Checked = True Then
            item = "crioscopia"
        ElseIf RadioUrea.Checked = True Then
            item = "urea"
        ElseIf RadioProteinaV.Checked = True Then
            item = "proteinav"
        ElseIf RadioCaseina.Checked = True Then
            item = "caseina"
        ElseIf RadioDensidad.Checked = True Then
            item = "densidad"
        ElseIf RadioPH.Checked = True Then
            item = "ph"
        ElseIf RadioCitratos.Checked = True Then
            item = "citratos"
        End If
        '**************************************************************************
        If TextL1.TextLength > 0 Then
            r1 = Val(TextDM1.Text)
            r2 = Val(TextDM1.Text) * 2
            r3 = Val(TextDM1.Text) * -1
            r4 = Val(TextDM1.Text) * -2


            Dim mr As New dMaterialReferencia()
            mr.FECHA = fec
            mr.OPERADOR = operador
            mr.EQUIPO = equipo
            mr.ITEM = item
            mr.LECTURA = Val(TextL1.Text.Trim)
            mr.VALORREF = Val(TextVR1.Text.Trim)
            mr.DIFERENCIA = Val(TextD1.Text.Trim)
            mr.DIFERENCIAREAL = Val(TextDR1.Text.Trim)
            mr.DIFMAXPERMITIDA = Val(TextDM1.Text.Trim)
            If Val(TextD1.Text) > r1 Or Val(TextD1.Text) < r3 Then
                resultado = "a"
            Else
                resultado = "v"
            End If
            If Val(TextD1.Text) > r2 Or Val(TextD1.Text) < r4 Then
                resultado = "r"
            End If
            mr.RESULTADO = resultado
            mr.PASADA = pasada
            If (mr.guardar(Usuario)) Then
                'MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                'limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        '**************************************************************************

        If TextL2.TextLength > 0 Then
            r1 = Val(TextDM2.Text)
            r2 = Val(TextDM2.Text) * 2
            r3 = Val(TextDM2.Text) * -1
            r4 = Val(TextDM2.Text) * -2


            Dim mr As New dMaterialReferencia()
            mr.FECHA = fec
            mr.OPERADOR = operador
            mr.EQUIPO = equipo
            mr.ITEM = item
            mr.LECTURA = Val(TextL2.Text.Trim)
            mr.VALORREF = Val(TextVR2.Text.Trim)
            mr.DIFERENCIA = Val(TextD2.Text.Trim)
            mr.DIFERENCIAREAL = Val(TextDR2.Text.Trim)
            mr.DIFMAXPERMITIDA = Val(TextDM2.Text.Trim)
            If Val(TextD2.Text) > r1 Or Val(TextD2.Text) < r3 Then
                resultado = "a"
            Else
                resultado = "v"
            End If
            If Val(TextD2.Text) > r2 Or Val(TextD2.Text) < r4 Then
                resultado = "r"
            End If
            mr.RESULTADO = resultado
            mr.PASADA = pasada
            If (mr.guardar(Usuario)) Then
                'MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                'limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        '**************************************************************************
        If TextL3.TextLength > 0 Then
            r1 = Val(TextDM3.Text)
            r2 = Val(TextDM3.Text) * 2
            r3 = Val(TextDM3.Text) * -1
            r4 = Val(TextDM3.Text) * -2


            Dim mr As New dMaterialReferencia()
            mr.FECHA = fec
            mr.OPERADOR = operador
            mr.EQUIPO = equipo
            mr.ITEM = item
            mr.LECTURA = Val(TextL3.Text.Trim)
            mr.VALORREF = Val(TextVR3.Text.Trim)
            mr.DIFERENCIA = Val(TextD3.Text.Trim)
            mr.DIFERENCIAREAL = Val(TextDR3.Text.Trim)
            mr.DIFMAXPERMITIDA = Val(TextDM3.Text.Trim)
            If Val(TextD3.Text) > r1 Or Val(TextD3.Text) < r3 Then
                resultado = "a"
            Else
                resultado = "v"
            End If
            If Val(TextD3.Text) > r2 Or Val(TextD3.Text) < r4 Then
                resultado = "r"
            End If
            mr.RESULTADO = resultado
            mr.PASADA = pasada
            If (mr.guardar(Usuario)) Then
                'MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                'limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        '**************************************************************************
        If TextL4.TextLength > 0 Then
            r1 = Val(TextDM4.Text)
            r2 = Val(TextDM4.Text) * 2
            r3 = Val(TextDM4.Text) * -1
            r4 = Val(TextDM4.Text) * -2


            Dim mr As New dMaterialReferencia()
            mr.FECHA = fec
            mr.OPERADOR = operador
            mr.EQUIPO = equipo
            mr.ITEM = item
            mr.LECTURA = Val(TextL4.Text.Trim)
            mr.VALORREF = Val(TextVR4.Text.Trim)
            mr.DIFERENCIA = Val(TextD4.Text.Trim)
            mr.DIFERENCIAREAL = Val(TextDR4.Text.Trim)
            mr.DIFMAXPERMITIDA = Val(TextDM4.Text.Trim)
            If Val(TextD4.Text) > r1 Or Val(TextD4.Text) < r3 Then
                resultado = "a"
            Else
                resultado = "v"
            End If
            If Val(TextD4.Text) > r2 Or Val(TextD4.Text) < r4 Then
                resultado = "r"
            End If
            mr.RESULTADO = resultado
            mr.PASADA = pasada
            If (mr.guardar(Usuario)) Then
                'MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                'limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        '**************************************************************************
        If TextL5.TextLength > 0 Then
            r1 = Val(TextDM5.Text)
            r2 = Val(TextDM5.Text) * 2
            r3 = Val(TextDM5.Text) * -1
            r4 = Val(TextDM5.Text) * -2


            Dim mr As New dMaterialReferencia()
            mr.FECHA = fec
            mr.OPERADOR = operador
            mr.EQUIPO = equipo
            mr.ITEM = item
            mr.LECTURA = Val(TextL5.Text.Trim)
            mr.VALORREF = Val(TextVR5.Text.Trim)
            mr.DIFERENCIA = Val(TextD5.Text.Trim)
            mr.DIFERENCIAREAL = Val(TextDR5.Text.Trim)
            mr.DIFMAXPERMITIDA = Val(TextDM5.Text.Trim)
            If Val(TextD5.Text) > r1 Or Val(TextD5.Text) < r3 Then
                resultado = "a"
            Else
                resultado = "v"
            End If
            If Val(TextD5.Text) > r2 Or Val(TextD5.Text) < r4 Then
                resultado = "r"
            End If
            mr.RESULTADO = resultado
            mr.PASADA = pasada
            If (mr.guardar(Usuario)) Then
                'MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                'limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        '**************************************************************************
        If TextL6.TextLength > 0 Then
            r1 = Val(TextDM6.Text)
            r2 = Val(TextDM6.Text) * 2
            r3 = Val(TextDM6.Text) * -1
            r4 = Val(TextDM6.Text) * -2


            Dim mr As New dMaterialReferencia()
            mr.FECHA = fec
            mr.OPERADOR = operador
            mr.EQUIPO = equipo
            mr.ITEM = item
            mr.LECTURA = Val(TextL6.Text.Trim)
            mr.VALORREF = Val(TextVR6.Text.Trim)
            mr.DIFERENCIA = Val(TextD6.Text.Trim)
            mr.DIFERENCIAREAL = Val(TextDR6.Text.Trim)
            mr.DIFMAXPERMITIDA = Val(TextDM6.Text.Trim)
            If Val(TextD6.Text) > r1 Or Val(TextD6.Text) < r3 Then
                resultado = "a"
            Else
                resultado = "v"
            End If
            If Val(TextD6.Text) > r2 Or Val(TextD6.Text) < r4 Then
                resultado = "r"
            End If
            mr.RESULTADO = resultado
            mr.PASADA = pasada
            If (mr.guardar(Usuario)) Then
                'MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                'limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        '**************************************************************************
        If TextL7.TextLength > 0 Then
            r1 = Val(TextDM7.Text)
            r2 = Val(TextDM7.Text) * 2
            r3 = Val(TextDM7.Text) * -1
            r4 = Val(TextDM7.Text) * -2


            Dim mr As New dMaterialReferencia()
            mr.FECHA = fec
            mr.OPERADOR = operador
            mr.EQUIPO = equipo
            mr.ITEM = item
            mr.LECTURA = Val(TextL7.Text.Trim)
            mr.VALORREF = Val(TextVR7.Text.Trim)
            mr.DIFERENCIA = Val(TextD7.Text.Trim)
            mr.DIFERENCIAREAL = Val(TextDR7.Text.Trim)
            mr.DIFMAXPERMITIDA = Val(TextDM7.Text.Trim)
            If Val(TextD7.Text) > r1 Or Val(TextD7.Text) < r3 Then
                resultado = "a"
            Else
                resultado = "v"
            End If
            If Val(TextD7.Text) > r2 Or Val(TextD7.Text) < r4 Then
                resultado = "r"
            End If
            mr.RESULTADO = resultado
            mr.PASADA = pasada
            If (mr.guardar(Usuario)) Then
                'MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                'limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        '**************************************************************************
        If TextL8.TextLength > 0 Then
            r1 = Val(TextDM8.Text)
            r2 = Val(TextDM8.Text) * 2
            r3 = Val(TextDM8.Text) * -1
            r4 = Val(TextDM8.Text) * -2


            Dim mr As New dMaterialReferencia()
            mr.FECHA = fec
            mr.OPERADOR = operador
            mr.EQUIPO = equipo
            mr.ITEM = item
            mr.LECTURA = Val(TextL8.Text.Trim)
            mr.VALORREF = Val(TextVR8.Text.Trim)
            mr.DIFERENCIA = Val(TextD8.Text.Trim)
            mr.DIFERENCIAREAL = Val(TextDR8.Text.Trim)
            mr.DIFMAXPERMITIDA = Val(TextDM8.Text.Trim)
            If Val(TextD8.Text) > r1 Or Val(TextD8.Text) < r3 Then
                resultado = "a"
            Else
                resultado = "v"
            End If
            If Val(TextD8.Text) > r2 Or Val(TextD8.Text) < r4 Then
                resultado = "r"
            End If
            mr.RESULTADO = resultado
            mr.PASADA = pasada
            If (mr.guardar(Usuario)) Then
                'MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                'limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        '**************************************************************************
        If TextL9.TextLength > 0 Then
            r1 = Val(TextDM9.Text)
            r2 = Val(TextDM9.Text) * 2
            r3 = Val(TextDM9.Text) * -1
            r4 = Val(TextDM9.Text) * -2


            Dim mr As New dMaterialReferencia()
            mr.FECHA = fec
            mr.OPERADOR = operador
            mr.EQUIPO = equipo
            mr.ITEM = item
            mr.LECTURA = Val(TextL9.Text.Trim)
            mr.VALORREF = Val(TextVR9.Text.Trim)
            mr.DIFERENCIA = Val(TextD9.Text.Trim)
            mr.DIFERENCIAREAL = Val(TextDR9.Text.Trim)
            mr.DIFMAXPERMITIDA = Val(TextDM9.Text.Trim)
            If Val(TextD9.Text) > r1 Or Val(TextD9.Text) < r3 Then
                resultado = "a"
            Else
                resultado = "v"
            End If
            If Val(TextD9.Text) > r2 Or Val(TextD9.Text) < r4 Then
                resultado = "r"
            End If
            mr.RESULTADO = resultado
            mr.PASADA = pasada
            If (mr.guardar(Usuario)) Then
                'MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                'limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        '**************************************************************************
        If TextL10.TextLength > 0 Then
            r1 = Val(TextDM10.Text)
            r2 = Val(TextDM10.Text) * 2
            r3 = Val(TextDM10.Text) * -1
            r4 = Val(TextDM10.Text) * -2


            Dim mr As New dMaterialReferencia()
            mr.FECHA = fec
            mr.OPERADOR = operador
            mr.EQUIPO = equipo
            mr.ITEM = item
            mr.LECTURA = Val(TextL10.Text.Trim)
            mr.VALORREF = Val(TextVR10.Text.Trim)
            mr.DIFERENCIA = Val(TextD10.Text.Trim)
            mr.DIFERENCIAREAL = Val(TextDR10.Text.Trim)
            mr.DIFMAXPERMITIDA = Val(TextDM10.Text.Trim)
            If Val(TextD10.Text) > r1 Or Val(TextD10.Text) < r3 Then
                resultado = "a"
            Else
                resultado = "v"
            End If
            If Val(TextD10.Text) > r2 Or Val(TextD10.Text) < r4 Then
                resultado = "r"
            End If
            mr.RESULTADO = resultado
            mr.PASADA = pasada
            If (mr.guardar(Usuario)) Then
                'MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                'limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        '**************************************************************************
        If TextL11.TextLength > 0 Then
            r1 = Val(TextDM11.Text)
            r2 = Val(TextDM11.Text) * 2
            r3 = Val(TextDM11.Text) * -1
            r4 = Val(TextDM11.Text) * -2


            Dim mr As New dMaterialReferencia()
            mr.FECHA = fec
            mr.OPERADOR = operador
            mr.EQUIPO = equipo
            mr.ITEM = item
            mr.LECTURA = Val(TextL11.Text.Trim)
            mr.VALORREF = Val(TextVR11.Text.Trim)
            mr.DIFERENCIA = Val(TextD11.Text.Trim)
            mr.DIFERENCIAREAL = Val(TextDR11.Text.Trim)
            mr.DIFMAXPERMITIDA = Val(TextDM11.Text.Trim)
            If Val(TextD11.Text) > r1 Or Val(TextD11.Text) < r3 Then
                resultado = "a"
            Else
                resultado = "v"
            End If
            If Val(TextD11.Text) > r2 Or Val(TextD11.Text) < r4 Then
                resultado = "r"
            End If
            mr.RESULTADO = resultado
            mr.PASADA = pasada
            If (mr.guardar(Usuario)) Then
                'MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                'limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If

        '** GUARDAR MEDIAS (Diferencia absoluta)  ************************************************************************
        Dim mrm As New dMaterialReferenciaMedias
        mrm.FECHA = fec
        mrm.OPERADOR = operador
        mrm.EQUIPO = equipo
        mrm.ITEM = item
        mrm.LECTURA = Val(TextDPromedio2.Text.Trim)
        mrm.PASADA = pasada
        If (mrm.guardar(Usuario)) Then
            'MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
            'limpiar()
        Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
        End If

        '*******************************************************************************


        '** GUARDAR PROMEDIO  ************************************************************************
        'Dim mr As New dMaterialReferencia()
        'mr.FECHA = fec
        'mr.OPERADOR = operador
        'mr.EQUIPO = equipo
        'mr.ITEM = item
        'mr.LECTURA = Val(TextL1.Text.Trim)
        'mr.VALORREF = Val(TextVR1.Text.Trim)
        'mr.DIFERENCIA = Val(TextD1.Text.Trim)
        'If Val(TextD1.Text) > r1 Or Val(TextD1.Text) < r3 Then
        '    resultado = "a"
        'Else
        '    resultado = "v"
        'End If
        'If Val(TextD1.Text) > r2 Or Val(TextD1.Text) < r4 Then
        '    resultado = "r"
        'End If
        'mr.RESULTADO = resultado
        'If (mr.guardar(Usuario)) Then
        '    'MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
        '    'limpiar()
        'Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
        'End If

        '*******************************************************************************

        limpiar()
        RadioCelulas.Checked = True
        cargarlista()
    End Sub
    Private Sub calculos()
        Dim promedio As Double = 0
        Dim promedio2 As Double = 0
        Dim valor1 As Double = 0
        Dim valor2 As Double = 0
        Dim valor3 As Double = 0
        Dim valor4 As Double = 0
        Dim difreal As Double = 0
        If RadioCelulas.Checked = True Then
            If TextL1.Text.Length > 0 And TextVR1.Text.Length > 0 Then
                Dim difmax As Double = 0
                If Val(TextVR1.Text) <= 150 Then
                    difmax = 25
                End If
                If Val(TextVR1.Text) > 150 And Val(TextVR1.Text) <= 300 Then
                    difmax = 42
                End If
                If Val(TextVR1.Text) > 300 And Val(TextVR1.Text) <= 450 Then
                    difmax = 50
                End If
                If Val(TextVR1.Text) > 450 And Val(TextVR1.Text) <= 750 Then
                    difmax = 63
                End If
                If Val(TextVR1.Text) > 750 Then
                    difmax = 126
                End If
                TextDM1.Text = difmax
                TextD1.Text = Math.Round(Val(TextVR1.Text) - Val(TextL1.Text), 3)
                TextP1.Text = Math.Round((Val(TextL1.Text) + Val(TextVR1.Text)) / 2, 3)
                If Val(TextD1.Text) <= Val(TextDM1.Text) Then
                    TextR1.BackColor = Color.Green
                End If
                If Val(TextD1.Text) >= Val(TextDM1.Text) * -1 Then
                    TextR1.BackColor = Color.Green
                End If
                If Val(TextD1.Text) > Val(TextDM1.Text) Then
                    TextR1.BackColor = Color.Yellow
                End If
                If Val(TextD1.Text) < Val(TextDM1.Text) * -1 Then
                    TextR1.BackColor = Color.Yellow
                End If
                If Val(TextD1.Text) > Val(TextDM1.Text) * 2 Then
                    TextR1.BackColor = Color.Red
                End If
                If Val(TextD1.Text) < Val(TextDM1.Text) * -2 Then
                    TextR1.BackColor = Color.Red
                End If
                difreal = Val(TextL1.Text) - Val(TextVR1.Text)
                TextDR1.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL2.Text.Length > 0 And TextVR2.Text.Length > 0 Then
                Dim difmax As Double = 0
                If Val(TextVR2.Text) <= 150 Then
                    difmax = 25
                End If
                If Val(TextVR2.Text) > 150 And Val(TextVR2.Text) <= 300 Then
                    difmax = 42
                End If
                If Val(TextVR2.Text) > 300 And Val(TextVR2.Text) <= 450 Then
                    difmax = 50
                End If
                If Val(TextVR2.Text) > 450 And Val(TextVR2.Text) <= 750 Then
                    difmax = 63
                End If
                If Val(TextVR2.Text) > 750 Then
                    difmax = 126
                End If
                TextDM2.Text = difmax
                TextD2.Text = Math.Round(Val(TextVR2.Text) - Val(TextL2.Text), 3)
                TextP2.Text = Math.Round((Val(TextL2.Text) + Val(TextVR2.Text)) / 2, 3)
                If Val(TextD2.Text) <= Val(TextDM2.Text) Then
                    TextR2.BackColor = Color.Green
                End If
                If Val(TextD2.Text) >= Val(TextDM2.Text) * -1 Then
                    TextR2.BackColor = Color.Green
                End If
                If Val(TextD2.Text) > Val(TextDM2.Text) Then
                    TextR2.BackColor = Color.Yellow
                End If
                If Val(TextD2.Text) < Val(TextDM2.Text) * -1 Then
                    TextR2.BackColor = Color.Yellow
                End If
                If Val(TextD2.Text) > Val(TextDM2.Text) * 2 Then
                    TextR2.BackColor = Color.Red
                End If
                If Val(TextD2.Text) < Val(TextDM2.Text) * -2 Then
                    TextR2.BackColor = Color.Red
                End If
                difreal = Val(TextL2.Text) - Val(TextVR2.Text)
                TextDR2.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL3.Text.Length > 0 And TextVR3.Text.Length > 0 Then
                Dim difmax As Double = 0
                If Val(TextVR3.Text) <= 150 Then
                    difmax = 25
                End If
                If Val(TextVR3.Text) > 150 And Val(TextVR3.Text) <= 300 Then
                    difmax = 42
                End If
                If Val(TextVR3.Text) > 300 And Val(TextVR3.Text) <= 450 Then
                    difmax = 50
                End If
                If Val(TextVR3.Text) > 450 And Val(TextVR3.Text) <= 750 Then
                    difmax = 63
                End If
                If Val(TextVR3.Text) > 750 Then
                    difmax = 126
                End If
                TextDM3.Text = difmax
                TextD3.Text = Math.Round(Val(TextVR3.Text) - Val(TextL3.Text), 3)
                TextP3.Text = Math.Round((Val(TextL3.Text) + Val(TextVR3.Text)) / 2, 3)
                If Val(TextD3.Text) <= Val(TextDM3.Text) Then
                    TextR3.BackColor = Color.Green
                End If
                If Val(TextD3.Text) >= Val(TextDM3.Text) * -1 Then
                    TextR3.BackColor = Color.Green
                End If
                If Val(TextD3.Text) > Val(TextDM3.Text) Then
                    TextR3.BackColor = Color.Yellow
                End If
                If Val(TextD3.Text) < Val(TextDM3.Text) * -1 Then
                    TextR3.BackColor = Color.Yellow
                End If
                If Val(TextD3.Text) > Val(TextDM3.Text) * 2 Then
                    TextR3.BackColor = Color.Red
                End If
                If Val(TextD3.Text) < Val(TextDM3.Text) * -2 Then
                    TextR3.BackColor = Color.Red
                End If
                difreal = Val(TextL3.Text) - Val(TextVR3.Text)
                TextDR3.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL4.Text.Length > 0 And TextVR4.Text.Length > 0 Then
                Dim difmax As Double = 0
                If Val(TextVR4.Text) <= 150 Then
                    difmax = 25
                End If
                If Val(TextVR4.Text) > 150 And Val(TextVR4.Text) <= 300 Then
                    difmax = 42
                End If
                If Val(TextVR4.Text) > 300 And Val(TextVR4.Text) <= 450 Then
                    difmax = 50
                End If
                If Val(TextVR4.Text) > 450 And Val(TextVR4.Text) <= 750 Then
                    difmax = 63
                End If
                If Val(TextVR4.Text) > 750 Then
                    difmax = 126
                End If
                TextDM4.Text = difmax
                TextD4.Text = Math.Round(Val(TextVR4.Text) - Val(TextL4.Text), 3)
                TextP4.Text = Math.Round((Val(TextL4.Text) + Val(TextVR4.Text)) / 2, 3)
                If Val(TextD4.Text) <= Val(TextDM4.Text) Then
                    TextR4.BackColor = Color.Green
                End If
                If Val(TextD4.Text) >= Val(TextDM4.Text) * -1 Then
                    TextR4.BackColor = Color.Green
                End If
                If Val(TextD4.Text) > Val(TextDM4.Text) Then
                    TextR4.BackColor = Color.Yellow
                End If
                If Val(TextD4.Text) < Val(TextDM4.Text) * -1 Then
                    TextR4.BackColor = Color.Yellow
                End If
                If Val(TextD4.Text) > Val(TextDM4.Text) * 2 Then
                    TextR4.BackColor = Color.Red
                End If
                If Val(TextD4.Text) < Val(TextDM4.Text) * -2 Then
                    TextR4.BackColor = Color.Red
                End If
                difreal = Val(TextL4.Text) - Val(TextVR4.Text)
                TextDR4.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL5.Text.Length > 0 And TextVR5.Text.Length > 0 Then
                Dim difmax As Double = 0
                If Val(TextVR5.Text) <= 150 Then
                    difmax = 25
                End If
                If Val(TextVR5.Text) > 150 And Val(TextVR5.Text) <= 300 Then
                    difmax = 42
                End If
                If Val(TextVR5.Text) > 300 And Val(TextVR5.Text) <= 450 Then
                    difmax = 50
                End If
                If Val(TextVR5.Text) > 450 And Val(TextVR5.Text) <= 750 Then
                    difmax = 63
                End If
                If Val(TextVR5.Text) > 750 Then
                    difmax = 126
                End If
                TextDM5.Text = difmax
                TextD5.Text = Math.Round(Val(TextVR5.Text) - Val(TextL5.Text), 3)
                TextP5.Text = Math.Round((Val(TextL5.Text) + Val(TextVR5.Text)) / 2, 3)
                If Val(TextD5.Text) <= Val(TextDM5.Text) Then
                    TextR5.BackColor = Color.Green
                End If
                If Val(TextD5.Text) >= Val(TextDM5.Text) * -1 Then
                    TextR5.BackColor = Color.Green
                End If
                If Val(TextD5.Text) > Val(TextDM5.Text) Then
                    TextR5.BackColor = Color.Yellow
                End If
                If Val(TextD5.Text) < Val(TextDM5.Text) * -1 Then
                    TextR5.BackColor = Color.Yellow
                End If
                If Val(TextD5.Text) > Val(TextDM5.Text) * 2 Then
                    TextR5.BackColor = Color.Red
                End If
                If Val(TextD5.Text) < Val(TextDM5.Text) * -2 Then
                    TextR5.BackColor = Color.Red
                End If
                difreal = Val(TextL5.Text) - Val(TextVR5.Text)
                TextDR5.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL6.Text.Length > 0 And TextVR6.Text.Length > 0 Then
                Dim difmax As Double = 0
                If Val(TextVR6.Text) <= 150 Then
                    difmax = 25
                End If
                If Val(TextVR6.Text) > 150 And Val(TextVR6.Text) <= 300 Then
                    difmax = 42
                End If
                If Val(TextVR6.Text) > 300 And Val(TextVR6.Text) <= 450 Then
                    difmax = 50
                End If
                If Val(TextVR6.Text) > 450 And Val(TextVR6.Text) <= 750 Then
                    difmax = 63
                End If
                If Val(TextVR6.Text) > 750 Then
                    difmax = 126
                End If
                TextDM6.Text = difmax
                TextD6.Text = Math.Round(Val(TextVR6.Text) - Val(TextL6.Text), 3)
                TextP6.Text = Math.Round((Val(TextL6.Text) + Val(TextVR6.Text)) / 2, 3)
                If Val(TextD6.Text) <= Val(TextDM6.Text) Then
                    TextR6.BackColor = Color.Green
                End If
                If Val(TextD6.Text) >= Val(TextDM6.Text) * -1 Then
                    TextR6.BackColor = Color.Green
                End If
                If Val(TextD6.Text) > Val(TextDM6.Text) Then
                    TextR6.BackColor = Color.Yellow
                End If
                If Val(TextD6.Text) < Val(TextDM6.Text) * -1 Then
                    TextR6.BackColor = Color.Yellow
                End If
                If Val(TextD6.Text) > Val(TextDM6.Text) * 2 Then
                    TextR6.BackColor = Color.Red
                End If
                If Val(TextD6.Text) < Val(TextDM6.Text) * -2 Then
                    TextR6.BackColor = Color.Red
                End If
                difreal = Val(TextL6.Text) - Val(TextVR6.Text)
                TextDR6.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL7.Text.Length > 0 And TextVR7.Text.Length > 0 Then
                Dim difmax As Double = 0
                If Val(TextVR7.Text) <= 150 Then
                    difmax = 25
                End If
                If Val(TextVR7.Text) > 150 And Val(TextVR7.Text) <= 300 Then
                    difmax = 42
                End If
                If Val(TextVR7.Text) > 300 And Val(TextVR7.Text) <= 450 Then
                    difmax = 50
                End If
                If Val(TextVR7.Text) > 450 And Val(TextVR7.Text) <= 750 Then
                    difmax = 63
                End If
                If Val(TextVR7.Text) > 750 Then
                    difmax = 126
                End If
                TextDM7.Text = difmax
                TextD7.Text = Math.Round(Val(TextVR7.Text) - Val(TextL7.Text), 3)
                TextP7.Text = Math.Round((Val(TextL7.Text) + Val(TextVR7.Text)) / 2, 3)
                If Val(TextD7.Text) <= Val(TextDM7.Text) Then
                    TextR7.BackColor = Color.Green
                End If
                If Val(TextD7.Text) >= Val(TextDM7.Text) * -1 Then
                    TextR7.BackColor = Color.Green
                End If
                If Val(TextD7.Text) > Val(TextDM7.Text) Then
                    TextR7.BackColor = Color.Yellow
                End If
                If Val(TextD7.Text) < Val(TextDM7.Text) * -1 Then
                    TextR7.BackColor = Color.Yellow
                End If
                If Val(TextD7.Text) > Val(TextDM7.Text) * 2 Then
                    TextR7.BackColor = Color.Red
                End If
                If Val(TextD7.Text) < Val(TextDM7.Text) * -2 Then
                    TextR7.BackColor = Color.Red
                End If
                difreal = Val(TextL7.Text) - Val(TextVR7.Text)
                TextDR7.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL8.Text.Length > 0 And TextVR8.Text.Length > 0 Then
                Dim difmax As Double = 0
                If Val(TextVR8.Text) <= 150 Then
                    difmax = 25
                End If
                If Val(TextVR8.Text) > 150 And Val(TextVR8.Text) <= 300 Then
                    difmax = 42
                End If
                If Val(TextVR8.Text) > 300 And Val(TextVR8.Text) <= 450 Then
                    difmax = 50
                End If
                If Val(TextVR8.Text) > 450 And Val(TextVR8.Text) <= 750 Then
                    difmax = 63
                End If
                If Val(TextVR8.Text) > 750 Then
                    difmax = 126
                End If
                TextDM8.Text = difmax
                TextD8.Text = Math.Round(Val(TextVR8.Text) - Val(TextL8.Text), 3)
                TextP8.Text = Math.Round((Val(TextL8.Text) + Val(TextVR8.Text)) / 2, 3)
                If Val(TextD8.Text) <= Val(TextDM8.Text) Then
                    TextR8.BackColor = Color.Green
                End If
                If Val(TextD8.Text) >= Val(TextDM8.Text) * -1 Then
                    TextR8.BackColor = Color.Green
                End If
                If Val(TextD8.Text) > Val(TextDM8.Text) Then
                    TextR8.BackColor = Color.Yellow
                End If
                If Val(TextD8.Text) < Val(TextDM8.Text) * -1 Then
                    TextR8.BackColor = Color.Yellow
                End If
                If Val(TextD8.Text) > Val(TextDM8.Text) * 2 Then
                    TextR8.BackColor = Color.Red
                End If
                If Val(TextD8.Text) < Val(TextDM8.Text) * -2 Then
                    TextR8.BackColor = Color.Red
                End If
                difreal = Val(TextL8.Text) - Val(TextVR8.Text)
                TextDR8.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL9.Text.Length > 0 And TextVR9.Text.Length > 0 Then
                Dim difmax As Double = 0
                If Val(TextVR9.Text) <= 150 Then
                    difmax = 25
                End If
                If Val(TextVR9.Text) > 150 And Val(TextVR9.Text) <= 300 Then
                    difmax = 42
                End If
                If Val(TextVR9.Text) > 300 And Val(TextVR9.Text) <= 450 Then
                    difmax = 50
                End If
                If Val(TextVR9.Text) > 450 And Val(TextVR9.Text) <= 750 Then
                    difmax = 63
                End If
                If Val(TextVR9.Text) > 750 Then
                    difmax = 126
                End If
                TextDM9.Text = difmax
                TextD9.Text = Math.Round(Val(TextVR9.Text) - Val(TextL9.Text), 3)
                TextP9.Text = Math.Round((Val(TextL9.Text) + Val(TextVR9.Text)) / 2, 3)
                If Val(TextD9.Text) <= Val(TextDM9.Text) Then
                    TextR9.BackColor = Color.Green
                End If
                If Val(TextD9.Text) >= Val(TextDM9.Text) * -1 Then
                    TextR9.BackColor = Color.Green
                End If
                If Val(TextD9.Text) > Val(TextDM9.Text) Then
                    TextR9.BackColor = Color.Yellow
                End If
                If Val(TextD9.Text) < Val(TextDM9.Text) * -1 Then
                    TextR9.BackColor = Color.Yellow
                End If
                If Val(TextD9.Text) > Val(TextDM9.Text) * 2 Then
                    TextR9.BackColor = Color.Red
                End If
                If Val(TextD9.Text) < Val(TextDM9.Text) * -2 Then
                    TextR9.BackColor = Color.Red
                End If
                difreal = Val(TextL9.Text) - Val(TextVR9.Text)
                TextDR9.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL10.Text.Length > 0 And TextVR10.Text.Length > 0 Then
                Dim difmax As Double = 0
                If Val(TextVR10.Text) <= 150 Then
                    difmax = 25
                End If
                If Val(TextVR10.Text) > 150 And Val(TextVR10.Text) <= 300 Then
                    difmax = 42
                End If
                If Val(TextVR10.Text) > 300 And Val(TextVR10.Text) <= 450 Then
                    difmax = 50
                End If
                If Val(TextVR10.Text) > 450 And Val(TextVR10.Text) <= 750 Then
                    difmax = 63
                End If
                If Val(TextVR10.Text) > 750 Then
                    difmax = 126
                End If
                TextDM10.Text = difmax
                TextD10.Text = Math.Round(Val(TextVR10.Text) - Val(TextL10.Text), 3)
                TextP10.Text = Math.Round((Val(TextL10.Text) + Val(TextVR10.Text)) / 2, 3)
                If Val(TextD10.Text) <= Val(TextDM10.Text) Then
                    TextR10.BackColor = Color.Green
                End If
                If Val(TextD10.Text) >= Val(TextDM10.Text) * -1 Then
                    TextR10.BackColor = Color.Green
                End If
                If Val(TextD10.Text) > Val(TextDM10.Text) Then
                    TextR10.BackColor = Color.Yellow
                End If
                If Val(TextD10.Text) < Val(TextDM10.Text) * -1 Then
                    TextR10.BackColor = Color.Yellow
                End If
                If Val(TextD10.Text) > Val(TextDM10.Text) * 2 Then
                    TextR10.BackColor = Color.Red
                End If
                If Val(TextD10.Text) < Val(TextDM10.Text) * -2 Then
                    TextR10.BackColor = Color.Red
                End If
                difreal = Val(TextL10.Text) - Val(TextVR10.Text)
                TextDR10.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL11.Text.Length > 0 And TextVR11.Text.Length > 0 Then
                Dim difmax As Double = 0
                If Val(TextVR11.Text) <= 150 Then
                    difmax = 25
                End If
                If Val(TextVR11.Text) > 150 And Val(TextVR11.Text) <= 300 Then
                    difmax = 42
                End If
                If Val(TextVR11.Text) > 300 And Val(TextVR11.Text) <= 450 Then
                    difmax = 50
                End If
                If Val(TextVR11.Text) > 450 And Val(TextVR11.Text) <= 750 Then
                    difmax = 63
                End If
                If Val(TextVR11.Text) > 750 Then
                    difmax = 126
                End If
                TextDM11.Text = difmax
                TextD11.Text = Math.Round(Val(TextVR11.Text) - Val(TextL11.Text), 3)
                TextP11.Text = Math.Round((Val(TextL11.Text) + Val(TextVR11.Text)) / 2, 3)
                If Val(TextD11.Text) <= Val(TextDM11.Text) Then
                    TextR11.BackColor = Color.Green
                End If
                If Val(TextD11.Text) >= Val(TextDM11.Text) * -1 Then
                    TextR11.BackColor = Color.Green
                End If
                If Val(TextD11.Text) > Val(TextDM11.Text) Then
                    TextR11.BackColor = Color.Yellow
                End If
                If Val(TextD11.Text) < Val(TextDM11.Text) * -1 Then
                    TextR11.BackColor = Color.Yellow
                End If
                If Val(TextD11.Text) > Val(TextDM11.Text) * 2 Then
                    TextR11.BackColor = Color.Red
                End If
                If Val(TextD11.Text) < Val(TextDM11.Text) * -2 Then
                    TextR11.BackColor = Color.Red
                End If
                difreal = Val(TextL11.Text) - Val(TextVR11.Text)
                TextDR11.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
        ElseIf RadioGrasa.Checked = True Then
            If TextL1.Text.Length > 0 And TextVR1.Text.Length > 0 Then
                promedio = Val((TextL1.Text) + Val(TextVR1.Text)) / 2
                valor1 = Val(TextL1.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD1.Text = Math.Round(valor4, 3)
                TextP1.Text = Math.Round((Val(TextL1.Text) + Val(TextVR1.Text)) / 2, 3)
                If Val(TextD1.Text) <= Val(TextDM1.Text) Then
                    TextR1.BackColor = Color.Green
                End If
                If Val(TextD1.Text) >= Val(TextDM1.Text) * -1 Then
                    TextR1.BackColor = Color.Green
                End If
                If Val(TextD1.Text) > Val(TextDM1.Text) Then
                    TextR1.BackColor = Color.Yellow
                End If
                If Val(TextD1.Text) < Val(TextDM1.Text) * -1 Then
                    TextR1.BackColor = Color.Yellow
                End If
                If Val(TextD1.Text) > Val(TextDM1.Text) * 2 Then
                    TextR1.BackColor = Color.Red
                End If
                If Val(TextD1.Text) < Val(TextDM1.Text) * -2 Then
                    TextR1.BackColor = Color.Red
                End If
                difreal = Val(TextL1.Text) - Val(TextVR1.Text)
                TextDR1.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL2.Text.Length > 0 And TextVR2.Text.Length > 0 Then
                promedio = Val((TextL2.Text) + Val(TextVR2.Text)) / 2
                valor1 = Val(TextL2.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD2.Text = Math.Round(valor4, 3)
                TextP2.Text = Math.Round((Val(TextL2.Text) + Val(TextVR2.Text)) / 2, 3)
                If Val(TextD2.Text) <= Val(TextDM2.Text) Then
                    TextR2.BackColor = Color.Green
                End If
                If Val(TextD2.Text) >= Val(TextDM2.Text) * -1 Then
                    TextR2.BackColor = Color.Green
                End If
                If Val(TextD2.Text) > Val(TextDM2.Text) Then
                    TextR2.BackColor = Color.Yellow
                End If
                If Val(TextD2.Text) < Val(TextDM2.Text) * -1 Then
                    TextR2.BackColor = Color.Yellow
                End If
                If Val(TextD2.Text) > Val(TextDM2.Text) * 2 Then
                    TextR2.BackColor = Color.Red
                End If
                If Val(TextD2.Text) < Val(TextDM2.Text) * -2 Then
                    TextR2.BackColor = Color.Red
                End If
                difreal = Val(TextL2.Text) - Val(TextVR2.Text)
                TextDR2.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL3.Text.Length > 0 And TextVR3.Text.Length > 0 Then
                promedio = Val((TextL3.Text) + Val(TextVR3.Text)) / 2
                valor1 = Val(TextL3.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD3.Text = Math.Round(valor4, 3)
                TextP3.Text = Math.Round((Val(TextL3.Text) + Val(TextVR3.Text)) / 2, 3)
                If Val(TextD3.Text) <= Val(TextDM3.Text) Then
                    TextR3.BackColor = Color.Green
                End If
                If Val(TextD3.Text) >= Val(TextDM3.Text) * -1 Then
                    TextR3.BackColor = Color.Green
                End If
                If Val(TextD3.Text) > Val(TextDM3.Text) Then
                    TextR3.BackColor = Color.Yellow
                End If
                If Val(TextD3.Text) < Val(TextDM3.Text) * -1 Then
                    TextR3.BackColor = Color.Yellow
                End If
                If Val(TextD3.Text) > Val(TextDM3.Text) * 2 Then
                    TextR3.BackColor = Color.Red
                End If
                If Val(TextD3.Text) < Val(TextDM3.Text) * -2 Then
                    TextR3.BackColor = Color.Red
                End If
                difreal = Val(TextL3.Text) - Val(TextVR3.Text)
                TextDR3.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL4.Text.Length > 0 And TextVR4.Text.Length > 0 Then
                promedio = Val((TextL4.Text) + Val(TextVR4.Text)) / 2
                valor1 = Val(TextL4.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD4.Text = Math.Round(valor4, 3)
                TextP4.Text = Math.Round((Val(TextL4.Text) + Val(TextVR4.Text)) / 2, 3)
                If Val(TextD4.Text) <= Val(TextDM4.Text) Then
                    TextR4.BackColor = Color.Green
                End If
                If Val(TextD4.Text) >= Val(TextDM4.Text) * -1 Then
                    TextR4.BackColor = Color.Green
                End If
                If Val(TextD4.Text) > Val(TextDM4.Text) Then
                    TextR4.BackColor = Color.Yellow
                End If
                If Val(TextD4.Text) < Val(TextDM4.Text) * -1 Then
                    TextR4.BackColor = Color.Yellow
                End If
                If Val(TextD4.Text) > Val(TextDM4.Text) * 2 Then
                    TextR4.BackColor = Color.Red
                End If
                If Val(TextD4.Text) < Val(TextDM4.Text) * -2 Then
                    TextR4.BackColor = Color.Red
                End If
                difreal = Val(TextL4.Text) - Val(TextVR4.Text)
                TextDR4.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL5.Text.Length > 0 And TextVR5.Text.Length > 0 Then
                promedio = Val((TextL5.Text) + Val(TextVR5.Text)) / 2
                valor1 = Val(TextL5.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD5.Text = Math.Round(valor4, 3)
                TextP5.Text = Math.Round((Val(TextL5.Text) + Val(TextVR5.Text)) / 2, 3)
                If Val(TextD5.Text) <= Val(TextDM5.Text) Then
                    TextR5.BackColor = Color.Green
                End If
                If Val(TextD5.Text) >= Val(TextDM5.Text) * -1 Then
                    TextR5.BackColor = Color.Green
                End If
                If Val(TextD5.Text) > Val(TextDM5.Text) Then
                    TextR5.BackColor = Color.Yellow
                End If
                If Val(TextD5.Text) < Val(TextDM5.Text) * -1 Then
                    TextR5.BackColor = Color.Yellow
                End If
                If Val(TextD5.Text) > Val(TextDM5.Text) * 2 Then
                    TextR5.BackColor = Color.Red
                End If
                If Val(TextD5.Text) < Val(TextDM5.Text) * -2 Then
                    TextR5.BackColor = Color.Red
                End If
                difreal = Val(TextL5.Text) - Val(TextVR5.Text)
                TextDR5.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL6.Text.Length > 0 And TextVR6.Text.Length > 0 Then
                promedio = Val((TextL6.Text) + Val(TextVR6.Text)) / 2
                valor1 = Val(TextL6.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD6.Text = Math.Round(valor4, 3)
                TextP6.Text = Math.Round((Val(TextL6.Text) + Val(TextVR6.Text)) / 2, 3)
                If Val(TextD6.Text) <= Val(TextDM6.Text) Then
                    TextR6.BackColor = Color.Green
                End If
                If Val(TextD6.Text) >= Val(TextDM6.Text) * -1 Then
                    TextR6.BackColor = Color.Green
                End If
                If Val(TextD6.Text) > Val(TextDM6.Text) Then
                    TextR6.BackColor = Color.Yellow
                End If
                If Val(TextD6.Text) < Val(TextDM6.Text) * -1 Then
                    TextR6.BackColor = Color.Yellow
                End If
                If Val(TextD6.Text) > Val(TextDM6.Text) * 2 Then
                    TextR6.BackColor = Color.Red
                End If
                If Val(TextD6.Text) < Val(TextDM6.Text) * -2 Then
                    TextR6.BackColor = Color.Red
                End If
                difreal = Val(TextL6.Text) - Val(TextVR6.Text)
                TextDR6.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL7.Text.Length > 0 And TextVR7.Text.Length > 0 Then
                promedio = Val((TextL7.Text) + Val(TextVR7.Text)) / 2
                valor1 = Val(TextL7.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD7.Text = Math.Round(valor4, 3)
                TextP7.Text = Math.Round((Val(TextL7.Text) + Val(TextVR7.Text)) / 2, 3)
                If Val(TextD7.Text) <= Val(TextDM7.Text) Then
                    TextR7.BackColor = Color.Green
                End If
                If Val(TextD7.Text) >= Val(TextDM7.Text) * -1 Then
                    TextR7.BackColor = Color.Green
                End If
                If Val(TextD7.Text) > Val(TextDM7.Text) Then
                    TextR7.BackColor = Color.Yellow
                End If
                If Val(TextD7.Text) < Val(TextDM7.Text) * -1 Then
                    TextR7.BackColor = Color.Yellow
                End If
                If Val(TextD7.Text) > Val(TextDM7.Text) * 2 Then
                    TextR7.BackColor = Color.Red
                End If
                If Val(TextD7.Text) < Val(TextDM7.Text) * -2 Then
                    TextR7.BackColor = Color.Red
                End If
                difreal = Val(TextL7.Text) - Val(TextVR7.Text)
                TextDR7.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL8.Text.Length > 0 And TextVR8.Text.Length > 0 Then
                promedio = Val((TextL8.Text) + Val(TextVR8.Text)) / 2
                valor1 = Val(TextL8.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD8.Text = Math.Round(valor4, 3)
                TextP8.Text = Math.Round((Val(TextL8.Text) + Val(TextVR8.Text)) / 2, 3)
                If Val(TextD8.Text) <= Val(TextDM8.Text) Then
                    TextR8.BackColor = Color.Green
                End If
                If Val(TextD8.Text) >= Val(TextDM8.Text) * -1 Then
                    TextR8.BackColor = Color.Green
                End If
                If Val(TextD8.Text) > Val(TextDM8.Text) Then
                    TextR8.BackColor = Color.Yellow
                End If
                If Val(TextD8.Text) < Val(TextDM8.Text) * -1 Then
                    TextR8.BackColor = Color.Yellow
                End If
                If Val(TextD8.Text) > Val(TextDM8.Text) * 2 Then
                    TextR8.BackColor = Color.Red
                End If
                If Val(TextD8.Text) < Val(TextDM8.Text) * -2 Then
                    TextR8.BackColor = Color.Red
                End If
                difreal = Val(TextL8.Text) - Val(TextVR8.Text)
                TextDR8.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL9.Text.Length > 0 And TextVR9.Text.Length > 0 Then
                promedio = Val((TextL9.Text) + Val(TextVR9.Text)) / 2
                valor1 = Val(TextL9.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD9.Text = Math.Round(valor4, 3)
                TextP9.Text = Math.Round((Val(TextL9.Text) + Val(TextVR9.Text)) / 2, 3)
                If Val(TextD9.Text) <= Val(TextDM9.Text) Then
                    TextR9.BackColor = Color.Green
                End If
                If Val(TextD9.Text) >= Val(TextDM9.Text) * -1 Then
                    TextR9.BackColor = Color.Green
                End If
                If Val(TextD9.Text) > Val(TextDM9.Text) Then
                    TextR9.BackColor = Color.Yellow
                End If
                If Val(TextD9.Text) < Val(TextDM9.Text) * -1 Then
                    TextR9.BackColor = Color.Yellow
                End If
                If Val(TextD9.Text) > Val(TextDM9.Text) * 2 Then
                    TextR9.BackColor = Color.Red
                End If
                If Val(TextD9.Text) < Val(TextDM9.Text) * -2 Then
                    TextR9.BackColor = Color.Red
                End If
                difreal = Val(TextL9.Text) - Val(TextVR9.Text)
                TextDR9.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL10.Text.Length > 0 And TextVR10.Text.Length > 0 Then
                promedio = Val((TextL10.Text) + Val(TextVR10.Text)) / 2
                valor1 = Val(TextL10.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD10.Text = Math.Round(valor4, 3)
                TextP10.Text = Math.Round((Val(TextL10.Text) + Val(TextVR10.Text)) / 2, 3)
                If Val(TextD10.Text) <= Val(TextDM10.Text) Then
                    TextR10.BackColor = Color.Green
                End If
                If Val(TextD10.Text) >= Val(TextDM10.Text) * -1 Then
                    TextR10.BackColor = Color.Green
                End If
                If Val(TextD10.Text) > Val(TextDM10.Text) Then
                    TextR10.BackColor = Color.Yellow
                End If
                If Val(TextD10.Text) < Val(TextDM10.Text) * -1 Then
                    TextR10.BackColor = Color.Yellow
                End If
                If Val(TextD10.Text) > Val(TextDM10.Text) * 2 Then
                    TextR10.BackColor = Color.Red
                End If
                If Val(TextD10.Text) < Val(TextDM10.Text) * -2 Then
                    TextR10.BackColor = Color.Red
                End If
                difreal = Val(TextL10.Text) - Val(TextVR10.Text)
                TextDR10.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL11.Text.Length > 0 And TextVR11.Text.Length > 0 Then
                promedio = Val((TextL11.Text) + Val(TextVR11.Text)) / 2
                valor1 = Val(TextL11.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD11.Text = Math.Round(valor4, 3)
                TextP11.Text = Math.Round((Val(TextL11.Text) + Val(TextVR11.Text)) / 2, 3)
                If Val(TextD11.Text) <= Val(TextDM11.Text) Then
                    TextR11.BackColor = Color.Green
                End If
                If Val(TextD11.Text) >= Val(TextDM11.Text) * -1 Then
                    TextR11.BackColor = Color.Green
                End If
                If Val(TextD11.Text) > Val(TextDM11.Text) Then
                    TextR11.BackColor = Color.Yellow
                End If
                If Val(TextD11.Text) < Val(TextDM11.Text) * -1 Then
                    TextR11.BackColor = Color.Yellow
                End If
                If Val(TextD11.Text) > Val(TextDM11.Text) * 2 Then
                    TextR11.BackColor = Color.Red
                End If
                If Val(TextD11.Text) < Val(TextDM11.Text) * -2 Then
                    TextR11.BackColor = Color.Red
                End If
                difreal = Val(TextL11.Text) - Val(TextVR11.Text)
                TextDR11.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
        ElseIf RadioProteina.Checked = True Then
            If TextL1.Text.Length > 0 And TextVR1.Text.Length > 0 Then
                promedio = Val((TextL1.Text) + Val(TextVR1.Text)) / 2
                valor1 = Val(TextL1.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD1.Text = Math.Round(valor4, 3)
                TextP1.Text = Math.Round((Val(TextL1.Text) + Val(TextVR1.Text)) / 2, 3)
                If Val(TextD1.Text) <= Val(TextDM1.Text) Then
                    TextR1.BackColor = Color.Green
                End If
                If Val(TextD1.Text) >= Val(TextDM1.Text) * -1 Then
                    TextR1.BackColor = Color.Green
                End If
                If Val(TextD1.Text) > Val(TextDM1.Text) Then
                    TextR1.BackColor = Color.Yellow
                End If
                If Val(TextD1.Text) < Val(TextDM1.Text) * -1 Then
                    TextR1.BackColor = Color.Yellow
                End If
                If Val(TextD1.Text) > Val(TextDM1.Text) * 2 Then
                    TextR1.BackColor = Color.Red
                End If
                If Val(TextD1.Text) < Val(TextDM1.Text) * -2 Then
                    TextR1.BackColor = Color.Red
                End If
                difreal = Val(TextL1.Text) - Val(TextVR1.Text)
                TextDR1.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL2.Text.Length > 0 And TextVR2.Text.Length > 0 Then
                promedio = Val((TextL2.Text) + Val(TextVR2.Text)) / 2
                valor1 = Val(TextL2.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD2.Text = Math.Round(valor4, 3)
                TextP2.Text = Math.Round((Val(TextL2.Text) + Val(TextVR2.Text)) / 2, 3)
                If Val(TextD2.Text) <= Val(TextDM2.Text) Then
                    TextR2.BackColor = Color.Green
                End If
                If Val(TextD2.Text) >= Val(TextDM2.Text) * -1 Then
                    TextR2.BackColor = Color.Green
                End If
                If Val(TextD2.Text) > Val(TextDM2.Text) Then
                    TextR2.BackColor = Color.Yellow
                End If
                If Val(TextD2.Text) < Val(TextDM2.Text) * -1 Then
                    TextR2.BackColor = Color.Yellow
                End If
                If Val(TextD2.Text) > Val(TextDM2.Text) * 2 Then
                    TextR2.BackColor = Color.Red
                End If
                If Val(TextD2.Text) < Val(TextDM2.Text) * -2 Then
                    TextR2.BackColor = Color.Red
                End If
                difreal = Val(TextL2.Text) - Val(TextVR2.Text)
                TextDR2.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL3.Text.Length > 0 And TextVR3.Text.Length > 0 Then
                promedio = Val((TextL3.Text) + Val(TextVR3.Text)) / 2
                valor1 = Val(TextL3.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD3.Text = Math.Round(valor4, 3)
                TextP3.Text = Math.Round((Val(TextL3.Text) + Val(TextVR3.Text)) / 2, 3)
                If Val(TextD3.Text) <= Val(TextDM3.Text) Then
                    TextR3.BackColor = Color.Green
                End If
                If Val(TextD3.Text) >= Val(TextDM3.Text) * -1 Then
                    TextR3.BackColor = Color.Green
                End If
                If Val(TextD3.Text) > Val(TextDM3.Text) Then
                    TextR3.BackColor = Color.Yellow
                End If
                If Val(TextD3.Text) < Val(TextDM3.Text) * -1 Then
                    TextR3.BackColor = Color.Yellow
                End If
                If Val(TextD3.Text) > Val(TextDM3.Text) * 2 Then
                    TextR3.BackColor = Color.Red
                End If
                If Val(TextD3.Text) < Val(TextDM3.Text) * -2 Then
                    TextR3.BackColor = Color.Red
                End If
                difreal = Val(TextL3.Text) - Val(TextVR3.Text)
                TextDR3.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL4.Text.Length > 0 And TextVR4.Text.Length > 0 Then
                promedio = Val((TextL4.Text) + Val(TextVR4.Text)) / 2
                valor1 = Val(TextL4.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD4.Text = Math.Round(valor4, 3)
                TextP4.Text = Math.Round((Val(TextL4.Text) + Val(TextVR4.Text)) / 2, 3)
                If Val(TextD4.Text) <= Val(TextDM4.Text) Then
                    TextR4.BackColor = Color.Green
                End If
                If Val(TextD4.Text) >= Val(TextDM4.Text) * -1 Then
                    TextR4.BackColor = Color.Green
                End If
                If Val(TextD4.Text) > Val(TextDM4.Text) Then
                    TextR4.BackColor = Color.Yellow
                End If
                If Val(TextD4.Text) < Val(TextDM4.Text) * -1 Then
                    TextR4.BackColor = Color.Yellow
                End If
                If Val(TextD4.Text) > Val(TextDM4.Text) * 2 Then
                    TextR4.BackColor = Color.Red
                End If
                If Val(TextD4.Text) < Val(TextDM4.Text) * -2 Then
                    TextR4.BackColor = Color.Red
                End If
                difreal = Val(TextL4.Text) - Val(TextVR4.Text)
                TextDR4.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL5.Text.Length > 0 And TextVR5.Text.Length > 0 Then
                promedio = Val((TextL5.Text) + Val(TextVR5.Text)) / 2
                valor1 = Val(TextL5.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD5.Text = Math.Round(valor4, 3)
                TextP5.Text = Math.Round((Val(TextL5.Text) + Val(TextVR5.Text)) / 2, 3)
                If Val(TextD5.Text) <= Val(TextDM5.Text) Then
                    TextR5.BackColor = Color.Green
                End If
                If Val(TextD5.Text) >= Val(TextDM5.Text) * -1 Then
                    TextR5.BackColor = Color.Green
                End If
                If Val(TextD5.Text) > Val(TextDM5.Text) Then
                    TextR5.BackColor = Color.Yellow
                End If
                If Val(TextD5.Text) < Val(TextDM5.Text) * -1 Then
                    TextR5.BackColor = Color.Yellow
                End If
                If Val(TextD5.Text) > Val(TextDM5.Text) * 2 Then
                    TextR5.BackColor = Color.Red
                End If
                If Val(TextD5.Text) < Val(TextDM5.Text) * -2 Then
                    TextR5.BackColor = Color.Red
                End If
                difreal = Val(TextL5.Text) - Val(TextVR5.Text)
                TextDR5.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL6.Text.Length > 0 And TextVR6.Text.Length > 0 Then
                promedio = Val((TextL6.Text) + Val(TextVR6.Text)) / 2
                valor1 = Val(TextL6.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD6.Text = Math.Round(valor4, 3)
                TextP6.Text = Math.Round((Val(TextL6.Text) + Val(TextVR6.Text)) / 2, 3)
                If Val(TextD6.Text) <= Val(TextDM6.Text) Then
                    TextR6.BackColor = Color.Green
                End If
                If Val(TextD6.Text) >= Val(TextDM6.Text) * -1 Then
                    TextR6.BackColor = Color.Green
                End If
                If Val(TextD6.Text) > Val(TextDM6.Text) Then
                    TextR6.BackColor = Color.Yellow
                End If
                If Val(TextD6.Text) < Val(TextDM6.Text) * -1 Then
                    TextR6.BackColor = Color.Yellow
                End If
                If Val(TextD6.Text) > Val(TextDM6.Text) * 2 Then
                    TextR6.BackColor = Color.Red
                End If
                If Val(TextD6.Text) < Val(TextDM6.Text) * -2 Then
                    TextR6.BackColor = Color.Red
                End If
                difreal = Val(TextL6.Text) - Val(TextVR6.Text)
                TextDR6.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL7.Text.Length > 0 And TextVR7.Text.Length > 0 Then
                promedio = Val((TextL7.Text) + Val(TextVR7.Text)) / 2
                valor1 = Val(TextL7.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD7.Text = Math.Round(valor4, 3)
                TextP7.Text = Math.Round((Val(TextL7.Text) + Val(TextVR7.Text)) / 2, 3)
                If Val(TextD7.Text) <= Val(TextDM7.Text) Then
                    TextR7.BackColor = Color.Green
                End If
                If Val(TextD7.Text) >= Val(TextDM7.Text) * -1 Then
                    TextR7.BackColor = Color.Green
                End If
                If Val(TextD7.Text) > Val(TextDM7.Text) Then
                    TextR7.BackColor = Color.Yellow
                End If
                If Val(TextD7.Text) < Val(TextDM7.Text) * -1 Then
                    TextR7.BackColor = Color.Yellow
                End If
                If Val(TextD7.Text) > Val(TextDM7.Text) * 2 Then
                    TextR7.BackColor = Color.Red
                End If
                If Val(TextD7.Text) < Val(TextDM7.Text) * -2 Then
                    TextR7.BackColor = Color.Red
                End If
                difreal = Val(TextL7.Text) - Val(TextVR7.Text)
                TextDR7.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL8.Text.Length > 0 And TextVR8.Text.Length > 0 Then
                promedio = Val((TextL8.Text) + Val(TextVR8.Text)) / 2
                valor1 = Val(TextL8.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD8.Text = Math.Round(valor4, 3)
                TextP8.Text = Math.Round((Val(TextL8.Text) + Val(TextVR8.Text)) / 2, 3)
                If Val(TextD8.Text) <= Val(TextDM8.Text) Then
                    TextR8.BackColor = Color.Green
                End If
                If Val(TextD8.Text) >= Val(TextDM8.Text) * -1 Then
                    TextR8.BackColor = Color.Green
                End If
                If Val(TextD8.Text) > Val(TextDM8.Text) Then
                    TextR8.BackColor = Color.Yellow
                End If
                If Val(TextD8.Text) < Val(TextDM8.Text) * -1 Then
                    TextR8.BackColor = Color.Yellow
                End If
                If Val(TextD8.Text) > Val(TextDM8.Text) * 2 Then
                    TextR8.BackColor = Color.Red
                End If
                If Val(TextD8.Text) < Val(TextDM8.Text) * -2 Then
                    TextR8.BackColor = Color.Red
                End If
                difreal = Val(TextL8.Text) - Val(TextVR8.Text)
                TextDR8.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL9.Text.Length > 0 And TextVR9.Text.Length > 0 Then
                promedio = Val((TextL9.Text) + Val(TextVR9.Text)) / 2
                valor1 = Val(TextL9.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD9.Text = Math.Round(valor4, 3)
                TextP9.Text = Math.Round((Val(TextL9.Text) + Val(TextVR9.Text)) / 2, 3)
                If Val(TextD9.Text) <= Val(TextDM9.Text) Then
                    TextR9.BackColor = Color.Green
                End If
                If Val(TextD9.Text) >= Val(TextDM9.Text) * -1 Then
                    TextR9.BackColor = Color.Green
                End If
                If Val(TextD9.Text) > Val(TextDM9.Text) Then
                    TextR9.BackColor = Color.Yellow
                End If
                If Val(TextD9.Text) < Val(TextDM9.Text) * -1 Then
                    TextR9.BackColor = Color.Yellow
                End If
                If Val(TextD9.Text) > Val(TextDM9.Text) * 2 Then
                    TextR9.BackColor = Color.Red
                End If
                If Val(TextD9.Text) < Val(TextDM9.Text) * -2 Then
                    TextR9.BackColor = Color.Red
                End If
                difreal = Val(TextL9.Text) - Val(TextVR9.Text)
                TextDR9.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL10.Text.Length > 0 And TextVR10.Text.Length > 0 Then
                promedio = Val((TextL10.Text) + Val(TextVR10.Text)) / 2
                valor1 = Val(TextL10.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD10.Text = Math.Round(valor4, 3)
                TextP10.Text = Math.Round((Val(TextL10.Text) + Val(TextVR10.Text)) / 2, 3)
                If Val(TextD10.Text) <= Val(TextDM10.Text) Then
                    TextR10.BackColor = Color.Green
                End If
                If Val(TextD10.Text) >= Val(TextDM10.Text) * -1 Then
                    TextR10.BackColor = Color.Green
                End If
                If Val(TextD10.Text) > Val(TextDM10.Text) Then
                    TextR10.BackColor = Color.Yellow
                End If
                If Val(TextD10.Text) < Val(TextDM10.Text) * -1 Then
                    TextR10.BackColor = Color.Yellow
                End If
                If Val(TextD10.Text) > Val(TextDM10.Text) * 2 Then
                    TextR10.BackColor = Color.Red
                End If
                If Val(TextD10.Text) < Val(TextDM10.Text) * -2 Then
                    TextR10.BackColor = Color.Red
                End If
                difreal = Val(TextL10.Text) - Val(TextVR10.Text)
                TextDR10.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL11.Text.Length > 0 And TextVR11.Text.Length > 0 Then
                promedio = Val((TextL11.Text) + Val(TextVR11.Text)) / 2
                valor1 = Val(TextL11.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD11.Text = Math.Round(valor4, 3)
                TextP11.Text = Math.Round((Val(TextL11.Text) + Val(TextVR11.Text)) / 2, 3)
                If Val(TextD11.Text) <= Val(TextDM11.Text) Then
                    TextR11.BackColor = Color.Green
                End If
                If Val(TextD11.Text) >= Val(TextDM11.Text) * -1 Then
                    TextR11.BackColor = Color.Green
                End If
                If Val(TextD11.Text) > Val(TextDM11.Text) Then
                    TextR11.BackColor = Color.Yellow
                End If
                If Val(TextD11.Text) < Val(TextDM11.Text) * -1 Then
                    TextR11.BackColor = Color.Yellow
                End If
                If Val(TextD11.Text) > Val(TextDM11.Text) * 2 Then
                    TextR11.BackColor = Color.Red
                End If
                If Val(TextD11.Text) < Val(TextDM11.Text) * -2 Then
                    TextR11.BackColor = Color.Red
                End If
                difreal = Val(TextL11.Text) - Val(TextVR11.Text)
                TextDR11.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
        ElseIf RadioLactosa.Checked = True Then
            If TextL1.Text.Length > 0 And TextVR1.Text.Length > 0 Then
                promedio = Val((TextL1.Text) + Val(TextVR1.Text)) / 2
                valor1 = Val(TextL1.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD1.Text = Math.Round(valor4, 3)
                TextP1.Text = Math.Round((Val(TextL1.Text) + Val(TextVR1.Text)) / 2, 3)
                If Val(TextD1.Text) <= Val(TextDM1.Text) Then
                    TextR1.BackColor = Color.Green
                End If
                If Val(TextD1.Text) >= Val(TextDM1.Text) * -1 Then
                    TextR1.BackColor = Color.Green
                End If
                If Val(TextD1.Text) > Val(TextDM1.Text) Then
                    TextR1.BackColor = Color.Yellow
                End If
                If Val(TextD1.Text) < Val(TextDM1.Text) * -1 Then
                    TextR1.BackColor = Color.Yellow
                End If
                If Val(TextD1.Text) > Val(TextDM1.Text) * 2 Then
                    TextR1.BackColor = Color.Red
                End If
                If Val(TextD1.Text) < Val(TextDM1.Text) * -2 Then
                    TextR1.BackColor = Color.Red
                End If
                difreal = Val(TextL1.Text) - Val(TextVR1.Text)
                TextDR1.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL2.Text.Length > 0 And TextVR2.Text.Length > 0 Then
                promedio = Val((TextL2.Text) + Val(TextVR2.Text)) / 2
                valor1 = Val(TextL2.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD2.Text = Math.Round(valor4, 3)
                TextP2.Text = Math.Round((Val(TextL2.Text) + Val(TextVR2.Text)) / 2, 3)
                If Val(TextD2.Text) <= Val(TextDM2.Text) Then
                    TextR2.BackColor = Color.Green
                End If
                If Val(TextD2.Text) >= Val(TextDM2.Text) * -1 Then
                    TextR2.BackColor = Color.Green
                End If
                If Val(TextD2.Text) > Val(TextDM2.Text) Then
                    TextR2.BackColor = Color.Yellow
                End If
                If Val(TextD2.Text) < Val(TextDM2.Text) * -1 Then
                    TextR2.BackColor = Color.Yellow
                End If
                If Val(TextD2.Text) > Val(TextDM2.Text) * 2 Then
                    TextR2.BackColor = Color.Red
                End If
                If Val(TextD2.Text) < Val(TextDM2.Text) * -2 Then
                    TextR2.BackColor = Color.Red
                End If
                difreal = Val(TextL2.Text) - Val(TextVR2.Text)
                TextDR2.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL3.Text.Length > 0 And TextVR3.Text.Length > 0 Then
                promedio = Val((TextL3.Text) + Val(TextVR3.Text)) / 2
                valor1 = Val(TextL3.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD3.Text = Math.Round(valor4, 3)
                TextP3.Text = Math.Round((Val(TextL3.Text) + Val(TextVR3.Text)) / 2, 3)
                If Val(TextD3.Text) <= Val(TextDM3.Text) Then
                    TextR3.BackColor = Color.Green
                End If
                If Val(TextD3.Text) >= Val(TextDM3.Text) * -1 Then
                    TextR3.BackColor = Color.Green
                End If
                If Val(TextD3.Text) > Val(TextDM3.Text) Then
                    TextR3.BackColor = Color.Yellow
                End If
                If Val(TextD3.Text) < Val(TextDM3.Text) * -1 Then
                    TextR3.BackColor = Color.Yellow
                End If
                If Val(TextD3.Text) > Val(TextDM3.Text) * 2 Then
                    TextR3.BackColor = Color.Red
                End If
                If Val(TextD3.Text) < Val(TextDM3.Text) * -2 Then
                    TextR3.BackColor = Color.Red
                End If
                difreal = Val(TextL3.Text) - Val(TextVR3.Text)
                TextDR3.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL4.Text.Length > 0 And TextVR4.Text.Length > 0 Then
                promedio = Val((TextL4.Text) + Val(TextVR4.Text)) / 2
                valor1 = Val(TextL4.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD4.Text = Math.Round(valor4, 3)
                TextP4.Text = Math.Round((Val(TextL4.Text) + Val(TextVR4.Text)) / 2, 3)
                If Val(TextD4.Text) <= Val(TextDM4.Text) Then
                    TextR4.BackColor = Color.Green
                End If
                If Val(TextD4.Text) >= Val(TextDM4.Text) * -1 Then
                    TextR4.BackColor = Color.Green
                End If
                If Val(TextD4.Text) > Val(TextDM4.Text) Then
                    TextR4.BackColor = Color.Yellow
                End If
                If Val(TextD4.Text) < Val(TextDM4.Text) * -1 Then
                    TextR4.BackColor = Color.Yellow
                End If
                If Val(TextD4.Text) > Val(TextDM4.Text) * 2 Then
                    TextR4.BackColor = Color.Red
                End If
                If Val(TextD4.Text) < Val(TextDM4.Text) * -2 Then
                    TextR4.BackColor = Color.Red
                End If
                difreal = Val(TextL4.Text) - Val(TextVR4.Text)
                TextDR4.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL5.Text.Length > 0 And TextVR5.Text.Length > 0 Then
                promedio = Val((TextL5.Text) + Val(TextVR5.Text)) / 2
                valor1 = Val(TextL5.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD5.Text = Math.Round(valor4, 3)
                TextP5.Text = Math.Round((Val(TextL5.Text) + Val(TextVR5.Text)) / 2, 3)
                If Val(TextD5.Text) <= Val(TextDM5.Text) Then
                    TextR5.BackColor = Color.Green
                End If
                If Val(TextD5.Text) >= Val(TextDM5.Text) * -1 Then
                    TextR5.BackColor = Color.Green
                End If
                If Val(TextD5.Text) > Val(TextDM5.Text) Then
                    TextR5.BackColor = Color.Yellow
                End If
                If Val(TextD5.Text) < Val(TextDM5.Text) * -1 Then
                    TextR5.BackColor = Color.Yellow
                End If
                If Val(TextD5.Text) > Val(TextDM5.Text) * 2 Then
                    TextR5.BackColor = Color.Red
                End If
                If Val(TextD5.Text) < Val(TextDM5.Text) * -2 Then
                    TextR5.BackColor = Color.Red
                End If
                difreal = Val(TextL5.Text) - Val(TextVR5.Text)
                TextDR5.Text = Math.Round(difreal, 3)
                difreal = 0

            End If
            If TextL6.Text.Length > 0 And TextVR6.Text.Length > 0 Then
                promedio = Val((TextL6.Text) + Val(TextVR6.Text)) / 2
                valor1 = Val(TextL6.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD6.Text = Math.Round(valor4, 3)
                TextP6.Text = Math.Round((Val(TextL6.Text) + Val(TextVR6.Text)) / 2, 3)
                If Val(TextD6.Text) <= Val(TextDM6.Text) Then
                    TextR6.BackColor = Color.Green
                End If
                If Val(TextD6.Text) >= Val(TextDM6.Text) * -1 Then
                    TextR6.BackColor = Color.Green
                End If
                If Val(TextD6.Text) > Val(TextDM6.Text) Then
                    TextR6.BackColor = Color.Yellow
                End If
                If Val(TextD6.Text) < Val(TextDM6.Text) * -1 Then
                    TextR6.BackColor = Color.Yellow
                End If
                If Val(TextD6.Text) > Val(TextDM6.Text) * 2 Then
                    TextR6.BackColor = Color.Red
                End If
                If Val(TextD6.Text) < Val(TextDM6.Text) * -2 Then
                    TextR6.BackColor = Color.Red
                End If
                difreal = Val(TextL6.Text) - Val(TextVR6.Text)
                TextDR6.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL7.Text.Length > 0 And TextVR7.Text.Length > 0 Then
                promedio = Val((TextL7.Text) + Val(TextVR7.Text)) / 2
                valor1 = Val(TextL7.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD7.Text = Math.Round(valor4, 3)
                TextP7.Text = Math.Round((Val(TextL7.Text) + Val(TextVR7.Text)) / 2, 3)
                If Val(TextD7.Text) <= Val(TextDM7.Text) Then
                    TextR7.BackColor = Color.Green
                End If
                If Val(TextD7.Text) >= Val(TextDM7.Text) * -1 Then
                    TextR7.BackColor = Color.Green
                End If
                If Val(TextD7.Text) > Val(TextDM7.Text) Then
                    TextR7.BackColor = Color.Yellow
                End If
                If Val(TextD7.Text) < Val(TextDM7.Text) * -1 Then
                    TextR7.BackColor = Color.Yellow
                End If
                If Val(TextD7.Text) > Val(TextDM7.Text) * 2 Then
                    TextR7.BackColor = Color.Red
                End If
                If Val(TextD7.Text) < Val(TextDM7.Text) * -2 Then
                    TextR7.BackColor = Color.Red
                End If
                difreal = Val(TextL7.Text) - Val(TextVR7.Text)
                TextDR7.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL8.Text.Length > 0 And TextVR8.Text.Length > 0 Then
                promedio = Val((TextL8.Text) + Val(TextVR8.Text)) / 2
                valor1 = Val(TextL8.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD8.Text = Math.Round(valor4, 3)
                TextP8.Text = Math.Round((Val(TextL8.Text) + Val(TextVR8.Text)) / 2, 3)
                If Val(TextD8.Text) <= Val(TextDM8.Text) Then
                    TextR8.BackColor = Color.Green
                End If
                If Val(TextD8.Text) >= Val(TextDM8.Text) * -1 Then
                    TextR8.BackColor = Color.Green
                End If
                If Val(TextD8.Text) > Val(TextDM8.Text) Then
                    TextR8.BackColor = Color.Yellow
                End If
                If Val(TextD8.Text) < Val(TextDM8.Text) * -1 Then
                    TextR8.BackColor = Color.Yellow
                End If
                If Val(TextD8.Text) > Val(TextDM8.Text) * 2 Then
                    TextR8.BackColor = Color.Red
                End If
                If Val(TextD8.Text) < Val(TextDM8.Text) * -2 Then
                    TextR8.BackColor = Color.Red
                End If
                difreal = Val(TextL8.Text) - Val(TextVR8.Text)
                TextDR8.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL9.Text.Length > 0 And TextVR9.Text.Length > 0 Then
                promedio = Val((TextL9.Text) + Val(TextVR9.Text)) / 2
                valor1 = Val(TextL9.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD9.Text = Math.Round(valor4, 3)
                TextP9.Text = Math.Round((Val(TextL9.Text) + Val(TextVR9.Text)) / 2, 3)
                If Val(TextD9.Text) <= Val(TextDM9.Text) Then
                    TextR9.BackColor = Color.Green
                End If
                If Val(TextD9.Text) >= Val(TextDM9.Text) * -1 Then
                    TextR9.BackColor = Color.Green
                End If
                If Val(TextD9.Text) > Val(TextDM9.Text) Then
                    TextR9.BackColor = Color.Yellow
                End If
                If Val(TextD9.Text) < Val(TextDM9.Text) * -1 Then
                    TextR9.BackColor = Color.Yellow
                End If
                If Val(TextD9.Text) > Val(TextDM9.Text) * 2 Then
                    TextR9.BackColor = Color.Red
                End If
                If Val(TextD9.Text) < Val(TextDM9.Text) * -2 Then
                    TextR9.BackColor = Color.Red
                End If
                difreal = Val(TextL9.Text) - Val(TextVR9.Text)
                TextDR9.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL10.Text.Length > 0 And TextVR10.Text.Length > 0 Then
                promedio = Val((TextL10.Text) + Val(TextVR10.Text)) / 2
                valor1 = Val(TextL10.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD10.Text = Math.Round(valor4, 3)
                TextP10.Text = Math.Round((Val(TextL10.Text) + Val(TextVR10.Text)) / 2, 3)
                If Val(TextD10.Text) <= Val(TextDM10.Text) Then
                    TextR10.BackColor = Color.Green
                End If
                If Val(TextD10.Text) >= Val(TextDM10.Text) * -1 Then
                    TextR10.BackColor = Color.Green
                End If
                If Val(TextD10.Text) > Val(TextDM10.Text) Then
                    TextR10.BackColor = Color.Yellow
                End If
                If Val(TextD10.Text) < Val(TextDM10.Text) * -1 Then
                    TextR10.BackColor = Color.Yellow
                End If
                If Val(TextD10.Text) > Val(TextDM10.Text) * 2 Then
                    TextR10.BackColor = Color.Red
                End If
                If Val(TextD10.Text) < Val(TextDM10.Text) * -2 Then
                    TextR10.BackColor = Color.Red
                End If
                difreal = Val(TextL10.Text) - Val(TextVR10.Text)
                TextDR10.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL11.Text.Length > 0 And TextVR11.Text.Length > 0 Then
                promedio = Val((TextL11.Text) + Val(TextVR11.Text)) / 2
                valor1 = Val(TextL11.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD11.Text = Math.Round(valor4, 3)
                TextP11.Text = Math.Round((Val(TextL11.Text) + Val(TextVR11.Text)) / 2, 3)
                If Val(TextD11.Text) <= Val(TextDM11.Text) Then
                    TextR11.BackColor = Color.Green
                End If
                If Val(TextD11.Text) >= Val(TextDM11.Text) * -1 Then
                    TextR11.BackColor = Color.Green
                End If
                If Val(TextD11.Text) > Val(TextDM11.Text) Then
                    TextR11.BackColor = Color.Yellow
                End If
                If Val(TextD11.Text) < Val(TextDM11.Text) * -1 Then
                    TextR11.BackColor = Color.Yellow
                End If
                If Val(TextD11.Text) > Val(TextDM11.Text) * 2 Then
                    TextR11.BackColor = Color.Red
                End If
                If Val(TextD11.Text) < Val(TextDM11.Text) * -2 Then
                    TextR11.BackColor = Color.Red
                End If
                difreal = Val(TextL11.Text) - Val(TextVR11.Text)
                TextDR11.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
        ElseIf RadioST.Checked = True Then
            If TextL1.Text.Length > 0 And TextVR1.Text.Length > 0 Then
                promedio = Val((TextL1.Text) + Val(TextVR1.Text)) / 2
                valor1 = Val(TextL1.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD1.Text = Math.Round(valor4, 3)
                TextP1.Text = Math.Round((Val(TextL1.Text) + Val(TextVR1.Text)) / 2, 3)
                If Val(TextD1.Text) <= Val(TextDM1.Text) Then
                    TextR1.BackColor = Color.Green
                End If
                If Val(TextD1.Text) >= Val(TextDM1.Text) * -1 Then
                    TextR1.BackColor = Color.Green
                End If
                If Val(TextD1.Text) > Val(TextDM1.Text) Then
                    TextR1.BackColor = Color.Yellow
                End If
                If Val(TextD1.Text) < Val(TextDM1.Text) * -1 Then
                    TextR1.BackColor = Color.Yellow
                End If
                If Val(TextD1.Text) > Val(TextDM1.Text) * 2 Then
                    TextR1.BackColor = Color.Red
                End If
                If Val(TextD1.Text) < Val(TextDM1.Text) * -2 Then
                    TextR1.BackColor = Color.Red
                End If
                difreal = Val(TextL1.Text) - Val(TextVR1.Text)
                TextDR1.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL2.Text.Length > 0 And TextVR2.Text.Length > 0 Then
                promedio = Val((TextL2.Text) + Val(TextVR2.Text)) / 2
                valor1 = Val(TextL2.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD2.Text = Math.Round(valor4, 3)
                TextP2.Text = Math.Round((Val(TextL2.Text) + Val(TextVR2.Text)) / 2, 3)
                If Val(TextD2.Text) <= Val(TextDM2.Text) Then
                    TextR2.BackColor = Color.Green
                End If
                If Val(TextD2.Text) >= Val(TextDM2.Text) * -1 Then
                    TextR2.BackColor = Color.Green
                End If
                If Val(TextD2.Text) > Val(TextDM2.Text) Then
                    TextR2.BackColor = Color.Yellow
                End If
                If Val(TextD2.Text) < Val(TextDM2.Text) * -1 Then
                    TextR2.BackColor = Color.Yellow
                End If
                If Val(TextD2.Text) > Val(TextDM2.Text) * 2 Then
                    TextR2.BackColor = Color.Red
                End If
                If Val(TextD2.Text) < Val(TextDM2.Text) * -2 Then
                    TextR2.BackColor = Color.Red
                End If
                difreal = Val(TextL2.Text) - Val(TextVR2.Text)
                TextDR2.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL3.Text.Length > 0 And TextVR3.Text.Length > 0 Then
                promedio = Val((TextL3.Text) + Val(TextVR3.Text)) / 2
                valor1 = Val(TextL3.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD3.Text = Math.Round(valor4, 3)
                TextP3.Text = Math.Round((Val(TextL3.Text) + Val(TextVR3.Text)) / 2, 3)
                If Val(TextD3.Text) <= Val(TextDM3.Text) Then
                    TextR3.BackColor = Color.Green
                End If
                If Val(TextD3.Text) >= Val(TextDM3.Text) * -1 Then
                    TextR3.BackColor = Color.Green
                End If
                If Val(TextD3.Text) > Val(TextDM3.Text) Then
                    TextR3.BackColor = Color.Yellow
                End If
                If Val(TextD3.Text) < Val(TextDM3.Text) * -1 Then
                    TextR3.BackColor = Color.Yellow
                End If
                If Val(TextD3.Text) > Val(TextDM3.Text) * 2 Then
                    TextR3.BackColor = Color.Red
                End If
                If Val(TextD3.Text) < Val(TextDM3.Text) * -2 Then
                    TextR3.BackColor = Color.Red
                End If
                difreal = Val(TextL3.Text) - Val(TextVR3.Text)
                TextDR3.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL4.Text.Length > 0 And TextVR4.Text.Length > 0 Then
                promedio = Val((TextL4.Text) + Val(TextVR4.Text)) / 2
                valor1 = Val(TextL4.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD4.Text = Math.Round(valor4, 3)
                TextP4.Text = Math.Round((Val(TextL4.Text) + Val(TextVR4.Text)) / 2, 3)
                If Val(TextD4.Text) <= Val(TextDM4.Text) Then
                    TextR4.BackColor = Color.Green
                End If
                If Val(TextD4.Text) >= Val(TextDM4.Text) * -1 Then
                    TextR4.BackColor = Color.Green
                End If
                If Val(TextD4.Text) > Val(TextDM4.Text) Then
                    TextR4.BackColor = Color.Yellow
                End If
                If Val(TextD4.Text) < Val(TextDM4.Text) * -1 Then
                    TextR4.BackColor = Color.Yellow
                End If
                If Val(TextD4.Text) > Val(TextDM4.Text) * 2 Then
                    TextR4.BackColor = Color.Red
                End If
                If Val(TextD4.Text) < Val(TextDM4.Text) * -2 Then
                    TextR4.BackColor = Color.Red
                End If
                difreal = Val(TextL4.Text) - Val(TextVR4.Text)
                TextDR4.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL5.Text.Length > 0 And TextVR5.Text.Length > 0 Then
                promedio = Val((TextL5.Text) + Val(TextVR5.Text)) / 2
                valor1 = Val(TextL5.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD5.Text = Math.Round(valor4, 3)
                TextP5.Text = Math.Round((Val(TextL5.Text) + Val(TextVR5.Text)) / 2, 3)
                If Val(TextD5.Text) <= Val(TextDM5.Text) Then
                    TextR5.BackColor = Color.Green
                End If
                If Val(TextD5.Text) >= Val(TextDM5.Text) * -1 Then
                    TextR5.BackColor = Color.Green
                End If
                If Val(TextD5.Text) > Val(TextDM5.Text) Then
                    TextR5.BackColor = Color.Yellow
                End If
                If Val(TextD5.Text) < Val(TextDM5.Text) * -1 Then
                    TextR5.BackColor = Color.Yellow
                End If
                If Val(TextD5.Text) > Val(TextDM5.Text) * 2 Then
                    TextR5.BackColor = Color.Red
                End If
                If Val(TextD5.Text) < Val(TextDM5.Text) * -2 Then
                    TextR5.BackColor = Color.Red
                End If
                difreal = Val(TextL5.Text) - Val(TextVR5.Text)
                TextDR5.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL6.Text.Length > 0 And TextVR6.Text.Length > 0 Then
                promedio = Val((TextL6.Text) + Val(TextVR6.Text)) / 2
                valor1 = Val(TextL6.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD6.Text = Math.Round(valor4, 3)
                TextP6.Text = Math.Round((Val(TextL6.Text) + Val(TextVR6.Text)) / 2, 3)
                If Val(TextD6.Text) <= Val(TextDM6.Text) Then
                    TextR6.BackColor = Color.Green
                End If
                If Val(TextD6.Text) >= Val(TextDM6.Text) * -1 Then
                    TextR6.BackColor = Color.Green
                End If
                If Val(TextD6.Text) > Val(TextDM6.Text) Then
                    TextR6.BackColor = Color.Yellow
                End If
                If Val(TextD6.Text) < Val(TextDM6.Text) * -1 Then
                    TextR6.BackColor = Color.Yellow
                End If
                If Val(TextD6.Text) > Val(TextDM6.Text) * 2 Then
                    TextR6.BackColor = Color.Red
                End If
                If Val(TextD6.Text) < Val(TextDM6.Text) * -2 Then
                    TextR6.BackColor = Color.Red
                End If
                difreal = Val(TextL6.Text) - Val(TextVR6.Text)
                TextDR6.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL7.Text.Length > 0 And TextVR7.Text.Length > 0 Then
                promedio = Val((TextL7.Text) + Val(TextVR7.Text)) / 2
                valor1 = Val(TextL7.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD7.Text = Math.Round(valor4, 3)
                TextP7.Text = Math.Round((Val(TextL7.Text) + Val(TextVR7.Text)) / 2, 3)
                If Val(TextD7.Text) <= Val(TextDM7.Text) Then
                    TextR7.BackColor = Color.Green
                End If
                If Val(TextD7.Text) >= Val(TextDM7.Text) * -1 Then
                    TextR7.BackColor = Color.Green
                End If
                If Val(TextD7.Text) > Val(TextDM7.Text) Then
                    TextR7.BackColor = Color.Yellow
                End If
                If Val(TextD7.Text) < Val(TextDM7.Text) * -1 Then
                    TextR7.BackColor = Color.Yellow
                End If
                If Val(TextD7.Text) > Val(TextDM7.Text) * 2 Then
                    TextR7.BackColor = Color.Red
                End If
                If Val(TextD7.Text) < Val(TextDM7.Text) * -2 Then
                    TextR7.BackColor = Color.Red
                End If
                difreal = Val(TextL7.Text) - Val(TextVR7.Text)
                TextDR7.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL8.Text.Length > 0 And TextVR8.Text.Length > 0 Then
                promedio = Val((TextL8.Text) + Val(TextVR8.Text)) / 2
                valor1 = Val(TextL8.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD8.Text = Math.Round(valor4, 3)
                TextP8.Text = Math.Round((Val(TextL8.Text) + Val(TextVR8.Text)) / 2, 3)
                If Val(TextD8.Text) <= Val(TextDM8.Text) Then
                    TextR8.BackColor = Color.Green
                End If
                If Val(TextD8.Text) >= Val(TextDM8.Text) * -1 Then
                    TextR8.BackColor = Color.Green
                End If
                If Val(TextD8.Text) > Val(TextDM8.Text) Then
                    TextR8.BackColor = Color.Yellow
                End If
                If Val(TextD8.Text) < Val(TextDM8.Text) * -1 Then
                    TextR8.BackColor = Color.Yellow
                End If
                If Val(TextD8.Text) > Val(TextDM8.Text) * 2 Then
                    TextR8.BackColor = Color.Red
                End If
                If Val(TextD8.Text) < Val(TextDM8.Text) * -2 Then
                    TextR8.BackColor = Color.Red
                End If
                difreal = Val(TextL8.Text) - Val(TextVR8.Text)
                TextDR8.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL9.Text.Length > 0 And TextVR9.Text.Length > 0 Then
                promedio = Val((TextL9.Text) + Val(TextVR9.Text)) / 2
                valor1 = Val(TextL9.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD9.Text = Math.Round(valor4, 3)
                TextP9.Text = Math.Round((Val(TextL9.Text) + Val(TextVR9.Text)) / 2, 3)
                If Val(TextD9.Text) <= Val(TextDM9.Text) Then
                    TextR9.BackColor = Color.Green
                End If
                If Val(TextD9.Text) >= Val(TextDM9.Text) * -1 Then
                    TextR9.BackColor = Color.Green
                End If
                If Val(TextD9.Text) > Val(TextDM9.Text) Then
                    TextR9.BackColor = Color.Yellow
                End If
                If Val(TextD9.Text) < Val(TextDM9.Text) * -1 Then
                    TextR9.BackColor = Color.Yellow
                End If
                If Val(TextD9.Text) > Val(TextDM9.Text) * 2 Then
                    TextR9.BackColor = Color.Red
                End If
                If Val(TextD9.Text) < Val(TextDM9.Text) * -2 Then
                    TextR9.BackColor = Color.Red
                End If
                difreal = Val(TextL9.Text) - Val(TextVR9.Text)
                TextDR9.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL10.Text.Length > 0 And TextVR10.Text.Length > 0 Then
                promedio = Val((TextL10.Text) + Val(TextVR10.Text)) / 2
                valor1 = Val(TextL10.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD10.Text = Math.Round(valor4, 3)
                TextP10.Text = Math.Round((Val(TextL10.Text) + Val(TextVR10.Text)) / 2, 3)
                If Val(TextD10.Text) <= Val(TextDM10.Text) Then
                    TextR10.BackColor = Color.Green
                End If
                If Val(TextD10.Text) >= Val(TextDM10.Text) * -1 Then
                    TextR10.BackColor = Color.Green
                End If
                If Val(TextD10.Text) > Val(TextDM10.Text) Then
                    TextR10.BackColor = Color.Yellow
                End If
                If Val(TextD10.Text) < Val(TextDM10.Text) * -1 Then
                    TextR10.BackColor = Color.Yellow
                End If
                If Val(TextD10.Text) > Val(TextDM10.Text) * 2 Then
                    TextR10.BackColor = Color.Red
                End If
                If Val(TextD10.Text) < Val(TextDM10.Text) * -2 Then
                    TextR10.BackColor = Color.Red
                End If
                difreal = Val(TextL10.Text) - Val(TextVR10.Text)
                TextDR10.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL11.Text.Length > 0 And TextVR11.Text.Length > 0 Then
                promedio = Val((TextL11.Text) + Val(TextVR11.Text)) / 2
                valor1 = Val(TextL11.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD11.Text = Math.Round(valor4, 3)
                TextP11.Text = Math.Round((Val(TextL11.Text) + Val(TextVR11.Text)) / 2, 3)
                If Val(TextD11.Text) <= Val(TextDM11.Text) Then
                    TextR11.BackColor = Color.Green
                End If
                If Val(TextD11.Text) >= Val(TextDM11.Text) * -1 Then
                    TextR11.BackColor = Color.Green
                End If
                If Val(TextD11.Text) > Val(TextDM11.Text) Then
                    TextR11.BackColor = Color.Yellow
                End If
                If Val(TextD11.Text) < Val(TextDM11.Text) * -1 Then
                    TextR11.BackColor = Color.Yellow
                End If
                If Val(TextD11.Text) > Val(TextDM11.Text) * 2 Then
                    TextR11.BackColor = Color.Red
                End If
                If Val(TextD11.Text) < Val(TextDM11.Text) * -2 Then
                    TextR11.BackColor = Color.Red
                End If
                difreal = Val(TextL11.Text) - Val(TextVR11.Text)
                TextDR11.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
        ElseIf RadioCrioscopia.Checked = True Then
            If TextL1.Text.Length > 0 And TextVR1.Text.Length > 0 Then
                TextD1.Text = Math.Round(Val(TextVR1.Text) - Val(TextL1.Text), 3)
                TextP1.Text = Math.Round((Val(TextL1.Text) + Val(TextVR1.Text)) / 2, 3)
                If Val(TextD1.Text) <= Val(TextDM1.Text) Then
                    TextR1.BackColor = Color.Green
                End If
                If Val(TextD1.Text) >= Val(TextDM1.Text) * -1 Then
                    TextR1.BackColor = Color.Green
                End If
                If Val(TextD1.Text) > Val(TextDM1.Text) Then
                    TextR1.BackColor = Color.Yellow
                End If
                If Val(TextD1.Text) < Val(TextDM1.Text) * -1 Then
                    TextR1.BackColor = Color.Yellow
                End If
                If Val(TextD1.Text) > Val(TextDM1.Text) * 2 Then
                    TextR1.BackColor = Color.Red
                End If
                If Val(TextD1.Text) < Val(TextDM1.Text) * -2 Then
                    TextR1.BackColor = Color.Red
                End If
                difreal = Val(TextL1.Text) - Val(TextVR1.Text)
                TextDR1.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL2.Text.Length > 0 And TextVR2.Text.Length > 0 Then
                TextD2.Text = Math.Round(Val(TextVR2.Text) - Val(TextL2.Text), 3)
                TextP2.Text = Math.Round((Val(TextL2.Text) + Val(TextVR2.Text)) / 2, 3)
                If Val(TextD2.Text) <= Val(TextDM2.Text) Then
                    TextR2.BackColor = Color.Green
                End If
                If Val(TextD2.Text) >= Val(TextDM2.Text) * -1 Then
                    TextR2.BackColor = Color.Green
                End If
                If Val(TextD2.Text) > Val(TextDM2.Text) Then
                    TextR2.BackColor = Color.Yellow
                End If
                If Val(TextD2.Text) < Val(TextDM2.Text) * -1 Then
                    TextR2.BackColor = Color.Yellow
                End If
                If Val(TextD2.Text) > Val(TextDM2.Text) * 2 Then
                    TextR2.BackColor = Color.Red
                End If
                If Val(TextD2.Text) < Val(TextDM2.Text) * -2 Then
                    TextR2.BackColor = Color.Red
                End If
                difreal = Val(TextL2.Text) - Val(TextVR2.Text)
                TextDR2.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL3.Text.Length > 0 And TextVR3.Text.Length > 0 Then
                TextD3.Text = Math.Round(Val(TextVR3.Text) - Val(TextL3.Text), 3)
                TextP3.Text = Math.Round((Val(TextL3.Text) + Val(TextVR3.Text)) / 2, 3)
                If Val(TextD3.Text) <= Val(TextDM3.Text) Then
                    TextR3.BackColor = Color.Green
                End If
                If Val(TextD3.Text) >= Val(TextDM3.Text) * -1 Then
                    TextR3.BackColor = Color.Green
                End If
                If Val(TextD3.Text) > Val(TextDM3.Text) Then
                    TextR3.BackColor = Color.Yellow
                End If
                If Val(TextD3.Text) < Val(TextDM3.Text) * -1 Then
                    TextR3.BackColor = Color.Yellow
                End If
                If Val(TextD3.Text) > Val(TextDM3.Text) * 2 Then
                    TextR3.BackColor = Color.Red
                End If
                If Val(TextD3.Text) < Val(TextDM3.Text) * -2 Then
                    TextR3.BackColor = Color.Red
                End If
                difreal = Val(TextL3.Text) - Val(TextVR3.Text)
                TextDR3.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL4.Text.Length > 0 And TextVR4.Text.Length > 0 Then
                TextD4.Text = Math.Round(Val(TextVR4.Text) - Val(TextL4.Text), 3)
                TextP4.Text = Math.Round((Val(TextL4.Text) + Val(TextVR4.Text)) / 2, 3)
                If Val(TextD4.Text) <= Val(TextDM4.Text) Then
                    TextR4.BackColor = Color.Green
                End If
                If Val(TextD4.Text) >= Val(TextDM4.Text) * -1 Then
                    TextR4.BackColor = Color.Green
                End If
                If Val(TextD4.Text) > Val(TextDM4.Text) Then
                    TextR4.BackColor = Color.Yellow
                End If
                If Val(TextD4.Text) < Val(TextDM4.Text) * -1 Then
                    TextR4.BackColor = Color.Yellow
                End If
                If Val(TextD4.Text) > Val(TextDM4.Text) * 2 Then
                    TextR4.BackColor = Color.Red
                End If
                If Val(TextD4.Text) < Val(TextDM4.Text) * -2 Then
                    TextR4.BackColor = Color.Red
                End If
                difreal = Val(TextL4.Text) - Val(TextVR4.Text)
                TextDR4.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL5.Text.Length > 0 And TextVR5.Text.Length > 0 Then
                TextD5.Text = Math.Round(Val(TextVR5.Text) - Val(TextL5.Text), 3)
                TextP5.Text = Math.Round((Val(TextL5.Text) + Val(TextVR5.Text)) / 2, 3)
                If Val(TextD5.Text) <= Val(TextDM5.Text) Then
                    TextR5.BackColor = Color.Green
                End If
                If Val(TextD5.Text) >= Val(TextDM5.Text) * -1 Then
                    TextR5.BackColor = Color.Green
                End If
                If Val(TextD5.Text) > Val(TextDM5.Text) Then
                    TextR5.BackColor = Color.Yellow
                End If
                If Val(TextD5.Text) < Val(TextDM5.Text) * -1 Then
                    TextR5.BackColor = Color.Yellow
                End If
                If Val(TextD5.Text) > Val(TextDM5.Text) * 2 Then
                    TextR5.BackColor = Color.Red
                End If
                If Val(TextD5.Text) < Val(TextDM5.Text) * -2 Then
                    TextR5.BackColor = Color.Red
                End If
                difreal = Val(TextL5.Text) - Val(TextVR5.Text)
                TextDR5.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL6.Text.Length > 0 And TextVR6.Text.Length > 0 Then
                TextD6.Text = Math.Round(Val(TextVR6.Text) - Val(TextL6.Text), 3)
                TextP6.Text = Math.Round((Val(TextL6.Text) + Val(TextVR6.Text)) / 2, 3)
                If Val(TextD6.Text) <= Val(TextDM6.Text) Then
                    TextR6.BackColor = Color.Green
                End If
                If Val(TextD6.Text) >= Val(TextDM6.Text) * -1 Then
                    TextR6.BackColor = Color.Green
                End If
                If Val(TextD6.Text) > Val(TextDM6.Text) Then
                    TextR6.BackColor = Color.Yellow
                End If
                If Val(TextD6.Text) < Val(TextDM6.Text) * -1 Then
                    TextR6.BackColor = Color.Yellow
                End If
                If Val(TextD6.Text) > Val(TextDM6.Text) * 2 Then
                    TextR6.BackColor = Color.Red
                End If
                If Val(TextD6.Text) < Val(TextDM6.Text) * -2 Then
                    TextR6.BackColor = Color.Red
                End If
                difreal = Val(TextL6.Text) - Val(TextVR6.Text)
                TextDR6.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL7.Text.Length > 0 And TextVR7.Text.Length > 0 Then
                TextD7.Text = Math.Round(Val(TextVR7.Text) - Val(TextL7.Text), 3)
                TextP7.Text = Math.Round((Val(TextL7.Text) + Val(TextVR7.Text)) / 2, 3)
                If Val(TextD7.Text) <= Val(TextDM7.Text) Then
                    TextR7.BackColor = Color.Green
                End If
                If Val(TextD7.Text) >= Val(TextDM7.Text) * -1 Then
                    TextR7.BackColor = Color.Green
                End If
                If Val(TextD7.Text) > Val(TextDM7.Text) Then
                    TextR7.BackColor = Color.Yellow
                End If
                If Val(TextD7.Text) < Val(TextDM7.Text) * -1 Then
                    TextR7.BackColor = Color.Yellow
                End If
                If Val(TextD7.Text) > Val(TextDM7.Text) * 2 Then
                    TextR7.BackColor = Color.Red
                End If
                If Val(TextD7.Text) < Val(TextDM7.Text) * -2 Then
                    TextR7.BackColor = Color.Red
                End If
                difreal = Val(TextL7.Text) - Val(TextVR7.Text)
                TextDR7.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL8.Text.Length > 0 And TextVR8.Text.Length > 0 Then
                TextD8.Text = Math.Round(Val(TextVR8.Text) - Val(TextL8.Text), 3)
                TextP8.Text = Math.Round((Val(TextL8.Text) + Val(TextVR8.Text)) / 2, 3)
                If Val(TextD8.Text) <= Val(TextDM8.Text) Then
                    TextR8.BackColor = Color.Green
                End If
                If Val(TextD8.Text) >= Val(TextDM8.Text) * -1 Then
                    TextR8.BackColor = Color.Green
                End If
                If Val(TextD8.Text) > Val(TextDM8.Text) Then
                    TextR8.BackColor = Color.Yellow
                End If
                If Val(TextD8.Text) < Val(TextDM8.Text) * -1 Then
                    TextR8.BackColor = Color.Yellow
                End If
                If Val(TextD8.Text) > Val(TextDM8.Text) * 2 Then
                    TextR8.BackColor = Color.Red
                End If
                If Val(TextD8.Text) < Val(TextDM8.Text) * -2 Then
                    TextR8.BackColor = Color.Red
                End If
                difreal = Val(TextL8.Text) - Val(TextVR8.Text)
                TextDR8.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL9.Text.Length > 0 And TextVR9.Text.Length > 0 Then
                TextD9.Text = Math.Round(Val(TextVR9.Text) - Val(TextL9.Text), 3)
                TextP9.Text = Math.Round((Val(TextL9.Text) + Val(TextVR9.Text)) / 2, 3)
                If Val(TextD9.Text) <= Val(TextDM9.Text) Then
                    TextR9.BackColor = Color.Green
                End If
                If Val(TextD9.Text) >= Val(TextDM9.Text) * -1 Then
                    TextR9.BackColor = Color.Green
                End If
                If Val(TextD9.Text) > Val(TextDM9.Text) Then
                    TextR9.BackColor = Color.Yellow
                End If
                If Val(TextD9.Text) < Val(TextDM9.Text) * -1 Then
                    TextR9.BackColor = Color.Yellow
                End If
                If Val(TextD9.Text) > Val(TextDM9.Text) * 2 Then
                    TextR9.BackColor = Color.Red
                End If
                If Val(TextD9.Text) < Val(TextDM9.Text) * -2 Then
                    TextR9.BackColor = Color.Red
                End If
                difreal = Val(TextL9.Text) - Val(TextVR9.Text)
                TextDR9.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL10.Text.Length > 0 And TextVR10.Text.Length > 0 Then
                TextD10.Text = Math.Round(Val(TextVR10.Text) - Val(TextL10.Text), 3)
                TextP10.Text = Math.Round((Val(TextL10.Text) + Val(TextVR10.Text)) / 2, 3)
                If Val(TextD10.Text) <= Val(TextDM10.Text) Then
                    TextR10.BackColor = Color.Green
                End If
                If Val(TextD10.Text) >= Val(TextDM10.Text) * -1 Then
                    TextR10.BackColor = Color.Green
                End If
                If Val(TextD10.Text) > Val(TextDM10.Text) Then
                    TextR10.BackColor = Color.Yellow
                End If
                If Val(TextD10.Text) < Val(TextDM10.Text) * -1 Then
                    TextR10.BackColor = Color.Yellow
                End If
                If Val(TextD10.Text) > Val(TextDM10.Text) * 2 Then
                    TextR10.BackColor = Color.Red
                End If
                If Val(TextD10.Text) < Val(TextDM10.Text) * -2 Then
                    TextR10.BackColor = Color.Red
                End If
                difreal = Val(TextL10.Text) - Val(TextVR10.Text)
                TextDR10.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL11.Text.Length > 0 And TextVR11.Text.Length > 0 Then
                TextD11.Text = Math.Round(Val(TextVR11.Text) - Val(TextL11.Text), 3)
                TextP11.Text = Math.Round((Val(TextL11.Text) + Val(TextVR11.Text)) / 2, 3)
                If Val(TextD11.Text) <= Val(TextDM11.Text) Then
                    TextR11.BackColor = Color.Green
                End If
                If Val(TextD11.Text) >= Val(TextDM11.Text) * -1 Then
                    TextR11.BackColor = Color.Green
                End If
                If Val(TextD11.Text) > Val(TextDM11.Text) Then
                    TextR11.BackColor = Color.Yellow
                End If
                If Val(TextD11.Text) < Val(TextDM11.Text) * -1 Then
                    TextR11.BackColor = Color.Yellow
                End If
                If Val(TextD11.Text) > Val(TextDM11.Text) * 2 Then
                    TextR11.BackColor = Color.Red
                End If
                If Val(TextD11.Text) < Val(TextDM11.Text) * -2 Then
                    TextR11.BackColor = Color.Red
                End If
                difreal = Val(TextL11.Text) - Val(TextVR11.Text)
                TextDR11.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
        ElseIf RadioUrea.Checked = True Then
            If TextL1.Text.Length > 0 And TextVR1.Text.Length > 0 Then
                TextD1.Text = Math.Round(Val(TextVR1.Text) - Val(TextL1.Text), 3)
                TextP1.Text = Math.Round((Val(TextL1.Text) + Val(TextVR1.Text)) / 2, 3)
                If Val(TextD1.Text) <= Val(TextDM1.Text) Then
                    TextR1.BackColor = Color.Green
                End If
                If Val(TextD1.Text) >= Val(TextDM1.Text) * -1 Then
                    TextR1.BackColor = Color.Green
                End If
                If Val(TextD1.Text) > Val(TextDM1.Text) Then
                    TextR1.BackColor = Color.Yellow
                End If
                If Val(TextD1.Text) < Val(TextDM1.Text) * -1 Then
                    TextR1.BackColor = Color.Yellow
                End If
                If Val(TextD1.Text) > Val(TextDM1.Text) * 2 Then
                    TextR1.BackColor = Color.Red
                End If
                If Val(TextD1.Text) < Val(TextDM1.Text) * -2 Then
                    TextR1.BackColor = Color.Red
                End If
                difreal = Val(TextL1.Text) - Val(TextVR1.Text)
                TextDR1.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL2.Text.Length > 0 And TextVR2.Text.Length > 0 Then
                TextD2.Text = Math.Round(Val(TextVR2.Text) - Val(TextL2.Text), 3)
                TextP2.Text = Math.Round((Val(TextL2.Text) + Val(TextVR2.Text)) / 2, 3)
                If Val(TextD2.Text) <= Val(TextDM2.Text) Then
                    TextR2.BackColor = Color.Green
                End If
                If Val(TextD2.Text) >= Val(TextDM2.Text) * -1 Then
                    TextR2.BackColor = Color.Green
                End If
                If Val(TextD2.Text) > Val(TextDM2.Text) Then
                    TextR2.BackColor = Color.Yellow
                End If
                If Val(TextD2.Text) < Val(TextDM2.Text) * -1 Then
                    TextR2.BackColor = Color.Yellow
                End If
                If Val(TextD2.Text) > Val(TextDM2.Text) * 2 Then
                    TextR2.BackColor = Color.Red
                End If
                If Val(TextD2.Text) < Val(TextDM2.Text) * -2 Then
                    TextR2.BackColor = Color.Red
                End If
                difreal = Val(TextL2.Text) - Val(TextVR2.Text)
                TextDR2.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL3.Text.Length > 0 And TextVR3.Text.Length > 0 Then
                TextD3.Text = Math.Round(Val(TextVR3.Text) - Val(TextL3.Text), 3)
                TextP3.Text = Math.Round((Val(TextL3.Text) + Val(TextVR3.Text)) / 2, 3)
                If Val(TextD3.Text) <= Val(TextDM3.Text) Then
                    TextR3.BackColor = Color.Green
                End If
                If Val(TextD3.Text) >= Val(TextDM3.Text) * -1 Then
                    TextR3.BackColor = Color.Green
                End If
                If Val(TextD3.Text) > Val(TextDM3.Text) Then
                    TextR3.BackColor = Color.Yellow
                End If
                If Val(TextD3.Text) < Val(TextDM3.Text) * -1 Then
                    TextR3.BackColor = Color.Yellow
                End If
                If Val(TextD3.Text) > Val(TextDM3.Text) * 2 Then
                    TextR3.BackColor = Color.Red
                End If
                If Val(TextD3.Text) < Val(TextDM3.Text) * -2 Then
                    TextR3.BackColor = Color.Red
                End If
                difreal = Val(TextL3.Text) - Val(TextVR3.Text)
                TextDR3.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL4.Text.Length > 0 And TextVR4.Text.Length > 0 Then
                TextD4.Text = Math.Round(Val(TextVR4.Text) - Val(TextL4.Text), 3)
                TextP4.Text = Math.Round((Val(TextL4.Text) + Val(TextVR4.Text)) / 2, 3)
                If Val(TextD4.Text) <= Val(TextDM4.Text) Then
                    TextR4.BackColor = Color.Green
                End If
                If Val(TextD4.Text) >= Val(TextDM4.Text) * -1 Then
                    TextR4.BackColor = Color.Green
                End If
                If Val(TextD4.Text) > Val(TextDM4.Text) Then
                    TextR4.BackColor = Color.Yellow
                End If
                If Val(TextD4.Text) < Val(TextDM4.Text) * -1 Then
                    TextR4.BackColor = Color.Yellow
                End If
                If Val(TextD4.Text) > Val(TextDM4.Text) * 2 Then
                    TextR4.BackColor = Color.Red
                End If
                If Val(TextD4.Text) < Val(TextDM4.Text) * -2 Then
                    TextR4.BackColor = Color.Red
                End If
                difreal = Val(TextL4.Text) - Val(TextVR4.Text)
                TextDR4.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL5.Text.Length > 0 And TextVR5.Text.Length > 0 Then
                TextD5.Text = Math.Round(Val(TextVR5.Text) - Val(TextL5.Text), 3)
                TextP5.Text = Math.Round((Val(TextL5.Text) + Val(TextVR5.Text)) / 2, 3)
                If Val(TextD5.Text) <= Val(TextDM5.Text) Then
                    TextR5.BackColor = Color.Green
                End If
                If Val(TextD5.Text) >= Val(TextDM5.Text) * -1 Then
                    TextR5.BackColor = Color.Green
                End If
                If Val(TextD5.Text) > Val(TextDM5.Text) Then
                    TextR5.BackColor = Color.Yellow
                End If
                If Val(TextD5.Text) < Val(TextDM5.Text) * -1 Then
                    TextR5.BackColor = Color.Yellow
                End If
                If Val(TextD5.Text) > Val(TextDM5.Text) * 2 Then
                    TextR5.BackColor = Color.Red
                End If
                If Val(TextD5.Text) < Val(TextDM5.Text) * -2 Then
                    TextR5.BackColor = Color.Red
                End If
                difreal = Val(TextL5.Text) - Val(TextVR5.Text)
                TextDR5.Text = Math.Round(difreal, 3)
                difreal = 0

            End If
            If TextL6.Text.Length > 0 And TextVR6.Text.Length > 0 Then
                TextD6.Text = Math.Round(Val(TextVR6.Text) - Val(TextL6.Text), 3)
                TextP6.Text = Math.Round((Val(TextL6.Text) + Val(TextVR6.Text)) / 2, 3)
                If Val(TextD6.Text) <= Val(TextDM6.Text) Then
                    TextR6.BackColor = Color.Green
                End If
                If Val(TextD6.Text) >= Val(TextDM6.Text) * -1 Then
                    TextR6.BackColor = Color.Green
                End If
                If Val(TextD6.Text) > Val(TextDM6.Text) Then
                    TextR6.BackColor = Color.Yellow
                End If
                If Val(TextD6.Text) < Val(TextDM6.Text) * -1 Then
                    TextR6.BackColor = Color.Yellow
                End If
                If Val(TextD6.Text) > Val(TextDM6.Text) * 2 Then
                    TextR6.BackColor = Color.Red
                End If
                If Val(TextD6.Text) < Val(TextDM6.Text) * -2 Then
                    TextR6.BackColor = Color.Red
                End If
                difreal = Val(TextL6.Text) - Val(TextVR6.Text)
                TextDR6.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL7.Text.Length > 0 And TextVR7.Text.Length > 0 Then
                TextD7.Text = Math.Round(Val(TextVR7.Text) - Val(TextL7.Text), 3)
                TextP7.Text = Math.Round((Val(TextL7.Text) + Val(TextVR7.Text)) / 2, 3)
                If Val(TextD7.Text) <= Val(TextDM7.Text) Then
                    TextR7.BackColor = Color.Green
                End If
                If Val(TextD7.Text) >= Val(TextDM7.Text) * -1 Then
                    TextR7.BackColor = Color.Green
                End If
                If Val(TextD7.Text) > Val(TextDM7.Text) Then
                    TextR7.BackColor = Color.Yellow
                End If
                If Val(TextD7.Text) < Val(TextDM7.Text) * -1 Then
                    TextR7.BackColor = Color.Yellow
                End If
                If Val(TextD7.Text) > Val(TextDM7.Text) * 2 Then
                    TextR7.BackColor = Color.Red
                End If
                If Val(TextD7.Text) < Val(TextDM7.Text) * -2 Then
                    TextR7.BackColor = Color.Red
                End If
                difreal = Val(TextL7.Text) - Val(TextVR7.Text)
                TextDR7.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL8.Text.Length > 0 And TextVR8.Text.Length > 0 Then
                TextD8.Text = Math.Round(Val(TextVR8.Text) - Val(TextL8.Text), 3)
                TextP8.Text = Math.Round((Val(TextL8.Text) + Val(TextVR8.Text)) / 2, 3)
                If Val(TextD8.Text) <= Val(TextDM8.Text) Then
                    TextR8.BackColor = Color.Green
                End If
                If Val(TextD8.Text) >= Val(TextDM8.Text) * -1 Then
                    TextR8.BackColor = Color.Green
                End If
                If Val(TextD8.Text) > Val(TextDM8.Text) Then
                    TextR8.BackColor = Color.Yellow
                End If
                If Val(TextD8.Text) < Val(TextDM8.Text) * -1 Then
                    TextR8.BackColor = Color.Yellow
                End If
                If Val(TextD8.Text) > Val(TextDM8.Text) * 2 Then
                    TextR8.BackColor = Color.Red
                End If
                If Val(TextD8.Text) < Val(TextDM8.Text) * -2 Then
                    TextR8.BackColor = Color.Red
                End If
                difreal = Val(TextL8.Text) - Val(TextVR8.Text)
                TextDR8.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL9.Text.Length > 0 And TextVR9.Text.Length > 0 Then
                TextD9.Text = Math.Round(Val(TextVR9.Text) - Val(TextL9.Text), 3)
                TextP9.Text = Math.Round((Val(TextL9.Text) + Val(TextVR9.Text)) / 2, 3)
                If Val(TextD9.Text) <= Val(TextDM9.Text) Then
                    TextR9.BackColor = Color.Green
                End If
                If Val(TextD9.Text) >= Val(TextDM9.Text) * -1 Then
                    TextR9.BackColor = Color.Green
                End If
                If Val(TextD9.Text) > Val(TextDM9.Text) Then
                    TextR9.BackColor = Color.Yellow
                End If
                If Val(TextD9.Text) < Val(TextDM9.Text) * -1 Then
                    TextR9.BackColor = Color.Yellow
                End If
                If Val(TextD9.Text) > Val(TextDM9.Text) * 2 Then
                    TextR9.BackColor = Color.Red
                End If
                If Val(TextD9.Text) < Val(TextDM9.Text) * -2 Then
                    TextR9.BackColor = Color.Red
                End If
                difreal = Val(TextL9.Text) - Val(TextVR9.Text)
                TextDR9.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL10.Text.Length > 0 And TextVR10.Text.Length > 0 Then
                TextD10.Text = Math.Round(Val(TextVR10.Text) - Val(TextL10.Text), 3)
                TextP10.Text = Math.Round((Val(TextL10.Text) + Val(TextVR10.Text)) / 2, 3)
                If Val(TextD10.Text) <= Val(TextDM10.Text) Then
                    TextR10.BackColor = Color.Green
                End If
                If Val(TextD10.Text) >= Val(TextDM10.Text) * -1 Then
                    TextR10.BackColor = Color.Green
                End If
                If Val(TextD10.Text) > Val(TextDM10.Text) Then
                    TextR10.BackColor = Color.Yellow
                End If
                If Val(TextD10.Text) < Val(TextDM10.Text) * -1 Then
                    TextR10.BackColor = Color.Yellow
                End If
                If Val(TextD10.Text) > Val(TextDM10.Text) * 2 Then
                    TextR10.BackColor = Color.Red
                End If
                If Val(TextD10.Text) < Val(TextDM10.Text) * -2 Then
                    TextR10.BackColor = Color.Red
                End If
                difreal = Val(TextL10.Text) - Val(TextVR10.Text)
                TextDR10.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL11.Text.Length > 0 And TextVR11.Text.Length > 0 Then
                TextD11.Text = Math.Round(Val(TextVR11.Text) - Val(TextL11.Text), 3)
                TextP11.Text = Math.Round((Val(TextL11.Text) + Val(TextVR11.Text)) / 2, 3)
                If Val(TextD11.Text) <= Val(TextDM11.Text) Then
                    TextR11.BackColor = Color.Green
                End If
                If Val(TextD11.Text) >= Val(TextDM11.Text) * -1 Then
                    TextR11.BackColor = Color.Green
                End If
                If Val(TextD11.Text) > Val(TextDM11.Text) Then
                    TextR11.BackColor = Color.Yellow
                End If
                If Val(TextD11.Text) < Val(TextDM11.Text) * -1 Then
                    TextR11.BackColor = Color.Yellow
                End If
                If Val(TextD11.Text) > Val(TextDM11.Text) * 2 Then
                    TextR11.BackColor = Color.Red
                End If
                If Val(TextD11.Text) < Val(TextDM11.Text) * -2 Then
                    TextR11.BackColor = Color.Red
                End If
                difreal = Val(TextL11.Text) - Val(TextVR11.Text)
                TextDR11.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
        ElseIf RadioProteinaV.Checked = True Then
            If TextL1.Text.Length > 0 And TextVR1.Text.Length > 0 Then
                promedio = Val((TextL1.Text) + Val(TextVR1.Text)) / 2
                valor1 = Val(TextL1.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD1.Text = Math.Round(valor4, 3)
                TextP1.Text = Math.Round((Val(TextL1.Text) + Val(TextVR1.Text)) / 2, 3)
                If Val(TextD1.Text) <= Val(TextDM1.Text) Then
                    TextR1.BackColor = Color.Green
                End If
                If Val(TextD1.Text) >= Val(TextDM1.Text) * -1 Then
                    TextR1.BackColor = Color.Green
                End If
                If Val(TextD1.Text) > Val(TextDM1.Text) Then
                    TextR1.BackColor = Color.Yellow
                End If
                If Val(TextD1.Text) < Val(TextDM1.Text) * -1 Then
                    TextR1.BackColor = Color.Yellow
                End If
                If Val(TextD1.Text) > Val(TextDM1.Text) * 2 Then
                    TextR1.BackColor = Color.Red
                End If
                If Val(TextD1.Text) < Val(TextDM1.Text) * -2 Then
                    TextR1.BackColor = Color.Red
                End If
                difreal = Val(TextL1.Text) - Val(TextVR1.Text)
                TextDR1.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL2.Text.Length > 0 And TextVR2.Text.Length > 0 Then
                promedio = Val((TextL2.Text) + Val(TextVR2.Text)) / 2
                valor1 = Val(TextL2.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD2.Text = Math.Round(valor4, 3)
                TextP2.Text = Math.Round((Val(TextL2.Text) + Val(TextVR2.Text)) / 2, 3)
                If Val(TextD2.Text) <= Val(TextDM2.Text) Then
                    TextR2.BackColor = Color.Green
                End If
                If Val(TextD2.Text) >= Val(TextDM2.Text) * -1 Then
                    TextR2.BackColor = Color.Green
                End If
                If Val(TextD2.Text) > Val(TextDM2.Text) Then
                    TextR2.BackColor = Color.Yellow
                End If
                If Val(TextD2.Text) < Val(TextDM2.Text) * -1 Then
                    TextR2.BackColor = Color.Yellow
                End If
                If Val(TextD2.Text) > Val(TextDM2.Text) * 2 Then
                    TextR2.BackColor = Color.Red
                End If
                If Val(TextD2.Text) < Val(TextDM2.Text) * -2 Then
                    TextR2.BackColor = Color.Red
                End If
                difreal = Val(TextL2.Text) - Val(TextVR2.Text)
                TextDR2.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL3.Text.Length > 0 And TextVR3.Text.Length > 0 Then
                promedio = Val((TextL3.Text) + Val(TextVR3.Text)) / 2
                valor1 = Val(TextL3.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD3.Text = Math.Round(valor4, 3)
                TextP3.Text = Math.Round((Val(TextL3.Text) + Val(TextVR3.Text)) / 2, 3)
                If Val(TextD3.Text) <= Val(TextDM3.Text) Then
                    TextR3.BackColor = Color.Green
                End If
                If Val(TextD3.Text) >= Val(TextDM3.Text) * -1 Then
                    TextR3.BackColor = Color.Green
                End If
                If Val(TextD3.Text) > Val(TextDM3.Text) Then
                    TextR3.BackColor = Color.Yellow
                End If
                If Val(TextD3.Text) < Val(TextDM3.Text) * -1 Then
                    TextR3.BackColor = Color.Yellow
                End If
                If Val(TextD3.Text) > Val(TextDM3.Text) * 2 Then
                    TextR3.BackColor = Color.Red
                End If
                If Val(TextD3.Text) < Val(TextDM3.Text) * -2 Then
                    TextR3.BackColor = Color.Red
                End If
                difreal = Val(TextL3.Text) - Val(TextVR3.Text)
                TextDR3.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL4.Text.Length > 0 And TextVR4.Text.Length > 0 Then
                promedio = Val((TextL4.Text) + Val(TextVR4.Text)) / 2
                valor1 = Val(TextL4.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD4.Text = Math.Round(valor4, 3)
                TextP4.Text = Math.Round((Val(TextL4.Text) + Val(TextVR4.Text)) / 2, 3)
                If Val(TextD4.Text) <= Val(TextDM4.Text) Then
                    TextR4.BackColor = Color.Green
                End If
                If Val(TextD4.Text) >= Val(TextDM4.Text) * -1 Then
                    TextR4.BackColor = Color.Green
                End If
                If Val(TextD4.Text) > Val(TextDM4.Text) Then
                    TextR4.BackColor = Color.Yellow
                End If
                If Val(TextD4.Text) < Val(TextDM4.Text) * -1 Then
                    TextR4.BackColor = Color.Yellow
                End If
                If Val(TextD4.Text) > Val(TextDM4.Text) * 2 Then
                    TextR4.BackColor = Color.Red
                End If
                If Val(TextD4.Text) < Val(TextDM4.Text) * -2 Then
                    TextR4.BackColor = Color.Red
                End If
                difreal = Val(TextL4.Text) - Val(TextVR4.Text)
                TextDR4.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL5.Text.Length > 0 And TextVR5.Text.Length > 0 Then
                promedio = Val((TextL5.Text) + Val(TextVR5.Text)) / 2
                valor1 = Val(TextL5.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD5.Text = Math.Round(valor4, 3)
                TextP5.Text = Math.Round((Val(TextL5.Text) + Val(TextVR5.Text)) / 2, 3)
                If Val(TextD5.Text) <= Val(TextDM5.Text) Then
                    TextR5.BackColor = Color.Green
                End If
                If Val(TextD5.Text) >= Val(TextDM5.Text) * -1 Then
                    TextR5.BackColor = Color.Green
                End If
                If Val(TextD5.Text) > Val(TextDM5.Text) Then
                    TextR5.BackColor = Color.Yellow
                End If
                If Val(TextD5.Text) < Val(TextDM5.Text) * -1 Then
                    TextR5.BackColor = Color.Yellow
                End If
                If Val(TextD5.Text) > Val(TextDM5.Text) * 2 Then
                    TextR5.BackColor = Color.Red
                End If
                If Val(TextD5.Text) < Val(TextDM5.Text) * -2 Then
                    TextR5.BackColor = Color.Red
                End If
                difreal = Val(TextL5.Text) - Val(TextVR5.Text)
                TextDR5.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL6.Text.Length > 0 And TextVR6.Text.Length > 0 Then
                promedio = Val((TextL6.Text) + Val(TextVR6.Text)) / 2
                valor1 = Val(TextL6.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD6.Text = Math.Round(valor4, 3)
                TextP6.Text = Math.Round((Val(TextL6.Text) + Val(TextVR6.Text)) / 2, 3)
                If Val(TextD6.Text) <= Val(TextDM6.Text) Then
                    TextR6.BackColor = Color.Green
                End If
                If Val(TextD6.Text) >= Val(TextDM6.Text) * -1 Then
                    TextR6.BackColor = Color.Green
                End If
                If Val(TextD6.Text) > Val(TextDM6.Text) Then
                    TextR6.BackColor = Color.Yellow
                End If
                If Val(TextD6.Text) < Val(TextDM6.Text) * -1 Then
                    TextR6.BackColor = Color.Yellow
                End If
                If Val(TextD6.Text) > Val(TextDM6.Text) * 2 Then
                    TextR6.BackColor = Color.Red
                End If
                If Val(TextD6.Text) < Val(TextDM6.Text) * -2 Then
                    TextR6.BackColor = Color.Red
                End If
                difreal = Val(TextL6.Text) - Val(TextVR6.Text)
                TextDR6.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL7.Text.Length > 0 And TextVR7.Text.Length > 0 Then
                promedio = Val((TextL7.Text) + Val(TextVR7.Text)) / 2
                valor1 = Val(TextL7.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD7.Text = Math.Round(valor4, 3)
                TextP7.Text = Math.Round((Val(TextL7.Text) + Val(TextVR7.Text)) / 2, 3)
                If Val(TextD7.Text) <= Val(TextDM7.Text) Then
                    TextR7.BackColor = Color.Green
                End If
                If Val(TextD7.Text) >= Val(TextDM7.Text) * -1 Then
                    TextR7.BackColor = Color.Green
                End If
                If Val(TextD7.Text) > Val(TextDM7.Text) Then
                    TextR7.BackColor = Color.Yellow
                End If
                If Val(TextD7.Text) < Val(TextDM7.Text) * -1 Then
                    TextR7.BackColor = Color.Yellow
                End If
                If Val(TextD7.Text) > Val(TextDM7.Text) * 2 Then
                    TextR7.BackColor = Color.Red
                End If
                If Val(TextD7.Text) < Val(TextDM7.Text) * -2 Then
                    TextR7.BackColor = Color.Red
                End If
                difreal = Val(TextL7.Text) - Val(TextVR7.Text)
                TextDR7.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL8.Text.Length > 0 And TextVR8.Text.Length > 0 Then
                promedio = Val((TextL8.Text) + Val(TextVR8.Text)) / 2
                valor1 = Val(TextL8.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD8.Text = Math.Round(valor4, 3)
                TextP8.Text = Math.Round((Val(TextL8.Text) + Val(TextVR8.Text)) / 2, 3)
                If Val(TextD8.Text) <= Val(TextDM8.Text) Then
                    TextR8.BackColor = Color.Green
                End If
                If Val(TextD8.Text) >= Val(TextDM8.Text) * -1 Then
                    TextR8.BackColor = Color.Green
                End If
                If Val(TextD8.Text) > Val(TextDM8.Text) Then
                    TextR8.BackColor = Color.Yellow
                End If
                If Val(TextD8.Text) < Val(TextDM8.Text) * -1 Then
                    TextR8.BackColor = Color.Yellow
                End If
                If Val(TextD8.Text) > Val(TextDM8.Text) * 2 Then
                    TextR8.BackColor = Color.Red
                End If
                If Val(TextD8.Text) < Val(TextDM8.Text) * -2 Then
                    TextR8.BackColor = Color.Red
                End If
                difreal = Val(TextL8.Text) - Val(TextVR8.Text)
                TextDR8.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL9.Text.Length > 0 And TextVR9.Text.Length > 0 Then
                promedio = Val((TextL9.Text) + Val(TextVR9.Text)) / 2
                valor1 = Val(TextL9.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD9.Text = Math.Round(valor4, 3)
                TextP9.Text = Math.Round((Val(TextL9.Text) + Val(TextVR9.Text)) / 2, 3)
                If Val(TextD9.Text) <= Val(TextDM9.Text) Then
                    TextR9.BackColor = Color.Green
                End If
                If Val(TextD9.Text) >= Val(TextDM9.Text) * -1 Then
                    TextR9.BackColor = Color.Green
                End If
                If Val(TextD9.Text) > Val(TextDM9.Text) Then
                    TextR9.BackColor = Color.Yellow
                End If
                If Val(TextD9.Text) < Val(TextDM9.Text) * -1 Then
                    TextR9.BackColor = Color.Yellow
                End If
                If Val(TextD9.Text) > Val(TextDM9.Text) * 2 Then
                    TextR9.BackColor = Color.Red
                End If
                If Val(TextD9.Text) < Val(TextDM9.Text) * -2 Then
                    TextR9.BackColor = Color.Red
                End If
                difreal = Val(TextL9.Text) - Val(TextVR9.Text)
                TextDR9.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL10.Text.Length > 0 And TextVR10.Text.Length > 0 Then
                promedio = Val((TextL10.Text) + Val(TextVR10.Text)) / 2
                valor1 = Val(TextL10.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD10.Text = Math.Round(valor4, 3)
                TextP10.Text = Math.Round((Val(TextL10.Text) + Val(TextVR10.Text)) / 2, 3)
                If Val(TextD10.Text) <= Val(TextDM10.Text) Then
                    TextR10.BackColor = Color.Green
                End If
                If Val(TextD10.Text) >= Val(TextDM10.Text) * -1 Then
                    TextR10.BackColor = Color.Green
                End If
                If Val(TextD10.Text) > Val(TextDM10.Text) Then
                    TextR10.BackColor = Color.Yellow
                End If
                If Val(TextD10.Text) < Val(TextDM10.Text) * -1 Then
                    TextR10.BackColor = Color.Yellow
                End If
                If Val(TextD10.Text) > Val(TextDM10.Text) * 2 Then
                    TextR10.BackColor = Color.Red
                End If
                If Val(TextD10.Text) < Val(TextDM10.Text) * -2 Then
                    TextR10.BackColor = Color.Red
                End If
                difreal = Val(TextL10.Text) - Val(TextVR10.Text)
                TextDR10.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL11.Text.Length > 0 And TextVR11.Text.Length > 0 Then
                promedio = Val((TextL11.Text) + Val(TextVR11.Text)) / 2
                valor1 = Val(TextL11.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD11.Text = Math.Round(valor4, 3)
                TextP11.Text = Math.Round((Val(TextL11.Text) + Val(TextVR11.Text)) / 2, 3)
                If Val(TextD11.Text) <= Val(TextDM11.Text) Then
                    TextR11.BackColor = Color.Green
                End If
                If Val(TextD11.Text) >= Val(TextDM11.Text) * -1 Then
                    TextR11.BackColor = Color.Green
                End If
                If Val(TextD11.Text) > Val(TextDM11.Text) Then
                    TextR11.BackColor = Color.Yellow
                End If
                If Val(TextD11.Text) < Val(TextDM11.Text) * -1 Then
                    TextR11.BackColor = Color.Yellow
                End If
                If Val(TextD11.Text) > Val(TextDM11.Text) * 2 Then
                    TextR11.BackColor = Color.Red
                End If
                If Val(TextD11.Text) < Val(TextDM11.Text) * -2 Then
                    TextR11.BackColor = Color.Red
                End If
                difreal = Val(TextL11.Text) - Val(TextVR11.Text)
                TextDR11.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
        ElseIf RadioCaseina.Checked = True Then
            If TextL1.Text.Length > 0 And TextVR1.Text.Length > 0 Then
                promedio = Val((TextL1.Text) + Val(TextVR1.Text)) / 2
                valor1 = Val(TextL1.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD1.Text = Math.Round(valor4, 3)
                TextP1.Text = Math.Round((Val(TextL1.Text) + Val(TextVR1.Text)) / 2, 3)
                If Val(TextD1.Text) <= Val(TextDM1.Text) Then
                    TextR1.BackColor = Color.Green
                End If
                If Val(TextD1.Text) >= Val(TextDM1.Text) * -1 Then
                    TextR1.BackColor = Color.Green
                End If
                If Val(TextD1.Text) > Val(TextDM1.Text) Then
                    TextR1.BackColor = Color.Yellow
                End If
                If Val(TextD1.Text) < Val(TextDM1.Text) * -1 Then
                    TextR1.BackColor = Color.Yellow
                End If
                If Val(TextD1.Text) > Val(TextDM1.Text) * 2 Then
                    TextR1.BackColor = Color.Red
                End If
                If Val(TextD1.Text) < Val(TextDM1.Text) * -2 Then
                    TextR1.BackColor = Color.Red
                End If
                difreal = Val(TextL1.Text) - Val(TextVR1.Text)
                TextDR1.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL2.Text.Length > 0 And TextVR2.Text.Length > 0 Then
                promedio = Val((TextL2.Text) + Val(TextVR2.Text)) / 2
                valor1 = Val(TextL2.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD2.Text = Math.Round(valor4, 3)
                TextP2.Text = Math.Round((Val(TextL2.Text) + Val(TextVR2.Text)) / 2, 3)
                If Val(TextD2.Text) <= Val(TextDM2.Text) Then
                    TextR2.BackColor = Color.Green
                End If
                If Val(TextD2.Text) >= Val(TextDM2.Text) * -1 Then
                    TextR2.BackColor = Color.Green
                End If
                If Val(TextD2.Text) > Val(TextDM2.Text) Then
                    TextR2.BackColor = Color.Yellow
                End If
                If Val(TextD2.Text) < Val(TextDM2.Text) * -1 Then
                    TextR2.BackColor = Color.Yellow
                End If
                If Val(TextD2.Text) > Val(TextDM2.Text) * 2 Then
                    TextR2.BackColor = Color.Red
                End If
                If Val(TextD2.Text) < Val(TextDM2.Text) * -2 Then
                    TextR2.BackColor = Color.Red
                End If
                difreal = Val(TextL2.Text) - Val(TextVR2.Text)
                TextDR2.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL3.Text.Length > 0 And TextVR3.Text.Length > 0 Then
                promedio = Val((TextL3.Text) + Val(TextVR3.Text)) / 2
                valor1 = Val(TextL3.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD3.Text = Math.Round(valor4, 3)
                TextP3.Text = Math.Round((Val(TextL3.Text) + Val(TextVR3.Text)) / 2, 3)
                If Val(TextD3.Text) <= Val(TextDM3.Text) Then
                    TextR3.BackColor = Color.Green
                End If
                If Val(TextD3.Text) >= Val(TextDM3.Text) * -1 Then
                    TextR3.BackColor = Color.Green
                End If
                If Val(TextD3.Text) > Val(TextDM3.Text) Then
                    TextR3.BackColor = Color.Yellow
                End If
                If Val(TextD3.Text) < Val(TextDM3.Text) * -1 Then
                    TextR3.BackColor = Color.Yellow
                End If
                If Val(TextD3.Text) > Val(TextDM3.Text) * 2 Then
                    TextR3.BackColor = Color.Red
                End If
                If Val(TextD3.Text) < Val(TextDM3.Text) * -2 Then
                    TextR3.BackColor = Color.Red
                End If
                difreal = Val(TextL3.Text) - Val(TextVR3.Text)
                TextDR3.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL4.Text.Length > 0 And TextVR4.Text.Length > 0 Then
                promedio = Val((TextL4.Text) + Val(TextVR4.Text)) / 2
                valor1 = Val(TextL4.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD4.Text = Math.Round(valor4, 3)
                TextP4.Text = Math.Round((Val(TextL4.Text) + Val(TextVR4.Text)) / 2, 3)
                If Val(TextD4.Text) <= Val(TextDM4.Text) Then
                    TextR4.BackColor = Color.Green
                End If
                If Val(TextD4.Text) >= Val(TextDM4.Text) * -1 Then
                    TextR4.BackColor = Color.Green
                End If
                If Val(TextD4.Text) > Val(TextDM4.Text) Then
                    TextR4.BackColor = Color.Yellow
                End If
                If Val(TextD4.Text) < Val(TextDM4.Text) * -1 Then
                    TextR4.BackColor = Color.Yellow
                End If
                If Val(TextD4.Text) > Val(TextDM4.Text) * 2 Then
                    TextR4.BackColor = Color.Red
                End If
                If Val(TextD4.Text) < Val(TextDM4.Text) * -2 Then
                    TextR4.BackColor = Color.Red
                End If
                difreal = Val(TextL4.Text) - Val(TextVR4.Text)
                TextDR4.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL5.Text.Length > 0 And TextVR5.Text.Length > 0 Then
                promedio = Val((TextL5.Text) + Val(TextVR5.Text)) / 2
                valor1 = Val(TextL5.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD5.Text = Math.Round(valor4, 3)
                TextP5.Text = Math.Round((Val(TextL5.Text) + Val(TextVR5.Text)) / 2, 3)
                If Val(TextD5.Text) <= Val(TextDM5.Text) Then
                    TextR5.BackColor = Color.Green
                End If
                If Val(TextD5.Text) >= Val(TextDM5.Text) * -1 Then
                    TextR5.BackColor = Color.Green
                End If
                If Val(TextD5.Text) > Val(TextDM5.Text) Then
                    TextR5.BackColor = Color.Yellow
                End If
                If Val(TextD5.Text) < Val(TextDM5.Text) * -1 Then
                    TextR5.BackColor = Color.Yellow
                End If
                If Val(TextD5.Text) > Val(TextDM5.Text) * 2 Then
                    TextR5.BackColor = Color.Red
                End If
                If Val(TextD5.Text) < Val(TextDM5.Text) * -2 Then
                    TextR5.BackColor = Color.Red
                End If
                difreal = Val(TextL5.Text) - Val(TextVR5.Text)
                TextDR5.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL6.Text.Length > 0 And TextVR6.Text.Length > 0 Then
                promedio = Val((TextL6.Text) + Val(TextVR6.Text)) / 2
                valor1 = Val(TextL6.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD6.Text = Math.Round(valor4, 3)
                TextP6.Text = Math.Round((Val(TextL6.Text) + Val(TextVR6.Text)) / 2, 3)
                If Val(TextD6.Text) <= Val(TextDM6.Text) Then
                    TextR6.BackColor = Color.Green
                End If
                If Val(TextD6.Text) >= Val(TextDM6.Text) * -1 Then
                    TextR6.BackColor = Color.Green
                End If
                If Val(TextD6.Text) > Val(TextDM6.Text) Then
                    TextR6.BackColor = Color.Yellow
                End If
                If Val(TextD6.Text) < Val(TextDM6.Text) * -1 Then
                    TextR6.BackColor = Color.Yellow
                End If
                If Val(TextD6.Text) > Val(TextDM6.Text) * 2 Then
                    TextR6.BackColor = Color.Red
                End If
                If Val(TextD6.Text) < Val(TextDM6.Text) * -2 Then
                    TextR6.BackColor = Color.Red
                End If
                difreal = Val(TextL6.Text) - Val(TextVR6.Text)
                TextDR6.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL7.Text.Length > 0 And TextVR7.Text.Length > 0 Then
                promedio = Val((TextL7.Text) + Val(TextVR7.Text)) / 2
                valor1 = Val(TextL7.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD7.Text = Math.Round(valor4, 3)
                TextP7.Text = Math.Round((Val(TextL7.Text) + Val(TextVR7.Text)) / 2, 3)
                If Val(TextD7.Text) <= Val(TextDM7.Text) Then
                    TextR7.BackColor = Color.Green
                End If
                If Val(TextD7.Text) >= Val(TextDM7.Text) * -1 Then
                    TextR7.BackColor = Color.Green
                End If
                If Val(TextD7.Text) > Val(TextDM7.Text) Then
                    TextR7.BackColor = Color.Yellow
                End If
                If Val(TextD7.Text) < Val(TextDM7.Text) * -1 Then
                    TextR7.BackColor = Color.Yellow
                End If
                If Val(TextD7.Text) > Val(TextDM7.Text) * 2 Then
                    TextR7.BackColor = Color.Red
                End If
                If Val(TextD7.Text) < Val(TextDM7.Text) * -2 Then
                    TextR7.BackColor = Color.Red
                End If
                difreal = Val(TextL7.Text) - Val(TextVR7.Text)
                TextDR7.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL8.Text.Length > 0 And TextVR8.Text.Length > 0 Then
                promedio = Val((TextL8.Text) + Val(TextVR8.Text)) / 2
                valor1 = Val(TextL8.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD8.Text = Math.Round(valor4, 3)
                TextP8.Text = Math.Round((Val(TextL8.Text) + Val(TextVR8.Text)) / 2, 3)
                If Val(TextD8.Text) <= Val(TextDM8.Text) Then
                    TextR8.BackColor = Color.Green
                End If
                If Val(TextD8.Text) >= Val(TextDM8.Text) * -1 Then
                    TextR8.BackColor = Color.Green
                End If
                If Val(TextD8.Text) > Val(TextDM8.Text) Then
                    TextR8.BackColor = Color.Yellow
                End If
                If Val(TextD8.Text) < Val(TextDM8.Text) * -1 Then
                    TextR8.BackColor = Color.Yellow
                End If
                If Val(TextD8.Text) > Val(TextDM8.Text) * 2 Then
                    TextR8.BackColor = Color.Red
                End If
                If Val(TextD8.Text) < Val(TextDM8.Text) * -2 Then
                    TextR8.BackColor = Color.Red
                End If
                difreal = Val(TextL8.Text) - Val(TextVR8.Text)
                TextDR8.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL9.Text.Length > 0 And TextVR9.Text.Length > 0 Then
                promedio = Val((TextL9.Text) + Val(TextVR9.Text)) / 2
                valor1 = Val(TextL9.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD9.Text = Math.Round(valor4, 3)
                TextP9.Text = Math.Round((Val(TextL9.Text) + Val(TextVR9.Text)) / 2, 3)
                If Val(TextD9.Text) <= Val(TextDM9.Text) Then
                    TextR9.BackColor = Color.Green
                End If
                If Val(TextD9.Text) >= Val(TextDM9.Text) * -1 Then
                    TextR9.BackColor = Color.Green
                End If
                If Val(TextD9.Text) > Val(TextDM9.Text) Then
                    TextR9.BackColor = Color.Yellow
                End If
                If Val(TextD9.Text) < Val(TextDM9.Text) * -1 Then
                    TextR9.BackColor = Color.Yellow
                End If
                If Val(TextD9.Text) > Val(TextDM9.Text) * 2 Then
                    TextR9.BackColor = Color.Red
                End If
                If Val(TextD9.Text) < Val(TextDM9.Text) * -2 Then
                    TextR9.BackColor = Color.Red
                End If
                difreal = Val(TextL9.Text) - Val(TextVR9.Text)
                TextDR9.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL10.Text.Length > 0 And TextVR10.Text.Length > 0 Then
                promedio = Val((TextL10.Text) + Val(TextVR10.Text)) / 2
                valor1 = Val(TextL10.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD10.Text = Math.Round(valor4, 3)
                TextP10.Text = Math.Round((Val(TextL10.Text) + Val(TextVR10.Text)) / 2, 3)
                If Val(TextD10.Text) <= Val(TextDM10.Text) Then
                    TextR10.BackColor = Color.Green
                End If
                If Val(TextD10.Text) >= Val(TextDM10.Text) * -1 Then
                    TextR10.BackColor = Color.Green
                End If
                If Val(TextD10.Text) > Val(TextDM10.Text) Then
                    TextR10.BackColor = Color.Yellow
                End If
                If Val(TextD10.Text) < Val(TextDM10.Text) * -1 Then
                    TextR10.BackColor = Color.Yellow
                End If
                If Val(TextD10.Text) > Val(TextDM10.Text) * 2 Then
                    TextR10.BackColor = Color.Red
                End If
                If Val(TextD10.Text) < Val(TextDM10.Text) * -2 Then
                    TextR10.BackColor = Color.Red
                End If
                difreal = Val(TextL10.Text) - Val(TextVR10.Text)
                TextDR10.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL11.Text.Length > 0 And TextVR11.Text.Length > 0 Then
                promedio = Val((TextL11.Text) + Val(TextVR11.Text)) / 2
                valor1 = Val(TextL11.Text) - promedio
                valor2 = valor1 * valor1
                valor3 = valor2 * 2
                valor4 = Math.Sqrt(valor3)
                TextD11.Text = Math.Round(valor4, 3)
                TextP11.Text = Math.Round((Val(TextL11.Text) + Val(TextVR11.Text)) / 2, 3)
                If Val(TextD11.Text) <= Val(TextDM11.Text) Then
                    TextR11.BackColor = Color.Green
                End If
                If Val(TextD11.Text) >= Val(TextDM11.Text) * -1 Then
                    TextR11.BackColor = Color.Green
                End If
                If Val(TextD11.Text) > Val(TextDM11.Text) Then
                    TextR11.BackColor = Color.Yellow
                End If
                If Val(TextD11.Text) < Val(TextDM11.Text) * -1 Then
                    TextR11.BackColor = Color.Yellow
                End If
                If Val(TextD11.Text) > Val(TextDM11.Text) * 2 Then
                    TextR11.BackColor = Color.Red
                End If
                If Val(TextD11.Text) < Val(TextDM11.Text) * -2 Then
                    TextR11.BackColor = Color.Red
                End If
                difreal = Val(TextL11.Text) - Val(TextVR11.Text)
                TextDR11.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
        ElseIf RadioDensidad.Checked = True Then
            If TextL1.Text.Length > 0 And TextVR1.Text.Length > 0 Then
                TextD1.Text = Math.Round(Val(TextVR1.Text) - Val(TextL1.Text), 3)
                TextP1.Text = Math.Round((Val(TextL1.Text) + Val(TextVR1.Text)) / 2, 3)
                If Val(TextD1.Text) <= Val(TextDM1.Text) Then
                    TextR1.BackColor = Color.Green
                End If
                If Val(TextD1.Text) >= Val(TextDM1.Text) * -1 Then
                    TextR1.BackColor = Color.Green
                End If
                If Val(TextD1.Text) > Val(TextDM1.Text) Then
                    TextR1.BackColor = Color.Yellow
                End If
                If Val(TextD1.Text) < Val(TextDM1.Text) * -1 Then
                    TextR1.BackColor = Color.Yellow
                End If
                If Val(TextD1.Text) > Val(TextDM1.Text) * 2 Then
                    TextR1.BackColor = Color.Red
                End If
                If Val(TextD1.Text) < Val(TextDM1.Text) * -2 Then
                    TextR1.BackColor = Color.Red
                End If
                difreal = Val(TextL1.Text) - Val(TextVR1.Text)
                TextDR1.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL2.Text.Length > 0 And TextVR2.Text.Length > 0 Then
                TextD2.Text = Math.Round(Val(TextVR2.Text) - Val(TextL2.Text), 3)
                TextP2.Text = Math.Round((Val(TextL2.Text) + Val(TextVR2.Text)) / 2, 3)
                If Val(TextD2.Text) <= Val(TextDM2.Text) Then
                    TextR2.BackColor = Color.Green
                End If
                If Val(TextD2.Text) >= Val(TextDM2.Text) * -1 Then
                    TextR2.BackColor = Color.Green
                End If
                If Val(TextD2.Text) > Val(TextDM2.Text) Then
                    TextR2.BackColor = Color.Yellow
                End If
                If Val(TextD2.Text) < Val(TextDM2.Text) * -1 Then
                    TextR2.BackColor = Color.Yellow
                End If
                If Val(TextD2.Text) > Val(TextDM2.Text) * 2 Then
                    TextR2.BackColor = Color.Red
                End If
                If Val(TextD2.Text) < Val(TextDM2.Text) * -2 Then
                    TextR2.BackColor = Color.Red
                End If
                difreal = Val(TextL2.Text) - Val(TextVR2.Text)
                TextDR2.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL3.Text.Length > 0 And TextVR3.Text.Length > 0 Then
                TextD3.Text = Math.Round(Val(TextVR3.Text) - Val(TextL3.Text), 3)
                TextP3.Text = Math.Round((Val(TextL3.Text) + Val(TextVR3.Text)) / 2, 3)
                If Val(TextD3.Text) <= Val(TextDM3.Text) Then
                    TextR3.BackColor = Color.Green
                End If
                If Val(TextD3.Text) >= Val(TextDM3.Text) * -1 Then
                    TextR3.BackColor = Color.Green
                End If
                If Val(TextD3.Text) > Val(TextDM3.Text) Then
                    TextR3.BackColor = Color.Yellow
                End If
                If Val(TextD3.Text) < Val(TextDM3.Text) * -1 Then
                    TextR3.BackColor = Color.Yellow
                End If
                If Val(TextD3.Text) > Val(TextDM3.Text) * 2 Then
                    TextR3.BackColor = Color.Red
                End If
                If Val(TextD3.Text) < Val(TextDM3.Text) * -2 Then
                    TextR3.BackColor = Color.Red
                End If
                difreal = Val(TextL3.Text) - Val(TextVR3.Text)
                TextDR3.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL4.Text.Length > 0 And TextVR4.Text.Length > 0 Then
                TextD4.Text = Math.Round(Val(TextVR4.Text) - Val(TextL4.Text), 3)
                TextP4.Text = Math.Round((Val(TextL4.Text) + Val(TextVR4.Text)) / 2, 3)
                If Val(TextD4.Text) <= Val(TextDM4.Text) Then
                    TextR4.BackColor = Color.Green
                End If
                If Val(TextD4.Text) >= Val(TextDM4.Text) * -1 Then
                    TextR4.BackColor = Color.Green
                End If
                If Val(TextD4.Text) > Val(TextDM4.Text) Then
                    TextR4.BackColor = Color.Yellow
                End If
                If Val(TextD4.Text) < Val(TextDM4.Text) * -1 Then
                    TextR4.BackColor = Color.Yellow
                End If
                If Val(TextD4.Text) > Val(TextDM4.Text) * 2 Then
                    TextR4.BackColor = Color.Red
                End If
                If Val(TextD4.Text) < Val(TextDM4.Text) * -2 Then
                    TextR4.BackColor = Color.Red
                End If
                difreal = Val(TextL4.Text) - Val(TextVR4.Text)
                TextDR4.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL5.Text.Length > 0 And TextVR5.Text.Length > 0 Then
                TextD5.Text = Math.Round(Val(TextVR5.Text) - Val(TextL5.Text), 3)
                TextP5.Text = Math.Round((Val(TextL5.Text) + Val(TextVR5.Text)) / 2, 3)
                If Val(TextD5.Text) <= Val(TextDM5.Text) Then
                    TextR5.BackColor = Color.Green
                End If
                If Val(TextD5.Text) >= Val(TextDM5.Text) * -1 Then
                    TextR5.BackColor = Color.Green
                End If
                If Val(TextD5.Text) > Val(TextDM5.Text) Then
                    TextR5.BackColor = Color.Yellow
                End If
                If Val(TextD5.Text) < Val(TextDM5.Text) * -1 Then
                    TextR5.BackColor = Color.Yellow
                End If
                If Val(TextD5.Text) > Val(TextDM5.Text) * 2 Then
                    TextR5.BackColor = Color.Red
                End If
                If Val(TextD5.Text) < Val(TextDM5.Text) * -2 Then
                    TextR5.BackColor = Color.Red
                End If
                difreal = Val(TextL5.Text) - Val(TextVR5.Text)
                TextDR5.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL6.Text.Length > 0 And TextVR6.Text.Length > 0 Then
                TextD6.Text = Math.Round(Val(TextVR6.Text) - Val(TextL6.Text), 3)
                TextP6.Text = Math.Round((Val(TextL6.Text) + Val(TextVR6.Text)) / 2, 3)
                If Val(TextD6.Text) <= Val(TextDM6.Text) Then
                    TextR6.BackColor = Color.Green
                End If
                If Val(TextD6.Text) >= Val(TextDM6.Text) * -1 Then
                    TextR6.BackColor = Color.Green
                End If
                If Val(TextD6.Text) > Val(TextDM6.Text) Then
                    TextR6.BackColor = Color.Yellow
                End If
                If Val(TextD6.Text) < Val(TextDM6.Text) * -1 Then
                    TextR6.BackColor = Color.Yellow
                End If
                If Val(TextD6.Text) > Val(TextDM6.Text) * 2 Then
                    TextR6.BackColor = Color.Red
                End If
                If Val(TextD6.Text) < Val(TextDM6.Text) * -2 Then
                    TextR6.BackColor = Color.Red
                End If
                difreal = Val(TextL6.Text) - Val(TextVR6.Text)
                TextDR6.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL7.Text.Length > 0 And TextVR7.Text.Length > 0 Then
                TextD7.Text = Math.Round(Val(TextVR7.Text) - Val(TextL7.Text), 3)
                TextP7.Text = Math.Round((Val(TextL7.Text) + Val(TextVR7.Text)) / 2, 3)
                If Val(TextD7.Text) <= Val(TextDM7.Text) Then
                    TextR7.BackColor = Color.Green
                End If
                If Val(TextD7.Text) >= Val(TextDM7.Text) * -1 Then
                    TextR7.BackColor = Color.Green
                End If
                If Val(TextD7.Text) > Val(TextDM7.Text) Then
                    TextR7.BackColor = Color.Yellow
                End If
                If Val(TextD7.Text) < Val(TextDM7.Text) * -1 Then
                    TextR7.BackColor = Color.Yellow
                End If
                If Val(TextD7.Text) > Val(TextDM7.Text) * 2 Then
                    TextR7.BackColor = Color.Red
                End If
                If Val(TextD7.Text) < Val(TextDM7.Text) * -2 Then
                    TextR7.BackColor = Color.Red
                End If
                difreal = Val(TextL7.Text) - Val(TextVR7.Text)
                TextDR7.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL8.Text.Length > 0 And TextVR8.Text.Length > 0 Then
                TextD8.Text = Math.Round(Val(TextVR8.Text) - Val(TextL8.Text), 3)
                TextP8.Text = Math.Round((Val(TextL8.Text) + Val(TextVR8.Text)) / 2, 3)
                If Val(TextD8.Text) <= Val(TextDM8.Text) Then
                    TextR8.BackColor = Color.Green
                End If
                If Val(TextD8.Text) >= Val(TextDM8.Text) * -1 Then
                    TextR8.BackColor = Color.Green
                End If
                If Val(TextD8.Text) > Val(TextDM8.Text) Then
                    TextR8.BackColor = Color.Yellow
                End If
                If Val(TextD8.Text) < Val(TextDM8.Text) * -1 Then
                    TextR8.BackColor = Color.Yellow
                End If
                If Val(TextD8.Text) > Val(TextDM8.Text) * 2 Then
                    TextR8.BackColor = Color.Red
                End If
                If Val(TextD8.Text) < Val(TextDM8.Text) * -2 Then
                    TextR8.BackColor = Color.Red
                End If
                difreal = Val(TextL8.Text) - Val(TextVR8.Text)
                TextDR8.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL9.Text.Length > 0 And TextVR9.Text.Length > 0 Then
                TextD9.Text = Math.Round(Val(TextVR9.Text) - Val(TextL9.Text), 3)
                TextP9.Text = Math.Round((Val(TextL9.Text) + Val(TextVR9.Text)) / 2, 3)
                If Val(TextD9.Text) <= Val(TextDM9.Text) Then
                    TextR9.BackColor = Color.Green
                End If
                If Val(TextD9.Text) >= Val(TextDM9.Text) * -1 Then
                    TextR9.BackColor = Color.Green
                End If
                If Val(TextD9.Text) > Val(TextDM9.Text) Then
                    TextR9.BackColor = Color.Yellow
                End If
                If Val(TextD9.Text) < Val(TextDM9.Text) * -1 Then
                    TextR9.BackColor = Color.Yellow
                End If
                If Val(TextD9.Text) > Val(TextDM9.Text) * 2 Then
                    TextR9.BackColor = Color.Red
                End If
                If Val(TextD9.Text) < Val(TextDM9.Text) * -2 Then
                    TextR9.BackColor = Color.Red
                End If
                difreal = Val(TextL9.Text) - Val(TextVR9.Text)
                TextDR9.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL10.Text.Length > 0 And TextVR10.Text.Length > 0 Then
                TextD10.Text = Math.Round(Val(TextVR10.Text) - Val(TextL10.Text), 3)
                TextP10.Text = Math.Round((Val(TextL10.Text) + Val(TextVR10.Text)) / 2, 3)
                If Val(TextD10.Text) <= Val(TextDM10.Text) Then
                    TextR10.BackColor = Color.Green
                End If
                If Val(TextD10.Text) >= Val(TextDM10.Text) * -1 Then
                    TextR10.BackColor = Color.Green
                End If
                If Val(TextD10.Text) > Val(TextDM10.Text) Then
                    TextR10.BackColor = Color.Yellow
                End If
                If Val(TextD10.Text) < Val(TextDM10.Text) * -1 Then
                    TextR10.BackColor = Color.Yellow
                End If
                If Val(TextD10.Text) > Val(TextDM10.Text) * 2 Then
                    TextR10.BackColor = Color.Red
                End If
                If Val(TextD10.Text) < Val(TextDM10.Text) * -2 Then
                    TextR10.BackColor = Color.Red
                End If
                difreal = Val(TextL10.Text) - Val(TextVR10.Text)
                TextDR10.Text = Math.Round(difreal, 3)
                difreal = 0

            End If
            If TextL11.Text.Length > 0 And TextVR11.Text.Length > 0 Then
                TextD11.Text = Math.Round(Val(TextVR11.Text) - Val(TextL11.Text), 3)
                TextP11.Text = Math.Round((Val(TextL11.Text) + Val(TextVR11.Text)) / 2, 3)
                If Val(TextD11.Text) <= Val(TextDM11.Text) Then
                    TextR11.BackColor = Color.Green
                End If
                If Val(TextD11.Text) >= Val(TextDM11.Text) * -1 Then
                    TextR11.BackColor = Color.Green
                End If
                If Val(TextD11.Text) > Val(TextDM11.Text) Then
                    TextR11.BackColor = Color.Yellow
                End If
                If Val(TextD11.Text) < Val(TextDM11.Text) * -1 Then
                    TextR11.BackColor = Color.Yellow
                End If
                If Val(TextD11.Text) > Val(TextDM11.Text) * 2 Then
                    TextR11.BackColor = Color.Red
                End If
                If Val(TextD11.Text) < Val(TextDM11.Text) * -2 Then
                    TextR11.BackColor = Color.Red
                End If
                difreal = Val(TextL11.Text) - Val(TextVR11.Text)
                TextDR11.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
        ElseIf RadioPH.Checked = True Then
            If TextL1.Text.Length > 0 And TextVR1.Text.Length > 0 Then
                TextD1.Text = Math.Round(Val(TextVR1.Text) - Val(TextL1.Text), 3)
                TextP1.Text = Math.Round((Val(TextL1.Text) + Val(TextVR1.Text)) / 2, 3)
                If Val(TextD1.Text) <= Val(TextDM1.Text) Then
                    TextR1.BackColor = Color.Green
                End If
                If Val(TextD1.Text) >= Val(TextDM1.Text) * -1 Then
                    TextR1.BackColor = Color.Green
                End If
                If Val(TextD1.Text) > Val(TextDM1.Text) Then
                    TextR1.BackColor = Color.Yellow
                End If
                If Val(TextD1.Text) < Val(TextDM1.Text) * -1 Then
                    TextR1.BackColor = Color.Yellow
                End If
                If Val(TextD1.Text) > Val(TextDM1.Text) * 2 Then
                    TextR1.BackColor = Color.Red
                End If
                If Val(TextD1.Text) < Val(TextDM1.Text) * -2 Then
                    TextR1.BackColor = Color.Red
                End If
                difreal = Val(TextL1.Text) - Val(TextVR1.Text)
                TextDR1.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL2.Text.Length > 0 And TextVR2.Text.Length > 0 Then
                TextD2.Text = Math.Round(Val(TextVR2.Text) - Val(TextL2.Text), 3)
                TextP2.Text = Math.Round((Val(TextL2.Text) + Val(TextVR2.Text)) / 2, 3)
                If Val(TextD2.Text) <= Val(TextDM2.Text) Then
                    TextR2.BackColor = Color.Green
                End If
                If Val(TextD2.Text) >= Val(TextDM2.Text) * -1 Then
                    TextR2.BackColor = Color.Green
                End If
                If Val(TextD2.Text) > Val(TextDM2.Text) Then
                    TextR2.BackColor = Color.Yellow
                End If
                If Val(TextD2.Text) < Val(TextDM2.Text) * -1 Then
                    TextR2.BackColor = Color.Yellow
                End If
                If Val(TextD2.Text) > Val(TextDM2.Text) * 2 Then
                    TextR2.BackColor = Color.Red
                End If
                If Val(TextD2.Text) < Val(TextDM2.Text) * -2 Then
                    TextR2.BackColor = Color.Red
                End If
                difreal = Val(TextL2.Text) - Val(TextVR2.Text)
                TextDR2.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL3.Text.Length > 0 And TextVR3.Text.Length > 0 Then
                TextD3.Text = Math.Round(Val(TextVR3.Text) - Val(TextL3.Text), 3)
                TextP3.Text = Math.Round((Val(TextL3.Text) + Val(TextVR3.Text)) / 2, 3)
                If Val(TextD3.Text) <= Val(TextDM3.Text) Then
                    TextR3.BackColor = Color.Green
                End If
                If Val(TextD3.Text) >= Val(TextDM3.Text) * -1 Then
                    TextR3.BackColor = Color.Green
                End If
                If Val(TextD3.Text) > Val(TextDM3.Text) Then
                    TextR3.BackColor = Color.Yellow
                End If
                If Val(TextD3.Text) < Val(TextDM3.Text) * -1 Then
                    TextR3.BackColor = Color.Yellow
                End If
                If Val(TextD3.Text) > Val(TextDM3.Text) * 2 Then
                    TextR3.BackColor = Color.Red
                End If
                If Val(TextD3.Text) < Val(TextDM3.Text) * -2 Then
                    TextR3.BackColor = Color.Red
                End If
                difreal = Val(TextL3.Text) - Val(TextVR3.Text)
                TextDR3.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL4.Text.Length > 0 And TextVR4.Text.Length > 0 Then
                TextD4.Text = Math.Round(Val(TextVR4.Text) - Val(TextL4.Text), 3)
                TextP4.Text = Math.Round((Val(TextL4.Text) + Val(TextVR4.Text)) / 2, 3)
                If Val(TextD4.Text) <= Val(TextDM4.Text) Then
                    TextR4.BackColor = Color.Green
                End If
                If Val(TextD4.Text) >= Val(TextDM4.Text) * -1 Then
                    TextR4.BackColor = Color.Green
                End If
                If Val(TextD4.Text) > Val(TextDM4.Text) Then
                    TextR4.BackColor = Color.Yellow
                End If
                If Val(TextD4.Text) < Val(TextDM4.Text) * -1 Then
                    TextR4.BackColor = Color.Yellow
                End If
                If Val(TextD4.Text) > Val(TextDM4.Text) * 2 Then
                    TextR4.BackColor = Color.Red
                End If
                If Val(TextD4.Text) < Val(TextDM4.Text) * -2 Then
                    TextR4.BackColor = Color.Red
                End If
                difreal = Val(TextL4.Text) - Val(TextVR4.Text)
                TextDR4.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL5.Text.Length > 0 And TextVR5.Text.Length > 0 Then
                TextD5.Text = Math.Round(Val(TextVR5.Text) - Val(TextL5.Text), 3)
                TextP5.Text = Math.Round((Val(TextL5.Text) + Val(TextVR5.Text)) / 2, 3)
                If Val(TextD5.Text) <= Val(TextDM5.Text) Then
                    TextR5.BackColor = Color.Green
                End If
                If Val(TextD5.Text) >= Val(TextDM5.Text) * -1 Then
                    TextR5.BackColor = Color.Green
                End If
                If Val(TextD5.Text) > Val(TextDM5.Text) Then
                    TextR5.BackColor = Color.Yellow
                End If
                If Val(TextD5.Text) < Val(TextDM5.Text) * -1 Then
                    TextR5.BackColor = Color.Yellow
                End If
                If Val(TextD5.Text) > Val(TextDM5.Text) * 2 Then
                    TextR5.BackColor = Color.Red
                End If
                If Val(TextD5.Text) < Val(TextDM5.Text) * -2 Then
                    TextR5.BackColor = Color.Red
                End If
                difreal = Val(TextL5.Text) - Val(TextVR5.Text)
                TextDR5.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL6.Text.Length > 0 And TextVR6.Text.Length > 0 Then
                TextD6.Text = Math.Round(Val(TextVR6.Text) - Val(TextL6.Text), 3)
                TextP6.Text = Math.Round((Val(TextL6.Text) + Val(TextVR6.Text)) / 2, 3)
                If Val(TextD6.Text) <= Val(TextDM6.Text) Then
                    TextR6.BackColor = Color.Green
                End If
                If Val(TextD6.Text) >= Val(TextDM6.Text) * -1 Then
                    TextR6.BackColor = Color.Green
                End If
                If Val(TextD6.Text) > Val(TextDM6.Text) Then
                    TextR6.BackColor = Color.Yellow
                End If
                If Val(TextD6.Text) < Val(TextDM6.Text) * -1 Then
                    TextR6.BackColor = Color.Yellow
                End If
                If Val(TextD6.Text) > Val(TextDM6.Text) * 2 Then
                    TextR6.BackColor = Color.Red
                End If
                If Val(TextD6.Text) < Val(TextDM6.Text) * -2 Then
                    TextR6.BackColor = Color.Red
                End If
                difreal = Val(TextL6.Text) - Val(TextVR6.Text)
                TextDR6.Text = Math.Round(difreal, 3)
                difreal = 0

            End If
            If TextL7.Text.Length > 0 And TextVR7.Text.Length > 0 Then
                TextD7.Text = Math.Round(Val(TextVR7.Text) - Val(TextL7.Text), 3)
                TextP7.Text = Math.Round((Val(TextL7.Text) + Val(TextVR7.Text)) / 2, 3)
                If Val(TextD7.Text) <= Val(TextDM7.Text) Then
                    TextR7.BackColor = Color.Green
                End If
                If Val(TextD7.Text) >= Val(TextDM7.Text) * -1 Then
                    TextR7.BackColor = Color.Green
                End If
                If Val(TextD7.Text) > Val(TextDM7.Text) Then
                    TextR7.BackColor = Color.Yellow
                End If
                If Val(TextD7.Text) < Val(TextDM7.Text) * -1 Then
                    TextR7.BackColor = Color.Yellow
                End If
                If Val(TextD7.Text) > Val(TextDM7.Text) * 2 Then
                    TextR7.BackColor = Color.Red
                End If
                If Val(TextD7.Text) < Val(TextDM7.Text) * -2 Then
                    TextR7.BackColor = Color.Red
                End If
                difreal = Val(TextL7.Text) - Val(TextVR7.Text)
                TextDR7.Text = Math.Round(difreal, 3)
                difreal = 0

            End If
            If TextL8.Text.Length > 0 And TextVR8.Text.Length > 0 Then
                TextD8.Text = Math.Round(Val(TextVR8.Text) - Val(TextL8.Text), 3)
                TextP8.Text = Math.Round((Val(TextL8.Text) + Val(TextVR8.Text)) / 2, 3)
                If Val(TextD8.Text) <= Val(TextDM8.Text) Then
                    TextR8.BackColor = Color.Green
                End If
                If Val(TextD8.Text) >= Val(TextDM8.Text) * -1 Then
                    TextR8.BackColor = Color.Green
                End If
                If Val(TextD8.Text) > Val(TextDM8.Text) Then
                    TextR8.BackColor = Color.Yellow
                End If
                If Val(TextD8.Text) < Val(TextDM8.Text) * -1 Then
                    TextR8.BackColor = Color.Yellow
                End If
                If Val(TextD8.Text) > Val(TextDM8.Text) * 2 Then
                    TextR8.BackColor = Color.Red
                End If
                If Val(TextD8.Text) < Val(TextDM8.Text) * -2 Then
                    TextR8.BackColor = Color.Red
                End If
                difreal = Val(TextL8.Text) - Val(TextVR8.Text)
                TextDR8.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL9.Text.Length > 0 And TextVR9.Text.Length > 0 Then
                TextD9.Text = Math.Round(Val(TextVR9.Text) - Val(TextL9.Text), 3)
                TextP9.Text = Math.Round((Val(TextL9.Text) + Val(TextVR9.Text)) / 2, 3)
                If Val(TextD9.Text) <= Val(TextDM9.Text) Then
                    TextR9.BackColor = Color.Green
                End If
                If Val(TextD9.Text) >= Val(TextDM9.Text) * -1 Then
                    TextR9.BackColor = Color.Green
                End If
                If Val(TextD9.Text) > Val(TextDM9.Text) Then
                    TextR9.BackColor = Color.Yellow
                End If
                If Val(TextD9.Text) < Val(TextDM9.Text) * -1 Then
                    TextR9.BackColor = Color.Yellow
                End If
                If Val(TextD9.Text) > Val(TextDM9.Text) * 2 Then
                    TextR9.BackColor = Color.Red
                End If
                If Val(TextD9.Text) < Val(TextDM9.Text) * -2 Then
                    TextR9.BackColor = Color.Red
                End If
                difreal = Val(TextL9.Text) - Val(TextVR9.Text)
                TextDR9.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL10.Text.Length > 0 And TextVR10.Text.Length > 0 Then
                TextD10.Text = Math.Round(Val(TextVR10.Text) - Val(TextL10.Text), 3)
                TextP10.Text = Math.Round((Val(TextL10.Text) + Val(TextVR10.Text)) / 2, 3)
                If Val(TextD10.Text) <= Val(TextDM10.Text) Then
                    TextR10.BackColor = Color.Green
                End If
                If Val(TextD10.Text) >= Val(TextDM10.Text) * -1 Then
                    TextR10.BackColor = Color.Green
                End If
                If Val(TextD10.Text) > Val(TextDM10.Text) Then
                    TextR10.BackColor = Color.Yellow
                End If
                If Val(TextD10.Text) < Val(TextDM10.Text) * -1 Then
                    TextR10.BackColor = Color.Yellow
                End If
                If Val(TextD10.Text) > Val(TextDM10.Text) * 2 Then
                    TextR10.BackColor = Color.Red
                End If
                If Val(TextD10.Text) < Val(TextDM10.Text) * -2 Then
                    TextR10.BackColor = Color.Red
                End If
                difreal = Val(TextL10.Text) - Val(TextVR10.Text)
                TextDR10.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL11.Text.Length > 0 And TextVR11.Text.Length > 0 Then
                TextD11.Text = Math.Round(Val(TextVR11.Text) - Val(TextL11.Text), 3)
                TextP11.Text = Math.Round((Val(TextL11.Text) + Val(TextVR11.Text)) / 2, 3)
                If Val(TextD11.Text) <= Val(TextDM11.Text) Then
                    TextR11.BackColor = Color.Green
                End If
                If Val(TextD11.Text) >= Val(TextDM11.Text) * -1 Then
                    TextR11.BackColor = Color.Green
                End If
                If Val(TextD11.Text) > Val(TextDM11.Text) Then
                    TextR11.BackColor = Color.Yellow
                End If
                If Val(TextD11.Text) < Val(TextDM11.Text) * -1 Then
                    TextR11.BackColor = Color.Yellow
                End If
                If Val(TextD11.Text) > Val(TextDM11.Text) * 2 Then
                    TextR11.BackColor = Color.Red
                End If
                If Val(TextD11.Text) < Val(TextDM11.Text) * -2 Then
                    TextR11.BackColor = Color.Red
                End If
                difreal = Val(TextL11.Text) - Val(TextVR11.Text)
                TextDR11.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
        ElseIf RadioCitratos.Checked = True Then
            If TextL1.Text.Length > 0 And TextVR1.Text.Length > 0 Then
                TextD1.Text = Math.Round(Val(TextVR1.Text) - Val(TextL1.Text), 3)
                TextP1.Text = Math.Round((Val(TextL1.Text) + Val(TextVR1.Text)) / 2, 3)
                If Val(TextD1.Text) <= Val(TextDM1.Text) Then
                    TextR1.BackColor = Color.Green
                End If
                If Val(TextD1.Text) >= Val(TextDM1.Text) * -1 Then
                    TextR1.BackColor = Color.Green
                End If
                If Val(TextD1.Text) > Val(TextDM1.Text) Then
                    TextR1.BackColor = Color.Yellow
                End If
                If Val(TextD1.Text) < Val(TextDM1.Text) * -1 Then
                    TextR1.BackColor = Color.Yellow
                End If
                If Val(TextD1.Text) > Val(TextDM1.Text) * 2 Then
                    TextR1.BackColor = Color.Red
                End If
                If Val(TextD1.Text) < Val(TextDM1.Text) * -2 Then
                    TextR1.BackColor = Color.Red
                End If
                difreal = Val(TextL1.Text) - Val(TextVR1.Text)
                TextDR1.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL2.Text.Length > 0 And TextVR2.Text.Length > 0 Then
                TextD2.Text = Math.Round(Val(TextVR2.Text) - Val(TextL2.Text), 3)
                TextP2.Text = Math.Round((Val(TextL2.Text) + Val(TextVR2.Text)) / 2, 3)
                If Val(TextD2.Text) <= Val(TextDM2.Text) Then
                    TextR2.BackColor = Color.Green
                End If
                If Val(TextD2.Text) >= Val(TextDM2.Text) * -1 Then
                    TextR2.BackColor = Color.Green
                End If
                If Val(TextD2.Text) > Val(TextDM2.Text) Then
                    TextR2.BackColor = Color.Yellow
                End If
                If Val(TextD2.Text) < Val(TextDM2.Text) * -1 Then
                    TextR2.BackColor = Color.Yellow
                End If
                If Val(TextD2.Text) > Val(TextDM2.Text) * 2 Then
                    TextR2.BackColor = Color.Red
                End If
                If Val(TextD2.Text) < Val(TextDM2.Text) * -2 Then
                    TextR2.BackColor = Color.Red
                End If
                difreal = Val(TextL2.Text) - Val(TextVR2.Text)
                TextDR2.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL3.Text.Length > 0 And TextVR3.Text.Length > 0 Then
                TextD3.Text = Math.Round(Val(TextVR3.Text) - Val(TextL3.Text), 3)
                TextP3.Text = Math.Round((Val(TextL3.Text) + Val(TextVR3.Text)) / 2, 3)
                If Val(TextD3.Text) <= Val(TextDM3.Text) Then
                    TextR3.BackColor = Color.Green
                End If
                If Val(TextD3.Text) >= Val(TextDM3.Text) * -1 Then
                    TextR3.BackColor = Color.Green
                End If
                If Val(TextD3.Text) > Val(TextDM3.Text) Then
                    TextR3.BackColor = Color.Yellow
                End If
                If Val(TextD3.Text) < Val(TextDM3.Text) * -1 Then
                    TextR3.BackColor = Color.Yellow
                End If
                If Val(TextD3.Text) > Val(TextDM3.Text) * 2 Then
                    TextR3.BackColor = Color.Red
                End If
                If Val(TextD3.Text) < Val(TextDM3.Text) * -2 Then
                    TextR3.BackColor = Color.Red
                End If
                difreal = Val(TextL3.Text) - Val(TextVR3.Text)
                TextDR3.Text = Math.Round(difreal, 3)
                difreal = 0

            End If
            If TextL4.Text.Length > 0 And TextVR4.Text.Length > 0 Then
                TextD4.Text = Math.Round(Val(TextVR4.Text) - Val(TextL4.Text), 3)
                TextP4.Text = Math.Round((Val(TextL4.Text) + Val(TextVR4.Text)) / 2, 3)
                If Val(TextD4.Text) <= Val(TextDM4.Text) Then
                    TextR4.BackColor = Color.Green
                End If
                If Val(TextD4.Text) >= Val(TextDM4.Text) * -1 Then
                    TextR4.BackColor = Color.Green
                End If
                If Val(TextD4.Text) > Val(TextDM4.Text) Then
                    TextR4.BackColor = Color.Yellow
                End If
                If Val(TextD4.Text) < Val(TextDM4.Text) * -1 Then
                    TextR4.BackColor = Color.Yellow
                End If
                If Val(TextD4.Text) > Val(TextDM4.Text) * 2 Then
                    TextR4.BackColor = Color.Red
                End If
                If Val(TextD4.Text) < Val(TextDM4.Text) * -2 Then
                    TextR4.BackColor = Color.Red
                End If
                difreal = Val(TextL4.Text) - Val(TextVR4.Text)
                TextDR4.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL5.Text.Length > 0 And TextVR5.Text.Length > 0 Then
                TextD5.Text = Math.Round(Val(TextVR5.Text) - Val(TextL5.Text), 3)
                TextP5.Text = Math.Round((Val(TextL5.Text) + Val(TextVR5.Text)) / 2, 3)
                If Val(TextD5.Text) <= Val(TextDM5.Text) Then
                    TextR5.BackColor = Color.Green
                End If
                If Val(TextD5.Text) >= Val(TextDM5.Text) * -1 Then
                    TextR5.BackColor = Color.Green
                End If
                If Val(TextD5.Text) > Val(TextDM5.Text) Then
                    TextR5.BackColor = Color.Yellow
                End If
                If Val(TextD5.Text) < Val(TextDM5.Text) * -1 Then
                    TextR5.BackColor = Color.Yellow
                End If
                If Val(TextD5.Text) > Val(TextDM5.Text) * 2 Then
                    TextR5.BackColor = Color.Red
                End If
                If Val(TextD5.Text) < Val(TextDM5.Text) * -2 Then
                    TextR5.BackColor = Color.Red
                End If
                difreal = Val(TextL5.Text) - Val(TextVR5.Text)
                TextDR5.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL6.Text.Length > 0 And TextVR6.Text.Length > 0 Then
                TextD6.Text = Math.Round(Val(TextVR6.Text) - Val(TextL6.Text), 3)
                TextP6.Text = Math.Round((Val(TextL6.Text) + Val(TextVR6.Text)) / 2, 3)
                If Val(TextD6.Text) <= Val(TextDM6.Text) Then
                    TextR6.BackColor = Color.Green
                End If
                If Val(TextD6.Text) >= Val(TextDM6.Text) * -1 Then
                    TextR6.BackColor = Color.Green
                End If
                If Val(TextD6.Text) > Val(TextDM6.Text) Then
                    TextR6.BackColor = Color.Yellow
                End If
                If Val(TextD6.Text) < Val(TextDM6.Text) * -1 Then
                    TextR6.BackColor = Color.Yellow
                End If
                If Val(TextD6.Text) > Val(TextDM6.Text) * 2 Then
                    TextR6.BackColor = Color.Red
                End If
                If Val(TextD6.Text) < Val(TextDM6.Text) * -2 Then
                    TextR6.BackColor = Color.Red
                End If
                difreal = Val(TextL6.Text) - Val(TextVR6.Text)
                TextDR6.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL7.Text.Length > 0 And TextVR7.Text.Length > 0 Then
                TextD7.Text = Math.Round(Val(TextVR7.Text) - Val(TextL7.Text), 3)
                TextP7.Text = Math.Round((Val(TextL7.Text) + Val(TextVR7.Text)) / 2, 3)
                If Val(TextD7.Text) <= Val(TextDM7.Text) Then
                    TextR7.BackColor = Color.Green
                End If
                If Val(TextD7.Text) >= Val(TextDM7.Text) * -1 Then
                    TextR7.BackColor = Color.Green
                End If
                If Val(TextD7.Text) > Val(TextDM7.Text) Then
                    TextR7.BackColor = Color.Yellow
                End If
                If Val(TextD7.Text) < Val(TextDM7.Text) * -1 Then
                    TextR7.BackColor = Color.Yellow
                End If
                If Val(TextD7.Text) > Val(TextDM7.Text) * 2 Then
                    TextR7.BackColor = Color.Red
                End If
                If Val(TextD7.Text) < Val(TextDM7.Text) * -2 Then
                    TextR7.BackColor = Color.Red
                End If
                difreal = Val(TextL7.Text) - Val(TextVR7.Text)
                TextDR7.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL8.Text.Length > 0 And TextVR8.Text.Length > 0 Then
                TextD8.Text = Math.Round(Val(TextVR8.Text) - Val(TextL8.Text), 3)
                TextP8.Text = Math.Round((Val(TextL8.Text) + Val(TextVR8.Text)) / 2, 3)
                If Val(TextD8.Text) <= Val(TextDM8.Text) Then
                    TextR8.BackColor = Color.Green
                End If
                If Val(TextD8.Text) >= Val(TextDM8.Text) * -1 Then
                    TextR8.BackColor = Color.Green
                End If
                If Val(TextD8.Text) > Val(TextDM8.Text) Then
                    TextR8.BackColor = Color.Yellow
                End If
                If Val(TextD8.Text) < Val(TextDM8.Text) * -1 Then
                    TextR8.BackColor = Color.Yellow
                End If
                If Val(TextD8.Text) > Val(TextDM8.Text) * 2 Then
                    TextR8.BackColor = Color.Red
                End If
                If Val(TextD8.Text) < Val(TextDM8.Text) * -2 Then
                    TextR8.BackColor = Color.Red
                End If
                difreal = Val(TextL8.Text) - Val(TextVR8.Text)
                TextDR8.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL9.Text.Length > 0 And TextVR9.Text.Length > 0 Then
                TextD9.Text = Math.Round(Val(TextVR9.Text) - Val(TextL9.Text), 3)
                TextP9.Text = Math.Round((Val(TextL9.Text) + Val(TextVR9.Text)) / 2, 3)
                If Val(TextD9.Text) <= Val(TextDM9.Text) Then
                    TextR9.BackColor = Color.Green
                End If
                If Val(TextD9.Text) >= Val(TextDM9.Text) * -1 Then
                    TextR9.BackColor = Color.Green
                End If
                If Val(TextD9.Text) > Val(TextDM9.Text) Then
                    TextR9.BackColor = Color.Yellow
                End If
                If Val(TextD9.Text) < Val(TextDM9.Text) * -1 Then
                    TextR9.BackColor = Color.Yellow
                End If
                If Val(TextD9.Text) > Val(TextDM9.Text) * 2 Then
                    TextR9.BackColor = Color.Red
                End If
                If Val(TextD9.Text) < Val(TextDM9.Text) * -2 Then
                    TextR9.BackColor = Color.Red
                End If
                difreal = Val(TextL9.Text) - Val(TextVR9.Text)
                TextDR9.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL10.Text.Length > 0 And TextVR10.Text.Length > 0 Then
                TextD10.Text = Math.Round(Val(TextVR10.Text) - Val(TextL10.Text), 3)
                TextP10.Text = Math.Round((Val(TextL10.Text) + Val(TextVR10.Text)) / 2, 3)
                If Val(TextD10.Text) <= Val(TextDM10.Text) Then
                    TextR10.BackColor = Color.Green
                End If
                If Val(TextD10.Text) >= Val(TextDM10.Text) * -1 Then
                    TextR10.BackColor = Color.Green
                End If
                If Val(TextD10.Text) > Val(TextDM10.Text) Then
                    TextR10.BackColor = Color.Yellow
                End If
                If Val(TextD10.Text) < Val(TextDM10.Text) * -1 Then
                    TextR10.BackColor = Color.Yellow
                End If
                If Val(TextD10.Text) > Val(TextDM10.Text) * 2 Then
                    TextR10.BackColor = Color.Red
                End If
                If Val(TextD10.Text) < Val(TextDM10.Text) * -2 Then
                    TextR10.BackColor = Color.Red
                End If
                difreal = Val(TextL10.Text) - Val(TextVR10.Text)
                TextDR10.Text = Math.Round(difreal, 3)
                difreal = 0
            End If
            If TextL11.Text.Length > 0 And TextVR11.Text.Length > 0 Then
                TextD11.Text = Math.Round(Val(TextVR11.Text) - Val(TextL11.Text), 3)
                TextP11.Text = Math.Round((Val(TextL11.Text) + Val(TextVR11.Text)) / 2, 3)
                If Val(TextD11.Text) <= Val(TextDM11.Text) Then
                    TextR11.BackColor = Color.Green
                End If
                If Val(TextD11.Text) >= Val(TextDM11.Text) * -1 Then
                    TextR11.BackColor = Color.Green
                End If
                If Val(TextD11.Text) > Val(TextDM11.Text) Then
                    TextR11.BackColor = Color.Yellow
                End If
                If Val(TextD11.Text) < Val(TextDM11.Text) * -1 Then
                    TextR11.BackColor = Color.Yellow
                End If
                If Val(TextD11.Text) > Val(TextDM11.Text) * 2 Then
                    TextR11.BackColor = Color.Red
                End If
                If Val(TextD11.Text) < Val(TextDM11.Text) * -2 Then
                    TextR11.BackColor = Color.Red
                End If
                difreal = Val(TextL11.Text) - Val(TextVR11.Text)
                TextDR11.Text = Math.Round(difreal, 3)
                difreal = 0
            End If

        End If
    End Sub
    Private Sub calculopromedio()
        Dim valores As Integer = 0
        Dim sumavalores As Double = 0
        Dim promediovalores As Double = 0
        If TextD1.Text <> "" Then
            valores = 1
            sumavalores = sumavalores + Val(TextD1.Text)
        End If
        If TextD2.Text <> "" Then
            valores = 2
            sumavalores = sumavalores + Val(TextD2.Text)
        End If
        If TextD3.Text <> "" Then
            valores = 3
            sumavalores = sumavalores + Val(TextD3.Text)
        End If
        If TextD4.Text <> "" Then
            valores = 4
            sumavalores = sumavalores + Val(TextD4.Text)
        End If
        If TextD5.Text <> "" Then
            valores = 5
            sumavalores = sumavalores + Val(TextD5.Text)
        End If
        If TextD6.Text <> "" Then
            valores = 6
            sumavalores = sumavalores + Val(TextD6.Text)
        End If
        If TextD7.Text <> "" Then
            valores = 7
            sumavalores = sumavalores + Val(TextD7.Text)
        End If
        If TextD8.Text <> "" Then
            valores = 8
            sumavalores = sumavalores + Val(TextD8.Text)
        End If
        If TextD9.Text <> "" Then
            valores = 9
            sumavalores = sumavalores + Val(TextD9.Text)
        End If
        If TextD10.Text <> "" Then
            valores = 10
            sumavalores = sumavalores + Val(TextD10.Text)
        End If
        If TextD11.Text <> "" Then
            valores = 11
            sumavalores = sumavalores + Val(TextD11.Text)
        End If
        promediovalores = sumavalores / valores
        TextDPromedio.Text = Math.Round(promediovalores, 3)
    End Sub
    Private Sub calculopromedioreal()
        Dim valores As Integer = 0
        Dim sumavalores As Double = 0
        Dim promediovalores As Double = 0
        If TextDR1.Text <> "" Then
            valores = 1
            sumavalores = sumavalores + Val(TextDR1.Text)
        End If
        If TextDR2.Text <> "" Then
            valores = 2
            sumavalores = sumavalores + Val(TextDR2.Text)
        End If
        If TextDR3.Text <> "" Then
            valores = 3
            sumavalores = sumavalores + Val(TextDR3.Text)
        End If
        If TextDR4.Text <> "" Then
            valores = 4
            sumavalores = sumavalores + Val(TextDR4.Text)
        End If
        If TextDR5.Text <> "" Then
            valores = 5
            sumavalores = sumavalores + Val(TextDR5.Text)
        End If
        If TextDR6.Text <> "" Then
            valores = 6
            sumavalores = sumavalores + Val(TextDR6.Text)
        End If
        If TextDR7.Text <> "" Then
            valores = 7
            sumavalores = sumavalores + Val(TextDR7.Text)
        End If
        If TextDR8.Text <> "" Then
            valores = 8
            sumavalores = sumavalores + Val(TextDR8.Text)
        End If
        If TextDR9.Text <> "" Then
            valores = 9
            sumavalores = sumavalores + Val(TextDR9.Text)
        End If
        If TextDR10.Text <> "" Then
            valores = 10
            sumavalores = sumavalores + Val(TextDR10.Text)
        End If
        If TextDR11.Text <> "" Then
            valores = 11
            sumavalores = sumavalores + Val(TextDR11.Text)
        End If
        promediovalores = sumavalores / valores
        TextDPromedio2.Text = Math.Round(promediovalores, 3)
    End Sub
    Private Sub TextL1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextL1.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            calculos()
            calculopromedio()
            calculopromedioreal()
            TextL2.Focus()
        End If
    End Sub
    Private Sub TextL2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextL2.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            calculos()
            calculopromedio()
            calculopromedioreal()
            TextL3.Focus()
        End If
    End Sub
    Private Sub TextL3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextL3.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            calculos()
            calculopromedio()
            calculopromedioreal()
            TextL4.Focus()
        End If
    End Sub
    Private Sub TextL4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextL4.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            calculos()
            calculopromedio()
            calculopromedioreal()
            TextL5.Focus()
        End If
    End Sub
    Private Sub TextL5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextL5.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            calculos()
            calculopromedio()
            calculopromedioreal()
            TextL6.Focus()
        End If
    End Sub
    Private Sub TextL6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextL6.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            calculos()
            calculopromedio()
            calculopromedioreal()
            TextL7.Focus()
        End If
    End Sub
    Private Sub TextL7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextL7.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            calculos()
            calculopromedio()
            calculopromedioreal()
            TextL8.Focus()
        End If
    End Sub
    Private Sub TextL8_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextL8.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            calculos()
            calculopromedio()
            calculopromedioreal()
            TextL9.Focus()
        End If
    End Sub
    Private Sub TextL9_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextL9.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            calculos()
            calculopromedio()
            calculopromedioreal()
            TextL10.Focus()
        End If
    End Sub
    Private Sub TextL10_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextL10.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            calculos()
            calculopromedio()
            calculopromedioreal()
            TextL11.Focus()
        End If
    End Sub
    Private Sub TextL11_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextL11.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            calculos()
            calculopromedio()
            calculopromedioreal()
            ButtonGuardar.Focus()
        End If
    End Sub
    Private Sub ButtonGraficar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGraficar.Click
        Dim v As New FormMaterialdeReferenciaBD()
        v.ShowDialog()
    End Sub

   
    Private Sub TextL1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextL1.TextChanged

    End Sub

    Private Sub TextVR1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextVR1.TextChanged

    End Sub
End Class