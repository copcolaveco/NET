Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System
Imports System.IO
Imports System.Collections
Public Class FormRgLab88
    Private _usuario As dUsuario
    Dim _hora As String
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property

    Public Sub New(ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        Timer1.Enabled = True
        cargarlista()
        cargarCombos()
        listarfuerarango()
        limpiar()

    End Sub

    Private Sub cargarlista()
        Dim r As New dRgLab88
        Dim lista As New ArrayList
        lista = r.listar
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each r In lista
                    DataGridView1(columna, fila).Value = r.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = r.FECHA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = r.FICHA
                    columna = 0
                    fila = fila + 1
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub
    Public Sub cargarCombos()
        Dim u As New dUsuario
        Dim lista As New ArrayList
        lista = u.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each u In lista
                    ComboOperador.Items.Add(u)
                    ComboEliminado.Items.Add(u)
                Next
            End If
        End If
    End Sub

    Public Sub limpiar()
        _hora = Now.ToString("HH:mm")
        TextId.Text = ""
        DateFecha.Value = Now
        TextHora.Text = _hora
        TextFicha.Text = ""
        TextMuestra.Text = ""
        TextCrioscopo.Text = ""
        TextDelta.Text = ""
        ComboOperador.SelectedItem = Usuario.ID
        ComboOperador.Text = Usuario.NOMBRE
        ComboEliminado.SelectedItem = Usuario.ID
        ComboEliminado.Text = Usuario.NOMBRE
        TextObservaciones.Text = ""
        listarfuerarango()
        TextFicha.Select()
    End Sub

    Private Sub ButtonNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo.Click
        limpiar()
        cargarlista()
    End Sub

    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click
        If TextId.Text <> "" Then
            If MsgBox("El registro será eliminado, ¿desea continuar?", MsgBoxStyle.OkCancel, "Atención") = MsgBoxResult.Ok Then
                Dim r As New dRgLab88
                Dim id As Long = CType(TextId.Text, Long)
                r.ID = id
                If (r.eliminar(Usuario)) Then
                    MsgBox("Registro eliminado", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        End If
        limpiar()
        cargarlista()
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click

        Dim fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        Dim hora As String = TextHora.Text.Trim
        Dim ficha As Long = TextFicha.Text.Trim
        Dim muestra As String = TextMuestra.Text
        Dim crioscopo As Double = TextCrioscopo.Text.Trim
        Dim delta As Double = TextDelta.Text.Trim
        Dim operador As dUsuario = CType(ComboOperador.SelectedItem, dUsuario)

        Dim eliminado As dUsuario = CType(ComboEliminado.SelectedItem, dUsuario)
        Dim observaciones As String = TextObservaciones.Text

        If TextId.Text.Trim.Length > 0 Then
            Dim r As New dRgLab88()
            Dim id As Long = CType(TextId.Text.Trim, Long)
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")
            r.ID = id
            r.FECHA = fec
            r.HORA = hora
            r.FICHA = ficha
            r.MUESTRA = muestra
            r.CRIOSCOPO = crioscopo
            r.DELTA = delta
            If Not operador Is Nothing Then
                r.OPERADOR = operador.ID
            Else
                MsgBox("Falta ingresar el operador")
                ComboOperador.Focus()
                Exit Sub
            End If
            If Not eliminado Is Nothing Then
                r.ELIMINADO = eliminado.ID
            Else
                MsgBox("Falta ingresar la persona que elimina las muestras")
                ComboEliminado.Focus()
                Exit Sub
            End If
            r.OBSERVACIONES = observaciones
            If (r.modificar(Usuario)) Then
                Dim cc As New dCrioscopia_Control
                cc.FICHA = ficha
                cc.MUESTRA = muestra
                cc.DELTA = delta
                cc.CRIOSCOPO = crioscopo
                cc.MARCA = 1
                cc.modificar2(Usuario)
                MsgBox("Registro modificado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim r As New dRgLab88()
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")
            r.FECHA = fec
            r.HORA = hora
            r.FICHA = ficha
            r.MUESTRA = muestra
            r.CRIOSCOPO = crioscopo
            r.DELTA = delta
            If Not operador Is Nothing Then
                r.OPERADOR = operador.ID
            Else
                MsgBox("Falta ingresar el operador")
                ComboOperador.Focus()
                Exit Sub
            End If
            If Not eliminado Is Nothing Then
                r.ELIMINADO = eliminado.ID
            Else
                MsgBox("Falta ingresar la persona que elimina las muestras")
                ComboEliminado.Focus()
                Exit Sub
            End If
            r.OBSERVACIONES = observaciones
            If (r.guardar(Usuario)) Then
                Dim cc As New dCrioscopia_Control
                cc.FICHA = ficha
                cc.MUESTRA = muestra
                cc.DELTA = delta
                cc.CRIOSCOPO = crioscopo
                cc.MARCA = 1
                cc.modificar2(Usuario)
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        cargarlista()
        limpiar()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Fecha" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim r As New dRgLab88
            id = row.Cells("Id").Value
            r.ID = id
            r = r.buscar
            If Not r Is Nothing Then
                TextId.Text = r.ID
                DateFecha.Value = r.FECHA
                TextHora.Text = r.HORA
                TextFicha.Text = r.FICHA
                TextMuestra.Text = r.MUESTRA
                TextCrioscopo.Text = r.CRIOSCOPO
                TextDelta.Text = r.DELTA
                Dim op As New dUsuario
                For Each op In ComboOperador.Items
                    If op.ID = r.OPERADOR Then
                        ComboOperador.SelectedItem = op
                        ComboOperador.Text = op.NOMBRE
                        Exit For
                    End If
                Next
                Dim us As New dUsuario
                For Each us In ComboEliminado.Items
                    If us.ID = r.ELIMINADO Then
                        ComboEliminado.SelectedItem = us
                        ComboEliminado.Text = us.NOMBRE
                        Exit For
                    End If
                Next
                TextObservaciones.Text = r.OBSERVACIONES
            End If
        End If

        If DataGridView1.Columns(e.ColumnIndex).Name = "Ficha" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim r As New dRgLab88
            id = row.Cells("Id").Value
            r.ID = id
            r = r.buscar
            If Not r Is Nothing Then
                TextId.Text = r.ID
                DateFecha.Value = r.FECHA
                TextHora.Text = r.HORA
                TextFicha.Text = r.FICHA
                TextMuestra.Text = r.MUESTRA
                TextCrioscopo.Text = r.CRIOSCOPO
                TextDelta.Text = r.DELTA
                Dim op As New dUsuario
                For Each op In ComboOperador.Items
                    If op.ID = r.OPERADOR Then
                        ComboOperador.SelectedItem = op
                        ComboOperador.Text = op.NOMBRE
                        Exit For
                    End If
                Next
                Dim us As New dUsuario
                For Each us In ComboEliminado.Items
                    If us.ID = r.ELIMINADO Then
                        ComboEliminado.SelectedItem = us
                        ComboEliminado.Text = us.NOMBRE
                        Exit For
                    End If
                Next
                TextObservaciones.Text = r.OBSERVACIONES
            End If
        End If
    End Sub

    Private Sub actualizarhora()
        If TextId.Text = "" Then
            _hora = Now.ToString("HH:mm")
            TextHora.Text = _hora
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        actualizarhora()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        importar()
        importar2()
        buscarfuerarango()
        listarfuerarango()
    End Sub
    Private Sub importar()
       
            Dim ca As New dCalidadAux2
            ca.eliminartodo(Usuario)
            Dim extension As String
            Dim nombrearchivo As String = ""
            Dim linea As Integer
        Dim folder As New DirectoryInfo("\\DELTA400\Samples")
            Dim _ficheros() As String
        _ficheros = Directory.GetFiles("\\DELTA400\Samples")
            If Not (_ficheros.Length > 0) Then
            Else
                For Each file As FileInfo In folder.GetFiles("*.csv")
                    nombrearchivo = file.Name
                    linea = 1
                    extension = Microsoft.VisualBasic.Right(file.Name, 3)
                Dim objReader As New StreamReader("\\DELTA400\Samples\" & file.Name)
                    Dim sLine As String = ""
                    Dim arraytext() As String
                    Dim matricula As String = ""
                    Dim ficha As String = ""
                    Dim ficha2 As String = ""
                    Dim ficha3 As String = ""
                    Dim crioscopia As Integer = 0

                    ' *** SI EL ARCHIVO ES CSV **************************************************************************************
                    If extension = "csv" Or extension = "CSV" Then
                        Dim c As New dCalidadAux2()
                        Do
                            sLine = objReader.ReadLine()
                            If sLine <> " " Then
                                If linea = 3 Then
                                    arraytext = Split(sLine, ";")
                                    If arraytext.Length < 11 Then
                                        arraytext = Split(sLine, ",")
                                    End If
                                End If
                                If Not sLine Is Nothing Then
                                    If linea >= 8 Then
                                        arraytext = Split(sLine, ";")
                                        If arraytext.Length < 39 Then
                                        arraytext = Split(sLine, ";")
                                        End If
                                    matricula = Trim(arraytext(1))
                                        If arraytext.Length <= 13 Then
                                        If Trim(arraytext(9)) = "" Or Trim(arraytext(9)) = "-" Then
                                            crioscopia = -1
                                        Else
                                            Try
                                                crioscopia = arraytext(9)
                                            Catch ex As Exception
                                                MsgBox("Error en archivo: " & file.Name & ", línea: " & linea & ", valor: Crioscopía")
                                                Exit Sub
                                            End Try
                                        End If
                                    Else
                                        If Trim(arraytext(9)) = "" Or Trim(arraytext(9)) = "-" Then
                                            crioscopia = -1
                                        Else
                                            Try
                                                crioscopia = arraytext(9)
                                            Catch ex As Exception
                                                MsgBox("Error en archivo: " & file.Name & ", línea: " & linea & ", valor: Crioscopía")
                                                Exit Sub
                                            End Try
                                        End If
                                    End If
                                        ficha2 = Mid(file.Name, Len(file.Name) - 4, 1)
                                        ficha3 = Mid(file.Name, 1, 1)
                                        If ficha2 = "a" Or ficha2 = "A" Or ficha2 = "b" Or ficha2 = "B" Or ficha2 = "c" Or ficha2 = "C" Or ficha2 = "d" Or ficha2 = "D" Or ficha2 = "e" Or ficha2 = "E" Or ficha2 = "f" Or ficha2 = "F" Or ficha2 = "g" Or ficha2 = "G" Or ficha2 = "h" Or ficha2 = "H" Or ficha2 = "i" Or ficha2 = "I" Or ficha2 = "j" Or ficha2 = "J" Or ficha2 = "k" Or ficha2 = "K" Then
                                            ficha = Mid(file.Name, 1, Len(file.Name) - 5)
                                        Else
                                            ficha = Mid(file.Name, 1, Len(file.Name) - 4)
                                        End If
                                        If Mid(ficha, 1, 1) = "l" Or Mid(ficha, 1, 1) = "L" Then
                                            Dim MyString As String = ficha
                                            Dim MyChar As Char() = {"l"c, "L"c}
                                            Dim NewString As String = MyString.TrimStart(MyChar)
                                            ficha3 = NewString
                                        Else
                                            ficha3 = ficha
                                        End If
                                        c.FICHA = ficha3
                                        c.MUESTRA = matricula
                                        c.CRIOSCOPIA = crioscopia
                                        c.guardar(Usuario)
                                    End If
                                End If
                            End If
                            linea = linea + 1
                        Loop Until sLine Is Nothing
                        objReader.Close()
                    End If
                Next
            End If
    End Sub
    Private Sub importar2()

            Dim ca As New dCalidadAux2
            'ca.eliminartodo(Usuario)
            Dim extension As String
            Dim nombrearchivo As String = ""
            Dim linea As Integer
            'Dim folder As New DirectoryInfo("\\DELTA\Samples")
        Dim folder As New DirectoryInfo("\\DELTA2\Export\CSV")
            Dim _ficheros() As String
            '_ficheros = Directory.GetFiles("\\DELTA\Samples")
        _ficheros = Directory.GetFiles("\\DELTA2\Export\CSV")

            If Not (_ficheros.Length > 0) Then
            Else
                For Each file As FileInfo In folder.GetFiles("*.csv")
                    nombrearchivo = file.Name
                    linea = 1
                    extension = Microsoft.VisualBasic.Right(file.Name, 3)
                Dim objReader As New StreamReader("\\DELTA2\Export\CSV\" & file.Name)
                    Dim sLine As String = ""
                    Dim arraytext() As String
                    Dim matricula As String = ""
                    Dim ficha As String = ""
                    Dim ficha2 As String = ""
                    Dim ficha3 As String = ""
                    Dim crioscopia As Integer = 0
                    ' *** SI EL ARCHIVO ES CSV **************************************************************************************
                    If extension = "csv" Or extension = "CSV" Then
                        Dim c As New dCalidadAux2()
                        Do
                            sLine = objReader.ReadLine()
                            If sLine <> " " Then
                                If linea = 3 Then
                                    arraytext = Split(sLine, ";")
                                    If arraytext.Length < 11 Then
                                        arraytext = Split(sLine, ",")
                                    End If
                                End If
                            If Not sLine Is Nothing Then
                                If linea >= 8 Then
                                    arraytext = Split(sLine, ",")
                                    If arraytext.Length < 39 Then
                                        arraytext = Split(sLine, ";")
                                    End If
                                    matricula = Trim(arraytext(5))
                                    '** IMPORTAR CRIOSCOPIA **************************************************************************
                                    If Trim(arraytext(15)) = "" Or Trim(arraytext(15)) = "-" Then
                                        crioscopia = -1
                                    Else
                                        Try
                                            crioscopia = arraytext(15)
                                        Catch ex As Exception
                                            MsgBox("Error en archivo: " & file.Name & ", línea: " & linea & ", valor: Crioscopía")
                                            Exit Sub
                                        End Try
                                    End If
                                    '***************************************************************************************************
                                    'If arraytext.Length <= 13 Then

                                    '    crioscopia = -1
                                    'Else

                                    '    If Trim(arraytext(17)) = "" Or Trim(arraytext(17)) = "-" Then
                                    '        crioscopia = -1
                                    '    Else
                                    '        Try
                                    '            crioscopia = arraytext(17)

                                    '        Catch ex As Exception
                                    '            MsgBox("Error en archivo: " & file.Name & ", línea: " & linea & ", valor: Crioscopía")
                                    '            Exit Sub
                                    '        End Try

                                    '    End If

                                    'End If
                                    'ficha2 = Mid(file.Name, Len(file.Name) - 4, 1)
                                    ficha2 = Mid(file.Name, Len(file.Name) - 21, 1)
                                    ficha3 = Mid(file.Name, 1, 1)
                                    If ficha2 = "a" Or ficha2 = "A" Or ficha2 = "b" Or ficha2 = "B" Or ficha2 = "c" Or ficha2 = "C" Or ficha2 = "d" Or ficha2 = "D" Or ficha2 = "e" Or ficha2 = "E" Or ficha2 = "f" Or ficha2 = "F" Or ficha2 = "g" Or ficha2 = "G" Or ficha2 = "h" Or ficha2 = "H" Or ficha2 = "i" Or ficha2 = "I" Or ficha2 = "j" Or ficha2 = "J" Or ficha2 = "k" Or ficha2 = "K" Then
                                        'ficha = Mid(file.Name, 1, Len(file.Name) - 5)
                                        ficha = Mid(file.Name, 1, Len(file.Name) - 22)
                                    Else
                                        'ficha = Mid(file.Name, 1, Len(file.Name) - 4)
                                        ficha = Mid(file.Name, 1, Len(file.Name) - 21)
                                    End If
                                    If Mid(ficha, 1, 1) = "l" Or Mid(ficha, 1, 1) = "L" Then
                                        Dim MyString As String = ficha
                                        Dim MyChar As Char() = {"l"c, "L"c}
                                        Dim NewString As String = MyString.TrimStart(MyChar)
                                        ficha3 = NewString
                                    Else
                                        ficha3 = ficha
                                    End If

                                    c.FICHA = ficha3
                                    c.MUESTRA = matricula
                                    c.CRIOSCOPIA = crioscopia
                                    c.guardar(Usuario)
                                End If
                            End If
                            End If
                            linea = linea + 1
                        Loop Until sLine Is Nothing
                        objReader.Close()
                    End If
                Next
            End If
    End Sub
    Private Sub buscarfuerarango()
        Dim cf As New dCrioscopia_Fichas
        Dim _ficha As Long = 0
        Dim lista As New ArrayList
        Dim ca2 As New dCalidadAux2
        Dim lista2 As New ArrayList
        lista = cf.listarsinmarcar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each cf In lista
                    _ficha = cf.FICHA
                    lista2 = ca2.listarxficha(_ficha)
                    If Not lista2 Is Nothing Then
                        If lista2.Count > 0 Then
                            For Each ca2 In lista2
                                If ca2.CRIOSCOPIA < 512 Or ca2.CRIOSCOPIA > 540 Then
                                    Dim cc As New dCrioscopia_Control
                                    cc.FICHA = _ficha
                                    cc.MUESTRA = ca2.MUESTRA
                                    cc.DELTA = ca2.CRIOSCOPIA
                                    cc.CRIOSCOPO = 0
                                    cc.MARCA = 0
                                    cc.guardar(Usuario)
                                End If
                                cf.marcarfichas(Usuario)
                            Next
                        End If
                    End If
                Next

            End If
        End If
    End Sub
    Private Sub listarfuerarango()

        Dim cc As New dCrioscopia_Control
        Dim lista As New ArrayList
        lista = cc.listarsinmarcar
        DataGridView2.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView2.Rows.Add(lista.Count)
                For Each cc In lista
                    DataGridView2(columna, fila).Value = cc.ID
                    columna = columna + 1
                    DataGridView2(columna, fila).Value = cc.FICHA
                    columna = columna + 1

                    Dim r As New dRgLab88
                    Dim lista2 As New ArrayList
                    lista2 = r.listar
                    If Not lista Is Nothing Then
                        If lista.Count > 0 Then
                            Dim fila2 As Integer = 0
                            Dim columna2 As Integer = 0
                            DataGridView1.Rows.Add(lista.Count)
                            'For Each r In lista

                            'Next
                        End If
                    End If

                    DataGridView2(columna, fila).Value = cc.MUESTRA
                    columna = 0
                    fila = fila + 1
                Next
            End If
        End If
    End Sub

    Private Sub DataGridView2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        If DataGridView2.Columns(e.ColumnIndex).Name = "Ficha2" Then
            actualizarhora()
            Dim row As DataGridViewRow = DataGridView2.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim cc As New dCrioscopia_Control
            id = row.Cells("Id2").Value
            cc.ID = id
            cc = cc.buscar
            If Not cc Is Nothing Then
                TextFicha.Text = cc.FICHA
                TextMuestra.Text = cc.MUESTRA
                TextDelta.Text = cc.DELTA
                TextCrioscopo.Focus()
            End If
        End If
        If DataGridView2.Columns(e.ColumnIndex).Name = "Muestra2" Then
            actualizarhora()
            Dim row As DataGridViewRow = DataGridView2.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim cc As New dCrioscopia_Control
            id = row.Cells("Id2").Value
            cc.ID = id
            cc = cc.buscar
            If Not cc Is Nothing Then
                TextFicha.Text = cc.FICHA
                TextMuestra.Text = cc.MUESTRA
                TextDelta.Text = cc.DELTA
                TextCrioscopo.Focus()
            End If
        End If
    End Sub

    Private Sub ButtonExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExcel.Click
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

        'x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(1)
        'x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        'x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        'x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(2)

        Dim rg88 As New dRgLab88

        Dim lista As New ArrayList
        lista = rg88.listar

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 1
                Dim columna As Integer = 1

                x1hoja.Cells(1, 1).columnwidth = 10
                x1hoja.Cells(1, 2).columnwidth = 10
                x1hoja.Cells(1, 3).columnwidth = 10
                x1hoja.Cells(1, 4).columnwidth = 10
                x1hoja.Cells(1, 5).columnwidth = 10
                x1hoja.Cells(1, 6).columnwidth = 10
                x1hoja.Cells(1, 7).columnwidth = 15
                x1hoja.Cells(1, 8).columnwidth = 30

                x1hoja.Cells(fila, columna).formula = "Fecha"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Hora"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Ficha"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Muestra"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Crióscopo"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Delta"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Operador"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Observaciones"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = 1
                fila = fila + 1

                For Each rg88 In lista

                    x1hoja.Cells(fila, columna).formula = rg88.FECHA
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    'x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = rg88.HORA
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    'x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = rg88.FICHA
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    'x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = rg88.MUESTRA
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    'x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = rg88.CRIOSCOPO
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    'x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = rg88.DELTA
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).WrapText = True
                    'x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                    Dim op As New dUsuario
                    op.ID = rg88.OPERADOR
                    op = op.buscar
                    If Not op Is Nothing Then
                        x1hoja.Cells(fila, columna).formula = op.NOMBRE
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).WrapText = True
                        'x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).WrapText = True
                        'x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    End If
                    x1hoja.Cells(fila, columna).formula = rg88.OPERADOR
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).WrapText = True
                    'x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = rg88.OBSERVACIONES
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).WrapText = True
                    'x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = 1
                    fila = fila + 1

                Next

            End If
        End If

        x1app.Visible = True
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing

    End Sub
End Class