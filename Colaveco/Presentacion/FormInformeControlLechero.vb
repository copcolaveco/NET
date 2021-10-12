Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System.IO
Public Class FormInformeControlLechero
    Private _usuario As dUsuario
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property
#Region "Constructores"
    Public Sub New(ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        listarfichas()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u

    End Sub
#End Region

    Private Sub ButtonGenerarInforme_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGenerarInforme.Click
        Dim ficha As Long = TextFicha.Text.Trim
        Dim idsolicitud As Long = TextFicha.Text.Trim

        '*** Controla que el productor realiza cambio de caravanas **********************
        Dim sa As New dSolicitudAnalisis
        Dim caravanas As Integer = 0
        sa.ID = idsolicitud
        sa = sa.buscar
        If Not sa Is Nothing Then
            Dim p As New dProductor
            p.ID = sa.IDPRODUCTOR
            p = p.buscar
            If Not p Is Nothing Then
                If p.CARAVANAS = 1 Then
                    caravanas = 1
                End If
            End If
        End If
        If caravanas = 1 Then
            Dim result = MessageBox.Show("El productor realiza cambio de caravanas!, desea continuar?", "Atención!", MessageBoxButtons.YesNoCancel)
            If result = DialogResult.Cancel Then
                limpiar()
                Exit Sub
            ElseIf result = DialogResult.No Then
                limpiar()
                Exit Sub
            ElseIf result = DialogResult.Yes Then

            End If
        End If
        '*********************************************************************************************

        Dim v As New FormSeleccionarTecnico
        v.ShowDialog()
        Dim v2 As New FormMuestrasNoAptas(Usuario, idsolicitud)
        v2.ShowDialog()
        Dim v3 As New FormObservaciones(Usuario, ficha)
        v3.ShowDialog()
        creainformetxt()
        creainformeexcel()
        abrirventanaenvio()
        limpiar()
    End Sub
    Private Sub limpiar()
        TextFicha.Text = ""
        listarfichas()
    End Sub
    Private Sub listarfichas()
        Dim s As New dSolicitudAnalisis
        Dim lista As New ArrayList
        lista = s.listarfichascontrol
        ListFichas.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each s In lista
                    ListFichas().Items.Add(s)
                Next
            End If
        End If
    End Sub
    Private Sub creainformeexcel()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

        Dim c As New dControl

        Dim i As New dIbc
        Dim sa As New dSolicitudAnalisis
        Dim pro As New dProductor
        Dim tec As New dTecnicos
        Dim lista As New ArrayList
        Dim lista2 As New ArrayList
        Dim lista3 As New ArrayList
        '*****************************
        Dim idsol As Long = TextFicha.Text.Trim
        sa.ID = idsol
        sa = sa.buscar
        '*****************************
        sa.marcar(Usuario)

        '*****************************
        Dim fila As Integer
        Dim columna As Integer
        'fila = 17
        'columna = 1
        'ListAntibiogramas.Items.Clear()
        fila = 1
        columna = 2

        'Poner Titulos
        x1hoja.Shapes.AddPicture("c:\Debug\logo.jpg", _
         Microsoft.Office.Core.MsoTriState.msoFalse, _
        Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 80, 35)

        'x1hoja.Shapes.AddPicture("c:\Debug\oua.jpg", _
        'Microsoft.Office.Core.MsoTriState.msoFalse, _
        'Microsoft.Office.Core.MsoTriState.msoCTrue, 400, 140, 80, 35)



        'x1hoja.Cells(1, 1).columnwidth = 7
        x1hoja.Cells(1, 1).columnwidth = 7
        x1hoja.Cells(1, 2).columnwidth = 5
        x1hoja.Cells(1, 3).columnwidth = 5
        x1hoja.Cells(1, 4).columnwidth = 5
        x1hoja.Cells(1, 5).columnwidth = 5
        x1hoja.Cells(1, 6).columnwidth = 7
        x1hoja.Cells(1, 7).columnwidth = 4
        x1hoja.Cells(1, 8).columnwidth = 7
        x1hoja.Cells(1, 9).columnwidth = 5
        x1hoja.Cells(1, 10).columnwidth = 5
        'x1hoja.Cells(1, 11).columnwidth = 8
        x1hoja.Cells(1, 11).columnwidth = 5
        'x1hoja.Cells(1, 12).columnwidth = 6
        x1hoja.Cells(1, 12).columnwidth = 5
        x1hoja.Cells(1, 13).columnwidth = 7
        x1hoja.Range("A1", "D1").Merge()

        columna = 4
        fila = fila + 1
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Formula = "Parque El Retiro, Nueva Helvecia. Tel/Fax: 45545311 / 45545975 / 45546838"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Range("B4", "C4").Merge()
        fila = fila + 1
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Formula = "Email: colaveco@gmail.com - Sitio: http://www.colaveco.com.uy"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Range("A5", "M5").Merge()
        fila = fila + 2
        columna = 1
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Formula = "INFORME DEL RECUENTO CELULAR Y COMPOSICIÓN DE VACAS INDIVIDUALES"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        fila = fila + 2
        columna = 1
        x1hoja.Cells(fila, columna).Formula = "Nº Ficha:"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        columna = columna + 2
        x1hoja.Cells(fila, columna).formula = sa.ID
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        columna = columna + 5
        x1hoja.Cells(fila, columna).Formula = "Métodos y estándares:"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 7
        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).Formula = "Cliente:"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        columna = columna + 2
        pro.ID = sa.IDPRODUCTOR
        pro = pro.buscar
        x1hoja.Cells(fila, columna).formula = pro.NOMBRE
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        columna = columna + 5
        x1hoja.Range("H8", "M8").Merge()
        x1hoja.Range("H8", "M8").Borders.Color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).formula = "R. Celular x 1000cel/mL (Mét. IR - ISO 13366-2:2006)"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 8
        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).Formula = "Dirección:"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        columna = columna + 2
        If pro.DIRECCION <> "" Then
            x1hoja.Cells(fila, columna).formula = pro.DIRECCION
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Size = 8
        Else
            x1hoja.Cells(fila, columna).formula = "No aportado"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Size = 8
        End If
        columna = columna + 5
        x1hoja.Range("H9", "M9").Merge()
        x1hoja.Range("H9", "M9").Borders.Color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).formula = "Gr, Pr, Lc % peso/vol.(Mét. IR - IDF 141C:2000)"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).Formula = "Fecha entrada:"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 7
        columna = columna + 2
        x1hoja.Range("C10", "D10").Merge()
        x1hoja.Cells(fila, columna).formula = sa.FECHAINGRESO
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        columna = columna + 5
        x1hoja.Range("H10", "M10").Merge()
        x1hoja.Range("H10", "M10").Borders.Color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).formula = "MUN mg/dL (Mét. IR - Boletín FIL 393:2003"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).Formula = "Fecha emisión:"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 7
        columna = columna + 2
        x1hoja.Range("C11", "D11").Merge()
        Dim fecha As Date = Now()
        Dim fecha2 As String = fecha.ToString("dd/MM/yyyy")
        x1hoja.Cells(fila, columna).formula = fecha2
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        columna = columna + 5
        x1hoja.Cells(fila, columna).formula = "Gr = Grasa, Pr = Proteina, Lc = Lactosa"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).Formula = "Paratécnico:"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 7
        columna = columna + 2

        Dim paratecnico As String = ""
        If idparatecnico1 = 1 Then
            paratecnico = paratecnico + "Diego Arenas - "
        End If
        If idparatecnico2 = 1 Then
            paratecnico = paratecnico + "Lorena Nidegger - "
        End If
        If idparatecnico3 = 1 Then
            paratecnico = paratecnico + "Claudia García - "
        End If
        If idparatecnico4 = 1 Then
            paratecnico = paratecnico + "Erika Silva - "
        End If
        If paratecnico <> "" Then
            x1hoja.Cells(fila, columna).formula = paratecnico
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Size = 8
            'fila = fila + 1
            'columna = 1
        Else
            x1hoja.Cells(fila, columna).formula = ""
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Size = 8
            'fila = fila + 1
            'columna = 1
        End If

        'If idparatecnicocontrol = 1 Then
        '    x1hoja.Cells(fila, columna).formula = "Diego Arenas"
        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        '    x1hoja.Cells(fila, columna).Font.Size = 8
        'ElseIf idparatecnicocontrol = 2 Then
        '    x1hoja.Cells(fila, columna).formula = "Lorena Nidegger"
        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        '    x1hoja.Cells(fila, columna).Font.Size = 8
        'ElseIf idparatecnicocontrol = 3 Then
        '    x1hoja.Cells(fila, columna).formula = "Claudia García"
        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        '    x1hoja.Cells(fila, columna).Font.Size = 8
        'ElseIf idparatecnicocontrol = 0 Then
        '    x1hoja.Cells(fila, columna).formula = ""
        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        '    x1hoja.Cells(fila, columna).Font.Size = 8
        'End If
        columna = columna + 5
        x1hoja.Cells(fila, columna).formula = "MUN = Nitrogeno ureico"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        fila = fila + 1
        columna = 1
        'x1hoja.Cells(fila, columna).Formula = "Temperatura de arribo de la/s muestra/s:"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 7
        columna = columna + 5
        'Dim valtemperatura = Val(sa.TEMPERATURA)
        'If valtemperatura < 1 Or valtemperatura > 7 Then
        'x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        'End If
        'x1hoja.Cells(fila, columna).formula = sa.TEMPERATURA & " " & "Cº"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        columna = columna + 2
        x1hoja.Cells(fila, columna).formula = "Rc = Recuento celular"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        fila = fila + 2
        columna = 1

        'x1hoja.Range("H8", "M13").Border.Color = RGB(255, 0, 0)
        'x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)

        lista = c.listarporsolicitud(idsol)
        lista2 = c.listarporrc(idsol)

        x1hoja.Cells(fila, columna).Formula = "Listado ordenado por identificación"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        columna = columna + 7
        x1hoja.Cells(fila, columna).Formula = "Listado ordenado decreciente por Recuento celular"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8

        fila = fila + 1
        columna = 1
        Dim filaguia As Integer = fila



        x1hoja.Cells(fila, columna).Formula = "Ident."
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Rc*"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Gr*"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Pr*"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Lc"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "MUN"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter

        columna = 1
        fila = fila + 1

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim cs As New dControlSolicitud
                cs.IDSOLICITUD = idsol
                cs = cs.buscar
                
                For Each c In lista
                    If c.MUESTRA <> "" Then
                        x1hoja.Cells(fila, columna).formula = Trim(c.MUESTRA)
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    End If
                    If c.RC = -1 Then
                        x1hoja.Cells(fila, columna).formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    Else
                        If c.RC < 4 Then
                            x1hoja.Cells(fila, columna).formula = "4"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        Else
                            x1hoja.Cells(fila, columna).formula = c.RC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        End If
                    End If
                    If c.GRASA = -1 Or c.GRASA = 0 Then
                        columna = columna - 1
                        x1hoja.Cells(fila, columna).formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1

                        x1hoja.Cells(fila, columna).formula = "MUESTRA NO APTA **"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    Else
                        Dim valgrasa = Val(c.GRASA)
                        If valgrasa < 2 Or valgrasa > 5.5 Then
                            x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                        End If
                        x1hoja.Cells(fila, columna).formula = FormatNumber(c.GRASA, 2)
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    End If
                    If c.PROTEINA = -1 Or c.PROTEINA = 0 Then
                        x1hoja.Cells(fila, columna).formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    Else
                        Dim valproteina = Val(c.PROTEINA)
                        If valproteina < 2 Or valproteina > 4.5 Then
                            x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                        End If
                        x1hoja.Cells(fila, columna).formula = FormatNumber(c.PROTEINA, 2)
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    End If
                    If c.LACTOSA = -1 Or c.LACTOSA = 0 Then
                        x1hoja.Cells(fila, columna).formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = FormatNumber(c.LACTOSA, 2)
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    End If
                 
                    If cs.UREA = 1 Then
                        If c.UREA = -1 Or c.UREA = 0 Then
                            x1hoja.Cells(fila, columna).formula = "-"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        Else
                            Dim valorurea As Integer
                            valorurea = c.UREA * 0.466
                            x1hoja.Cells(fila, columna).formula = FormatNumber(valorurea, 0)
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        End If
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    End If
                    columna = 1
                    fila = fila + 1
                Next
                'Referencias
                fila = fila + 1
                columna = 1
            End If
            '****** ORDENADO POR RC ************************************************************************
            Dim libreinfeccion As Integer = 0
            Dim posibleinfeccion As Integer = 0
            Dim probableinfeccion As Integer = 0

            fila = filaguia
            columna = 8
            x1hoja.Cells(fila, columna).Formula = "Ident."
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            columna = columna + 1
            x1hoja.Cells(fila, columna).Formula = "Rc*"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            columna = columna + 1
            x1hoja.Cells(fila, columna).Formula = "Gr*"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            columna = columna + 1
            x1hoja.Cells(fila, columna).Formula = "Pr*"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            columna = columna + 1
            x1hoja.Cells(fila, columna).Formula = "Lc"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            columna = columna + 1
            x1hoja.Cells(fila, columna).Formula = "MUN"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter

            columna = 8
            fila = fila + 1

            If Not lista2 Is Nothing Then
                If lista2.Count > 0 Then

                    Dim cs As New dControlSolicitud
                    cs.IDSOLICITUD = idsol
                    cs = cs.buscar
                    For Each c In lista2
                        If c.MUESTRA <> "" Then
                            x1hoja.Cells(fila, columna).formula = Trim(c.MUESTRA)
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        Else
                            x1hoja.Cells(fila, columna).formula = "-"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        End If
                        If c.RC = -1 Then
                            x1hoja.Cells(fila, columna).formula = ""
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        Else
                            If c.RC < 4 Then
                                x1hoja.Cells(fila, columna).formula = "4"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = c.RC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                            End If
                        End If
                        If c.RC < 150 Then
                            libreinfeccion = libreinfeccion + 1
                        ElseIf c.RC <= 150 Or c.RC < 400 Then
                            posibleinfeccion = posibleinfeccion + 1
                        ElseIf c.RC >= 400 Then
                            probableinfeccion = probableinfeccion + 1
                        End If
                        If c.GRASA = -1 Or c.GRASA = 0 Then
                            columna = columna - 1
                            x1hoja.Cells(fila, columna).formula = ""
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1

                            x1hoja.Cells(fila, columna).formula = "MUESTRA NO APTA **"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        Else
                            Dim valgrasa = Val(c.GRASA)
                            If valgrasa < 2 Or valgrasa > 5.5 Then
                                x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                            End If
                            x1hoja.Cells(fila, columna).formula = FormatNumber(c.GRASA, 2)
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        End If
                        If c.PROTEINA = -1 Or c.PROTEINA = 0 Then
                            x1hoja.Cells(fila, columna).formula = ""
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        Else
                            Dim valproteina = Val(c.PROTEINA)
                            If valproteina < 2 Or valproteina > 4.5 Then
                                x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                            End If
                            x1hoja.Cells(fila, columna).formula = FormatNumber(c.PROTEINA, 2)
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        End If
                        If c.LACTOSA = -1 Or c.LACTOSA = 0 Then
                            x1hoja.Cells(fila, columna).formula = ""
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        Else
                            x1hoja.Cells(fila, columna).formula = FormatNumber(c.LACTOSA, 2)
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        End If
                        If cs.UREA = 1 Then
                            If c.UREA = -1 Or c.UREA = 0 Then
                                x1hoja.Cells(fila, columna).formula = "-"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                            Else
                                Dim valorurea As Integer
                                valorurea = c.UREA * 0.466
                                x1hoja.Cells(fila, columna).formula = FormatNumber(valorurea, 0)
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                            End If
                        Else
                            x1hoja.Cells(fila, columna).formula = "-"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        End If
                        columna = 8
                        fila = fila + 1
                    Next
                    'Referencias
                    fila = fila + 1
                    columna = 1
                End If
                

                '******* CALCULO PRECIO ************************************************************************

                Dim listamuestras As New ArrayList
                listamuestras = c.listarporsolicitud(idsol)
                Dim total As Double
                Dim ana As New dAnalisis
                Dim minimomuestras As Integer = 0

                Dim idtimbre As Integer = 86
                Dim idrc_comp As Integer = 116
                Dim idrc_comp_urea As Integer = 117

                Dim preciotimbre As Double
                Dim preciorc_comp As Double
                Dim preciorc_comp_urea As Double


                ana.ID = idtimbre
                ana = ana.buscar
                preciotimbre = ana.COSTO


                ana.ID = idrc_comp
                ana = ana.buscar
                preciorc_comp = ana.COSTO

                ana.ID = idrc_comp_urea
                ana = ana.buscar
                preciorc_comp_urea = ana.COSTO

                '*** CUENTA MUESTRAS NO APTAS ***************************************
                Dim mna As New dMuestrasNoAptas
                Dim cuenta_mna As Integer = 0
                Dim faltan As Integer = 0
                lista3 = mna.listarporficha(idsol)
                If Not lista3 Is Nothing Then
                    If lista3.Count > 0 Then
                        For Each mna In lista3
                            cuenta_mna = cuenta_mna + mna.CANTIDAD
                            If mna.MOTIVO = 4 Or mna.MOTIVO = 6 Then
                                faltan = faltan + 1
                            End If
                        Next
                    End If
                End If
                '********************************************************************

                Dim muestras As Integer = 0
                Dim muestrastotales As Integer = 0
                Dim muestrasanalizadas As Integer = 0
                Dim total2 As Double = 0
                muestras = listamuestras.Count
                muestrasanalizadas = listamuestras.Count
                Dim muestrasreales As Integer = 0
                muestrasreales = listamuestras.Count
                'muestrasreales = muestrasreales - cuenta_mna

                'Descuento al total de muestras las marcadas como faltan
                muestras = muestras - faltan

                If muestras < 20 Then
                    muestras = 20
                    minimomuestras = 1
                Else
                    If cuenta_mna > 0 Then
                        muestras = muestras - cuenta_mna
                        muestrastotales = muestras + cuenta_mna
                        If muestras < 20 Then
                            muestras = 20
                            cuenta_mna = muestrastotales - muestras
                        End If
                    End If
                End If

                Dim subtipo As Integer
                subtipo = sa.IDSUBINFORME

                If subtipo = 1 Then
                    total = muestras * preciorc_comp
                    total2 = (cuenta_mna * preciorc_comp) * 0.5
                ElseIf subtipo = 32 Then
                    total = muestras * preciorc_comp_urea
                    total2 = (cuenta_mna * preciorc_comp_urea) * 0.5
                End If

                If minimomuestras = 0 Then
                    total = total + total2 + preciotimbre
                Else
                    total = total + preciotimbre
                End If

                columna = 1

                If sa.OBSERVACIONES <> "" Then
                    x1hoja.Cells(fila, columna).formula = "Observaciones:"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    fila = fila + 1
                    If sa.OBSERVACIONES <> "" Then
                        x1hoja.Cells(fila, columna).formula = sa.OBSERVACIONES
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        fila = fila + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = "Sin observaciones."
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        fila = fila + 1
                    End If
                    fila = fila + 1
                End If

                x1hoja.Cells(fila, columna).formula = "Total de muestras recibidas:" & " " & muestrasanalizadas
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                columna = columna + 6
                x1hoja.Cells(fila, columna).formula = ""
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Valor fuera de rango (<2 o >4,5 Proteína"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = False
                columna = 1
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Por concepto de análisis: $" & " " & Math.Round(total, 0)
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                columna = columna + 7
                x1hoja.Cells(fila, columna).formula = "<2 o >5,5 Grasa)"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = False
                columna = 1
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Este precio incluye IVA y timbre CJPPU"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                columna = columna + 6
                x1hoja.Cells(fila, columna).formula = "-"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Análisis no requerido"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = False
                fila = fila + 2
                columna = 1

                'fila = fila - 1
                x1libro.Worksheets(1).cells(fila, columna).select()
                x1libro.ActiveSheet.pictures.Insert("c:\Debug\dario.jpg").select()
                x1libro.Worksheets(1).cells(2, 1).select()
                'fila = fila + 5

                columna = columna + 6
                x1hoja.Cells(fila, columna).formula = "Interpretación de recuento celular"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                columna = columna + 1
                x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                columna = columna + 1
                x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                columna = columna + 1
                x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                columna = columna + 1
                x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                columna = columna + 1
                x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                columna = columna - 5
                fila = fila + 1
               
                Dim vallibreinfeccion As Integer = 0
                Dim valposibleinfeccion As Integer = 0
                Dim valprobableinfeccion As Integer = 0
                Dim sumavalores As Integer = 0
                Dim diferenciavalores As Integer = 0
                
                vallibreinfeccion = (libreinfeccion / muestrasreales) * 100
                valposibleinfeccion = (posibleinfeccion / muestrasreales) * 100
                valprobableinfeccion = (probableinfeccion / muestrasreales) * 100

                sumavalores = vallibreinfeccion + valposibleinfeccion + valprobableinfeccion
                diferenciavalores = sumavalores - 100
                If diferenciavalores < 0 Then
                    diferenciavalores = diferenciavalores * -1
                End If
                If sumavalores > 100 Then
                    vallibreinfeccion = vallibreinfeccion - diferenciavalores
                ElseIf sumavalores < 100 Then
                    vallibreinfeccion = vallibreinfeccion + diferenciavalores
                End If

               

                x1hoja.Cells(fila, columna).formula = "<150: probablemente libre de infección:" & " " & libreinfeccion & " " & "(" & Math.Round(vallibreinfeccion, 0) & " %" & ")"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                columna = columna + 1
                x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                columna = columna + 1
                x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                columna = columna + 1
                x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                columna = columna + 1
                x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                columna = columna + 1
                x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                columna = columna - 5
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "150-400: posiblemente infectadas:" & " " & posibleinfeccion & " " & "(" & Math.Round(valposibleinfeccion, 0) & " %" & ")"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                columna = columna + 1
                x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                columna = columna + 1
                x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                columna = columna + 1
                x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                columna = columna + 1
                x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                columna = columna + 1
                x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                columna = columna - 5
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = ">400: probablemente infectadas:" & " " & probableinfeccion & " " & "(" & Math.Round(valprobableinfeccion, 0) & " %" & ")"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                columna = columna + 1
                x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                columna = columna + 1
                x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                columna = columna + 1
                x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                columna = columna + 1
                x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                columna = columna + 1
                x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                columna = columna - 5
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "R.Blowey & P. Edmonson, (1995)"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                columna = columna + 1
                x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                columna = columna + 1
                x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                columna = columna + 1
                x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                columna = columna + 1
                x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                columna = columna + 1
                x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                '** SI HAY MUESTRAS NO APTAS ***************************************
                If cuenta_mna > 0 Then
                    columna = 1
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).formula = "(**) No apta por:"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                    columna = 1
                    fila = fila + 1
                    Dim muestrasna As New dMuestrasNoAptas
                    Dim muestrana As New dMuestraNoApta
                    Dim motivomna As Integer = 0
                    Dim cantidadmna As Integer = 0
                    lista3 = muestrasna.listarporficha(idsol)
                    If Not lista3 Is Nothing Then
                        If lista3.Count > 0 Then
                            For Each muestrasna In lista3
                                motivomna = muestrasna.MOTIVO
                                muestrana.ID = motivomna
                                muestrana = muestrana.buscar()
                                x1hoja.Cells(fila, columna).formula = muestrana.NOMBRE
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                                columna = columna + 1
                                cantidadmna = muestrasna.CANTIDAD
                                x1hoja.Cells(fila, columna).formula = cantidadmna
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                                columna = 1
                                fila = fila + 1
                            Next
                        End If
                    End If
                    x1hoja.Cells(fila, columna).formula = "Muestras no aptas = 50% importe del análisis"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    x1hoja.Cells(fila, columna).Font.Bold = True
                End If



                '*******************************************************************
                columna = 1
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Este informe no podrá ser reproducido total o parcialmente sin la autorización escrita de COLAVECO."
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Los resultados consignados se refieren exclusivamente a la muestra recibida."
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "COLAVECO declina toda responsabilidad por el uso indebido o incorrecto que se hiciere a este informe,"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "asi como el plan y procedimientos de muestreo aplicados por el cliente. Dr. Darío Hirigoyen (Director)."
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6



            End If
            End If




            'PROTEGE LA HOJA DE EXCEL
            x1hoja.Protect(Password:="1582782", DrawingObjects:=True, _
                Contents:=True, Scenarios:=True)
            'GUARDA EL ARCHIVO DE EXCEL
        x1hoja.SaveAs("\\SRVCOLAVECO\D\NET\CONTROL_LECHERO\" & idsol & ".xls")
        'x1hoja.SaveAs("c:\NET\CONTROL_LECHERO\" & idsol & ".xls")

            'x1hoja.Protect(Password:="pepo", DrawingObjects:=True, _
            'Contents:=True, Scenarios:=True)
            'x1hoja.SaveAs("C:\" & idsol & ".xls")
            x1app.Visible = True
            'x1libro.Close()
            x1app = Nothing
            x1libro = Nothing
            x1hoja = Nothing
    End Sub

    Private Sub creainformetxt()
        Dim idficha As Long = TextFicha.Text.Trim
        Dim oSW As New StreamWriter("\\SRVCOLAVECO\D\NET\CONTROL_LECHERO\" & idficha & ".txt")
        Dim c As New dControl
        Dim lista4 As New ArrayList
        lista4 = c.listarporsolicitud(idficha)
        Dim secuencial As Integer = 1

        If Not lista4 Is Nothing Then
            If lista4.Count > 0 Then
                Dim cs As New dControlSolicitud
                cs.IDSOLICITUD = idficha
                cs = cs.buscar
                Dim Linea As String = ""

                For Each c In lista4
                    Linea = Linea & secuencial & Chr(9)
                    If c.MUESTRA <> "" Then
                        Linea = Linea & c.MUESTRA + Chr(9)
                    Else
                        Linea = Linea & "-" & Chr(9)
                    End If
                    If c.GRASA = -1 Or c.GRASA = 0 Then
                        Linea = Linea & "-" & Chr(9)
                    Else
                        Dim valgrasa = Val(c.GRASA)
                        Linea = Linea & valgrasa & Chr(9)
                    End If
                    If c.PROTEINA = -1 Or c.PROTEINA = 0 Then
                        Linea = Linea & "-" & Chr(9)
                    Else
                        Dim valproteina = Val(c.PROTEINA)
                        Linea = Linea & valproteina & Chr(9)
                    End If
                    If c.LACTOSA = -1 Or c.LACTOSA = 0 Then
                        Linea = Linea & "-" & Chr(9)
                    Else
                        Linea = Linea & c.LACTOSA & Chr(9)
                    End If
                    'If cs.UREA = 1 Then
                    'If c.UREA = -1 Or c.UREA = 0 Then
                    'Linea = Linea & vbNewLine
                    'Else
                    'Dim valorurea As Integer
                    'valorurea = c.UREA * 0.466
                    'Linea = Linea & valorurea & vbNewLine
                    'End If
                    'Else
                    'Linea = Linea & vbNewLine
                    'End If
                    Linea = Linea & "0" & Chr(9)
                    If c.RC = -1 Then
                        Linea = Linea & "-" '& vbNewLine
                    Else
                        If c.GRASA = -1 Or c.GRASA = 0 Then
                            Linea = Linea & "-" & Chr(9)
                        Else
                            If c.RC < 4 Then
                                Linea = Linea & "4" ' & vbNewLine
                            Else
                                Linea = Linea & c.RC ' & vbNewLine
                            End If
                        End If
                    End If
                    oSW.WriteLine(Linea)
                    Linea = ""
                    secuencial = secuencial + 1
                Next
            End If
        End If

        Dim sa2 As New dSolicitudAnalisis
        sa2.ID = idficha
        sa2.NMUESTRAS = secuencial - 1
        sa2.actualizar_cantidad_muestras(Usuario)
        oSW.Flush()
    End Sub

    Private Sub ListFichas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListFichas.SelectedIndexChanged
        If ListFichas.SelectedItems.Count = 1 Then
            Dim s As dSolicitudAnalisis = CType(ListFichas.SelectedItem, dSolicitudAnalisis)
            TextFicha.Text = s.ID
        End If
    End Sub
    Private Sub abrirventanaenvio()
        Dim v As New FormSubirInformes(Usuario)
        v.ShowDialog()
    End Sub
End Class