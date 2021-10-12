'Imports Microsoft.Office.Interop
'Imports Microsoft.Office.Interop.Excel
Imports System
Imports System.IO
Imports System.Collections
Public Class FormControlIBC

#Region "Constructores"
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        cargarvaloresmedios()

    End Sub

#End Region
    Private Sub cargarvaloresmedios()
        Dim c As New dControlIbc
        c = c.buscarultimo()
        If Not c Is Nothing Then
            TextBajo.Text = c.BAJO
            TextAlto.Text = c.ALTO
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCargarValoresMedios.Click
        Dim fichero As String = ""
        Dim linea As Integer = 0
        Dim dlAbrir As New System.Windows.Forms.OpenFileDialog
        dlAbrir.InitialDirectory = "\\Ibc1123\Pilotos"
        'dlAbrir.Filter = "Archivos de Texto (*.txt)|*.txt|" & "Archivos de log (*.log)|*.log|" & "Todos los archivos (*.*)|*.*"
        dlAbrir.Filter = "Archivos CSV (*.csv)|*.csv"
        dlAbrir.Multiselect = False
        dlAbrir.CheckFileExists = False
        dlAbrir.Title = "Selección de archivo"
        dlAbrir.ShowDialog()
        If dlAbrir.FileName <> "" Then
            fichero = dlAbrir.FileName
        End If
        If fichero <> "" Then
            Dim objReader As New StreamReader(fichero)
            Dim objReader2 As New StreamReader(fichero)
            Dim sLine As String = ""
            Dim sline2 As String = ""
            Dim arraytext() As String
            Dim sumabajo As Double = 0
            Dim sumaalto As Double = 0
            Dim promediobajo As Double = 0
            Dim promedioalto As Double = 0
            Dim fecha As String = ""
            Dim fecha2 As String = ""
            Dim fecha3 As DateTime
            Dim fecha4 As DateTime
            Dim fecha5 As String = ""
            Dim b1 As Double = 0
            Dim a1 As Double = 0

            Do
                sLine = objReader.ReadLine()
                linea = linea + 1
            Loop Until sLine Is Nothing
            ' SI EL ARCHIVO ES DE PROMEDIOS ************************************************************************
            If linea = 49 Then
                linea = 1
                Do
                    sline2 = objReader2.ReadLine()
                    If linea = 2 Then
                        arraytext = Split(sline2, ",")
                        fecha = Trim(arraytext(0))
                        fecha2 = Mid(fecha, 18, 19)
                        fecha3 = Convert.ToDateTime(fecha2)
                        fecha4 = fecha3.ToString("yyyy-MM-dd HH:mm:ss")
                        fecha5 = Format(fecha4, "yyyy-MM-dd HH:mm:ss")
                    End If
                    If linea = 17 Then
                        arraytext = Split(sline2, ",")
                        sumabajo = sumabajo + Val(Trim(arraytext(10)))
                    ElseIf linea = 18 Then
                        arraytext = Split(sline2, ",")
                        sumabajo = sumabajo + Val(Trim(arraytext(10)))
                    ElseIf linea = 19 Then
                        arraytext = Split(sline2, ",")
                        sumabajo = sumabajo + Val(Trim(arraytext(10)))
                    ElseIf linea = 20 Then
                        arraytext = Split(sline2, ",")
                        sumabajo = sumabajo + Val(Trim(arraytext(10)))
                    ElseIf linea = 21 Then
                        arraytext = Split(sline2, ",")
                        sumabajo = sumabajo + Val(Trim(arraytext(10)))
                    ElseIf linea = 22 Then
                        arraytext = Split(sline2, ",")
                        sumabajo = sumabajo + Val(Trim(arraytext(10)))
                    ElseIf linea = 23 Then
                        arraytext = Split(sline2, ",")
                        sumabajo = sumabajo + Val(Trim(arraytext(10)))
                    ElseIf linea = 24 Then
                        arraytext = Split(sline2, ",")
                        sumabajo = sumabajo + Val(Trim(arraytext(10)))
                    ElseIf linea = 25 Then
                        arraytext = Split(sline2, ",")
                        sumabajo = sumabajo + Val(Trim(arraytext(10)))
                    ElseIf linea = 26 Then
                        arraytext = Split(sline2, ",")
                        sumabajo = sumabajo + Val(Trim(arraytext(10)))
                    ElseIf linea = 27 Then
                        arraytext = Split(sline2, ",")
                        sumabajo = sumabajo + Val(Trim(arraytext(10)))
                    ElseIf linea = 28 Then
                        arraytext = Split(sline2, ",")
                        sumabajo = sumabajo + Val(Trim(arraytext(10)))
                    ElseIf linea = 29 Then
                        arraytext = Split(sline2, ",")
                        sumabajo = sumabajo + Val(Trim(arraytext(10)))
                    ElseIf linea = 30 Then
                        arraytext = Split(sline2, ",")
                        sumabajo = sumabajo + Val(Trim(arraytext(10)))
                    ElseIf linea = 31 Then
                        arraytext = Split(sline2, ",")
                        sumabajo = sumabajo + Val(Trim(arraytext(10)))
                    ElseIf linea = 32 Then
                        arraytext = Split(sline2, ",")
                        sumaalto = sumaalto + Val(Trim(arraytext(10)))
                    ElseIf linea = 33 Then
                        arraytext = Split(sline2, ",")
                        sumaalto = sumaalto + Val(Trim(arraytext(10)))
                    ElseIf linea = 34 Then
                        arraytext = Split(sline2, ",")
                        sumaalto = sumaalto + Val(Trim(arraytext(10)))
                    ElseIf linea = 35 Then
                        arraytext = Split(sline2, ",")
                        sumaalto = sumaalto + Val(Trim(arraytext(10)))
                    ElseIf linea = 36 Then
                        arraytext = Split(sline2, ",")
                        sumaalto = sumaalto + Val(Trim(arraytext(10)))
                    ElseIf linea = 37 Then
                        arraytext = Split(sline2, ",")
                        sumaalto = sumaalto + Val(Trim(arraytext(10)))
                    ElseIf linea = 38 Then
                        arraytext = Split(sline2, ",")
                        sumaalto = sumaalto + Val(Trim(arraytext(10)))
                    ElseIf linea = 39 Then
                        arraytext = Split(sline2, ",")
                        sumaalto = sumaalto + Val(Trim(arraytext(10)))
                    ElseIf linea = 40 Then
                        arraytext = Split(sline2, ",")
                        sumaalto = sumaalto + Val(Trim(arraytext(10)))
                    ElseIf linea = 41 Then
                        arraytext = Split(sline2, ",")
                        sumaalto = sumaalto + Val(Trim(arraytext(10)))
                    ElseIf linea = 42 Then
                        arraytext = Split(sline2, ",")
                        sumaalto = sumaalto + Val(Trim(arraytext(10)))
                    ElseIf linea = 43 Then
                        arraytext = Split(sline2, ",")
                        sumaalto = sumaalto + Val(Trim(arraytext(10)))
                    ElseIf linea = 44 Then
                        arraytext = Split(sline2, ",")
                        sumaalto = sumaalto + Val(Trim(arraytext(10)))
                    ElseIf linea = 45 Then
                        arraytext = Split(sline2, ",")
                        sumaalto = sumaalto + Val(Trim(arraytext(10)))
                    ElseIf linea = 46 Then
                        arraytext = Split(sline2, ",")
                        sumaalto = sumaalto + Val(Trim(arraytext(10)))
                    End If

                    linea = linea + 1
                Loop Until sline2 Is Nothing

                Dim c As New dControlIbc
                promediobajo = sumabajo / 15
                promedioalto = sumaalto / 15
                c.FECHA = fecha5
                c.BAJO = promediobajo
                c.ALTO = promedioalto
                If (c.guardar) Then
                    MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                    linea = 1
                    cargarvaloresmedios()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If

            If linea = 50 Then
                linea = 1
                Do
                    sline2 = objReader2.ReadLine()
                    If linea = 2 Then
                        arraytext = Split(sline2, ",")
                        fecha = Trim(arraytext(0))
                        fecha2 = Mid(fecha, 18, 19)
                        fecha3 = Convert.ToDateTime(fecha2)
                        fecha4 = fecha3.ToString("yyyy-MM-dd HH:mm:ss")
                        fecha5 = Format(fecha4, "yyyy-MM-dd HH:mm:ss")
                    End If
                    If linea = 18 Then
                        arraytext = Split(sline2, ",")
                        sumabajo = sumabajo + Val(Trim(arraytext(10)))
                    ElseIf linea = 19 Then
                        arraytext = Split(sline2, ",")
                        sumabajo = sumabajo + Val(Trim(arraytext(10)))
                    ElseIf linea = 20 Then
                        arraytext = Split(sline2, ",")
                        sumabajo = sumabajo + Val(Trim(arraytext(10)))
                    ElseIf linea = 21 Then
                        arraytext = Split(sline2, ",")
                        sumabajo = sumabajo + Val(Trim(arraytext(10)))
                    ElseIf linea = 22 Then
                        arraytext = Split(sline2, ",")
                        sumabajo = sumabajo + Val(Trim(arraytext(10)))
                    ElseIf linea = 23 Then
                        arraytext = Split(sline2, ",")
                        sumabajo = sumabajo + Val(Trim(arraytext(10)))
                    ElseIf linea = 24 Then
                        arraytext = Split(sline2, ",")
                        sumabajo = sumabajo + Val(Trim(arraytext(10)))
                    ElseIf linea = 25 Then
                        arraytext = Split(sline2, ",")
                        sumabajo = sumabajo + Val(Trim(arraytext(10)))
                    ElseIf linea = 26 Then
                        arraytext = Split(sline2, ",")
                        sumabajo = sumabajo + Val(Trim(arraytext(10)))
                    ElseIf linea = 27 Then
                        arraytext = Split(sline2, ",")
                        sumabajo = sumabajo + Val(Trim(arraytext(10)))
                    ElseIf linea = 28 Then
                        arraytext = Split(sline2, ",")
                        sumabajo = sumabajo + Val(Trim(arraytext(10)))
                    ElseIf linea = 29 Then
                        arraytext = Split(sline2, ",")
                        sumabajo = sumabajo + Val(Trim(arraytext(10)))
                    ElseIf linea = 30 Then
                        arraytext = Split(sline2, ",")
                        sumabajo = sumabajo + Val(Trim(arraytext(10)))
                    ElseIf linea = 31 Then
                        arraytext = Split(sline2, ",")
                        sumabajo = sumabajo + Val(Trim(arraytext(10)))
                    ElseIf linea = 32 Then
                        arraytext = Split(sline2, ",")
                        sumabajo = sumabajo + Val(Trim(arraytext(10)))
                    ElseIf linea = 33 Then
                        arraytext = Split(sline2, ",")
                        sumaalto = sumaalto + Val(Trim(arraytext(10)))
                    ElseIf linea = 34 Then
                        arraytext = Split(sline2, ",")
                        sumaalto = sumaalto + Val(Trim(arraytext(10)))
                    ElseIf linea = 35 Then
                        arraytext = Split(sline2, ",")
                        sumaalto = sumaalto + Val(Trim(arraytext(10)))
                    ElseIf linea = 36 Then
                        arraytext = Split(sline2, ",")
                        sumaalto = sumaalto + Val(Trim(arraytext(10)))
                    ElseIf linea = 37 Then
                        arraytext = Split(sline2, ",")
                        sumaalto = sumaalto + Val(Trim(arraytext(10)))
                    ElseIf linea = 38 Then
                        arraytext = Split(sline2, ",")
                        sumaalto = sumaalto + Val(Trim(arraytext(10)))
                    ElseIf linea = 39 Then
                        arraytext = Split(sline2, ",")
                        sumaalto = sumaalto + Val(Trim(arraytext(10)))
                    ElseIf linea = 40 Then
                        arraytext = Split(sline2, ",")
                        sumaalto = sumaalto + Val(Trim(arraytext(10)))
                    ElseIf linea = 41 Then
                        arraytext = Split(sline2, ",")
                        sumaalto = sumaalto + Val(Trim(arraytext(10)))
                    ElseIf linea = 42 Then
                        arraytext = Split(sline2, ",")
                        sumaalto = sumaalto + Val(Trim(arraytext(10)))
                    ElseIf linea = 43 Then
                        arraytext = Split(sline2, ",")
                        sumaalto = sumaalto + Val(Trim(arraytext(10)))
                    ElseIf linea = 44 Then
                        arraytext = Split(sline2, ",")
                        sumaalto = sumaalto + Val(Trim(arraytext(10)))
                    ElseIf linea = 45 Then
                        arraytext = Split(sline2, ",")
                        sumaalto = sumaalto + Val(Trim(arraytext(10)))
                    ElseIf linea = 46 Then
                        arraytext = Split(sline2, ",")
                        sumaalto = sumaalto + Val(Trim(arraytext(10)))
                    ElseIf linea = 47 Then
                        arraytext = Split(sline2, ",")
                        sumaalto = sumaalto + Val(Trim(arraytext(10)))
                    End If

                    linea = linea + 1
                Loop Until sline2 Is Nothing

                Dim c As New dControlIbc
                promediobajo = sumabajo / 15
                promedioalto = sumaalto / 15
                c.FECHA = fecha5
                c.BAJO = promediobajo
                c.ALTO = promedioalto
                If (c.guardar) Then
                    MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                    linea = 1
                    cargarvaloresmedios()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
            ' SI EL ARCHIVO ES DE LECTURAS ************************************************************************
            If linea = 19 Then
                linea = 1
                Do
                    sline2 = objReader2.ReadLine()
                    If linea = 2 Then
                        arraytext = Split(sline2, ",")
                        fecha = Trim(arraytext(0))
                        fecha2 = Mid(fecha, 18, 19)
                        fecha3 = Convert.ToDateTime(fecha2)
                        fecha4 = fecha3.ToString("yyyy-MM-dd HH:mm:ss")
                        fecha5 = Format(fecha4, "yyyy-MM-dd HH:mm:ss")
                    End If
                    If linea = 7 Then
                        arraytext = Split(sline2, ",")
                        sumabajo = sumabajo + Val(Trim(arraytext(10)))
                    ElseIf linea = 8 Then
                        arraytext = Split(sline2, ",")
                        sumabajo = sumabajo + Val(Trim(arraytext(10)))
                    ElseIf linea = 9 Then
                        arraytext = Split(sline2, ",")
                        sumabajo = sumabajo + Val(Trim(arraytext(10)))
                    ElseIf linea = 10 Then
                        arraytext = Split(sline2, ",")
                        sumabajo = sumabajo + Val(Trim(arraytext(10)))
                    ElseIf linea = 11 Then
                        arraytext = Split(sline2, ",")
                        sumabajo = sumabajo + Val(Trim(arraytext(10)))
                    ElseIf linea = 12 Then
                        arraytext = Split(sline2, ",")
                        sumaalto = sumaalto + Val(Trim(arraytext(10)))
                    ElseIf linea = 13 Then
                        arraytext = Split(sline2, ",")
                        sumaalto = sumaalto + Val(Trim(arraytext(10)))
                    ElseIf linea = 14 Then
                        arraytext = Split(sline2, ",")
                        sumaalto = sumaalto + Val(Trim(arraytext(10)))
                    ElseIf linea = 15 Then
                        arraytext = Split(sline2, ",")
                        sumaalto = sumaalto + Val(Trim(arraytext(10)))
                    ElseIf linea = 16 Then
                        arraytext = Split(sline2, ",")
                        sumaalto = sumaalto + Val(Trim(arraytext(10)))
                    End If

                    linea = linea + 1
                Loop Until sline2 Is Nothing
                Dim vmb As Double = Val(TextBajo.Text.Trim)
                Dim vma As Double = Val(TextAlto.Text.Trim)
                Dim promediosbajos As Double = 0
                Dim promediosaltos As Double = 0
                Dim restobajo1 As Double = 0
                Dim restobajo2 As Double = 0
                Dim restoalto1 As Double = 0
                Dim restoalto2 As Double = 0
                Dim desvbajo As Double = 0
                Dim desvalto As Double = 0
                Dim bajocuadrado1 As Double = 0
                Dim bajocuadrado2 As Double = 0
                Dim altocuadrado1 As Double = 0
                Dim altocuadrado2 As Double = 0
                Dim sumabajos As Double = 0
                Dim sumaaltos As Double = 0


                promediobajo = sumabajo / 5
                promedioalto = sumaalto / 5
                promediosbajos = (promediobajo + vmb) / 2
                promediosaltos = (promedioalto + vma) / 2
                restobajo1 = promediobajo - promediosbajos
                restobajo2 = vmb - promediosbajos
                restoalto1 = promedioalto - promediosaltos
                restoalto2 = vma - promediosaltos
                bajocuadrado1 = restobajo1 * restobajo1
                bajocuadrado2 = restobajo2 * restobajo2
                altocuadrado1 = restoalto1 * restoalto1
                altocuadrado2 = restoalto2 * restoalto2
                sumabajos = bajocuadrado1 + bajocuadrado2
                sumaaltos = altocuadrado1 + altocuadrado2
                desvbajo = Math.Sqrt(sumabajos)
                desvalto = Math.Sqrt(sumaaltos)
                b1 = (desvbajo / promediosbajos) * 100
                a1 = (desvalto / promediosaltos) * 100

                Dim l As New dLecturasIbc
                l.FECHA = fecha5
                l.B1 = b1
                l.A1 = a1
                If (l.guardar) Then
                    MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                    linea = 1
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If

            If linea = 20 Then
                linea = 1
                Do
                    sline2 = objReader2.ReadLine()
                    If linea = 2 Then
                        arraytext = Split(sline2, ",")
                        fecha = Trim(arraytext(0))
                        fecha2 = Mid(fecha, 18, 19)
                        fecha3 = Convert.ToDateTime(fecha2)
                        fecha4 = fecha3.ToString("yyyy-MM-dd HH:mm:ss")
                        fecha5 = Format(fecha4, "yyyy-MM-dd HH:mm:ss")
                    End If
                    If linea = 8 Then
                        arraytext = Split(sline2, ",")
                        sumabajo = sumabajo + Val(Trim(arraytext(10)))
                    ElseIf linea = 9 Then
                        arraytext = Split(sline2, ",")
                        sumabajo = sumabajo + Val(Trim(arraytext(10)))
                    ElseIf linea = 10 Then
                        arraytext = Split(sline2, ",")
                        sumabajo = sumabajo + Val(Trim(arraytext(10)))
                    ElseIf linea = 11 Then
                        arraytext = Split(sline2, ",")
                        sumabajo = sumabajo + Val(Trim(arraytext(10)))
                    ElseIf linea = 12 Then
                        arraytext = Split(sline2, ",")
                        sumabajo = sumabajo + Val(Trim(arraytext(10)))
                    ElseIf linea = 13 Then
                        arraytext = Split(sline2, ",")
                        sumaalto = sumaalto + Val(Trim(arraytext(10)))
                    ElseIf linea = 14 Then
                        arraytext = Split(sline2, ",")
                        sumaalto = sumaalto + Val(Trim(arraytext(10)))
                    ElseIf linea = 15 Then
                        arraytext = Split(sline2, ",")
                        sumaalto = sumaalto + Val(Trim(arraytext(10)))
                    ElseIf linea = 16 Then
                        arraytext = Split(sline2, ",")
                        sumaalto = sumaalto + Val(Trim(arraytext(10)))
                    ElseIf linea = 17 Then
                        arraytext = Split(sline2, ",")
                        sumaalto = sumaalto + Val(Trim(arraytext(10)))
                    End If

                    linea = linea + 1
                Loop Until sline2 Is Nothing
                Dim vmb As Double = Val(TextBajo.Text.Trim)
                Dim vma As Double = Val(TextAlto.Text.Trim)
                Dim promediosbajos As Double = 0
                Dim promediosaltos As Double = 0
                Dim restobajo1 As Double = 0
                Dim restobajo2 As Double = 0
                Dim restoalto1 As Double = 0
                Dim restoalto2 As Double = 0
                Dim desvbajo As Double = 0
                Dim desvalto As Double = 0
                Dim bajocuadrado1 As Double = 0
                Dim bajocuadrado2 As Double = 0
                Dim altocuadrado1 As Double = 0
                Dim altocuadrado2 As Double = 0
                Dim sumabajos As Double = 0
                Dim sumaaltos As Double = 0


                promediobajo = sumabajo / 5
                promedioalto = sumaalto / 5
                promediosbajos = (promediobajo + vmb) / 2
                promediosaltos = (promedioalto + vma) / 2
                restobajo1 = promediobajo - promediosbajos
                restobajo2 = vmb - promediosbajos
                restoalto1 = promedioalto - promediosaltos
                restoalto2 = vma - promediosaltos
                bajocuadrado1 = restobajo1 * restobajo1
                bajocuadrado2 = restobajo2 * restobajo2
                altocuadrado1 = restoalto1 * restoalto1
                altocuadrado2 = restoalto2 * restoalto2
                sumabajos = bajocuadrado1 + bajocuadrado2
                sumaaltos = altocuadrado1 + altocuadrado2
                desvbajo = Math.Sqrt(sumabajos)
                desvalto = Math.Sqrt(sumaaltos)
                b1 = (desvbajo / promediosbajos) * 100
                a1 = (desvalto / promediosaltos) * 100

                Dim l As New dLecturasIbc
                l.FECHA = fecha5
                l.B1 = b1
                l.A1 = a1
                If (l.guardar) Then
                    MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                    linea = 1
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If

            objReader.Close()
            objReader2.Close()

        End If


    End Sub

    Private Sub ButtonCargarLecturas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim v As New FormCambiarVMIBC
        v.ShowDialog()
        If Not v.VM Is Nothing Then
            Dim vm As dControlIbc = v.VM
            TextBajo.Text = vm.BAJO
            TextAlto.Text = vm.ALTO
        End If
    End Sub

    Private Sub ButtonVerGrafica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonVerGrafica.Click
        Dim v As New FormGraficaControlIBC
        v.ShowDialog()
    End Sub
End Class