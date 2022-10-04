Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System.IO
Imports iTextSharp.text 'Para trabajar con los pdf
Imports iTextSharp.text.pdf
Imports System.Reflection
Imports System.Drawing.Text
Imports System.Runtime.InteropServices
Imports System.Globalization

Public Class FormCrearInformes
    Private contador_rc As Integer = 0
#Region "Atributos"
    Private _usuario As dUsuario
    Private idti As Integer = 0
    Private nroficha As Long = 0
    Public isAnexo As Boolean = False
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
        cargarComboTI()
    End Sub
#End Region
    Public Sub cargarComboTI()
        Dim ti As New dTipoInforme
        Dim lista As New ArrayList
        lista = ti.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each ti In lista
                    ComboTI.Items.Add(ti)
                Next
            End If
        End If
    End Sub
    Private Sub ComboTI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboTI.SelectedIndexChanged
        If ComboTI.Text <> "" Then
            listarxtipo()
            TextFicha.Text = ""
        End If
    End Sub
    Private Sub listarxtipo()
        Dim ti As dTipoInforme = CType(ComboTI.SelectedItem, dTipoInforme)
        idti = ti.ID
        If Not ti Is Nothing Then
            Dim lista As New ArrayList
            Dim sa As New dSolicitudAnalisis
            Dim fila As Integer = 0
            Dim columna As Integer = 0
            lista = sa.listarxtipo(idti)
            DataGridView1.Rows.Clear()
            If Not lista Is Nothing Then
                DataGridView1.Rows.Add(lista.Count)
                If lista.Count > 0 Then
                    For Each sa In lista
                        DataGridView1(columna, fila).Value = sa.ID
                        columna = columna + 1
                        Dim t As New dTipoInforme
                        t.ID = sa.IDTIPOINFORME
                        t = t.buscar
                        If Not t Is Nothing Then
                            DataGridView1(columna, fila).Value = t.NOMBRE
                            columna = columna + 1
                        Else
                            DataGridView1(columna, fila).Value = ""
                            columna = columna + 1
                        End If
                        Dim c As New dCliente
                        c.ID = sa.IDPRODUCTOR
                        c = c.buscar
                        If Not c Is Nothing Then
                            DataGridView1(columna, fila).Value = c.NOMBRE
                            columna = 0
                            fila = fila + 1
                        Else
                            DataGridView1(columna, fila).Value = ""
                            columna = 0
                            fila = fila + 1
                        End If
                    Next
                End If
            End If
        End If
    End Sub
    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Ficha" Then
            Dim id As Long = 0
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            id = row.Cells("Ficha").Value
            TextFicha.Text = id
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Informe" Then
            Dim id As Long = 0
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            id = row.Cells("Ficha").Value
            TextFicha.Text = id
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Cliente" Then
            Dim id As Long = 0
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            id = row.Cells("Ficha").Value
            TextFicha.Text = id
        End If
    End Sub
    Private Sub ButtonCrear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCrear.Click
        If ComboTI.Text = "" Then
            MsgBox("Debe seleccionar un tipo de informe!")
            ComboTI.Focus()
            Exit Sub
        End If
        Dim ti As dTipoInforme = CType(ComboTI.SelectedItem, dTipoInforme)
        idti = ti.ID
        If TextFicha.Text <> "" Then
            nroficha = TextFicha.Text
        End If
        If idti = 1 Then '*** Control lechero **************************************************

            '*** Controla que el productor realiza cambio de caravanas **********************
            Dim sa As New dSolicitudAnalisis
            Dim caravanas As Integer = 0
            sa.ID = nroficha
            sa = sa.buscar
            If Not sa Is Nothing Then
                Dim p As New dCliente
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
            Dim v2 As New FormMuestrasNoAptas(Usuario, nroficha)
            v2.ShowDialog()
            Dim v3 As New FormObservaciones(Usuario, nroficha)
            v3.ShowDialog()
            creainformetxt()
            informe_control()
            abrirventanaenvio()
            limpiar()
            'crea_informe_control()
        ElseIf idti = 3 Then '*** Agua **************************************************
            Dim ficha As Long = TextFicha.Text.Trim
            Dim s As New dSolicitudAnalisis
            informe_agua()
            s.ID = ficha
            s = s.buscar
            Dim productor As Long = 0
            If Not s Is Nothing Then
                productor = s.IDPRODUCTOR
            End If
            abrirventanaenvio()
            limpiar()
        ElseIf idti = 4 Then '*** ATB **************************************************
            Dim ficha As Long = TextFicha.Text.Trim
            Dim s As New dSolicitudAnalisis
            informe_atb()
            s.ID = ficha
            s = s.buscar
            Dim productor As Long = 0
            If Not s Is Nothing Then
                productor = s.IDPRODUCTOR
            End If
            abrirventanaenvio()
            limpiar()
        ElseIf idti = 6 Then '*** Parasitología **************************************************
            Dim ficha As Long = TextFicha.Text.Trim
            Dim s As New dSolicitudAnalisis
            informe_parasitologia()
            s.ID = ficha
            s = s.buscar
            Dim productor As Long = 0
            If Not s Is Nothing Then
                productor = s.IDPRODUCTOR
            End If
            abrirventanaenvio()
            limpiar()
        ElseIf idti = 7 Then '*** Alimentos **************************************************
            Dim ficha As Long = TextFicha.Text.Trim
            Dim s As New dSolicitudAnalisis
            informe_alimentos()
            s.ID = ficha
            s = s.buscar
            Dim productor As Long = 0
            If Not s Is Nothing Then
                productor = s.IDPRODUCTOR
            End If
            abrirventanaenvio()
            limpiar()
        ElseIf idti = 8 Then
            Dim ficha As Long = TextFicha.Text.Trim
            Dim s As New dSolicitudAnalisis
            Dim subtipoinforme As Integer = 0
            s.ID = ficha
            s = s.buscar
            subtipoinforme = s.IDSUBINFORME
            If subtipoinforme = 23 Then
                informe_leucosis()
            ElseIf subtipoinforme = 7 Then
                informe_serologia()
            End If
            Dim productor As Long = 0
            If Not s Is Nothing Then
                productor = s.IDPRODUCTOR
            End If
            abrirventanaenvio()
            limpiar()
        ElseIf idti = 9 Then '*** Patología - Toxicología **************************************************
            Dim ficha As Long = TextFicha.Text.Trim
            Dim s As New dSolicitudAnalisis
            informe_patologia()
            s.ID = ficha
            s = s.buscar
            Dim productor As Long = 0
            If Not s Is Nothing Then
                productor = s.IDPRODUCTOR
            End If
            abrirventanaenvio()
            limpiar()
        ElseIf idti = 10 Then '*** Calidad de leche **************************************************
            Dim v As New FormSeleccionarTecnico
            v.ShowDialog()
            Dim v3 As New FormObservaciones(Usuario, nroficha)
            v3.ShowDialog()
            informe_calidad()
            abrirventanaenvio()
            limpiar()
        ElseIf idti = 11 Then '*** Ambiental **************************************************
            Dim ficha As Long = TextFicha.Text.Trim
            Dim s As New dSolicitudAnalisis
            informe_ambiental()
            s.ID = ficha
            s = s.buscar
            Dim productor As Long = 0
            If Not s Is Nothing Then
                productor = s.IDPRODUCTOR
            End If
            abrirventanaenvio()
            limpiar()
        ElseIf idti = 13 Then '*** Nutrición **************************************************
            Dim ficha As Long = TextFicha.Text.Trim
            Dim s As New dSolicitudAnalisis
            informe_nutricion()
            s.ID = ficha
            s = s.buscar
            Dim productor As Long = 0
            If Not s Is Nothing Then
                productor = s.IDPRODUCTOR
            End If
            abrirventanaenvio()
            limpiar()
        ElseIf idti = 14 Then '*** Suelos **************************************************
            Dim ficha As Long = TextFicha.Text.Trim
            Dim s As New dSolicitudAnalisis
            informe_suelos_conversion_fertilizante()
            informe_suelos()
            s.ID = ficha
            s = s.buscar
            Dim productor As Long = 0
            If Not s Is Nothing Then
                productor = s.IDPRODUCTOR
            End If
            abrirventanaenvio()
            limpiar()
        ElseIf idti = 15 Then '*** Brucelosis en leche **************************************************
            Dim ficha As Long = TextFicha.Text.Trim
            Dim s As New dSolicitudAnalisis
            s.ID = ficha
            s = s.buscar
            Dim productor As Long = 0
            If Not s Is Nothing Then
                productor = s.IDPRODUCTOR
                Dim c As New dCliente
                c.ID = productor
                c = c.buscar
                If Not c Is Nothing Then
                    If c.TIPOUSUARIO = 1 Or c.TIPOUSUARIO = 3 Then
                        informe_brucelosisenleche_productor()
                    ElseIf c.TIPOUSUARIO = 2 Then
                        informe_brucelosisenleche_empresa()
                    End If
                End If
            End If
            abrirventanaenvio()
            limpiar()
        ElseIf idti = 16 Then '*** Efluentes **************************************************
            Dim ficha As Long = TextFicha.Text.Trim
            Dim s As New dSolicitudAnalisis
            informe_efluentes()
            s.ID = ficha
            s = s.buscar
            Dim productor As Long = 0
            If Not s Is Nothing Then
                productor = s.IDPRODUCTOR
            End If
            abrirventanaenvio()
            limpiar()
        ElseIf idti = 17 Then '*** Bacteriologia **************************************************
            Dim ficha As Long = TextFicha.Text.Trim
            Dim s As New dSolicitudAnalisis
            informe_bacteriologia()
            s.ID = ficha
            s = s.buscar
            Dim productor As Long = 0
            If Not s Is Nothing Then
                productor = s.IDPRODUCTOR
            End If
            abrirventanaenvio()
            limpiar()
        ElseIf idti = 18 Then '*** Bacteriología clínica aeróbica**************************************************
            Dim ficha As Long = TextFicha.Text.Trim
            Dim s As New dSolicitudAnalisis
            informe_bacteriologia_clinica_aerobica()
            s.ID = ficha
            s = s.buscar
            Dim productor As Long = 0
            If Not s Is Nothing Then
                productor = s.IDPRODUCTOR
            End If
            abrirventanaenvio()
            limpiar()
        ElseIf idti = 19 Then '*** Foliares **************************************************
            Dim ficha As Long = TextFicha.Text.Trim
            Dim s As New dSolicitudAnalisis
            informe_foliar()
            s.ID = ficha
            s = s.buscar
            Dim productor As Long = 0
            If Not s Is Nothing Then
                productor = s.IDPRODUCTOR
            End If
            abrirventanaenvio()
            limpiar()
        ElseIf idti = 20 Then '*** Efluentes **************************************************
            informe_toxicologia()
        ElseIf idti = 99 Then '*** Efluentes **************************************************
            informe_semen()
        End If
    End Sub
    Private Sub limpiar()
        TextFicha.Text = ""
        listarxtipo()
    End Sub
    Private Sub abrirventanaenvio()
        Dim v As New FormSubirInformes2(Usuario)
        v.Show()
    End Sub
    Private Sub informe_control()
        Dim idsol As Long = TextFicha.Text.Trim
        Dim Arch As String
        Arch = "\\ROBOT\PREINFORMES\CONTROL\" & idsol & ".xls"
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Open(Arch), Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
        x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(1)
        x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.5)
        x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(1)
        'ARCHIVO ANEXO *********************************************************************************
        Dim Arch2 As String
        Arch2 = "\\ROBOT\GraficasRC\x" & idsol & ".xls"
        Dim x1app2 As Microsoft.Office.Interop.Excel.Application
        Dim x1libro2 As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja2 As Microsoft.Office.Interop.Excel.Worksheet
        Dim existe_archivo_x As Integer = 0
        x1app2 = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        If File.Exists("\\ROBOT\GraficasRC\x" & idsol & ".xls") Then
            existe_archivo_x = 1
        End If
        If existe_archivo_x = 1 Then
            x1libro2 = CType(x1app2.Workbooks.Open(Arch2), Microsoft.Office.Interop.Excel.Workbook)
            x1hoja2 = CType(x1libro2.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
        End If
        '***********************************************************************************************
        x1hoja.Unprotect(Password:="1582782")
        'x1hoja.PageSetup.Orientation = (Excel.XlPageOrientation.xlLandscape)
        Dim sa As New dSolicitudAnalisis
        Dim cli As New dCliente
        Dim na As New dNuevoAnalisis
        Dim na3 As New dNuevoAnalisis
        Dim met As New dMetodos
        Dim lista As New ArrayList
        Dim lista2 As New ArrayList
        Dim lista3 As New ArrayList
        Dim acreditado As Integer = 0
        Dim informefinal As Integer = 0
        Dim nombre_paratecnico As String = ""
        contador_rc = 0
        '*****************************
        nroficha = TextFicha.Text.Trim
        sa.ID = nroficha
        sa = sa.buscar
        lista = na.listarporfichamuestra(nroficha)
        lista3 = na3.listarporficha3(nroficha)
        '*****************************
        Dim fila As Integer
        Dim columna As Integer
        fila = 1
        columna = 1
        columna = 2
        x1hoja.Cells(1, 1).columnwidth = 6
        x1hoja.Cells(1, 2).columnwidth = 5
        x1hoja.Cells(1, 3).columnwidth = 5
        x1hoja.Cells(1, 4).columnwidth = 5
        x1hoja.Cells(1, 5).columnwidth = 5
        x1hoja.Cells(1, 6).columnwidth = 5
        x1hoja.Cells(1, 7).columnwidth = 5
        x1hoja.Cells(1, 8).columnwidth = 2.57
        x1hoja.Cells(1, 9).columnwidth = 6
        x1hoja.Cells(1, 10).columnwidth = 5
        x1hoja.Cells(1, 11).columnwidth = 5
        x1hoja.Cells(1, 12).columnwidth = 5
        x1hoja.Cells(1, 13).columnwidth = 5
        x1hoja.Cells(1, 14).columnwidth = 5
        x1hoja.Cells(1, 15).columnwidth = 5
        fila = fila + 4
        columna = 1
        x1hoja.Range("A5", "O5").Merge()
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Formula = "INFORME DEL RECUENTO CELULAR Y COMPOSICIÓN DE VACAS INDIVIDUALES"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 2
        columna = 1
        x1hoja.Cells(fila, columna).Formula = "Nº Ficha: " & sa.ID
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        columna = columna + 11
        x1hoja.Cells(fila, columna).Formula = "Fecha entrada: " & sa.FECHAINGRESO
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        fila = fila + 1
        columna = 1
        cli.ID = sa.IDPRODUCTOR
        cli = cli.buscar
        Dim cc As New dClienteConvenio
        Dim listacc As New ArrayList
        Dim bhb As Integer = 0
        listacc = cc.listarporcliente(sa.IDPRODUCTOR)
        If Not listacc Is Nothing Then
            For Each cc In listacc
                If cc.CONVENIO = 2 Then
                    bhb = 1
                End If
            Next
        End If
        x1hoja.Cells(fila, columna).Formula = "Cliente: " & cli.NOMBRE
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        columna = columna + 11
        Dim nnaa As New dNuevoAnalisis
        Dim fechaproceso As String = ""
        Dim listannaa As New ArrayList
        listannaa = nnaa.listarporficha2(sa.ID)
        If Not listannaa Is Nothing Then
            For Each nnaa In listannaa
                fechaproceso = nnaa.FECHAPROCESO
            Next
        End If
        nnaa = Nothing
        listannaa = Nothing
        x1hoja.Cells(fila, columna).Formula = "Fecha proceso: " & sa.FECHAPROCESO 'fechaproceso
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        fila = fila + 1
        columna = 1
        If cli.DIRECCION <> "" Or cli.DIRECCION <> "No aportado" Then
            x1hoja.Cells(fila, columna).Formula = "Dirección: " & cli.DIRECCION
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            columna = columna + 11
        ElseIf cli.IDLOCALIDAD <> 999 Then
            Dim loc As New dLocalidad
            loc.ID = cli.IDLOCALIDAD
            loc = loc.buscar
            If Not loc Is Nothing Then
                x1hoja.Cells(fila, columna).Formula = loc.NOMBRE
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 11
            End If
        ElseIf cli.IDDEPARTAMENTO <> 999 Then
            Dim dep As New dDepartamento
            dep.ID = cli.IDDEPARTAMENTO
            dep = dep.buscar
            If Not dep Is Nothing Then
                x1hoja.Cells(fila, columna).Formula = dep.NOMBRE
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 11
            End If
        ElseIf cli.CELULAR <> "" Then
            x1hoja.Cells(fila, columna).Formula = "Celular: " & cli.CELULAR
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            columna = columna + 11
        Else
            x1hoja.Cells(fila, columna).Formula = "No aportado"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            columna = columna + 11
        End If
        Dim fecha As Date = Now()
        Dim fecha2 As String = fecha.ToString("dd/MM/yyyy")
        x1hoja.Cells(fila, columna).Formula = "Fecha informe: " & fecha2
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        fila = fila + 1
        columna = 1
        Dim mm As New dMuestras
        mm.ID = sa.IDMUESTRA
        mm = mm.buscar
        If Not mm Is Nothing Then
            x1hoja.Cells(fila, columna).Formula = "Material recibido: " & mm.NOMBRE
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            columna = columna + 5
        Else
            x1hoja.Cells(fila, columna).Formula = "Material recibido: "
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            columna = columna + 5
        End If
        columna = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).Formula = "Temperatura de arribo de las muestras: " & sa.TEMPERATURA & " ºC"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        columna = columna + 7
        x1hoja.Cells(fila, columna).formula = "Muestreo realizado por el cliente"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = True
        columna = 1
        fila = fila + 1
        x1hoja.Range("A12", "O12").Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).rowheight = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).rowheight = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).rowheight = 1
        fila = fila + 1
        columna = 1
        Dim cuenta As Integer = 1
        Dim listademetodos As String = ""
        listademetodos = "RCS ISO 13366-2(IDF 148-2:2006); Grasa, Proteína, Lactosa * ISO 9622 (IDF141:2013), Urea*, Caseína* (Boletín FIL 393/2003)"
        columna = 1
        '******************************************************************************************************
        Dim c As New dControl
        Dim listac As New ArrayList
        listac = c.listarporsolicitud(nroficha)
        If Not listac Is Nothing Then
            If listac.Count > 0 Then
                fila = fila + listac.Count
            End If
        End If
        fila = fila + 4
        'CONTROLA LAS VACAS INFECTADAS ***********************************************************************
        Dim libreinfeccion As Integer = 0
        Dim posibleinfeccion As Integer = 0
        Dim probableinfeccion As Integer = 0
        If Not listac Is Nothing Then
            For Each c In listac
                If c.RC <= 200 Then
                    libreinfeccion = libreinfeccion + 1
                ElseIf c.RC > 200 Then
                    probableinfeccion = probableinfeccion + 1
                End If
            Next
        End If
        '*** CUENTA MUESTRAS NO APTAS ***************************************
        Dim muestrastotales As Integer = 0
        Dim listamuestras As New ArrayList
        listamuestras = c.listarporsolicitud(nroficha)
        muestrastotales = listamuestras.Count
        Dim mna As New dMuestrasNoAptas
        Dim cuenta_mna As Integer = 0
        Dim cuenta_rep As Integer = 0
        Dim faltan As Integer = 0
        lista3 = mna.listarporficha(idsol)
        If Not lista3 Is Nothing Then
            If lista3.Count > 0 Then
                For Each mna In lista3
                    If mna.MOTIVO = 8 Then
                        cuenta_rep = cuenta_rep + mna.CANTIDAD
                    End If
                    If mna.MOTIVO = 4 Or mna.MOTIVO = 6 Or mna.MOTIVO = 10 Then
                        faltan = faltan + mna.CANTIDAD
                    End If
                    If mna.MOTIVO = 1 Or mna.MOTIVO = 2 Or mna.MOTIVO = 3 Or mna.MOTIVO = 5 Or mna.MOTIVO = 7 Or mna.MOTIVO = 9 Then
                        cuenta_mna = cuenta_mna + mna.CANTIDAD
                    End If
                Next
            End If
        End If
        Dim muestrasanalizadas As Integer = 0
        muestrasanalizadas = muestrastotales - cuenta_mna
        muestrasanalizadas = muestrasanalizadas - faltan
        '*******************************************************************************************************
        x1hoja.Cells(fila, columna).rowheight = 3
        fila = fila + 1
        x1hoja.Range("A" & fila, "O" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).rowheight = 1
        fila = fila + 1
        columna = 1
        'TOTAL DE MUESTRAS ********************************************************
        x1hoja.Cells(fila, columna).Formula = "Total de muestras: " & sa.NMUESTRAS
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        columna = columna + 5
        'PARATECNICOS************************************************************************
        If idparatecnico1 = 1 Then
            nombre_paratecnico = nombre_paratecnico + "Diego Arenas - "
        End If
        If idparatecnico2 = 1 Then
            nombre_paratecnico = nombre_paratecnico + "Lorena Nidegger - "
        End If
        If idparatecnico3 = 1 Then
            nombre_paratecnico = nombre_paratecnico + "Claudia García - "
        End If
        If idparatecnico4 = 1 Then
            nombre_paratecnico = nombre_paratecnico + "Erika Silva - "
        End If
        If idparatecnico5 = 1 Then
            nombre_paratecnico = nombre_paratecnico + "Virginia Ferreira - "
        End If
        If idparatecnico6 = 1 Then
            nombre_paratecnico = nombre_paratecnico + "Jeniffer Madera - "
        End If
        x1hoja.Cells(fila, columna).Formula = "Paratécnico: " & nombre_paratecnico
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        '** SI HAY MUESTRAS NO APTAS *****************************************************************************
        If cuenta_mna > 0 Or cuenta_rep > 0 Then
            columna = 1
            fila = fila + 1
            x1hoja.Cells(fila, columna).formula = "(**) No apta por:"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Size = 8
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).interior.color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            columna = columna + 1
            x1hoja.Cells(fila, columna).interior.color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            columna = columna + 1
            x1hoja.Cells(fila, columna).interior.color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            columna = columna + 1
            x1hoja.Cells(fila, columna).interior.color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
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
                        x1hoja.Cells(fila, columna).interior.color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).interior.color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).interior.color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                        columna = columna + 1
                        cantidadmna = muestrasna.CANTIDAD
                        x1hoja.Cells(fila, columna).formula = cantidadmna
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).interior.color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
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
        '*** FACTURAR MUESTRAS NO APTAS ******************************************************************
        If cuenta_mna > 0 Then
            Dim analisis As Integer = 0
            MsgBox("Hay muestras no aptas para hacer Nota de Crédito!")
            analisis = 224
            Dim f1 As New dFacturacion
            f1.FICHA = idsol
            f1.CANTIDAD = cuenta_mna
            f1.ANALISIS = analisis
            f1.PRECIO = 0
            f1.SUBTOTAL = 0
            f1.FACTURA = 0
            f1.guardar(Usuario)
            f1 = Nothing
        End If
        '*************************************************************************************************
        fila = fila + 2
        columna = 1
        x1hoja.Cells(fila, columna).Formula = "Referencias:"
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        x1hoja.Cells(fila, columna).Formula = ""
        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).Font.Bold = False
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Valor fuera de rango de acreditación"
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 7
        columna = columna + 4
        x1hoja.Cells(fila, columna).Formula = "-"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).Font.Bold = False
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Análisis no requerido"
        x1hoja.Cells(fila, columna).Font.Size = 7
        x1hoja.Cells(fila, columna).Font.Bold = False
        columna = columna + 3
        x1hoja.Cells(fila, columna).Font.Size = 7
        x1hoja.Cells(fila, columna).formula = "Valores de 30 en RC, corresponden a <=30 (menor o igual)"
        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).Formula = "Métodos"
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        x1hoja.Cells(fila, columna).rowheight = 20
        x1hoja.Cells(fila, columna).Formula = listademetodos
        x1hoja.Range("A" & fila, "O" & fila).WrapText = True
        x1hoja.Range("A" & fila, "O" & fila).Merge()
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 7
        fila = fila + 1
        x1hoja.Cells(fila, columna).Formula = "(*)Ensayo no acreditado ISO 17025 O.U.A."
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        '*** OBSERVACIONES **************************************************
        If sa.OBSERVACIONES <> "" Then
            x1hoja.Cells(fila, columna).rowheight = 25
            x1hoja.Cells(fila, columna).Formula = "Observaciones: " & sa.OBSERVACIONES
            x1hoja.Range("A" & fila, "O" & fila).WrapText = True
            x1hoja.Range("A" & fila, "O" & fila).Merge()
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Size = 8
            fila = fila + 1
        End If
        '********************************************************************
        'CABEZAL CON O SIN LOGO OUA
        acreditado = 1
        If acreditado = 1 Then
            x1hoja.Shapes.AddPicture("c:\Debug\encabezado_con_oua2.png", _
     Microsoft.Office.Core.MsoTriState.msoFalse, _
     Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 452, 42)
        Else
            x1hoja.Shapes.AddPicture("c:\Debug\encabezado_sin_oua2.png", _
     Microsoft.Office.Core.MsoTriState.msoFalse, _
     Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 452, 42)
        End If
        '********************************************************************
        columna = 1
        'RANGOS ACREDITADOS******************************************************************
        columna = 1
        x1hoja.Cells(fila, columna).Formula = "RANGOS ACREDITADOS"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 7
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = ""
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 7
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = ""
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 7
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = ""
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 7
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        columna = columna - 3
        fila = fila + 1
        x1hoja.Cells(fila, columna).Formula = "RCS = 100.000 a 1 millón cel/mL"
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 7
        fila = fila + 1
        x1hoja.Cells(fila, columna).Formula = "Pr = 2.5 - 4.0 g/100mL"
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 7
        fila = fila + 1
        x1hoja.Cells(fila, columna).Formula = "Gr = 2.5 - 5.0 g/100mL"
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 7
        fila = fila - 3
        'ABREVIATURAS************************************************************************
        columna = columna + 4
        x1hoja.Cells(fila, columna).Formula = "                       ABREVIATURAS"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 7
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = ""
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 7
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = ""
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 7
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = ""
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 7
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = ""
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 7
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = ""
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 7
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = ""
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 7
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        columna = columna - 6
        fila = fila + 1
        x1hoja.Cells(fila, columna).Formula = "Gr = Grasa"
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 7
        columna = columna + 3
        x1hoja.Cells(fila, columna).Formula = "MUN = Nitrógeno uréico en leche"
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 7
        fila = fila + 1
        columna = columna - 3
        x1hoja.Cells(fila, columna).Formula = "Pr = Proteína total"
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 7
        columna = columna + 3
        x1hoja.Cells(fila, columna).Formula = "MUN = Urea x 0.466"
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 7
        fila = fila + 1
        columna = columna - 3
        x1hoja.Cells(fila, columna).Formula = "Lac = Lactosa"
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 7
        columna = columna + 3
        x1hoja.Cells(fila, columna).Formula = "Cas = Caseína"
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 7
        fila = fila + 1
        columna = columna - 3
        x1hoja.Cells(fila, columna).Formula = "RCS = Recuento Células Somáticas"
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 7
        columna = 1
        '*** PONER FIRMA ********************************************************
        fila = fila + 1
        x1libro.Worksheets(1).cells(fila, columna).select()
        x1libro.ActiveSheet.pictures.Insert("c:\Debug\cecilia.jpg").select()
        x1libro.Worksheets(1).cells(2, 1).select()
        fila = fila + 6
        x1hoja.Cells(fila, columna).Formula = "Laboratorio habilitado RNL 0029 - MGAP" & " - Certificado vigente al 31/08/2022"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        fila = fila + 1
        '************************************************************************
        '*** PIE DE PAGINA ******************************************************
        x1hoja.Cells(fila, columna).rowheight = 35
        x1hoja.Cells(fila, columna).Formula = "Este informe no podrá ser reproducido total o parcialmente sin la autorización escrita de COLAVECO. Los resultados consignados se refieren exclusivamente a la muestra recibida. COLAVECO declina toda responsabilidad por el uso indebido o incorrecto que se hiciere a este informe, asi como el plan y procedimientos de muestreo aplicados por el cliente. Dra. Cecilia Abelenda (DT)"
        x1hoja.Range("A" & fila, "O" & fila).WrapText = True
        x1hoja.Range("A" & fila, "O" & fila).Merge()
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        '************************************************************************
        fila = fila + 1
        x1hoja.Range("A" & fila, "O" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(215, 219, 221)
        x1hoja.Cells(fila, columna).rowheight = 8
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
        x1hoja.Cells(fila, columna).Formula = "Fin del informe."
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 7
        'PROTEGE LA HOJA DE EXCEL
        x1hoja.Protect(Password:="1582782", DrawingObjects:=True, _
        Contents:=True, Scenarios:=True)
        x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas
        x1hoja.SaveAs("\\ROBOT\PREINFORMES\CONTROL\" & idsol & ".xls")
        x1app.Visible = True
        If existe_archivo_x = 1 Then
            x1app2.Visible = True
        End If
    End Sub
    Private Sub informe_calidad()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
        x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(0.5) '(1)
        x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(0.5) '(1.9)
        x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(0.5) '(1)
        'x1hoja.PageSetup.Orientation = (Excel.XlPageOrientation.xlLandscape)
        Dim sa As New dSolicitudAnalisis
        Dim cli As New dCliente
        Dim na As New dNuevoAnalisis
        Dim na3 As New dNuevoAnalisis
        Dim met As New dMetodos
        Dim lista As New ArrayList
        Dim lista2 As New ArrayList
        Dim lista3 As New ArrayList
        Dim acreditado As Integer = 0
        Dim informefinal As Integer = 0
        Dim nombre_paratecnico As String = ""
        contador_rc = 0
        '*****************************
        nroficha = TextFicha.Text.Trim
        sa.ID = nroficha
        sa = sa.buscar
        lista = na.listarporfichamuestra(nroficha)
        lista3 = na3.listarporficha3(nroficha)
        '*****************************
        Dim fila As Integer
        Dim columna As Integer
        fila = 1
        columna = 1
        columna = 2
        x1hoja.Cells(1, 1).columnwidth = 8
        x1hoja.Cells(1, 2).columnwidth = 5
        x1hoja.Cells(1, 3).columnwidth = 5.5
        x1hoja.Cells(1, 4).columnwidth = 5
        x1hoja.Cells(1, 5).columnwidth = 5
        x1hoja.Cells(1, 6).columnwidth = 5
        x1hoja.Cells(1, 7).columnwidth = 5
        x1hoja.Cells(1, 8).columnwidth = 5
        x1hoja.Cells(1, 9).columnwidth = 5
        x1hoja.Cells(1, 10).columnwidth = 8
        x1hoja.Cells(1, 11).columnwidth = 7
        x1hoja.Cells(1, 12).columnwidth = 7
        x1hoja.Cells(1, 13).columnwidth = 7
        x1hoja.Cells(1, 14).columnwidth = 7
        fila = fila + 4
        columna = 1
        x1hoja.Range("A5", "N5").Merge()
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Formula = "INFORME DE CALIDAD DE LECHE"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 12
        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).Formula = "Nº Ficha: " & sa.ID
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        columna = columna + 11
        x1hoja.Cells(fila, columna).Formula = "Fecha entrada: " & sa.FECHAINGRESO
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        fila = fila + 1
        columna = 1
        cli.ID = sa.IDPRODUCTOR
        cli = cli.buscar
        x1hoja.Cells(fila, columna).Formula = "Cliente: " & cli.NOMBRE
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        columna = columna + 11
        Dim nnaa As New dNuevoAnalisis
        Dim fechaproceso As String = ""
        Dim listannaa As New ArrayList
        listannaa = nnaa.listarporficha2(sa.ID)
        If Not listannaa Is Nothing Then
            For Each nnaa In listannaa
                fechaproceso = nnaa.FECHAPROCESO
            Next
        End If
        nnaa = Nothing
        listannaa = Nothing
        x1hoja.Cells(fila, columna).Formula = "Fecha proceso: " & sa.FECHAPROCESO
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        fila = fila + 1
        columna = 1
        If cli.DIRECCION <> "" Or cli.DIRECCION <> "No aportado" Then
            x1hoja.Cells(fila, columna).Formula = "Dirección: " & cli.DIRECCION
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            columna = columna + 11
        ElseIf cli.IDLOCALIDAD <> 999 Then
            Dim loc As New dLocalidad
            loc.ID = cli.IDLOCALIDAD
            loc = loc.buscar
            If Not loc Is Nothing Then
                x1hoja.Cells(fila, columna).Formula = loc.NOMBRE
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 11
            End If
        ElseIf cli.IDDEPARTAMENTO <> 999 Then
            Dim dep As New dDepartamento
            dep.ID = cli.IDDEPARTAMENTO
            dep = dep.buscar
            If Not dep Is Nothing Then
                x1hoja.Cells(fila, columna).Formula = dep.NOMBRE
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 11
            End If
        ElseIf cli.CELULAR <> "" Then
            x1hoja.Cells(fila, columna).Formula = "Celular: " & cli.CELULAR
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            columna = columna + 11
        Else
            x1hoja.Cells(fila, columna).Formula = "No aportado"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            columna = columna + 11
        End If
        Dim fecha As Date = Now()
        Dim fecha2 As String = fecha.ToString("dd/MM/yyyy")
        x1hoja.Cells(fila, columna).Formula = "Fecha informe: " & fecha2
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        fila = fila + 1
        columna = 1
        Dim mm As New dMuestras
        mm.ID = sa.IDMUESTRA
        mm = mm.buscar
        If Not mm Is Nothing Then
            x1hoja.Cells(fila, columna).Formula = "Material recibido: " & mm.NOMBRE
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            columna = columna + 4
        Else
            x1hoja.Cells(fila, columna).Formula = "Material recibido: "
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 1
            columna = columna + 4
        End If
        columna = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).Formula = "Temperatura de arribo de las muestras: " & sa.TEMPERATURA & " ºC" & " (óptima de 1ºC a 7ºC )"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        columna = columna + 11
        x1hoja.Cells(fila, columna).Formula = "Muestreo realizado por el cliente"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        columna = 1
        fila = fila + 1
        x1hoja.Range("A" & fila, "N" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).rowheight = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).rowheight = 3
        fila = fila + 1
        columna = 1
        Dim cuenta As Integer = 1
        Dim detallemuestras As String = ""
        Dim idoperador As Integer = 0
        Dim operador As String = ""
        Dim iu As New dUsuario
        iu.ID = idoperador
        iu = iu.buscar
        If Not iu Is Nothing Then
            operador = iu.NOMBRE
        End If
        columna = 1
        x1hoja.Cells(fila, columna).Formula = "Ident."
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "RCS"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "RBt"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Gr"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Pr"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Lac*"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "ST"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Crio*"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "MUN*"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Inh"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Esp.ana.*"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Psicro.*"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Cas.*"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "AFL*"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = 1
        fila = fila + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("A14", "A15").Merge()
        x1hoja.Range("A14", "A15").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("A14", "A15").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("A14", "A15").WrapText = True
        x1hoja.Cells(fila, columna).formula = ""
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("B14", "B15").Merge()
        x1hoja.Range("B14", "B15").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("B14", "B15").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("B14", "B15").WrapText = True
        x1hoja.Cells(fila, columna).formula = "x 1.000 cel/mL"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("C14", "C15").Merge()
        x1hoja.Range("C14", "C15").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("C14", "C15").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("C14", "C15").WrapText = True
        x1hoja.Cells(fila, columna).formula = "x 1.000 eq. UFC/mL"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("D14", "D15").Merge()
        x1hoja.Range("D14", "D15").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("D14", "D15").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("D14", "D15").WrapText = True
        x1hoja.Cells(fila, columna).formula = "g/100mL"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("E14", "E15").Merge()
        x1hoja.Range("E14", "E15").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("E14", "E15").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("E14", "E15").WrapText = True
        x1hoja.Cells(fila, columna).formula = "g/100mL"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("F14", "F15").Merge()
        x1hoja.Range("F14", "F15").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("F14", "F15").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("F14", "F15").WrapText = True
        x1hoja.Cells(fila, columna).formula = "g/100mL"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("G14", "G15").Merge()
        x1hoja.Range("G14", "G15").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("G14", "G15").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("G14", "G15").WrapText = True
        x1hoja.Cells(fila, columna).formula = "g/100mL"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("H14", "H15").Merge()
        x1hoja.Range("H14", "H15").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("H14", "H15").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("H14", "H15").WrapText = True
        x1hoja.Cells(fila, columna).formula = "(ºC)"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("I14", "I15").Merge()
        x1hoja.Range("I14", "I15").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("I14", "I15").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("I14", "I15").WrapText = True
        x1hoja.Cells(fila, columna).formula = "mg/dL"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("J14", "J15").Merge()
        x1hoja.Range("J14", "J15").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("J14", "J15").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("J14", "J15").WrapText = True
        x1hoja.Cells(fila, columna).formula = ""
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("K14", "K15").Merge()
        x1hoja.Range("K14", "K15").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("K14", "K15").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("K14", "K15").WrapText = True
        x1hoja.Cells(fila, columna).formula = "NMP/L"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("L14", "L15").Merge()
        x1hoja.Range("L14", "L15").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("L14", "L15").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("L14", "L15").WrapText = True
        x1hoja.Cells(fila, columna).formula = "x 1000 UFC/mL"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("M14", "M15").Merge()
        x1hoja.Range("M14", "M15").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("M14", "M15").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("M14", "M15").WrapText = True
        x1hoja.Cells(fila, columna).formula = "g/100mL"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("N14", "N15").Merge()
        x1hoja.Range("N14", "N15").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("N14", "N15").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("N14", "N15").WrapText = True
        x1hoja.Cells(fila, columna).formula = "µg/Kg"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        Dim listademetodos As String = ""
        listademetodos = "RCS: ISO 13366-2 - IDF 148-2:2006 // Grasa, Proteína, Solidos Totales, Lactosa *: ISO 9622 - IDF141:2013 // Crioscopía*, Urea*, Caseína*: Boletín FIL 393/2003 // R.Bacteriano Total: Citometría de flujo - PE.LAB.62 // Inhibidores: Delvo Test - PE.LAB.17 // Antibióticos en leche: ROSA Charm* // Psicrótrofos*: FIL 132:2004 mod. // Esporulados Anaerobios*: NMP - CNERNA, 1896 mod. // Aflatoxína M1*: ROSA Charm"
        columna = 1
        fila = fila + 2
        '******************************************************************************************************
        Dim csm As New dCalidadSolicitudMuestra
        Dim listacsm As New ArrayList
        listacsm = csm.listarporsolicitud(nroficha)
        Dim desde As Double = 0
        Dim hasta As Double = 0
        Dim a As New dAcreditacion
        If Not listacsm Is Nothing Then
            If listacsm.Count > 0 Then
                For Each csm In listacsm
                    Dim c As New dCalidad
                    c.FICHA = nroficha
                    c.MUESTRA = Trim(csm.MUESTRA)
                    c = c.buscarxfichaxmuestra
                    If csm.MUESTRA <> "" Then
                        x1hoja.Cells(fila, columna).formula = Trim(csm.MUESTRA)
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    End If
                    If csm.RC = 1 Then
                        If Not c Is Nothing Then
                            Dim valrc As Double = Val(c.RC)
                            a.ANALISIS = 2
                            a = a.buscar
                            If Not a Is Nothing Then
                                desde = a.DESDE
                                hasta = a.HASTA
                                If valrc < desde Or valrc > hasta Then
                                    x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                                End If
                            End If
                            x1hoja.Cells(fila, columna).formula = c.RC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            If c.RC < 100 Then
                                contador_rc = contador_rc + 1
                            End If
                        Else
                            x1hoja.Cells(fila, columna).formula = "-"
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
                    If csm.RB = 1 Then
                        Dim ibc As New dIbc
                        ibc.FICHA = nroficha
                        ibc.MUESTRA = Trim(csm.MUESTRA)
                        ibc = ibc.buscarxfichaxmuestra
                        If Not ibc Is Nothing Then
                            Dim valrb As Double = Val(ibc.RB)
                            'a.ANALISIS = 1
                            'a = a.buscar
                            'If Not a Is Nothing Then
                            '    desde = a.DESDE
                            '    hasta = a.HASTA
                            '    If valrb < desde Or valrb > hasta Then
                            '        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                            '    End If
                            'End If
                            Dim rb_ As String = ""
                            If ibc.RB > 800 Then
                                rb_ = ">800"
                            ElseIf ibc.RB < 5.4 Then
                                rb_ = "<5.4"
                            Else
                                rb_ = ibc.RB
                            End If
                            x1hoja.Cells(fila, columna).formula = rb_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        Else
                            x1hoja.Cells(fila, columna).formula = "-"
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
                    If csm.COMPOSICION = 1 Or csm.COMPOSICIONSUERO = 1 Then
                        If Not c Is Nothing Then
                            Dim valgrasa As Double = Val(c.GRASA)
                            a.ANALISIS = 267
                            a = a.buscar
                            If Not a Is Nothing Then
                                desde = a.DESDE
                                hasta = a.HASTA
                                If valgrasa < desde Or valgrasa > hasta Then
                                    x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                                End If
                            End If
                            If valgrasa < 2.5 Or valgrasa > 5 Then
                                x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                            End If
                            x1hoja.Cells(fila, columna).formula = FormatNumber(c.GRASA, 2)
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        Else
                            x1hoja.Cells(fila, columna).formula = "-"
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
                    If csm.COMPOSICION = 1 Or csm.COMPOSICIONSUERO = 1 Then
                        If Not c Is Nothing Then
                            Dim valproteina As Double = Val(c.PROTEINA)
                            a.ANALISIS = 270
                            a = a.buscar
                            If Not a Is Nothing Then
                                desde = a.DESDE
                                hasta = a.HASTA
                                If valproteina < desde Or valproteina > hasta Then
                                    x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                                End If
                            End If
                            x1hoja.Cells(fila, columna).formula = FormatNumber(c.PROTEINA, 2)
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        Else
                            x1hoja.Cells(fila, columna).formula = "-"
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
                    If csm.COMPOSICION = 1 Or csm.COMPOSICIONSUERO = 1 Then
                        If Not c Is Nothing Then
                            x1hoja.Cells(fila, columna).formula = FormatNumber(c.LACTOSA, 2)
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        Else
                            x1hoja.Cells(fila, columna).formula = "-"
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
                    If csm.COMPOSICION = 1 Or csm.COMPOSICIONSUERO = 1 Then
                        If Not c Is Nothing Then
                            Dim valst As Double = Val(c.ST)
                            a.ANALISIS = 269
                            a = a.buscar
                            If Not a Is Nothing Then
                                desde = a.DESDE
                                hasta = a.HASTA
                                If valst < desde Or valst > hasta Then
                                    x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                                End If
                            End If
                            x1hoja.Cells(fila, columna).formula = FormatNumber(c.ST, 2)
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        Else
                            x1hoja.Cells(fila, columna).formula = "-"
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
                    If csm.CRIOSCOPIA = 1 Then 'Or csm.CRIOSCOPIA_CRIOSCOPO = 1 Then
                        If Not c Is Nothing Then
                            If c.CRIOSCOPIA <> -1 Then
                                Dim valcrioscopia As Double = Val(c.CRIOSCOPIA) * -1 / 1000
                                x1hoja.Cells(fila, columna).formula = valcrioscopia.ToString("##,###0.000")
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                If valcrioscopia > -0.512 Then
                                    'Dim r As New dRgLab88
                                    'r.FICHA = nroficha
                                    'r.MUESTRA = csm.MUESTRA
                                    'r = r.buscarxfichaxmuestra
                                    'If Not r Is Nothing Then
                                    '    Dim delta As Double = 0
                                    '    Dim criosc As Double = 0
                                    '    Dim resultado As Double = 0
                                    '    delta = r.DELTA
                                    '    criosc = r.CRIOSCOPO
                                    '    If delta > criosc Then
                                    '        resultado = delta - criosc
                                    '    Else
                                    '        resultado = criosc - delta
                                    '    End If
                                    '    If resultado > 5 Then
                                    '        valcrioscopia = Val(r.CRIOSCOPO) * -1 / 1000
                                    '        a.ANALISIS = 102
                                    '        a = a.buscar
                                    '        If Not a Is Nothing Then
                                    '            desde = a.DESDE
                                    '            hasta = a.HASTA
                                    '        End If
                                    'If valcrioscopia > desde Or valcrioscopia < hasta Then
                                    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                                    '        End If
                                    '    End If
                                    'End If
                                End If
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = "-"
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
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    End If
                    If csm.CRIOSCOPIA_CRIOSCOPO = 1 Then
                            columna = columna - 1
                            Dim r As New dRgLab88
                            Dim valcrioscopia As Double = 0
                            r.FICHA = nroficha
                            r.MUESTRA = csm.MUESTRA
                            r = r.buscarxfichaxmuestra
                            'If Not r Is Nothing Then
                            Dim criosc As Double = 0
                            criosc = r.CRIOSCOPO
                            valcrioscopia = Val(criosc) * -1 / 1000
                            a.ANALISIS = 102
                            a = a.buscar
                        If valcrioscopia > -0.512 Then
                            'If Not a Is Nothing Then
                            '    desde = a.DESDE
                            '    hasta = a.HASTA
                            'End If
                            'If valcrioscopia > desde Or valcrioscopia < hasta Then
                            x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                            'End If
                            x1hoja.Cells(fila, columna).formula = valcrioscopia.ToString("##,###0.000")
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        Else
                            x1hoja.Cells(fila, columna).formula = "-"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        End If
                    End If
            If csm.UREA = 1 Then
                If Not c Is Nothing Then
                    If c.UREA <> -1 Then
                        Dim valorurea As Integer
                        valorurea = c.UREA * 0.466
                        x1hoja.Cells(fila, columna).formula = valorurea
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        If valorurea > 20 Or valorurea < 9 Then
                            x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                        End If
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
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
            Else
                x1hoja.Cells(fila, columna).formula = "-"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
            End If
            Dim inh As New dInhibidores
            inh.FICHA = nroficha
            inh.MUESTRA = Trim(csm.MUESTRA)
            inh = inh.buscarxfichaxmuestra
            If Not inh Is Nothing Then
                If inh.RESULTADO = 0 Then
                    x1hoja.Cells(fila, columna).formula = "Negativo"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 6
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "Positivo"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 6
                    columna = columna + 1
                End If
            Else
                x1hoja.Cells(fila, columna).formula = "-"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
            End If
            'ESPORULADOS*******************************************************************************
            Dim esp As New dEsporulados
            esp.FICHA = nroficha
            esp.MUESTRA = Trim(csm.MUESTRA)
            esp = esp.buscarxfichaxmuestra
            If Not esp Is Nothing Then
                x1hoja.Cells(fila, columna).formula = esp.RESULTADO
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
            Else
                x1hoja.Cells(fila, columna).formula = "-"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
            End If
            'PSICROTROFOS*******************************************************************************
            Dim psi As New dPsicrotrofos
            psi.FICHA = nroficha
            psi.MUESTRA = Trim(csm.MUESTRA)
            psi = psi.buscarxfichaxmuestra
            If Not psi Is Nothing Then
                x1hoja.Cells(fila, columna).formula = psi.PROMEDIO
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
            Else
                x1hoja.Cells(fila, columna).formula = "-"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
            End If
            'CASEINA ************************************************************************************
            If csm.CASEINA = 1 Then
                If Not c Is Nothing Then
                    If c.CASEINA <> -1 Then
                        Dim valorcaseina As Double
                        valorcaseina = c.CASEINA
                        x1hoja.Cells(fila, columna).formula = FormatNumber(valorcaseina, 2)
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
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
            Else
                x1hoja.Cells(fila, columna).formula = "-"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
            End If
            'AFLATOXINA M1*******************************************************************************
            Dim m As New dMicotoxinasLeche
            m.FICHA = nroficha
            m.MUESTRA = Trim(csm.MUESTRA)
            m = m.buscarxfichaxmuestra
            If Not m Is Nothing Then
                x1hoja.Cells(fila, columna).formula = m.RESULTADO
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = 1
            Else
                x1hoja.Cells(fila, columna).formula = "-"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = 1
            End If
            columna = 1
            fila = fila + 1
                Next
                'Referencias
                fila = fila + 1
                columna = 1
                '*******************************************************************************************************
                x1hoja.Cells(fila, columna).rowheight = 3
                fila = fila + 1
                x1hoja.Range("A" & fila, "N" & fila).Merge()
                x1hoja.Cells(fila, columna).Interior.Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).rowheight = 1
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Referencias:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = ""
                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).Font.Bold = False
                columna = columna + 1
                x1hoja.Cells(fila, columna).Formula = "Valor fuera de rango de acreditación"
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 7
                columna = columna + 4
                x1hoja.Cells(fila, columna).Formula = "-"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Font.Bold = False
                columna = columna + 1
                x1hoja.Cells(fila, columna).Formula = "Análisis no requerido"
                x1hoja.Cells(fila, columna).Font.Size = 7
                x1hoja.Cells(fila, columna).Font.Bold = False
                columna = columna + 3
                x1hoja.Cells(fila, columna).Formula = "(*)Ensayo no acreditado ISO 17025 O.U.A."
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                fila = fila + 1
                columna = 1
                'x1hoja.Cells(fila, columna).Formula = "Valor resaltado: valor fuera de especificación del Decreto 382/2016"
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 8
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Métodos"
                x1hoja.Cells(fila, columna).Font.Bold = True
                fila = fila + 1
                x1hoja.Cells(fila, columna).rowheight = 30
                x1hoja.Cells(fila, columna).Formula = listademetodos
                x1hoja.Range("A" & fila, "N" & fila).WrapText = True
                x1hoja.Range("A" & fila, "N" & fila).Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Size = 7
                fila = fila + 1
                '*** OBSERVACIONES **************************************************
                If sa.OBSERVACIONES <> "" Then
                    x1hoja.Cells(fila, columna).rowheight = 25
                    x1hoja.Cells(fila, columna).Formula = "Observaciones: " & sa.OBSERVACIONES
                    x1hoja.Range("A" & fila, "N" & fila).WrapText = True
                    x1hoja.Range("A" & fila, "N" & fila).Merge()
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    fila = fila + 1
                End If
                '********************************************************************
                Dim na2 As New dNuevoAnalisis
                Dim listana2 As New ArrayList
                listana2 = na2.listarporficha2(nroficha)
                If Not listana2 Is Nothing Then
                    For Each na2 In listana2
                        Dim lp As New dListaPrecios
                        lp.ID = na2.ANALISIS
                        lp = lp.buscar
                        If Not lp Is Nothing Then
                            If lp.ACREDITADO = 1 Then
                                acreditado = 1
                            End If
                        End If
                    Next
                End If
                'CABEZAL CON O SIN LOGO OUA
                If acreditado = 1 Then
                    x1hoja.Shapes.AddPicture("c:\Debug\encabezado_con_oua2.png", _
             Microsoft.Office.Core.MsoTriState.msoFalse, _
             Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 470, 42)
                Else
                    x1hoja.Shapes.AddPicture("c:\Debug\encabezado_sin_oua2.png", _
             Microsoft.Office.Core.MsoTriState.msoFalse, _
             Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 470, 42)
                End If
                '********************************************************************
                If idparatecnico1 = 1 Then
                    nombre_paratecnico = nombre_paratecnico + "Diego Arenas - "
                End If
                If idparatecnico2 = 1 Then
                    nombre_paratecnico = nombre_paratecnico + "Lorena Nidegger - "
                End If
                If idparatecnico3 = 1 Then
                    nombre_paratecnico = nombre_paratecnico + "Claudia García - "
                End If
                If idparatecnico4 = 1 Then
                    nombre_paratecnico = nombre_paratecnico + "Erika Silva - "
                End If
                If idparatecnico5 = 1 Then
                    nombre_paratecnico = nombre_paratecnico + "Virginia Ferreira - "
                End If
                If idparatecnico6 = 1 Then
                    nombre_paratecnico = nombre_paratecnico + "Jeniffer Madera - "
                End If
                columna = 1
                '*** PONER FIRMA ********************************************************
                fila = fila + 1
                x1libro.Worksheets(1).cells(fila, columna).select()
                x1libro.ActiveSheet.pictures.Insert("c:\Debug\cecilia.jpg").select()
                x1libro.Worksheets(1).cells(2, 1).select()
                fila = fila - 1
                'RANGOS ACREDITADOS******************************************************************
                columna = columna + 4
                x1hoja.Cells(fila, columna).Formula = " RANGOS ACREDITADOS"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 7
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                columna = columna + 1
                x1hoja.Cells(fila, columna).Formula = ""
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 7
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                columna = columna + 1
                x1hoja.Cells(fila, columna).Formula = ""
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 7
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                columna = columna + 1
                x1hoja.Cells(fila, columna).Formula = ""
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 7
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                columna = columna - 3
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "RCS = 100.000 a 1 millón cel/mL"
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 7
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Pr = 2.5 - 4.0 g/100mL"
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 7
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Gr = 2.5 - 5.0 g/100mL"
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 7
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Crio. = -0.408ºC a -0.600ºC"
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 7
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "RBt= 5.400 a 800.000 ufc/mL"
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 7
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "ST = 10.5 a 14.0 g/100mL"
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 7
                fila = fila - 6
                'ABREVIATURAS************************************************************************
                columna = columna + 4
                x1hoja.Cells(fila, columna).Formula = "                                                   ABREVIATURAS"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 7
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                columna = columna + 1
                x1hoja.Cells(fila, columna).Formula = ""
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 7
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                columna = columna + 1
                x1hoja.Cells(fila, columna).Formula = ""
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 7
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                columna = columna + 1
                x1hoja.Cells(fila, columna).Formula = ""
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 7
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                columna = columna + 1
                x1hoja.Cells(fila, columna).Formula = ""
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 7
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                columna = columna + 1
                x1hoja.Cells(fila, columna).Formula = ""
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 7
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                columna = columna - 5
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "RCS = Recuento Células Somáticas"
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 7
                columna = columna + 3
                x1hoja.Cells(fila, columna).Formula = "Crio. = Crioscopía"
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 7
                fila = fila + 1
                columna = columna - 3
                x1hoja.Cells(fila, columna).Formula = "RBt = Recuento Bacteriano total"
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 7
                columna = columna + 3
                x1hoja.Cells(fila, columna).Formula = "MUN = Nitrógeno uréico en leche"
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 7
                fila = fila + 1
                columna = columna - 3
                x1hoja.Cells(fila, columna).Formula = "Gr = Grasa"
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 7
                columna = columna + 3
                x1hoja.Cells(fila, columna).Formula = "MUN = Urea x 0.466"
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 7
                fila = fila + 1
                columna = columna - 3
                x1hoja.Cells(fila, columna).Formula = "Pr = Proteína total"
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 7
                columna = columna + 3
                x1hoja.Cells(fila, columna).Formula = "Inh = Inhibidores"
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 7
                fila = fila + 1
                columna = columna - 3
                x1hoja.Cells(fila, columna).Formula = "Lac = Lactosa"
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 7
                columna = columna + 3
                x1hoja.Cells(fila, columna).Formula = "Esp.ana. = Esporulados anaerobios"
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 7
                fila = fila + 1
                columna = columna - 3
                x1hoja.Cells(fila, columna).Formula = "ST = Sólidos totales"
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 7
                columna = columna + 3
                x1hoja.Cells(fila, columna).Formula = "Psicro = Psicrótrofos"
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 7
                fila = fila + 1
                columna = columna - 3
                x1hoja.Cells(fila, columna).Formula = "Cas = Caseína"
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 7
                columna = columna + 3
                x1hoja.Cells(fila, columna).Formula = "AFL = Aflatoxína M1 =µg/Kg = ppb"
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 7
                fila = fila + 1
                columna = 1
                x1hoja.Cells(fila, columna).Formula = "Laboratorio habilitado RNL 0029 - MGAP" & " - Certificado vigente al 31/08/2022"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                'PARATECNICOS************************************************************************
                x1hoja.Cells(fila, columna).Formula = "Paratécnico: " & nombre_paratecnico
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                'TOTAL DE MUESTRAS **********************************************************
                x1hoja.Cells(fila, columna).Formula = "Total de muestras: " & sa.NMUESTRAS
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                '*** PIE DE PAGINA ******************************************************
                x1hoja.Cells(fila, columna).rowheight = 25
                x1hoja.Cells(fila, columna).Formula = "Este informe no podrá ser reproducido total o parcialmente sin la autorización escrita de COLAVECO. Los resultados consignados se refieren exclusivamente a la muestra recibida." & vbCrLf _
                    & "COLAVECO declina toda responsabilidad por el uso indebido o incorrecto que se hiciere a este informe, asi como el plan y procedimientos de muestreo aplicados por el cliente. Dra. Cecilia Abelenda (DT)"
                x1hoja.Range("A" & fila, "N" & fila).WrapText = True
                x1hoja.Range("A" & fila, "N" & fila).Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Size = 6
                '************************************************************************
                fila = fila + 1
                x1hoja.Range("A" & fila, "N" & fila).Merge()
                x1hoja.Cells(fila, columna).Interior.Color = RGB(215, 219, 221)
                x1hoja.Cells(fila, columna).rowheight = 8
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Formula = "Fin del informe."
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 7
            End If
        End If
        '***********************************************************
        x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas
        'PROTEGE LA HOJA DE EXCEL
        x1hoja.Protect(Password:="1582782", DrawingObjects:=True, _
        Contents:=True, Scenarios:=True)
        'GUARDA EL ARCHIVO DE EXCEL
        x1hoja.SaveAs("\\ROBOT\PREINFORMES\CALIDAD\" & nroficha & ".xls")
        x1app.Visible = True
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub informe_brucelosisenleche_empresa()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
        x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(1)
        x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(1)
        x1hoja.PageSetup.Orientation = (Excel.XlPageOrientation.xlLandscape)
        Dim sa As New dSolicitudAnalisis
        Dim cli As New dCliente
        Dim b As New dBrucelosis
        Dim met As New dMetodos
        Dim lista As New ArrayList
        Dim acreditado As Integer = 0
        Dim acreditado2 As Integer = 0
        Dim informefinal As Integer = 0
        Dim nombre_operador As String = ""
        Dim nombre_tecnico As String = ""
        '*****************************
        nroficha = TextFicha.Text.Trim
        sa.ID = nroficha
        sa = sa.buscar
        lista = b.listarporsolicitud(nroficha)
        '***********************************************
        Dim fila As Integer
        Dim columna As Integer
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                fila = 1
                columna = 1
                'Poner Titulos
                columna = 2
                x1hoja.Cells(3, 1).columnwidth = 17
                x1hoja.Cells(3, 2).columnwidth = 56
                x1hoja.Cells(3, 3).columnwidth = 13
                x1hoja.Cells(3, 4).columnwidth = 11
                x1hoja.Cells(3, 5).columnwidth = 5
                x1hoja.Cells(3, 6).columnwidth = 5
                x1hoja.Cells(3, 7).columnwidth = 5
                x1hoja.Cells(3, 8).columnwidth = 7
                x1hoja.Cells(3, 9).columnwidth = 7
                x1hoja.Cells(3, 10).columnwidth = 7
                fila = fila + 4
                columna = 1
                x1hoja.Cells(fila, columna).rowheight = 3
                fila = fila + 1
                x1hoja.Range("A" & fila, "I" & fila).Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).Formula = "INFORME DE BRUCELOSIS EN LECHE"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 12
                fila = fila + 1
                columna = 1
                x1hoja.Cells(fila, columna).Formula = "Nº Ficha: " & sa.ID
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 5
                x1hoja.Cells(fila, columna).Formula = "Fecha entrada: " & sa.FECHAINGRESO
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                cli.ID = sa.IDPRODUCTOR
                cli = cli.buscar
                x1hoja.Cells(fila, columna).Formula = "Cliente: " & cli.NOMBRE
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 5
                Dim b2 As New dBrucelosis
                Dim fechaproceso As String = ""
                Dim listab As New ArrayList
                listab = b2.listarporsolicitud(sa.ID)
                If Not listab Is Nothing Then
                    For Each b2 In listab
                        fechaproceso = b2.FECHA
                    Next
                End If
                b = Nothing
                listab = Nothing
                x1hoja.Cells(fila, columna).Formula = "Fecha proceso: " & fechaproceso
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                If cli.DIRECCION <> "" Or cli.DIRECCION <> "No aportado" Then
                    x1hoja.Cells(fila, columna).Formula = "Dirección: " & cli.DIRECCION
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = columna + 5
                ElseIf cli.IDLOCALIDAD <> 999 Then
                    Dim loc As New dLocalidad
                    loc.ID = cli.IDLOCALIDAD
                    loc = loc.buscar
                    If Not loc Is Nothing Then
                        x1hoja.Cells(fila, columna).Formula = loc.NOMBRE
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 9
                        columna = columna + 5
                    End If
                ElseIf cli.IDDEPARTAMENTO <> 999 Then
                    Dim dep As New dDepartamento
                    dep.ID = cli.IDDEPARTAMENTO
                    dep = dep.buscar
                    If Not dep Is Nothing Then
                        x1hoja.Cells(fila, columna).Formula = dep.NOMBRE
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 9
                        columna = columna + 5
                    End If
                ElseIf cli.CELULAR <> "" Then
                    x1hoja.Cells(fila, columna).Formula = "Celular: " & cli.CELULAR
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = columna + 5
                Else
                    x1hoja.Cells(fila, columna).Formula = "No aportado"
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = columna + 5
                End If
                Dim fecha As Date = Now()
                Dim fecha2 As String = fecha.ToString("dd/MM/yyyy")
                x1hoja.Cells(fila, columna).Formula = "Fecha informe: " & fecha2
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                Dim mm As New dMuestras
                mm.ID = sa.IDMUESTRA
                mm = mm.buscar
                If Not mm Is Nothing Then
                    x1hoja.Cells(fila, columna).Formula = "Material recibido: " & mm.NOMBRE
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = 1
                Else
                    x1hoja.Cells(fila, columna).Formula = "Material recibido: "
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    fila = fila + 1
                    columna = 1
                End If
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Muestreo realizado por el cliente"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                x1hoja.Range("A" & fila, "I" & fila).Merge()
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).rowheight = 1
                fila = fila + 1
                x1hoja.Cells(fila, columna).rowheight = 3
                fila = fila + 1
                columna = 1
                Dim cuenta As Integer = 1
                Dim detallemuestras As String = ""
                Dim idoperador As Integer = 0
                Dim operador As String = ""
                Dim iu As New dUsuario
                iu.ID = idoperador
                iu = iu.buscar
                If Not iu Is Nothing Then
                    operador = iu.NOMBRE
                End If
                x1hoja.Cells(fila, columna).Formula = "Matrícula"
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 1
                x1hoja.Cells(fila, columna).Formula = "Propietario"
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 1
                x1hoja.Cells(fila, columna).Formula = "DICOSE"
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 1
                x1hoja.Cells(fila, columna).Formula = "Resultado"
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = 1
                fila = fila + 1
                Dim lm As New dListaMetodos
                Dim listademetodos As String = ""
                lm.ANALISIS = 124
                lm = lm.buscarxanalisis
                If Not lm Is Nothing Then
                    listademetodos = lm.METODO
                End If
                If Not lista Is Nothing Then
                    For Each b In lista
                        If nombre_operador = "" Then
                            Dim u As New dUsuario
                            u.ID = b.OPERADOR
                            u = u.buscar
                            If Not u Is Nothing Then
                                nombre_operador = u.NOMBRE
                            End If
                        End If
                        x1hoja.Cells(fila, columna).formula = b.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 1
                        Dim pe As New dProductorEmpresa
                        pe.IDEMPRESA = sa.IDPRODUCTOR
                        pe.MATRICULA = b.MUESTRA
                        pe = pe.buscarproductorempresa2
                        If Not pe Is Nothing Then
                            Dim produc As New dCliente
                            produc.ID = pe.IDPRODUCTOR
                            produc = produc.buscar
                            If Not produc Is Nothing Then
                                x1hoja.Cells(fila, columna).formula = produc.NOMBRE
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).formula = produc.DICOSE
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                columna = columna + 1
                            End If
                        End If
                        If b.RESULTADO = 0 Then
                            x1hoja.Cells(fila, columna).formula = "Negativo"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = 1
                            fila = fila + 1
                        ElseIf b.RESULTADO = 1 Then
                            x1hoja.Cells(fila, columna).formula = "Positivo"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = 1
                            fila = fila + 1
                        Else
                            x1hoja.Cells(fila, columna).formula = "Dudoso"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = 1
                            fila = fila + 1
                        End If
                        pe = Nothing
                    Next
                End If
                x1hoja.Cells(fila, columna).rowheight = 3
                fila = fila + 1
                x1hoja.Range("A" & fila, "I" & fila).Merge()
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).rowheight = 1
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Método"
                x1hoja.Cells(fila, columna).Font.Bold = True
                fila = fila + 1
                x1hoja.Cells(fila, columna).rowheight = 15
                x1hoja.Cells(fila, columna).Formula = listademetodos
                x1hoja.Range("A" & fila, "I" & fila).WrapText = True
                x1hoja.Range("A" & fila, "I" & fila).Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Size = 7
                fila = fila + 1
                '*** OBSERVACIONES **************************************************
                If sa.OBSERVACIONES <> "" Then
                    x1hoja.Cells(fila, columna).rowheight = 25
                    x1hoja.Cells(fila, columna).Formula = "Observaciones: " & sa.OBSERVACIONES
                    x1hoja.Range("A" & fila, "I" & fila).WrapText = True
                    x1hoja.Range("A" & fila, "I" & fila).Merge()
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    fila = fila + 1
                End If
                '********************************************************************
                'CABEZAL CON O SIN LOGO OUA
                x1hoja.Shapes.AddPicture("c:\Debug\encabezado_sin_oua2.png", _
         Microsoft.Office.Core.MsoTriState.msoFalse, _
         Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 690, 50)
                '***********************************************************
                columna = columna + 4
                x1hoja.Cells(fila, columna).Formula = "Operador: " & nombre_operador
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = 1
                fila = fila + 1
                '*** PONER FIRMA ********************************************************
                x1libro.Worksheets(1).cells(fila, columna).select()
                x1libro.ActiveSheet.pictures.Insert("c:\Debug\cecilia.jpg").select()
                x1libro.Worksheets(1).cells(2, 1).select()
                fila = fila + 6
                columna = 1
                x1hoja.Cells(fila, columna).Formula = "Laboratorio habilitado RNL 0029 - MGAP" & " - Certificado vigente al 31/08/2022"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Total de muestras: " & sa.NMUESTRAS
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                '*** PIE DE PAGINA ******************************************************
                x1hoja.Cells(fila, columna).rowheight = 25
                x1hoja.Cells(fila, columna).Formula = "Este informe no podrá ser reproducido total o parcialmente sin la autorización escrita de COLAVECO. Los resultados consignados se refieren exclusivamente a la muestra recibida." & vbCrLf _
                    & "COLAVECO declina toda responsabilidad por el uso indebido o incorrecto que se hiciere a este informe, asi como el plan y procedimientos de muestreo aplicados por el cliente. Dra. Cecilia Abelenda (Directora Técnica)"
                x1hoja.Range("A" & fila, "I" & fila).WrapText = True
                x1hoja.Range("A" & fila, "I" & fila).Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Size = 6
                '************************************************************************
                fila = fila + 1
                x1hoja.Range("A" & fila, "I" & fila).Merge()
                x1hoja.Cells(fila, columna).Interior.Color = RGB(215, 219, 221)
                x1hoja.Cells(fila, columna).rowheight = 8
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Formula = "Fin del informe."
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 7
            End If
        End If
        'Insert tabla preinformes**************************
        Dim pi As New dPreinformes
        Dim fechaactual As Date = Now()
        Dim _fecha As String
        _fecha = Format(fechaactual, "yyyy-MM-dd")
        pi.FICHA = nroficha
        pi = pi.buscar
        If Not pi Is Nothing Then
        Else
            Dim pi2 As New dPreinformes
            pi2.FICHA = nroficha
            pi2.TIPO = 15
            pi2.CREADO = 1
            pi2.FECHA = _fecha
            pi2.guardar()
            pi2 = Nothing
        End If
        pi = Nothing
        '***********************************************************
        x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas
        'PROTEGE LA HOJA DE EXCEL
        x1hoja.Protect(Password:="1582782", DrawingObjects:=True, _
        Contents:=True, Scenarios:=True)
        'GUARDA EL ARCHIVO DE EXCEL
        x1hoja.SaveAs("\\ROBOT\PREINFORMES\BRUCELOSIS_LECHE\" & nroficha & ".xls")
        x1app.Visible = True
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub informe_brucelosisenleche_productor()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
        x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(1)
        x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(1)
        x1hoja.PageSetup.Orientation = (Excel.XlPageOrientation.xlLandscape)
        Dim sa As New dSolicitudAnalisis
        Dim cli As New dCliente
        Dim b As New dBrucelosis
        Dim met As New dMetodos
        Dim lista As New ArrayList
        Dim acreditado As Integer = 0
        Dim acreditado2 As Integer = 0
        Dim informefinal As Integer = 0
        Dim nombre_operador As String = ""
        Dim nombre_tecnico As String = ""
        '*****************************
        nroficha = TextFicha.Text.Trim
        sa.ID = nroficha
        sa = sa.buscar
        lista = b.listarporsolicitud(nroficha)
        '***********************************************
        Dim fila As Integer
        Dim columna As Integer
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                fila = 1
                columna = 1
                'Poner Titulos
                columna = 2
                x1hoja.Cells(3, 1).columnwidth = 17
                x1hoja.Cells(3, 2).columnwidth = 24
                x1hoja.Cells(3, 3).columnwidth = 13
                x1hoja.Cells(3, 4).columnwidth = 43 '11
                x1hoja.Cells(3, 5).columnwidth = 5
                x1hoja.Cells(3, 6).columnwidth = 5
                x1hoja.Cells(3, 7).columnwidth = 5
                x1hoja.Cells(3, 8).columnwidth = 7
                x1hoja.Cells(3, 9).columnwidth = 7
                x1hoja.Cells(3, 10).columnwidth = 7
                fila = fila + 4
                columna = 1
                x1hoja.Cells(fila, columna).rowheight = 3
                fila = fila + 1
                x1hoja.Range("A" & fila, "I" & fila).Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).Formula = "INFORME DE BRUCELOSIS EN LECHE"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 12
                fila = fila + 1
                columna = 1
                x1hoja.Cells(fila, columna).Formula = "Nº Ficha: " & sa.ID
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 5
                x1hoja.Cells(fila, columna).Formula = "Fecha entrada: " & sa.FECHAINGRESO
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                cli.ID = sa.IDPRODUCTOR
                cli = cli.buscar
                x1hoja.Cells(fila, columna).Formula = "Cliente: " & cli.NOMBRE
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 5
                Dim b2 As New dBrucelosis
                Dim fechaproceso As String = ""
                Dim listab As New ArrayList
                listab = b2.listarporsolicitud(sa.ID)
                If Not listab Is Nothing Then
                    For Each b2 In listab
                        fechaproceso = b2.FECHA
                    Next
                End If
                b = Nothing
                listab = Nothing
                x1hoja.Cells(fila, columna).Formula = "Fecha proceso: " & fechaproceso
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                If cli.DIRECCION <> "" Or cli.DIRECCION <> "No aportado" Then
                    x1hoja.Cells(fila, columna).Formula = "Dirección: " & cli.DIRECCION
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = columna + 5
                ElseIf cli.IDLOCALIDAD <> 999 Then
                    Dim loc As New dLocalidad
                    loc.ID = cli.IDLOCALIDAD
                    loc = loc.buscar
                    If Not loc Is Nothing Then
                        x1hoja.Cells(fila, columna).Formula = loc.NOMBRE
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 9
                        columna = columna + 5
                    End If
                ElseIf cli.IDDEPARTAMENTO <> 999 Then
                    Dim dep As New dDepartamento
                    dep.ID = cli.IDDEPARTAMENTO
                    dep = dep.buscar
                    If Not dep Is Nothing Then
                        x1hoja.Cells(fila, columna).Formula = dep.NOMBRE
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 9
                        columna = columna + 5
                    End If
                ElseIf cli.CELULAR <> "" Then
                    x1hoja.Cells(fila, columna).Formula = "Celular: " & cli.CELULAR
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = columna + 5
                Else
                    x1hoja.Cells(fila, columna).Formula = "No aportado"
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = columna + 5
                End If
                Dim fecha As Date = Now()
                Dim fecha2 As String = fecha.ToString("dd/MM/yyyy")
                x1hoja.Cells(fila, columna).Formula = "Fecha informe: " & fecha2
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                Dim mm As New dMuestras
                mm.ID = sa.IDMUESTRA
                mm = mm.buscar
                If Not mm Is Nothing Then
                    x1hoja.Cells(fila, columna).Formula = "Material recibido: " & mm.NOMBRE
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = 1
                Else
                    x1hoja.Cells(fila, columna).Formula = "Material recibido: "
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    fila = fila + 1
                    columna = 1
                End If
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Muestreo realizado por el cliente"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                x1hoja.Range("A" & fila, "I" & fila).Merge()
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).rowheight = 1
                fila = fila + 1
                x1hoja.Cells(fila, columna).rowheight = 3
                fila = fila + 1
                columna = 1
                Dim cuenta As Integer = 1
                Dim detallemuestras As String = ""
                Dim idoperador As Integer = 0
                Dim operador As String = ""
                Dim iu As New dUsuario
                iu.ID = idoperador
                iu = iu.buscar
                If Not iu Is Nothing Then
                    operador = iu.NOMBRE
                End If
                x1hoja.Cells(fila, columna).Formula = "Matrícula"
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 1
                x1hoja.Cells(fila, columna).Formula = "DICOSE"
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 1
                x1hoja.Cells(fila, columna).Formula = "Resultado"
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = 1
                fila = fila + 1
                Dim lm As New dListaMetodos
                Dim listademetodos As String = ""
                lm.ANALISIS = 124
                lm = lm.buscarxanalisis
                If Not lm Is Nothing Then
                    listademetodos = lm.METODO
                End If
                If Not lista Is Nothing Then
                    For Each b In lista
                        If nombre_operador = "" Then
                            Dim u As New dUsuario
                            u.ID = b.OPERADOR
                            u = u.buscar
                            If Not u Is Nothing Then
                                nombre_operador = u.NOMBRE
                            End If
                        End If
                        x1hoja.Cells(fila, columna).formula = b.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 1
                        If cli.DICOSE <> "" Then
                            x1hoja.Cells(fila, columna).formula = cli.DICOSE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                        Else
                            x1hoja.Cells(fila, columna).formula = ""
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                        End If
                        If b.RESULTADO = 0 Then
                            x1hoja.Cells(fila, columna).formula = "Negativo"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = 1
                            fila = fila + 1
                        ElseIf b.RESULTADO = 1 Then
                            x1hoja.Cells(fila, columna).formula = "Positivo"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = 1
                            fila = fila + 1
                        Else
                            x1hoja.Cells(fila, columna).formula = "Dudoso"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = 1
                            fila = fila + 1
                        End If
                    Next
                End If
                x1hoja.Cells(fila, columna).rowheight = 3
                fila = fila + 1
                x1hoja.Range("A" & fila, "I" & fila).Merge()
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).rowheight = 1
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Método"
                x1hoja.Cells(fila, columna).Font.Bold = True
                fila = fila + 1
                x1hoja.Cells(fila, columna).rowheight = 15
                x1hoja.Cells(fila, columna).Formula = listademetodos
                x1hoja.Range("A" & fila, "I" & fila).WrapText = True
                x1hoja.Range("A" & fila, "I" & fila).Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Size = 7
                fila = fila + 1
                '*** OBSERVACIONES **************************************************
                If sa.OBSERVACIONES <> "" Then
                    x1hoja.Cells(fila, columna).rowheight = 25
                    x1hoja.Cells(fila, columna).Formula = "Observaciones: " & sa.OBSERVACIONES
                    x1hoja.Range("A" & fila, "I" & fila).WrapText = True
                    x1hoja.Range("A" & fila, "I" & fila).Merge()
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    fila = fila + 1
                End If
                '********************************************************************
                'CABEZAL CON O SIN LOGO OUA
                x1hoja.Shapes.AddPicture("c:\Debug\encabezado_sin_oua2.png", _
         Microsoft.Office.Core.MsoTriState.msoFalse, _
         Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 690, 50)
                '***********************************************************
                columna = columna + 4
                x1hoja.Cells(fila, columna).Formula = "Operador: " & nombre_operador
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = 1
                fila = fila + 1

                '*** PONER FIRMA ********************************************************
                x1libro.Worksheets(1).cells(fila, columna).select()
                x1libro.ActiveSheet.pictures.Insert("c:\Debug\cecilia.jpg").select()
                x1libro.Worksheets(1).cells(2, 1).select()
                fila = fila + 6
                columna = 1
                x1hoja.Cells(fila, columna).Formula = "Laboratorio habilitado RNL 0029 - MGAP" & " - Certificado vigente al 31/08/2022"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Total de muestras: " & sa.NMUESTRAS
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                '*** PIE DE PAGINA ******************************************************
                x1hoja.Cells(fila, columna).rowheight = 25
                x1hoja.Cells(fila, columna).Formula = "Este informe no podrá ser reproducido total o parcialmente sin la autorización escrita de COLAVECO. Los resultados consignados se refieren exclusivamente a la muestra recibida." & vbCrLf _
                    & "COLAVECO declina toda responsabilidad por el uso indebido o incorrecto que se hiciere a este informe, asi como el plan y procedimientos de muestreo aplicados por el cliente. Dra. Cecilia Abelenda (Directora Técnica)"
                x1hoja.Range("A" & fila, "I" & fila).WrapText = True
                x1hoja.Range("A" & fila, "I" & fila).Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Size = 6
                '************************************************************************
                fila = fila + 1
                x1hoja.Range("A" & fila, "I" & fila).Merge()
                x1hoja.Cells(fila, columna).Interior.Color = RGB(215, 219, 221)
                x1hoja.Cells(fila, columna).rowheight = 8
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Formula = "Fin del informe."
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 7
            End If
        End If
        'Insert tabla preinformes**************************
        Dim pi As New dPreinformes
        Dim fechaactual As Date = Now()
        Dim _fecha As String
        _fecha = Format(fechaactual, "yyyy-MM-dd")
        pi.FICHA = nroficha
        pi = pi.buscar
        If Not pi Is Nothing Then
        Else
            Dim pi2 As New dPreinformes
            pi2.FICHA = nroficha
            pi2.TIPO = 15
            pi2.CREADO = 1
            pi2.FECHA = _fecha
            pi2.guardar()
            pi2 = Nothing
        End If
        pi = Nothing
        '***********************************************************
        x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas
        'PROTEGE LA HOJA DE EXCEL
        x1hoja.Protect(Password:="1582782", DrawingObjects:=True, _
        Contents:=True, Scenarios:=True)
        'GUARDA EL ARCHIVO DE EXCEL
        x1hoja.SaveAs("\\ROBOT\PREINFORMES\BRUCELOSIS_LECHE\" & nroficha & ".xls")
        x1app.Visible = True
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub informe_suelos_conversion_fertilizante()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
        x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(1)
        x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(1)
        x1hoja.PageSetup.Orientation = (Excel.XlPageOrientation.xlLandscape)
        Dim sa As New dSolicitudAnalisis
        Dim cli As New dCliente
        Dim na As New dNuevoAnalisis
        Dim na_ As New dNuevoAnalisis
        Dim na3 As New dNuevoAnalisis
        Dim met As New dMetodos
        Dim lista As New ArrayList
        Dim lista_ As New ArrayList
        Dim lista2 As New ArrayList
        Dim lista3 As New ArrayList
        Dim acreditado As Integer = 0
        Dim acreditado2 As Integer = 0
        Dim xanalisis As Integer = 0
        Dim vec(xanalisis) As Integer
        Dim informefinal As Integer = 0
        Dim nombre_operador As String = "José L. García"
        Dim nombre_tecnico As String = "Ing. Agr. Victor González"
        Dim sin_asterisco As Integer = 1

        Dim Ms As Double = 0
        Dim Potasio As Double = 0
        Dim Nitrogeno As Double = 0
        Dim Fosforo As Double = 0
        Dim MsCantidad As Integer = 0
        Dim PotasioCantidad As Integer = 0
        Dim NitrogenoCantidad As Integer = 0
        Dim FosforoCantidad As Integer = 0
        Dim MsPrecente As Boolean = False
        Dim PotasioPrecente As Boolean = False
        Dim NitrogenoPrecente As Boolean = False
        Dim FosforoPrecente As Boolean = False
        Dim fechaFicha As Date
        Dim KgApli As Integer = 10000



        '*****************************
        nroficha = TextFicha.Text.Trim
        sa.ID = nroficha
        sa = sa.buscar
        lista = na.listarporfichamuestra(nroficha)
        lista3 = na3.listarporficha3(nroficha)
        lista_ = na_.listarporficha3(nroficha)
        '**********************************************
        If Not lista3 Is Nothing Then
            xanalisis = lista3.Count - 1
            ReDim vec(xanalisis)
            Dim i As Integer = 0
            For Each na3 In lista3
                vec(i) = na3.ANALISIS
                i = i + 1
            Next
        End If
        '***********************************************
        If Not lista_ Is Nothing Then
            For Each na_ In lista_
                Dim lp_ As New dListaPrecios
                lp_.ID = na_.ANALISIS
                lp_ = lp_.buscar
                If Not lp_ Is Nothing Then
                    If lp_.ACREDITADO = 1 Then
                        sin_asterisco = 0
                    End If
                End If
            Next
        End If
        '***********************************************
        Dim fila As Integer
        Dim columna As Integer
        Dim titulo As Boolean = False
        Dim compost As Boolean = False
        columna = 1
        fila = 1
        If Not lista Is Nothing Then
            If lista.Count > 0 Then

                For Each na In lista
                    Dim na2 As New dNuevoAnalisis
                    lista2 = na2.listarpormuestra(nroficha, na.MUESTRA)

                    For Each na2 In lista2
                        fechaFicha = na2.FECHAPROCESO
                        Dim a As New dAcreditacion
                        a.ANALISIS = na2.ANALISIS
                        a = a.buscar
                        If Not a Is Nothing Then
                            Dim desde As Double = a.DESDE
                            Dim hasta As Double = a.HASTA
                            If Val(na2.RESULTADO2) < desde Or Val(na2.RESULTADO2) > hasta Then
                                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                            Else
                                acreditado2 = 1
                            End If
                        End If

                        '%MS
                        If sa.IDMUESTRA = 37 Then
                            compost = True
                            If na2.ANALISIS = 473 Or na2.ANALISIS = 479 Or na2.ANALISIS = 474 Then
                                If IsNumeric(na2.RESULTADO) Then
                                    If na2.RESULTADO <> -1 Then
                                        Ms = na2.RESULTADO
                                        MsCantidad += 1
                                        MsPrecente = True
                                    End If
                                ElseIf IsNumeric(na2.RESULTADO2) Then
                                    If na2.RESULTADO2 <> -1 Then
                                        Ms = na2.RESULTADO2
                                        MsCantidad += 1
                                        MsPrecente = True
                                    End If
                                End If
                            End If
                        End If


                        'Nitrogeno
                        If sa.IDMUESTRA = 37 Then
                            If na2.ANALISIS = 138 Or na2.ANALISIS = 374 Then
                                If IsNumeric(na2.RESULTADO) Then
                                    If na2.RESULTADO <> -1 Then
                                        Nitrogeno = na2.RESULTADO
                                        NitrogenoCantidad += 1
                                        NitrogenoPrecente = True
                                    End If
                                ElseIf IsNumeric(na2.RESULTADO2) Then
                                    If na2.RESULTADO2 <> -1 Then
                                        Nitrogeno = na2.RESULTADO2
                                        NitrogenoCantidad += 1
                                        NitrogenoPrecente = True
                                    End If
                                End If
                            End If
                        End If

                        'Fosforo
                        If sa.IDMUESTRA = 37 Then
                            If na2.ANALISIS = 226 Or na2.ANALISIS = 375 Or na2.ANALISIS = 400 Then
                                If IsNumeric(na2.RESULTADO) Then
                                    If na2.RESULTADO <> -1 Then
                                        Fosforo = na2.RESULTADO
                                        FosforoCantidad += 1
                                        FosforoPrecente = True
                                    End If
                                ElseIf IsNumeric(na2.RESULTADO2) Then
                                    If na2.RESULTADO2 <> -1 Then
                                        Fosforo = na2.RESULTADO2
                                        FosforoCantidad += 1
                                        FosforoPrecente = True
                                    End If
                                End If
                            End If
                        End If


                        'Potasio
                        If sa.IDMUESTRA = 37 Then
                            If na2.ANALISIS = 208 Or na2.ANALISIS = 376 Or na2.ANALISIS = 401 Then
                                If IsNumeric(na2.RESULTADO) Then
                                    If na2.RESULTADO <> -1 Then
                                        Potasio = na2.RESULTADO
                                        PotasioCantidad += 1
                                        PotasioPrecente = True
                                    End If
                                ElseIf IsNumeric(na2.RESULTADO2) Then
                                    If na2.RESULTADO2 <> -1 Then
                                        Potasio = na2.RESULTADO2
                                        PotasioCantidad += 1
                                        PotasioPrecente = True
                                    End If
                                End If
                            End If
                        End If

                    Next

                    If titulo = False Then
                        'Poner Titulos
                        x1hoja.Shapes.AddPicture("c:\Debug\logo.jpg", _
                        Microsoft.Office.Core.MsoTriState.msoFalse, _
                        Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 160, 70)
                        columna = 1
                        fila = fila + 6

                        x1hoja.Range("A" & fila, "J" & fila).Merge()
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).Formula = "ANEXO"
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 12
                        columna = 1
                        fila = fila + 1

                        x1hoja.Range("A" & fila, "J" & fila).Merge()
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).Formula = "Conversión del Contenido de Nutrientes del fertilizante Orgánico, " & " - Ficha " & nroficha & ""
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 12
                        columna = 2
                        fila = fila + 1
                        fechaFicha = Nothing

                        titulo = True
                    End If

                    '//Comienzo de Contenido de Nutrientes

                    'Ms = Ms / MsCantidad
                    'Potasio = Potasio / PotasioCantidad
                    'Nitrogeno = Nitrogeno / NitrogenoCantidad
                    'Fosforo = Fosforo / FosforoCantidad

                    If MsPrecente = True Then
                        fila = fila + 1
                        x1hoja.Range("A" & fila, "C" & fila).Merge()
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        x1hoja.Cells(fila, columna).Font.Size = 12
                        x1hoja.Cells(fila, columna).Formula = "Compost"

                        fila = fila + 1
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 12
                        x1hoja.Cells(fila, columna).Formula = "Kg Aplicados"
                        'x1hoja.Cells(fila, columna).Style.WrapText = True
                        'x1hoja.Cells(fila, columna).EntireColumn.autofit()
                        columna = columna + 1

                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 12
                        x1hoja.Cells(fila, columna).Formula = "MS (0-1)"
                        columna = columna + 1

                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 12
                        x1hoja.Cells(fila, columna).Formula = "Kg MS Aplicados"
                        x1hoja.Cells(fila, columna).Style.WrapText = True
                        fila = fila + 1
                        columna = columna - 2

                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        x1hoja.Cells(fila, columna).Font.Size = 12
                        x1hoja.Cells(fila, columna).Formula = KgApli
                        columna = columna + 1

                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        x1hoja.Cells(fila, columna).Font.Size = 12
                        Dim MScalculo As Double = Ms / 100
                        MScalculo = Format(MScalculo, "0.000")
                        x1hoja.Cells(fila, columna).Formula = MScalculo
                        columna = columna + 1

                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        x1hoja.Cells(fila, columna).Font.Size = 12
                        Dim kgMasaApli As Integer = MScalculo * KgApli
                        x1hoja.Cells(fila, columna).Formula = kgMasaApli
                        columna = columna + 1
                        fila = fila - 2

                        'x1hoja.Range("D" & fila, "F" & fila).Merge()
                        'x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        'x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        'x1hoja.Cells(fila, columna).WrapText = True
                        'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        'x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        'x1hoja.Cells(fila, columna).Font.Size = 12
                        'x1hoja.Cells(fila, columna).Formula = "Contenido Nutrientes"
                        'x1hoja.Cells(fila, columna).Style.WrapText = True
                        'x1hoja.Cells(fila, columna).EntireColumn.autofit()

                        fila = fila + 1
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        x1hoja.Cells(fila, columna).Font.Size = 12
                        x1hoja.Cells(fila, columna).Formula = "Nitrògeno %"
                        columna = columna + 1

                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        x1hoja.Cells(fila, columna).Font.Size = 12
                        x1hoja.Cells(fila, columna).Formula = "Fòsforo (mg / kg)"
                        columna = columna + 1

                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        x1hoja.Cells(fila, columna).Font.Size = 12
                        x1hoja.Cells(fila, columna).Formula = "Potasio (mg / kg)"
                        fila = fila + 1
                        columna = columna - 2

                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        x1hoja.Cells(fila, columna).Font.Size = 12
                        x1hoja.Cells(fila, columna).Formula = Nitrogeno
                        columna = columna + 1

                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        x1hoja.Cells(fila, columna).Font.Size = 12
                        x1hoja.Cells(fila, columna).Formula = Fosforo
                        columna = columna + 1

                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        x1hoja.Cells(fila, columna).Font.Size = 12
                        x1hoja.Cells(fila, columna).Formula = Potasio

                        columna = 2
                        fila = fila + 2

                        x1hoja.Range("B" & fila, "J" & fila).Merge()
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).Formula = "Cada 10 Toneladas de fertilizante orgánico aplicado, equivale a:"
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 12
                        columna = 1
                        fila = fila + 2

                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        x1hoja.Cells(fila, columna).Font.Size = 12
                        x1hoja.Cells(fila, columna).Formula = "P2O5 Aplicados(Kg / ha)"

                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        x1hoja.Cells(fila, columna).Font.Size = 12
                        Dim p205Aplicados As Double = ((((Fosforo / 1000) * 2.29) * kgMasaApli) / 1000)
                        p205Aplicados = Format(p205Aplicados, "0.00")
                        x1hoja.Cells(fila, columna).Formula = p205Aplicados

                        columna = columna - 1
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        x1hoja.Cells(fila, columna).Font.Size = 12
                        x1hoja.Cells(fila, columna).Formula = "Equiv.Fert 7 - 40 - 0(Kg / ha)"

                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        x1hoja.Cells(fila, columna).Font.Size = 12
                        Dim EquicFert7 As Double = (p205Aplicados * 2.5)
                        EquicFert7 = Format(EquicFert7, "0.00")
                        x1hoja.Cells(fila, columna).Formula = EquicFert7

                        columna = columna + 2
                        fila = fila - 1
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        x1hoja.Cells(fila, columna).Font.Size = 12
                        x1hoja.Cells(fila, columna).Formula = "K2O Aplicados (Kg/ha)"

                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        x1hoja.Cells(fila, columna).Font.Size = 12
                        Dim K20Apli As Double = ((((Potasio / 1000) * 1.2046) * kgMasaApli) / 1000)
                        K20Apli = Format(K20Apli, "0.00")
                        x1hoja.Cells(fila, columna).Formula = K20Apli

                        columna = columna - 1
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        x1hoja.Cells(fila, columna).Font.Size = 12
                        x1hoja.Cells(fila, columna).Formula = "Equiv. Fert KCl (Kg/ha)"

                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        x1hoja.Cells(fila, columna).Font.Size = 12
                        Dim EquivFertKC1 As Double = (100 / 60) * K20Apli
                        EquivFertKC1 = Format(EquivFertKC1, "0.00")
                        x1hoja.Cells(fila, columna).Formula = EquivFertKC1

                        columna = columna + 2
                        fila = fila - 1
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        x1hoja.Cells(fila, columna).Font.Size = 12
                        x1hoja.Cells(fila, columna).Formula = "N Total Aplic."

                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        x1hoja.Cells(fila, columna).Font.Size = 12
                        Dim NTotalAplic As Double = (kgMasaApli * (Nitrogeno / 100))
                        NTotalAplic = Format(NTotalAplic, "0.00")
                        x1hoja.Cells(fila, columna).Formula = NTotalAplic

                        columna = columna - 1
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        x1hoja.Cells(fila, columna).Font.Size = 12
                        x1hoja.Cells(fila, columna).Formula = "Equiv. Fert Urea (Kg/ha)"

                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        x1hoja.Cells(fila, columna).Font.Size = 12
                        Dim EquivFertUrea As Double = (100 / 46) * NTotalAplic
                        EquivFertUrea = Format(EquivFertUrea, "0.00")
                        x1hoja.Cells(fila, columna).Formula = EquivFertUrea

                        fila = fila + 2
                        columna = 1

                    End If
                    columna = 2
                    fila = fila + 1
                    Nitrogeno = 0
                    Fosforo = 0
                    Ms = 0
                    Potasio = 0

                    'MsPrecente = False
                    'PotasioPrecente = False
                    'NitrogenoPrecente = False
                    'FosforoPrecente = False
                Next


                x1hoja.Range("A" & fila, "E" & fila).Merge()
                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).WrapText = True
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Size = 12
                x1hoja.Cells(fila, columna).Formula = "Por consultas, comunicarse con el Laboratorio Colaveco"
                columna = 1
                fila = fila + 1

                x1hoja.Range("A" & fila, "E" & fila).Merge()
                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).WrapText = True
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Size = 12
                x1hoja.Cells(fila, columna).Formula = "www.colaveco.com.uy"

                '*** IMPORTE ********************************************************
                Dim f As New dFacturacion
                Dim listast As New ArrayList
                listast = f.listarxficha(nroficha)
                Dim total As Double = 0
                Dim lp2 As New dListaPrecios
                lp2.ID = 86
                lp2 = lp2.buscar
                If Not lp2 Is Nothing Then
                    total = total + lp2.PRECIO1
                End If
                For Each f In listast
                    total = total + f.SUBTOTAL
                Next
                f = Nothing
                lp2 = Nothing
                fila = fila - 2
            End If
        End If

        x1hoja.Cells().Range("A11:H11").Columns.AutoFit()

        x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas
        x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas
        columna = 1
        fila = fila + 2
        x1libro.Worksheets(1).cells(fila, columna).select()
        x1libro.ActiveSheet.pictures.Insert("c:\Debug\AVISOS_informes_SUELOS Y PASTURAS.png").select()

        'x1hoja.Shapes.AddPicture("c:\Debug\AVISOS_informes_EFLUENTES.png", _
        'Microsoft.Office.Core.MsoTriState.msoFalse, _
        'Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 160, 70)

        '***********************************************************


        'PROTEGE LA HOJA DE EXCEL
        If MsPrecente And compost Then
            x1hoja.Protect(Password:="1582782", DrawingObjects:=True, _
           Contents:=True, Scenarios:=True)
            'GUARDA EL ARCHIVO DE EXCEL
            x1hoja.SaveAs("\\ROBOT\PREINFORMES\SUELOS\anexo" & nroficha & ".xls")
            x1app.Visible = True
            Module1.isAnexo = True
        End If


        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
        MsPrecente = False
        PotasioPrecente = False
        NitrogenoPrecente = False
        FosforoPrecente = False
    End Sub
    Private Sub informe_suelos()
        Dim ficha = TextFicha.Text.Trim
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
        x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(1)
        x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(1)
        x1hoja.PageSetup.Orientation = (Excel.XlPageOrientation.xlLandscape)

        'ARCHIVO ANEXO *********************************************************************************
        Dim Arch2 As String
        Arch2 = "\\ROBOT\PREINFORMES\SUELOS\cf" & nroficha & ".xls"
        Dim x1app2 As Microsoft.Office.Interop.Excel.Application
        Dim x1libro2 As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja2 As Microsoft.Office.Interop.Excel.Worksheet
        Dim existe_archivo_x As Integer = 0
        x1app2 = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        If File.Exists("\\ROBOT\PREINFORMES\SUELOS\cf" & nroficha & ".xls") Then
            existe_archivo_x = 1
        End If
        If existe_archivo_x = 1 Then
            x1libro2 = CType(x1app2.Workbooks.Open(Arch2), Microsoft.Office.Interop.Excel.Workbook)
            x1hoja2 = CType(x1libro2.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
        End If

        Dim sa As New dSolicitudAnalisis
        Dim cli As New dCliente
        Dim na As New dNuevoAnalisis
        Dim na_ As New dNuevoAnalisis
        Dim na3 As New dNuevoAnalisis
        Dim met As New dMetodos
        Dim lista As New ArrayList
        Dim lista_ As New ArrayList
        Dim lista2 As New ArrayList
        Dim lista3 As New ArrayList
        Dim acreditado As Integer = 0
        Dim acreditado2 As Integer = 0
        Dim xanalisis As Integer = 0
        Dim vec(xanalisis) As Integer
        Dim informefinal As Integer = 0
        Dim nombre_operador As String = "José L. García"
        Dim nombre_tecnico As String = "Ing. Agr. Victor González"
        Dim sin_asterisco As Integer = 1

        Dim Ms As Double = 0
        Dim Potasio As Double = 0
        Dim Nitrogeno As Double = 0
        Dim Fosforo As Double = 0
        Dim MsCantidad As Integer = 0
        Dim PotasioCantidad As Integer = 0
        Dim NitrogenoCantidad As Integer = 0
        Dim FosforoCantidad As Integer = 0
        Dim MsPrecente As Boolean = False
        Dim PotasioPrecente As Boolean = False
        Dim NitrogenoPrecente As Boolean = False
        Dim FosforoPrecente As Boolean = False

        '*****************************
        nroficha = TextFicha.Text.Trim
        sa.ID = nroficha
        sa = sa.buscar
        lista = na.listarporfichamuestra(nroficha)
        lista3 = na3.listarporficha3(nroficha)
        lista_ = na_.listarporficha3(nroficha)
        '**********************************************
        If Not lista3 Is Nothing Then
            xanalisis = lista3.Count - 1
            ReDim vec(xanalisis)
            Dim i As Integer = 0
            For Each na3 In lista3
                vec(i) = na3.ANALISIS
                i = i + 1
            Next
        End If
        '***********************************************
        If Not lista_ Is Nothing Then
            For Each na_ In lista_
                Dim lp_ As New dListaPrecios
                lp_.ID = na_.ANALISIS
                lp_ = lp_.buscar
                If Not lp_ Is Nothing Then
                    If lp_.ACREDITADO = 1 Then
                        sin_asterisco = 0
                    End If
                End If
            Next
        End If
        '***********************************************
        Dim fila As Integer
        Dim columna As Integer
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                fila = 1
                columna = 1
                'Poner Titulos
                columna = 2
                x1hoja.Cells(3, 1).columnwidth = 20
                x1hoja.Cells(3, 2).columnwidth = 7
                x1hoja.Cells(3, 3).columnwidth = 7
                x1hoja.Cells(3, 4).columnwidth = 7
                x1hoja.Cells(3, 5).columnwidth = 7
                x1hoja.Cells(3, 6).columnwidth = 7
                x1hoja.Cells(3, 7).columnwidth = 7
                x1hoja.Cells(3, 8).columnwidth = 7
                x1hoja.Cells(3, 9).columnwidth = 7
                x1hoja.Cells(3, 10).columnwidth = 7
                x1hoja.Cells(3, 11).columnwidth = 7
                x1hoja.Cells(3, 12).columnwidth = 7
                x1hoja.Cells(3, 13).columnwidth = 7
                x1hoja.Cells(3, 14).columnwidth = 7
                x1hoja.Cells(3, 15).columnwidth = 7
                x1hoja.Cells(3, 16).columnwidth = 7
                fila = fila + 4
                columna = 1
                x1hoja.Cells(fila, columna).rowheight = 3
                fila = fila + 1
                x1hoja.Range("A" & fila, "P" & fila).Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).Formula = "INFORME DE SUELOS"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 12
                fila = fila + 1
                columna = 1
                x1hoja.Cells(fila, columna).Formula = "Nº Ficha: " & sa.ID
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 11
                x1hoja.Cells(fila, columna).Formula = "Fecha entrada: " & sa.FECHAINGRESO
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                cli.ID = sa.IDPRODUCTOR
                cli = cli.buscar
                x1hoja.Cells(fila, columna).Formula = "Cliente: " & cli.NOMBRE
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 11
                Dim nnaa As New dNuevoAnalisis
                Dim fechaproceso As String = ""
                Dim listannaa As New ArrayList
                listannaa = nnaa.listarporficha2(sa.ID)
                If Not listannaa Is Nothing Then
                    For Each nnaa In listannaa
                        fechaproceso = nnaa.FECHAPROCESO
                    Next
                End If
                nnaa = Nothing
                listannaa = Nothing
                x1hoja.Cells(fila, columna).Formula = "Fecha proceso: " & fechaproceso
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                If cli.DIRECCION <> "" Or cli.DIRECCION <> "No aportado" Then
                    x1hoja.Cells(fila, columna).Formula = "Dirección: " & cli.DIRECCION
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = columna + 11
                ElseIf cli.IDLOCALIDAD <> 999 Then
                    Dim loc As New dLocalidad
                    loc.ID = cli.IDLOCALIDAD
                    loc = loc.buscar
                    If Not loc Is Nothing Then
                        x1hoja.Cells(fila, columna).Formula = loc.NOMBRE
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 9
                        columna = columna + 11
                    End If
                ElseIf cli.IDDEPARTAMENTO <> 999 Then
                    Dim dep As New dDepartamento
                    dep.ID = cli.IDDEPARTAMENTO
                    dep = dep.buscar
                    If Not dep Is Nothing Then
                        x1hoja.Cells(fila, columna).Formula = dep.NOMBRE
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 9
                        columna = columna + 11
                    End If
                ElseIf cli.CELULAR <> "" Then
                    x1hoja.Cells(fila, columna).Formula = "Celular: " & cli.CELULAR
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = columna + 11
                Else
                    x1hoja.Cells(fila, columna).Formula = "No aportado"
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = columna + 11
                End If
                Dim fecha As Date = Now()
                Dim fecha2 As String = fecha.ToString("dd/MM/yyyy")
                x1hoja.Cells(fila, columna).Formula = "Fecha informe: " & fecha2
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                Dim mm As New dMuestras
                mm.ID = sa.IDMUESTRA
                mm = mm.buscar
                If Not mm Is Nothing Then
                    x1hoja.Cells(fila, columna).Formula = "Material recibido: " & mm.NOMBRE
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = columna + 2
                Else
                    x1hoja.Cells(fila, columna).Formula = "Material recibido: "
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    fila = fila + 1
                    columna = columna + 3
                End If
                x1hoja.Cells(fila, columna).Formula = "Total de muestras: " & sa.NMUESTRAS
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = 1
                fila = fila + 1
                x1hoja.Range("A" & fila, "P" & fila).Merge()
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).rowheight = 1
                fila = fila + 1
                x1hoja.Cells(fila, columna).rowheight = 3
                fila = fila + 1
                columna = 1
                Dim cuenta As Integer = 1
                Dim detallemuestras As String = ""
                Dim idoperador As Integer = 0
                Dim operador As String = ""
                Dim iu As New dUsuario
                iu.ID = idoperador
                iu = iu.buscar
                If Not iu Is Nothing Then
                    operador = iu.NOMBRE
                End If
                x1hoja.Cells(fila, columna).Formula = "Id."
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeTop).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeLeft).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeRight).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).WrapText = True
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Muestra"
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeBottom).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeLeft).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeRight).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).WrapText = True
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                fila = fila - 1
                Dim listademetodos As String = ""
                Dim listadeabreviaturas As String = ""
                For Each na In lista3
                    Dim u As New dUsuario
                    u.ID = na.OPERADOR
                    u = u.buscar
                    If Not u Is Nothing Then
                        nombre_operador = u.NOMBRE
                    End If
                    Dim lp As New dListaPrecios
                    lp.ID = na.ANALISIS
                    lp = lp.buscar
                    Dim lm As New dListaMetodos
                    lm.ID = na.METODO
                    lm = lm.buscar
                    If Not lm Is Nothing Then
                        listademetodos = listademetodos & lp.DESCTECNICA & " - " & lm.METODO & " / "
                    End If
                    If lp.ABREVIATURA <> lp.DESCTECNICA Then
                        listadeabreviaturas = listadeabreviaturas & lp.ABREVIATURA & " - " & lp.DESCTECNICA & " / "
                    End If
                    Dim l As New dListaPrecios
                    l.ID = na.ANALISIS
                    l = l.buscar
                    If Not l Is Nothing Then
                        If l.ACREDITADO = 1 Then
                            x1hoja.Cells(fila, columna).Formula = l.ABREVIATURA
                            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                            x1hoja.Cells(fila, columna).WrapText = True
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            acreditado = 1
                        Else
                            If sin_asterisco = 0 Then
                                x1hoja.Cells(fila, columna).Formula = "* " & l.ABREVIATURA
                                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                                x1hoja.Cells(fila, columna).Font.Size = 8
                            Else
                                x1hoja.Cells(fila, columna).Formula = l.ABREVIATURA
                                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                                x1hoja.Cells(fila, columna).Font.Size = 8
                            End If
                        End If
                    End If
                    l = Nothing
                    Dim au As New dAnalisisUnidad
                    au.ID = na.UNIDAD
                    au = au.buscar
                    If Not au Is Nothing Then
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).Formula = au.UNIDAD
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        x1hoja.Cells(fila, columna).Font.Size = 6
                        fila = fila - 1
                        columna = columna + 1
                    Else
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).Formula = ""
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        x1hoja.Cells(fila, columna).Font.Size = 6
                        fila = fila - 1
                        columna = columna + 1
                    End If
                    lp = Nothing
                    lm = Nothing
                    u = Nothing
                Next
                columna = 1
                fila = fila + 2
                For Each na In lista
                    x1hoja.Cells(fila, columna).Formula = na.MUESTRA
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    Dim x As Integer = 0
                    Dim n As Integer = 0
                    x = vec.Length
                    For n = 1 To x
                        x1hoja.Cells(fila, columna).Formula = "-"
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    Next
                    columna = columna - x
                    Dim na2 As New dNuevoAnalisis
                    lista2 = na2.listarpormuestra(nroficha, na.MUESTRA)
                    For Each na2 In lista2
                        Dim ret As Integer = Array.IndexOf(vec, na2.ANALISIS)
                        columna = columna + ret
                        x1hoja.Cells(fila, columna).Formula = na2.RESULTADO & " " & na2.RESULTADO2
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        Dim a As New dAcreditacion
                        a.ANALISIS = na2.ANALISIS
                        a = a.buscar
                        If Not a Is Nothing Then
                            Dim desde As Double = a.DESDE
                            Dim hasta As Double = a.HASTA
                            If Val(na2.RESULTADO2) < desde Or Val(na2.RESULTADO2) > hasta Then
                                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                            Else
                                acreditado2 = 1
                            End If
                        End If
                        columna = columna - ret

                        '%MS
                        If na2.ANALISIS = 473 Or na2.ANALISIS = 479 Or na2.ANALISIS = 474 Then
                            If IsNumeric(na2.RESULTADO) Then
                                If na2.RESULTADO <> -1 Then
                                    Ms += na2.RESULTADO
                                    MsCantidad += 1
                                    MsPrecente = True
                                End If
                            ElseIf IsNumeric(na2.RESULTADO2) Then
                                If na2.RESULTADO2 <> -1 Then
                                    Ms += na2.RESULTADO2
                                    MsCantidad += 1
                                    MsPrecente = True
                                End If
                            End If
                        End If

                        'Nitrogeno
                        If na2.ANALISIS = 138 Or na2.ANALISIS = 374 Then
                            If IsNumeric(na2.RESULTADO) Then
                                If na2.RESULTADO <> -1 Then
                                    Nitrogeno += na2.RESULTADO
                                    NitrogenoCantidad += 1
                                    NitrogenoPrecente = True
                                End If
                            ElseIf IsNumeric(na2.RESULTADO2) Then
                                If na2.RESULTADO2 <> -1 Then
                                    Nitrogeno += na2.RESULTADO2
                                    NitrogenoCantidad += 1
                                    NitrogenoPrecente = True
                                End If
                            End If
                        End If

                        'Fosforo
                        If na2.ANALISIS = 226 Or na2.ANALISIS = 375 Then
                            If IsNumeric(na2.RESULTADO) Then
                                If na2.RESULTADO <> -1 Then
                                    Fosforo += na2.RESULTADO
                                    FosforoCantidad += 1
                                    FosforoPrecente = True
                                End If
                            ElseIf IsNumeric(na2.RESULTADO2) Then
                                If na2.RESULTADO2 <> -1 Then
                                    Fosforo += na2.RESULTADO2
                                    FosforoCantidad += 1
                                    FosforoPrecente = True
                                End If
                            End If
                        End If

                        'Potasio
                        If na2.ANALISIS = 208 Or na2.ANALISIS = 376 Then
                            If IsNumeric(na2.RESULTADO) Then
                                If na2.RESULTADO <> -1 Then
                                    Potasio += na2.RESULTADO
                                    PotasioCantidad += 1
                                    PotasioPrecente = True
                                End If
                            ElseIf IsNumeric(na2.RESULTADO2) Then
                                If na2.RESULTADO2 <> -1 Then
                                    Potasio += na2.RESULTADO2
                                    PotasioCantidad += 1
                                    PotasioPrecente = True
                                End If
                            End If
                        End If

                    Next
                    columna = 1
                    fila = fila + 1
                Next

                '//Comienzo de Contenido de Nutrientes

                Ms = Ms / MsCantidad
                Potasio = Potasio / PotasioCantidad
                Nitrogeno = Nitrogeno / NitrogenoCantidad
                Fosforo = Fosforo / FosforoCantidad

                'If MsPrecente = True And PotasioPrecente = True And FosforoPrecente = True And NitrogenoPrecente = True Then
                '    fila = fila + 1
                '    x1hoja.Range("A" & fila, "B" & fila).Merge()
                '    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                '    x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                '    x1hoja.Cells(fila, columna).WrapText = True
                '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                '    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                '    x1hoja.Cells(fila, columna).Font.Size = 8
                '    x1hoja.Cells(fila, columna).Formula = "Compost"

                '    fila = fila + 1
                '    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                '    x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                '    x1hoja.Cells(fila, columna).WrapText = True
                '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                '    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                '    x1hoja.Cells(fila, columna).Font.Size = 6
                '    x1hoja.Cells(fila, columna).Formula = "Kg Aplicados"
                '    columna = columna + 1

                '    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                '    x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                '    x1hoja.Cells(fila, columna).WrapText = True
                '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                '    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                '    x1hoja.Cells(fila, columna).Font.Size = 6
                '    x1hoja.Cells(fila, columna).Formula = "Kg MS Aplicados"
                '    fila = fila + 1
                '    columna = columna - 1

                '    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                '    x1hoja.Cells(fila, columna).WrapText = True
                '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                '    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                '    x1hoja.Cells(fila, columna).Font.Size = 6
                '    x1hoja.Cells(fila, columna).Formula = "10000"
                '    columna = columna + 1

                '    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                '    x1hoja.Cells(fila, columna).WrapText = True
                '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                '    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                '    x1hoja.Cells(fila, columna).Font.Size = 6
                '    Dim kgMasaApli As Integer = Ms * 10000
                '    x1hoja.Cells(fila, columna).Formula = kgMasaApli
                '    columna = columna - 1

                '    fila = fila + 2
                '    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                '    x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                '    x1hoja.Cells(fila, columna).WrapText = True
                '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                '    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                '    x1hoja.Cells(fila, columna).Font.Size = 8
                '    x1hoja.Cells(fila, columna).Formula = "P2O5 Aplicados(Kg / ha)"

                '    columna = columna + 1
                '    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                '    x1hoja.Cells(fila, columna).WrapText = True
                '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                '    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                '    x1hoja.Cells(fila, columna).Font.Size = 8
                '    Dim p205Aplicados As Double = ((((Fosforo / 1000) * 2.29) * kgMasaApli) / 1000)
                '    x1hoja.Cells(fila, columna).Formula = p205Aplicados

                '    columna = columna - 1
                '    fila = fila + 1
                '    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                '    x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                '    x1hoja.Cells(fila, columna).WrapText = True
                '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                '    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                '    x1hoja.Cells(fila, columna).Font.Size = 8
                '    x1hoja.Cells(fila, columna).Formula = "Equiv.Fert 7 - 40 - 0(Kg / ha)"

                '    columna = columna + 1
                '    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                '    x1hoja.Cells(fila, columna).WrapText = True
                '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                '    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                '    x1hoja.Cells(fila, columna).Font.Size = 8
                '    Dim EquicFert7 As Double = (Ms * 2.5)
                '    x1hoja.Cells(fila, columna).Formula = EquicFert7

                '    columna = columna + 2
                '    fila = fila - 1
                '    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                '    x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                '    x1hoja.Cells(fila, columna).WrapText = True
                '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                '    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                '    x1hoja.Cells(fila, columna).Font.Size = 8
                '    x1hoja.Cells(fila, columna).Formula = "K2O Aplicados (Kg/ha)"

                '    columna = columna + 1
                '    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                '    x1hoja.Cells(fila, columna).WrapText = True
                '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                '    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                '    x1hoja.Cells(fila, columna).Font.Size = 8
                '    Dim K20Apli As Double = ((((Potasio / 1000) * 1.2046) * kgMasaApli) / 1000)
                '    x1hoja.Cells(fila, columna).Formula = K20Apli

                '    columna = columna - 1
                '    fila = fila + 1
                '    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                '    x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                '    x1hoja.Cells(fila, columna).WrapText = True
                '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                '    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                '    x1hoja.Cells(fila, columna).Font.Size = 8
                '    x1hoja.Cells(fila, columna).Formula = "Equiv. Fert KCl (Kg/ha)"

                '    columna = columna + 1
                '    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                '    x1hoja.Cells(fila, columna).WrapText = True
                '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                '    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                '    x1hoja.Cells(fila, columna).Font.Size = 8
                '    Dim EquivFertKC1 As Double = (100 / 60) * Potasio
                '    x1hoja.Cells(fila, columna).Formula = EquivFertKC1

                '    columna = columna + 2
                '    fila = fila - 1
                '    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                '    x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                '    x1hoja.Cells(fila, columna).WrapText = True
                '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                '    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                '    x1hoja.Cells(fila, columna).Font.Size = 8
                '    x1hoja.Cells(fila, columna).Formula = "N Total Aplic."

                '    columna = columna + 1
                '    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                '    x1hoja.Cells(fila, columna).WrapText = True
                '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                '    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                '    x1hoja.Cells(fila, columna).Font.Size = 8
                '    Dim NTotalAplic As Double = (kgMasaApli * (Nitrogeno / 100))
                '    x1hoja.Cells(fila, columna).Formula = NTotalAplic

                '    columna = columna - 1
                '    fila = fila + 1
                '    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                '    x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                '    x1hoja.Cells(fila, columna).WrapText = True
                '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                '    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                '    x1hoja.Cells(fila, columna).Font.Size = 8
                '    x1hoja.Cells(fila, columna).Formula = "Equiv. Fert Urea (Kg/ha)"

                '    columna = columna + 1
                '    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                '    x1hoja.Cells(fila, columna).WrapText = True
                '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                '    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                '    x1hoja.Cells(fila, columna).Font.Size = 8
                '    Dim EquivFertUrea As Double = (100 / 46) * NTotalAplic
                '    x1hoja.Cells(fila, columna).Formula = EquivFertUrea

                '    fila = fila + 2
                '    columna = 1

                'End If

                '//Fin de Contenido de Nutrientes

                x1hoja.Cells(fila, columna).rowheight = 3
                fila = fila + 1
                x1hoja.Range("A" & fila, "P" & fila).Merge()
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).rowheight = 1
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Todos los resultados son expresados en base seca."
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 8
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Abreviaturas"
                x1hoja.Cells(fila, columna).Font.Bold = True
                fila = fila + 1
                x1hoja.Cells(fila, columna).rowheight = 30
                x1hoja.Cells(fila, columna).Formula = listadeabreviaturas
                x1hoja.Range("A" & fila, "O" & fila).WrapText = True
                x1hoja.Range("A" & fila, "O" & fila).Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Size = 7
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Métodos"
                x1hoja.Cells(fila, columna).Font.Bold = True
                fila = fila + 1
                x1hoja.Cells(fila, columna).rowheight = 30
                x1hoja.Cells(fila, columna).Formula = listademetodos
                x1hoja.Range("A" & fila, "O" & fila).WrapText = True
                x1hoja.Range("A" & fila, "O" & fila).Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Size = 7
                fila = fila + 1
                '*** OBSERVACIONES **************************************************
                If sa.OBSERVACIONES <> "" Then
                    x1hoja.Cells(fila, columna).rowheight = 25
                    x1hoja.Cells(fila, columna).Formula = "Observaciones: " & sa.OBSERVACIONES
                    x1hoja.Range("A" & fila, "P" & fila).WrapText = True
                    x1hoja.Range("A" & fila, "p" & fila).Merge()
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    fila = fila + 1
                End If
                '********************************************************************
                '*** DETALLE DEL MUESTREO **************************************************
                If sa.MUESTREO = 1 Then
                    Dim dm As New dDetalleMuestreo
                    dm.FICHA = sa.ID
                    dm = dm.buscar
                    If Not dm Is Nothing Then
                        x1hoja.Cells(fila, columna).rowheight = 45
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Formula = "Fecha de muestreo: " & dm.FECHA & vbCrLf _
            & dm.OBSERVACIONES
                        x1hoja.Range("A" & fila, "P" & fila).WrapText = True
                        x1hoja.Range("A" & fila, "p" & fila).Merge()
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        fila = fila + 1
                    End If
                Else
                    x1hoja.Cells(fila, columna).rowheight = 13
                    x1hoja.Cells(fila, columna).Formula = "Muestreo realizado por el cliente."
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Range("A" & fila, "P" & fila).WrapText = True
                    x1hoja.Range("A" & fila, "p" & fila).Merge()
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    fila = fila + 1
                End If
                '********************************************************************
                If sin_asterisco = 0 Then
                    x1hoja.Cells(fila, columna).Formula = "(*)Ensayo no acreditado ISO 17025 O.U.A."
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    columna = columna + 3
                Else
                    x1hoja.Cells(fila, columna).Formula = ""
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    columna = columna + 3
                End If
                x1hoja.Cells(fila, columna).Formula = "Referencias:"
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = ""
                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).Font.Bold = False
                columna = columna + 1
                x1hoja.Cells(fila, columna).Formula = "Valor fuera de rango de acreditación"
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 7
                fila = fila + 1
                columna = columna - 1
                x1hoja.Cells(fila, columna).Formula = "-"
                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                'x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Bold = False
                columna = columna + 1
                x1hoja.Cells(fila, columna).Formula = "Análisis no requerido."
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 7
                columna = 1
                'CABEZAL CON O SIN LOGO OUA
                If acreditado = 1 And acreditado2 = 1 Then
                    x1hoja.Shapes.AddPicture("c:\Debug\encabezado_con_oua2.png", _
             Microsoft.Office.Core.MsoTriState.msoFalse, _
             Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 700, 50)
                Else
                    x1hoja.Shapes.AddPicture("c:\Debug\encabezado_sin_oua2.png", _
             Microsoft.Office.Core.MsoTriState.msoFalse, _
             Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 700, 50)
                End If
                '*** IMPORTE ********************************************************
                Dim f As New dFacturacion
                Dim listast As New ArrayList
                listast = f.listarxficha(nroficha)
                Dim total As Double = 0
                Dim lp2 As New dListaPrecios
                lp2.ID = 86
                lp2 = lp2.buscar
                If Not lp2 Is Nothing Then
                    total = total + lp2.PRECIO1
                End If
                For Each f In listast
                    total = total + f.SUBTOTAL
                Next
                f = Nothing
                lp2 = Nothing
                fila = fila - 2
                columna = columna + 11
                x1hoja.Cells(fila, columna).Formula = "Operador: " & nombre_operador
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                columna = columna + 11
                x1hoja.Cells(fila, columna).Formula = "Técnico resp: " & nombre_tecnico
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = 1
                fila = fila + 3
                'ANALISIS TERCERIZADOS***************************************************
                Dim at As New dAnalisisTercerizado
                Dim listaat As New ArrayList
                listaat = at.listarporficha4(nroficha)
                If Not listaat Is Nothing Then
                    x1hoja.Cells(fila, columna).Formula = "ANÁLISIS TERCERIZADOS"
                    x1hoja.Range("A" & fila, "M" & fila).Merge()
                    x1hoja.Cells(fila, columna).Interior.Color = RGB(215, 219, 221)
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).Formula = "Muestra"
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "Análisis"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 3
                    x1hoja.Cells(fila, columna).Formula = "Resultado"
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "Unidad"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "Método"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 4
                    x1hoja.Cells(fila, columna).Formula = "Laboratorio"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = 1
                    fila = fila + 1
                    For Each at In listaat
                        x1hoja.Cells(fila, columna).Formula = at.MUESTRA
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                        Dim att As New dAnalisisTercerizadoTipo
                        att.ID = at.ANALISIS
                        att = att.buscar
                        If Not att Is Nothing Then
                            x1hoja.Cells(fila, columna).Formula = att.NOMBRE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 3
                        Else
                            x1hoja.Cells(fila, columna).Formula = ""
                            x1hoja.Cells(fila, columna).WrapText = True
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 3
                        End If
                        x1hoja.Cells(fila, columna).Formula = at.RESULTADO
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = at.UNIDAD
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = at.METODO
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 4
                        Dim ol As New dOtrosLaboratorios
                        ol.ID = at.LABORATORIO
                        ol = ol.buscar
                        If Not ol Is Nothing Then
                            x1hoja.Cells(fila, columna).Formula = ol.NOMBRE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = 1
                            fila = fila + 1
                        Else
                            x1hoja.Cells(fila, columna).Formula = ""
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = 1
                            fila = fila + 1
                        End If
                    Next
                    fila = fila + 1
                End If
                '*** PONER FIRMA ********************************************************
                x1libro.Worksheets(1).cells(fila, columna).select()
                x1libro.ActiveSheet.pictures.Insert("c:\Debug\cecilia.jpg").select()
                x1libro.Worksheets(1).cells(2, 1).select()
                fila = fila + 6
                columna = 1
                '*** PIE DE PAGINA ******************************************************
                x1hoja.Cells(fila, columna).rowheight = 25
                x1hoja.Cells(fila, columna).Formula = "Este informe no podrá ser reproducido total o parcialmente sin la autorización escrita de COLAVECO. Los resultados consignados se refieren exclusivamente a la muestra recibida." & vbCrLf _
                    & "COLAVECO declina toda responsabilidad por el uso indebido o incorrecto que se hiciere a este informe, asi como el plan y procedimientos de muestreo aplicados por el cliente. Dra. Cecilia Abelenda (Directora Técnica)"
                x1hoja.Range("A" & fila, "O" & fila).WrapText = True
                x1hoja.Range("A" & fila, "O" & fila).Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Size = 6
                '************************************************************************
                fila = fila + 1
                x1hoja.Range("A" & fila, "P" & fila).Merge()
                x1hoja.Cells(fila, columna).Interior.Color = RGB(215, 219, 221)
                x1hoja.Cells(fila, columna).rowheight = 8
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Formula = "Fin del informe."
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 7
            End If
        End If
        'Insert tabla preinformes**************************
        Dim pi As New dPreinformes
        Dim fechaactual As Date = Now()
        Dim _fecha As String
        _fecha = Format(fechaactual, "yyyy-MM-dd")
        pi.FICHA = nroficha
        pi = pi.buscar
        If Not pi Is Nothing Then
        Else
            Dim pi2 As New dPreinformes
            pi2.FICHA = nroficha
            pi2.TIPO = 14
            pi2.CREADO = 1
            pi2.FECHA = _fecha
            pi2.guardar()
            pi2 = Nothing
        End If
        pi = Nothing
        '***********************************************************
        x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas
        'PROTEGE LA HOJA DE EXCEL
        x1hoja.Protect(Password:="1582782", DrawingObjects:=True, _
        Contents:=True, Scenarios:=True)
        'GUARDA EL ARCHIVO DE EXCEL
        If MsPrecente = True And PotasioPrecente = True And FosforoPrecente = True And NitrogenoPrecente = True Then
            x1hoja.SaveAs("\\ROBOT\PREINFORMES\SUELOS\" & nroficha & ".xls")
        Else
            x1hoja.SaveAs("\\ROBOT\PREINFORMES\SUELOS\" & nroficha & ".xls")
        End If
        x1app.Visible = True
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub informe_semen()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
        x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(1)
        x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(1)
        x1hoja.PageSetup.Orientation = (Excel.XlPageOrientation.xlLandscape)
        Dim sa As New dSolicitudAnalisis
        Dim cli As New dCliente
        Dim na As New dNuevoAnalisis
        Dim na_ As New dNuevoAnalisis
        Dim na3 As New dNuevoAnalisis
        Dim met As New dMetodos
        Dim lista As New ArrayList
        Dim lista_ As New ArrayList
        Dim lista2 As New ArrayList
        Dim lista3 As New ArrayList
        Dim acreditado As Integer = 0
        Dim acreditado2 As Integer = 0
        Dim xanalisis As Integer = 0
        Dim vec(xanalisis) As Integer
        Dim informefinal As Integer = 0
        Dim nombre_operador As String = ""
        Dim sin_asterisco As Integer = 1
        '*****************************
        nroficha = TextFicha.Text.Trim
        sa.ID = nroficha
        sa = sa.buscar
        lista = na.listarporfichamuestra(nroficha)
        lista3 = na3.listarporficha3(nroficha)
        lista_ = na_.listarporficha3(nroficha)
        '**********************************************
        If Not lista3 Is Nothing Then
            xanalisis = lista3.Count - 1
            ReDim vec(xanalisis)
            Dim i As Integer = 0
            For Each na3 In lista3
                vec(i) = na3.ANALISIS
                i = i + 1
            Next
        End If
        '***********************************************
        If Not lista_ Is Nothing Then
            For Each na_ In lista_
                Dim lp_ As New dListaPrecios
                lp_.ID = na_.ANALISIS
                lp_ = lp_.buscar
                If Not lp_ Is Nothing Then
                    If lp_.ACREDITADO = 1 Then
                        sin_asterisco = 0
                    End If
                End If
            Next
        End If
        '***********************************************
        Dim fila As Integer
        Dim columna As Integer
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                fila = 1
                columna = 1
                'Poner Titulos
                columna = 2
                x1hoja.Cells(3, 1).columnwidth = 20
                x1hoja.Cells(3, 2).columnwidth = 14 '7
                x1hoja.Cells(3, 3).columnwidth = 14 '7
                x1hoja.Cells(3, 4).columnwidth = 14 '7
                x1hoja.Cells(3, 5).columnwidth = 14 '7
                x1hoja.Cells(3, 6).columnwidth = 14 '7
                x1hoja.Cells(3, 7).columnwidth = 14
                x1hoja.Cells(3, 8).columnwidth = 7
                x1hoja.Cells(3, 9).columnwidth = 7
                x1hoja.Cells(3, 10).columnwidth = 7
                fila = fila + 4
                columna = 1
                x1hoja.Cells(fila, columna).rowheight = 3
                fila = fila + 1
                x1hoja.Range("A" & fila, "J" & fila).Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).Formula = "INFORME DE ANÁLISIS DE SEMEN"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 12
                fila = fila + 1
                columna = 1
                x1hoja.Cells(fila, columna).Formula = "Nº Ficha: " & sa.ID
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 7
                x1hoja.Cells(fila, columna).Formula = "Fecha entrada: " & sa.FECHAINGRESO
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                cli.ID = sa.IDPRODUCTOR
                cli = cli.buscar
                x1hoja.Cells(fila, columna).Formula = "Cliente: " & cli.NOMBRE
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 7
                Dim nnaa As New dNuevoAnalisis
                Dim fechaproceso As String = ""
                Dim listannaa As New ArrayList
                listannaa = nnaa.listarporficha2(sa.ID)
                If Not listannaa Is Nothing Then
                    For Each nnaa In listannaa
                        fechaproceso = nnaa.FECHAPROCESO
                    Next
                End If
                nnaa = Nothing
                listannaa = Nothing
                x1hoja.Cells(fila, columna).Formula = "Fecha proceso: " & fechaproceso
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                If cli.DIRECCION <> "" Or cli.DIRECCION <> "No aportado" Then
                    x1hoja.Cells(fila, columna).Formula = "Dirección: " & cli.DIRECCION
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = columna + 7
                ElseIf cli.IDLOCALIDAD <> 999 Then
                    Dim loc As New dLocalidad
                    loc.ID = cli.IDLOCALIDAD
                    loc = loc.buscar
                    If Not loc Is Nothing Then
                        x1hoja.Cells(fila, columna).Formula = loc.NOMBRE
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 9
                        columna = columna + 7
                    End If
                ElseIf cli.IDDEPARTAMENTO <> 999 Then
                    Dim dep As New dDepartamento
                    dep.ID = cli.IDDEPARTAMENTO
                    dep = dep.buscar
                    If Not dep Is Nothing Then
                        x1hoja.Cells(fila, columna).Formula = dep.NOMBRE
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 9
                        columna = columna + 7
                    End If
                ElseIf cli.CELULAR <> "" Then
                    x1hoja.Cells(fila, columna).Formula = "Celular: " & cli.CELULAR
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = columna + 7
                Else
                    x1hoja.Cells(fila, columna).Formula = "No aportado"
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = columna + 7
                End If
                Dim fecha As Date = Now()
                Dim fecha2 As String = fecha.ToString("dd/MM/yyyy")
                x1hoja.Cells(fila, columna).Formula = "Fecha informe: " & fecha2
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                Dim mm As New dMuestras
                mm.ID = sa.IDMUESTRA
                mm = mm.buscar
                If Not mm Is Nothing Then
                    x1hoja.Cells(fila, columna).Formula = "Material recibido: " & mm.NOMBRE
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = columna + 2
                Else
                    x1hoja.Cells(fila, columna).Formula = "Material recibido: "
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    fila = fila + 1
                    columna = columna + 3
                End If
                x1hoja.Cells(fila, columna).Formula = "Total de muestras: " & sa.NMUESTRAS
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = 1
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Muestreo realizado por el cliente."
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                x1hoja.Range("A" & fila, "J" & fila).Merge()
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).rowheight = 1
                fila = fila + 1
                x1hoja.Cells(fila, columna).rowheight = 3
                fila = fila + 1
                columna = 1
                Dim cuenta As Integer = 1
                Dim detallemuestras As String = ""
                Dim idoperador As Integer = 0
                Dim operador As String = ""
                Dim iu As New dUsuario
                iu.ID = idoperador
                iu = iu.buscar
                If Not iu Is Nothing Then
                    operador = iu.NOMBRE
                End If
                x1hoja.Cells(fila, columna).Formula = "Id."
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeTop).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeLeft).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeRight).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).WrapText = True
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Muestra"
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeBottom).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeLeft).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeRight).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).WrapText = True
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                fila = fila - 1
                Dim listademetodos As String = "Microscópico directo"
                Dim listadeabreviaturas As String = ""
                For Each na In lista3
                    Dim u As New dUsuario
                    u.ID = na.OPERADOR
                    u = u.buscar
                    If Not u Is Nothing Then
                        nombre_operador = u.NOMBRE
                    End If
                    Dim lp As New dListaPrecios
                    lp.ID = na.ANALISIS
                    lp = lp.buscar
                    Dim lm As New dListaMetodos
                    lm.ID = na.METODO
                    lm = lm.buscar
                    If Not lm Is Nothing Then
                        listademetodos = listademetodos & lp.DESCTECNICA & " - " & lm.METODO & " / "
                    End If
                    If lp.ABREVIATURA <> lp.DESCTECNICA Then
                        listadeabreviaturas = listadeabreviaturas & lp.ABREVIATURA & " - " & lp.DESCTECNICA & " / "
                    End If
                    Dim l As New dListaPrecios
                    l.ID = na.ANALISIS
                    l = l.buscar
                    If Not l Is Nothing Then
                        If l.ACREDITADO = 1 Then
                            x1hoja.Cells(fila, columna).Formula = l.ABREVIATURA
                            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                            x1hoja.Cells(fila, columna).WrapText = True
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            acreditado = 1
                        Else
                            If sin_asterisco = 0 Then
                                x1hoja.Cells(fila, columna).Formula = "* " & l.ABREVIATURA
                                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                                x1hoja.Cells(fila, columna).Font.Size = 8
                            Else
                                x1hoja.Cells(fila, columna).Formula = l.ABREVIATURA
                                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                                x1hoja.Cells(fila, columna).Font.Size = 8
                            End If
                        End If
                    End If
                    l = Nothing
                    Dim au As New dAnalisisUnidad
                    au.ID = na.UNIDAD
                    au = au.buscar
                    If Not au Is Nothing Then
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).Formula = au.UNIDAD
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        x1hoja.Cells(fila, columna).Font.Size = 6
                        fila = fila - 1
                        columna = columna + 1
                    Else
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).Formula = ""
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        x1hoja.Cells(fila, columna).Font.Size = 6
                        fila = fila - 1
                        columna = columna + 1
                    End If
                    lp = Nothing
                    lm = Nothing
                    u = Nothing
                Next
                columna = 1
                fila = fila + 2
                For Each na In lista
                    x1hoja.Cells(fila, columna).Formula = na.MUESTRA
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    Dim x As Integer = 0
                    Dim n As Integer = 0
                    x = vec.Length
                    For n = 1 To x
                        x1hoja.Cells(fila, columna).Formula = "-"
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    Next
                    columna = columna - x
                    Dim na2 As New dNuevoAnalisis
                    lista2 = na2.listarpormuestra(nroficha, na.MUESTRA)
                    For Each na2 In lista2
                        Dim ret As Integer = Array.IndexOf(vec, na2.ANALISIS)
                        columna = columna + ret
                        x1hoja.Cells(fila, columna).Formula = na2.RESULTADO & " " & na2.RESULTADO2
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        Dim a As New dAcreditacion
                        a.ANALISIS = na2.ANALISIS
                        a = a.buscar
                        If Not a Is Nothing Then
                            Dim desde As Double = a.DESDE
                            Dim hasta As Double = a.HASTA
                            If Val(na2.RESULTADO2) < desde Or Val(na2.RESULTADO2) > hasta Then
                                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                            Else
                                acreditado2 = 1
                            End If
                        End If
                        columna = columna - ret
                    Next
                    columna = 1
                    fila = fila + 1
                Next
                x1hoja.Cells(fila, columna).rowheight = 3
                fila = fila + 1
                x1hoja.Range("A" & fila, "J" & fila).Merge()
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).rowheight = 1
                fila = fila + 1
                If listadeabreviaturas <> "" Then
                    x1hoja.Cells(fila, columna).Formula = "Abreviaturas"
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).rowheight = 30
                    x1hoja.Cells(fila, columna).Formula = listadeabreviaturas
                    x1hoja.Range("A" & fila, "J" & fila).WrapText = True
                    x1hoja.Range("A" & fila, "J" & fila).Merge()
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                    x1hoja.Cells(fila, columna).Font.Size = 7
                    fila = fila + 1
                End If
                x1hoja.Cells(fila, columna).Formula = "Método:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                fila = fila + 1
                x1hoja.Cells(fila, columna).rowheight = 30
                x1hoja.Cells(fila, columna).Formula = listademetodos
                x1hoja.Range("A" & fila, "J" & fila).WrapText = True
                x1hoja.Range("A" & fila, "J" & fila).Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Size = 7
                fila = fila + 1
                '*** OBSERVACIONES **************************************************
                If sa.OBSERVACIONES <> "" Then
                    x1hoja.Cells(fila, columna).rowheight = 25
                    x1hoja.Cells(fila, columna).Formula = "Observaciones: " & sa.OBSERVACIONES
                    x1hoja.Range("A" & fila, "J" & fila).WrapText = True
                    x1hoja.Range("A" & fila, "J" & fila).Merge()
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    fila = fila + 1
                End If
                '********************************************************************
                fila = fila + 1
                'CABEZAL CON O SIN LOGO OUA
                x1hoja.Shapes.AddPicture("c:\Debug\encabezado_sin_oua2.png", _
             Microsoft.Office.Core.MsoTriState.msoFalse, _
             Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 690, 50)
                '*** IMPORTE ********************************************************
                'Dim f As New dFacturacion
                'Dim listast As New ArrayList
                'listast = f.listarxficha(nroficha)
                'Dim total As Double = 0
                'Dim lp2 As New dListaPrecios
                'lp2.ID = 86
                'lp2 = lp2.buscar
                'If Not lp2 Is Nothing Then
                '    total = total + lp2.PRECIO1
                'End If
                'For Each f In listast
                '    total = total + f.SUBTOTAL
                'Next
                'f = Nothing
                'lp2 = Nothing
                'fila = fila - 2
                '*** PONER FIRMA ********************************************************
                x1libro.Worksheets(1).cells(fila, columna).select()
                x1libro.ActiveSheet.pictures.Insert("c:\Debug\cecilia.jpg").select()
                x1libro.Worksheets(1).cells(2, 1).select()
                columna = columna + 6
                x1hoja.Cells(fila, columna).Formula = "Operador: " & nombre_operador
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 6
                columna = 1
                '*** PIE DE PAGINA ******************************************************
                x1hoja.Cells(fila, columna).rowheight = 25
                x1hoja.Cells(fila, columna).Formula = "Este informe no podrá ser reproducido total o parcialmente sin la autorización escrita de COLAVECO. Los resultados consignados se refieren exclusivamente a la muestra recibida." & vbCrLf _
                    & "COLAVECO declina toda responsabilidad por el uso indebido o incorrecto que se hiciere a este informe, asi como el plan y procedimientos de muestreo aplicados por el cliente. Dra. Cecilia Abelenda (Directora Técnica)"
                x1hoja.Range("A" & fila, "O" & fila).WrapText = True
                x1hoja.Range("A" & fila, "O" & fila).Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Size = 6
                '************************************************************************
                fila = fila + 1
                x1hoja.Range("A" & fila, "J" & fila).Merge()
                x1hoja.Cells(fila, columna).Interior.Color = RGB(215, 219, 221)
                x1hoja.Cells(fila, columna).rowheight = 8
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Formula = "Fin del informe."
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 7
            End If
        End If
        'Insert tabla preinformes**************************
        'Dim pi As New dPreinformes
        'Dim fechaactual As Date = Now()
        'Dim _fecha As String
        '_fecha = Format(fechaactual, "yyyy-MM-dd")
        'pi.FICHA = nroficha
        'pi = pi.buscar
        'If Not pi Is Nothing Then
        'Else
        '    Dim pi2 As New dPreinformes
        '    pi2.FICHA = nroficha
        '    pi2.TIPO = 14
        '    pi2.CREADO = 1
        '    pi2.FECHA = _fecha
        '    pi2.guardar()
        '    pi2 = Nothing
        'End If
        'pi = Nothing
        '***********************************************************
        x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas
        'PROTEGE LA HOJA DE EXCEL
        x1hoja.Protect(Password:="1582782", DrawingObjects:=True, _
        Contents:=True, Scenarios:=True)
        'GUARDA EL ARCHIVO DE EXCEL
        'x1hoja.SaveAs("\\ROBOT\PREINFORMES\SUELOS\" & nroficha & ".xls")
        x1app.Visible = True
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub informe_bacteriologia_clinica_aerobica()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
        x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(1)
        x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(1)
        x1hoja.PageSetup.Orientation = (Excel.XlPageOrientation.xlLandscape)
        Dim sa As New dSolicitudAnalisis
        Dim cli As New dCliente
        Dim na As New dNuevoAnalisis
        Dim na_ As New dNuevoAnalisis
        Dim na3 As New dNuevoAnalisis
        Dim met As New dMetodos
        Dim lista As New ArrayList
        Dim lista_ As New ArrayList
        Dim lista2 As New ArrayList
        Dim lista3 As New ArrayList
        Dim acreditado As Integer = 0
        Dim acreditado2 As Integer = 0
        Dim xanalisis As Integer = 0
        Dim vec(xanalisis) As Integer
        Dim informefinal As Integer = 0
        Dim nombre_operador As String = ""
        Dim nombre_tecnico As String = ""
        Dim sin_asterisco As Integer = 1
        '*****************************
        nroficha = TextFicha.Text.Trim
        sa.ID = nroficha
        sa = sa.buscar
        lista = na.listarporfichamuestra(nroficha)
        lista3 = na3.listarporficha3(nroficha)
        lista_ = na_.listarporficha3(nroficha)
        '**********************************************
        If Not lista3 Is Nothing Then
            xanalisis = lista3.Count - 1
            ReDim vec(xanalisis)
            Dim i As Integer = 0
            For Each na3 In lista3
                vec(i) = na3.ANALISIS
                i = i + 1
            Next
        End If
        '***********************************************
        If Not lista_ Is Nothing Then
            For Each na_ In lista_
                Dim lp_ As New dListaPrecios
                lp_.ID = na_.ANALISIS
                lp_ = lp_.buscar
                If Not lp_ Is Nothing Then
                    If lp_.ACREDITADO = 1 Then
                        sin_asterisco = 0
                    End If
                End If
            Next
        End If
        '***********************************************
        Dim fila As Integer
        Dim columna As Integer
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                fila = 1
                columna = 1
                'Poner Titulos
                columna = 2
                x1hoja.Cells(3, 1).columnwidth = 20
                x1hoja.Cells(3, 2).columnwidth = 42
                x1hoja.Cells(3, 3).columnwidth = 42
                x1hoja.Cells(3, 4).columnwidth = 7
                x1hoja.Cells(3, 5).columnwidth = 7
                x1hoja.Cells(3, 6).columnwidth = 7
                x1hoja.Cells(3, 7).columnwidth = 7
                fila = fila + 4
                columna = 1
                x1hoja.Cells(fila, columna).rowheight = 3
                fila = fila + 1
                x1hoja.Range("A" & fila, "G" & fila).Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).Formula = "INFORME DE BACTERIOLOGÍA CLÍNICA AERÓBICA"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 12
                fila = fila + 1
                columna = 1
                x1hoja.Cells(fila, columna).Formula = "Nº Ficha: " & sa.ID
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 3
                x1hoja.Cells(fila, columna).Formula = "Fecha entrada: " & sa.FECHAINGRESO
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                cli.ID = sa.IDPRODUCTOR
                cli = cli.buscar
                x1hoja.Cells(fila, columna).Formula = "Cliente: " & cli.NOMBRE
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 3
                Dim dicose As String = ""
                If cli.DICOSE <> "" Then
                    dicose = cli.DICOSE
                End If
                Dim tecnico As String = ""
                Dim cl As New dCliente
                cl.ID = cli.TECNICO1
                cl = cl.buscar
                If Not cl Is Nothing Then
                    tecnico = cl.NOMBRE
                End If
                Dim nnaa As New dNuevoAnalisis
                Dim fechaproceso As String = ""
                Dim listannaa As New ArrayList
                listannaa = nnaa.listarporficha2(sa.ID)
                If Not listannaa Is Nothing Then
                    For Each nnaa In listannaa
                        fechaproceso = nnaa.FECHAPROCESO
                    Next
                End If
                nnaa = Nothing
                listannaa = Nothing
                x1hoja.Cells(fila, columna).Formula = "Fecha proceso: " & fechaproceso
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                If cli.DIRECCION <> "" Or cli.DIRECCION <> "No aportado" Then
                    x1hoja.Cells(fila, columna).Formula = "Dirección: " & cli.DIRECCION
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = columna + 3
                ElseIf cli.IDLOCALIDAD <> 999 Then
                    Dim loc As New dLocalidad
                    loc.ID = cli.IDLOCALIDAD
                    loc = loc.buscar
                    If Not loc Is Nothing Then
                        x1hoja.Cells(fila, columna).Formula = loc.NOMBRE
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 9
                        columna = columna + 3
                    End If
                ElseIf cli.IDDEPARTAMENTO <> 999 Then
                    Dim dep As New dDepartamento
                    dep.ID = cli.IDDEPARTAMENTO
                    dep = dep.buscar
                    If Not dep Is Nothing Then
                        x1hoja.Cells(fila, columna).Formula = dep.NOMBRE
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 9
                        columna = columna + 3
                    End If
                ElseIf cli.CELULAR <> "" Then
                    x1hoja.Cells(fila, columna).Formula = "Celular: " & cli.CELULAR
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = columna + 3
                Else
                    x1hoja.Cells(fila, columna).Formula = "No aportado"
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = columna + 3
                End If
                Dim fecha As Date = Now()
                Dim fecha2 As String = fecha.ToString("dd/MM/yyyy")
                x1hoja.Cells(fila, columna).Formula = "Fecha informe: " & fecha2
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                Dim mm As New dMuestras
                mm.ID = sa.IDMUESTRA
                mm = mm.buscar
                If Not mm Is Nothing Then
                    x1hoja.Cells(fila, columna).Formula = "Material recibido: " & mm.NOMBRE
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    fila = fila + 1
                Else
                    x1hoja.Cells(fila, columna).Formula = "Material recibido: "
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    fila = fila + 1
                End If
                x1hoja.Cells(fila, columna).Formula = "Total de muestras: " & sa.NMUESTRAS
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 3
                x1hoja.Cells(fila, columna).Formula = "Técnico: " & tecnico
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                x1hoja.Cells(fila, columna).Formula = "Muestreo realizado por el cliente"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 3
                x1hoja.Cells(fila, columna).Formula = "DICOSE: " & dicose
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                x1hoja.Range("A" & fila, "G" & fila).Merge()
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).rowheight = 1
                fila = fila + 1
                x1hoja.Cells(fila, columna).rowheight = 3
                fila = fila + 1
                columna = 1
                Dim cuenta As Integer = 1
                Dim detallemuestras As String = ""
                Dim idoperador As Integer = 0
                Dim operador As String = ""
                Dim iu As New dUsuario
                iu.ID = idoperador
                iu = iu.buscar
                If Not iu Is Nothing Then
                    operador = iu.NOMBRE
                End If
                x1hoja.Cells(fila, columna).Formula = "Id."
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeTop).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeLeft).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeRight).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).WrapText = True
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Muestra"
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeBottom).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeLeft).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeRight).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).WrapText = True
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                fila = fila - 1
                Dim listademetodos As String = ""
                Dim listadeabreviaturas As String = ""
                For Each na In lista3
                    Dim u As New dUsuario
                    u.ID = na.OPERADOR
                    u = u.buscar
                    If Not u Is Nothing Then
                        nombre_operador = u.NOMBRE
                    End If
                    Dim lp As New dListaPrecios
                    lp.ID = na.ANALISIS
                    lp = lp.buscar
                    Dim lm As New dListaMetodos
                    lm.ID = na.METODO
                    lm = lm.buscar
                    If Not lm Is Nothing Then
                        listademetodos = listademetodos & lp.DESCTECNICA & " - " & lm.METODO & " / "
                    End If
                    If lp.ABREVIATURA <> lp.DESCTECNICA Then
                        listadeabreviaturas = listadeabreviaturas & lp.ABREVIATURA & " - " & lp.DESCTECNICA & " / "
                    End If
                    Dim l As New dListaPrecios
                    l.ID = na.ANALISIS
                    l = l.buscar
                    If Not l Is Nothing Then
                        x1hoja.Cells(fila, columna).Formula = l.ABREVIATURA
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        acreditado = 1
                    End If
                    l = Nothing
                    Dim au As New dAnalisisUnidad
                    au.ID = na.UNIDAD
                    au = au.buscar
                    If Not au Is Nothing Then
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).Formula = au.UNIDAD
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        x1hoja.Cells(fila, columna).Font.Size = 6
                        fila = fila - 1
                        columna = columna + 1
                    Else
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).Formula = ""
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        x1hoja.Cells(fila, columna).Font.Size = 6
                        fila = fila - 1
                        columna = columna + 1
                    End If
                    lp = Nothing
                    lm = Nothing
                    u = Nothing
                Next
                columna = 1
                fila = fila + 2
                For Each na In lista
                    x1hoja.Cells(fila, columna).Formula = na.MUESTRA
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    Dim x As Integer = 0
                    Dim n As Integer = 0
                    x = vec.Length
                    For n = 1 To x
                        x1hoja.Cells(fila, columna).Formula = "-"
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    Next
                    columna = columna - x
                    Dim na2 As New dNuevoAnalisis
                    lista2 = na2.listarpormuestra(nroficha, na.MUESTRA)
                    For Each na2 In lista2
                        Dim ret As Integer = Array.IndexOf(vec, na2.ANALISIS)
                        columna = columna + ret
                        x1hoja.Cells(fila, columna).Formula = na2.RESULTADO & " " & na2.RESULTADO2
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        Dim a As New dAcreditacion
                        a.ANALISIS = na2.ANALISIS
                        a = a.buscar
                        If Not a Is Nothing Then
                            Dim desde As Double = a.DESDE
                            Dim hasta As Double = a.HASTA
                            If Val(na2.RESULTADO2) < desde Or Val(na2.RESULTADO2) > hasta Then
                                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                            Else
                                acreditado2 = 1
                            End If
                        End If
                        columna = columna - ret
                    Next
                    columna = 1
                    fila = fila + 1
                Next
                x1hoja.Cells(fila, columna).rowheight = 3
                fila = fila + 1
                x1hoja.Range("A" & fila, "G" & fila).Merge()
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).rowheight = 1
                fila = fila + 1
                If listadeabreviaturas <> "" Then
                    x1hoja.Cells(fila, columna).Formula = "Abreviaturas"
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).rowheight = 30
                    x1hoja.Cells(fila, columna).Formula = listadeabreviaturas
                    x1hoja.Range("A" & fila, "I" & fila).WrapText = True
                    x1hoja.Range("A" & fila, "I" & fila).Merge()
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                    x1hoja.Cells(fila, columna).Font.Size = 7
                    fila = fila + 1
                End If
                x1hoja.Cells(fila, columna).Formula = "Métodos"
                x1hoja.Cells(fila, columna).Font.Bold = True
                fila = fila + 1
                x1hoja.Cells(fila, columna).rowheight = 30
                x1hoja.Cells(fila, columna).Formula = listademetodos
                x1hoja.Range("A" & fila, "G" & fila).WrapText = True
                x1hoja.Range("A" & fila, "G" & fila).Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Size = 7
                fila = fila + 1
                '*** OBSERVACIONES **************************************************
                If sa.OBSERVACIONES <> "" Then
                    x1hoja.Cells(fila, columna).rowheight = 25
                    x1hoja.Cells(fila, columna).Formula = "Observaciones: " & sa.OBSERVACIONES
                    x1hoja.Range("A" & fila, "G" & fila).WrapText = True
                    x1hoja.Range("A" & fila, "G" & fila).Merge()
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    fila = fila + 1
                End If
                '********************************************************************
                'CABEZAL SIN LOGO OUA
                x1hoja.Shapes.AddPicture("c:\Debug\encabezado_sin_oua2.png", _
             Microsoft.Office.Core.MsoTriState.msoFalse, _
             Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 700, 50)

                '*** PONER FIRMA ********************************************************
                x1libro.Worksheets(1).cells(fila, columna).select()
                x1libro.ActiveSheet.pictures.Insert("c:\Debug\cecilia.jpg").select()
                x1libro.Worksheets(1).cells(2, 1).select()

                columna = 1
                columna = columna + 3
                x1hoja.Cells(fila, columna).Formula = "Operador: " & nombre_operador
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 2
                '********************************************************************
                x1hoja.Cells(fila, columna).Formula = "Referencias:"
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "-"
                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Bold = False
                columna = columna + 1
                x1hoja.Cells(fila, columna).Formula = "Análisis no requerido."
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 7
                columna = 1
                '*** IMPORTE ********************************************************
                Dim f As New dFacturacion
                Dim listast As New ArrayList
                listast = f.listarxficha(nroficha)
                Dim total As Double = 0
                Dim lp2 As New dListaPrecios
                lp2.ID = 86
                lp2 = lp2.buscar
                If Not lp2 Is Nothing Then
                    total = total + lp2.PRECIO1
                End If
                For Each f In listast
                    total = total + f.SUBTOTAL
                Next
                f = Nothing
                lp2 = Nothing
                fila = fila + 2
                '*** PIE DE PAGINA ******************************************************
                x1hoja.Cells(fila, columna).rowheight = 25
                x1hoja.Cells(fila, columna).Formula = "Este informe no podrá ser reproducido total o parcialmente sin la autorización escrita de COLAVECO. Los resultados consignados se refieren exclusivamente a la muestra recibida." & vbCrLf _
                    & "COLAVECO declina toda responsabilidad por el uso indebido o incorrecto que se hiciere a este informe, asi como el plan y procedimientos de muestreo aplicados por el cliente. Dra. Cecilia Abelenda (Directora Técnica)"
                x1hoja.Range("A" & fila, "G" & fila).WrapText = True
                x1hoja.Range("A" & fila, "G" & fila).Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Size = 6
                '************************************************************************
                fila = fila + 1
                x1hoja.Range("A" & fila, "G" & fila).Merge()
                x1hoja.Cells(fila, columna).Interior.Color = RGB(215, 219, 221)
                x1hoja.Cells(fila, columna).rowheight = 8
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Formula = "Fin del informe."
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 7
            End If
        End If
        'Insert tabla preinformes**************************
        Dim pi As New dPreinformes
        Dim fechaactual As Date = Now()
        Dim _fecha As String
        _fecha = Format(fechaactual, "yyyy-MM-dd")
        pi.FICHA = nroficha
        pi = pi.buscar
        If Not pi Is Nothing Then
        Else
            Dim pi2 As New dPreinformes
            pi2.FICHA = nroficha
            pi2.TIPO = 18
            pi2.CREADO = 1
            pi2.FECHA = _fecha
            pi2.guardar()
            pi2 = Nothing
        End If
        pi = Nothing
        '***********************************************************
        x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas
        'PROTEGE LA HOJA DE EXCEL
        x1hoja.Protect(Password:="1582782", DrawingObjects:=True, _
        Contents:=True, Scenarios:=True)
        'GUARDA EL ARCHIVO DE EXCEL
        x1hoja.SaveAs("\\ROBOT\PREINFORMES\BACTERIOLOGIA\" & nroficha & ".xls")
        x1app.Visible = True
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub informe_foliar()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
        x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(1)
        x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(1)
        x1hoja.PageSetup.Orientation = (Excel.XlPageOrientation.xlLandscape)
        Dim sa As New dSolicitudAnalisis
        Dim cli As New dCliente
        Dim na As New dNuevoAnalisis
        Dim na3 As New dNuevoAnalisis
        Dim met As New dMetodos
        Dim lista As New ArrayList
        Dim lista2 As New ArrayList
        Dim lista3 As New ArrayList
        Dim acreditado As Integer = 0
        Dim acreditado2 As Integer = 0
        Dim xanalisis As Integer = 0
        Dim vec(xanalisis) As Integer
        Dim informefinal As Integer = 0
        Dim nombre_operador As String = "José L. García"
        Dim nombre_tecnico As String = "Ing. Agr. Victor González"
        '*****************************
        nroficha = TextFicha.Text.Trim
        sa.ID = nroficha
        sa = sa.buscar
        lista = na.listarporfichamuestra(nroficha)
        lista3 = na3.listarporficha3(nroficha)
        '**********************************************
        If Not lista3 Is Nothing Then
            xanalisis = lista3.Count - 1
            ReDim vec(xanalisis)
            Dim i As Integer = 0
            For Each na3 In lista3
                vec(i) = na3.ANALISIS
                i = i + 1
            Next
        End If
        '***********************************************
        Dim fila As Integer
        Dim columna As Integer
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                fila = 1
                columna = 1
                'Poner Titulos
                columna = 2
                x1hoja.Cells(3, 1).columnwidth = 20
                x1hoja.Cells(3, 2).columnwidth = 7
                x1hoja.Cells(3, 3).columnwidth = 7
                x1hoja.Cells(3, 4).columnwidth = 7
                x1hoja.Cells(3, 5).columnwidth = 7
                x1hoja.Cells(3, 6).columnwidth = 7
                x1hoja.Cells(3, 7).columnwidth = 7
                x1hoja.Cells(3, 8).columnwidth = 7
                x1hoja.Cells(3, 9).columnwidth = 7
                x1hoja.Cells(3, 10).columnwidth = 7
                x1hoja.Cells(3, 11).columnwidth = 7
                x1hoja.Cells(3, 12).columnwidth = 7
                x1hoja.Cells(3, 13).columnwidth = 7
                x1hoja.Cells(3, 14).columnwidth = 7
                x1hoja.Cells(3, 15).columnwidth = 7
                x1hoja.Cells(3, 16).columnwidth = 7
                fila = fila + 4
                columna = 1
                x1hoja.Cells(fila, columna).rowheight = 3
                fila = fila + 1
                x1hoja.Range("A" & fila, "P" & fila).Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).Formula = "INFORME FOLIAR"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 12
                fila = fila + 1
                columna = 1
                x1hoja.Cells(fila, columna).Formula = "Nº Ficha: " & sa.ID
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 11
                x1hoja.Cells(fila, columna).Formula = "Fecha entrada: " & sa.FECHAINGRESO
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                cli.ID = sa.IDPRODUCTOR
                cli = cli.buscar
                x1hoja.Cells(fila, columna).Formula = "Cliente: " & cli.NOMBRE
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 11
                Dim nnaa As New dNuevoAnalisis
                Dim fechaproceso As String = ""
                Dim listannaa As New ArrayList
                listannaa = nnaa.listarporficha2(sa.ID)
                If Not listannaa Is Nothing Then
                    For Each nnaa In listannaa
                        fechaproceso = nnaa.FECHAPROCESO
                    Next
                End If
                nnaa = Nothing
                listannaa = Nothing
                x1hoja.Cells(fila, columna).Formula = "Fecha proceso: " & fechaproceso
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                If cli.DIRECCION <> "" Or cli.DIRECCION <> "No aportado" Then
                    x1hoja.Cells(fila, columna).Formula = "Dirección: " & cli.DIRECCION
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = columna + 11
                ElseIf cli.IDLOCALIDAD <> 999 Then
                    Dim loc As New dLocalidad
                    loc.ID = cli.IDLOCALIDAD
                    loc = loc.buscar
                    If Not loc Is Nothing Then
                        x1hoja.Cells(fila, columna).Formula = loc.NOMBRE
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 9
                        columna = columna + 11
                    End If
                ElseIf cli.IDDEPARTAMENTO <> 999 Then
                    Dim dep As New dDepartamento
                    dep.ID = cli.IDDEPARTAMENTO
                    dep = dep.buscar
                    If Not dep Is Nothing Then
                        x1hoja.Cells(fila, columna).Formula = dep.NOMBRE
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 9
                        columna = columna + 11
                    End If
                ElseIf cli.CELULAR <> "" Then
                    x1hoja.Cells(fila, columna).Formula = "Celular: " & cli.CELULAR
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = columna + 11
                Else
                    x1hoja.Cells(fila, columna).Formula = "No aportado"
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = columna + 11
                End If
                Dim fecha As Date = Now()
                Dim fecha2 As String = fecha.ToString("dd/MM/yyyy")
                x1hoja.Cells(fila, columna).Formula = "Fecha informe: " & fecha2
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                Dim mm As New dMuestras
                mm.ID = sa.IDMUESTRA
                mm = mm.buscar
                If Not mm Is Nothing Then
                    x1hoja.Cells(fila, columna).Formula = "Material recibido: " & mm.NOMBRE
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = columna + 2
                Else
                    x1hoja.Cells(fila, columna).Formula = "Material recibido: "
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    fila = fila + 1
                    columna = columna + 3
                End If
                x1hoja.Cells(fila, columna).Formula = "Total de muestras: " & sa.NMUESTRAS
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = 1
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Muestreo realizado por el cliente"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                x1hoja.Range("A" & fila, "P" & fila).Merge()
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).rowheight = 1
                fila = fila + 1
                x1hoja.Cells(fila, columna).rowheight = 3
                fila = fila + 1
                columna = 1
                Dim cuenta As Integer = 1
                Dim detallemuestras As String = ""
                Dim idoperador As Integer = 0
                Dim operador As String = ""
                Dim iu As New dUsuario
                iu.ID = idoperador
                iu = iu.buscar
                If Not iu Is Nothing Then
                    operador = iu.NOMBRE
                End If
                x1hoja.Cells(fila, columna).Formula = "Id."
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeTop).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeLeft).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeRight).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).WrapText = True
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Muestra"
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeBottom).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeLeft).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeRight).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).WrapText = True
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                fila = fila - 1
                Dim listademetodos As String = ""
                Dim listadeabreviaturas As String = ""
                For Each na In lista3
                    Dim u As New dUsuario
                    u.ID = na.OPERADOR
                    u = u.buscar
                    If Not u Is Nothing Then
                        nombre_operador = u.NOMBRE
                    End If
                    Dim lp As New dListaPrecios
                    lp.ID = na.ANALISIS
                    lp = lp.buscar
                    Dim lm As New dListaMetodos
                    lm.ID = na.METODO
                    lm = lm.buscar
                    If Not lm Is Nothing Then
                        listademetodos = listademetodos & lp.DESCTECNICA & " - " & lm.METODO & " / "
                    End If
                    If lp.ABREVIATURA <> lp.DESCTECNICA Then
                        listadeabreviaturas = listadeabreviaturas & lp.ABREVIATURA & " - " & lp.DESCTECNICA & " / "
                    End If
                    Dim l As New dListaPrecios
                    l.ID = na.ANALISIS
                    l = l.buscar
                    If Not l Is Nothing Then
                        x1hoja.Cells(fila, columna).Formula = l.ABREVIATURA
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        acreditado = 1
                    End If
                    l = Nothing
                    Dim au As New dAnalisisUnidad
                    au.ID = na.UNIDAD
                    au = au.buscar
                    If Not au Is Nothing Then
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).Formula = au.UNIDAD
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        x1hoja.Cells(fila, columna).Font.Size = 6
                        fila = fila - 1
                        columna = columna + 1
                    Else
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).Formula = ""
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        x1hoja.Cells(fila, columna).Font.Size = 6
                        fila = fila - 1
                        columna = columna + 1
                    End If
                    lp = Nothing
                    lm = Nothing
                    u = Nothing
                Next
                columna = 1
                fila = fila + 2
                For Each na In lista
                    x1hoja.Cells(fila, columna).Formula = na.MUESTRA
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    Dim x As Integer = 0
                    Dim n As Integer = 0
                    x = vec.Length
                    For n = 1 To x
                        x1hoja.Cells(fila, columna).Formula = "-"
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    Next
                    columna = columna - x
                    Dim na2 As New dNuevoAnalisis
                    lista2 = na2.listarpormuestra(nroficha, na.MUESTRA)
                    For Each na2 In lista2
                        Dim ret As Integer = Array.IndexOf(vec, na2.ANALISIS)
                        columna = columna + ret
                        x1hoja.Cells(fila, columna).Formula = na2.RESULTADO & " " & na2.RESULTADO2
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        Dim a As New dAcreditacion
                        a.ANALISIS = na2.ANALISIS
                        a = a.buscar
                        If Not a Is Nothing Then
                            Dim desde As Double = a.DESDE
                            Dim hasta As Double = a.HASTA
                            If Val(na2.RESULTADO2) < desde Or Val(na2.RESULTADO2) > hasta Then
                                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                            Else
                                acreditado2 = 1
                            End If
                        End If
                        columna = columna - ret
                    Next
                    columna = 1
                    fila = fila + 1
                Next
                x1hoja.Cells(fila, columna).rowheight = 3
                fila = fila + 1
                x1hoja.Range("A" & fila, "P" & fila).Merge()
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).rowheight = 1
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Todos los resultados son expresados en base seca."
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 8
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Abreviaturas"
                x1hoja.Cells(fila, columna).Font.Bold = True
                fila = fila + 1
                x1hoja.Cells(fila, columna).rowheight = 30
                x1hoja.Cells(fila, columna).Formula = listadeabreviaturas
                x1hoja.Range("A" & fila, "O" & fila).WrapText = True
                x1hoja.Range("A" & fila, "O" & fila).Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Size = 7
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Métodos"
                x1hoja.Cells(fila, columna).Font.Bold = True
                fila = fila + 1
                x1hoja.Cells(fila, columna).rowheight = 30
                x1hoja.Cells(fila, columna).Formula = listademetodos
                x1hoja.Range("A" & fila, "O" & fila).WrapText = True
                x1hoja.Range("A" & fila, "O" & fila).Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Size = 7
                fila = fila + 1
                '*** OBSERVACIONES **************************************************
                If sa.OBSERVACIONES <> "" Then
                    x1hoja.Cells(fila, columna).rowheight = 25
                    x1hoja.Cells(fila, columna).Formula = "Observaciones: " & sa.OBSERVACIONES
                    x1hoja.Range("A" & fila, "P" & fila).WrapText = True
                    x1hoja.Range("A" & fila, "p" & fila).Merge()
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    fila = fila + 1
                End If
                '********************************************************************
                fila = fila + 2
                x1hoja.Shapes.AddPicture("c:\Debug\encabezado_sin_oua2.png", _
         Microsoft.Office.Core.MsoTriState.msoFalse, _
         Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 700, 50)
                '*** IMPORTE ********************************************************
                Dim f As New dFacturacion
                Dim listast As New ArrayList
                listast = f.listarxficha(nroficha)
                Dim total As Double = 0
                Dim lp2 As New dListaPrecios
                lp2.ID = 86
                lp2 = lp2.buscar
                If Not lp2 Is Nothing Then
                    total = total + lp2.PRECIO1
                End If
                For Each f In listast
                    total = total + f.SUBTOTAL
                Next
                f = Nothing
                lp2 = Nothing
                fila = fila - 2
                columna = columna + 11
                x1hoja.Cells(fila, columna).Formula = "Operador: " & nombre_operador
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                columna = columna + 11
                x1hoja.Cells(fila, columna).Formula = "Técnico resp: " & nombre_tecnico
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = 1
                '*** PONER FIRMA ********************************************************
                x1libro.Worksheets(1).cells(fila, columna).select()
                x1libro.ActiveSheet.pictures.Insert("c:\Debug\cecilia.jpg").select()
                x1libro.Worksheets(1).cells(2, 1).select()
                fila = fila + 6
                columna = 1
                '*** PIE DE PAGINA ******************************************************
                x1hoja.Cells(fila, columna).rowheight = 25
                x1hoja.Cells(fila, columna).Formula = "Este informe no podrá ser reproducido total o parcialmente sin la autorización escrita de COLAVECO. Los resultados consignados se refieren exclusivamente a la muestra recibida." & vbCrLf _
                    & "COLAVECO declina toda responsabilidad por el uso indebido o incorrecto que se hiciere a este informe, asi como el plan y procedimientos de muestreo aplicados por el cliente. Dra. Cecilia Abelenda (Directora Técnica)"
                x1hoja.Range("A" & fila, "O" & fila).WrapText = True
                x1hoja.Range("A" & fila, "O" & fila).Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Size = 6
                '************************************************************************
                fila = fila + 1
                x1hoja.Range("A" & fila, "P" & fila).Merge()
                x1hoja.Cells(fila, columna).Interior.Color = RGB(215, 219, 221)
                x1hoja.Cells(fila, columna).rowheight = 8
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Formula = "Fin del informe."
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 7
            End If
        End If
        'Insert tabla preinformes**************************
        Dim pi As New dPreinformes
        Dim fechaactual As Date = Now()
        Dim _fecha As String
        _fecha = Format(fechaactual, "yyyy-MM-dd")
        pi.FICHA = nroficha
        pi = pi.buscar
        If Not pi Is Nothing Then
        Else
            Dim pi2 As New dPreinformes
            pi2.FICHA = nroficha
            pi2.TIPO = 19
            pi2.CREADO = 1
            pi2.FECHA = _fecha
            pi2.guardar()
            pi2 = Nothing
        End If
        pi = Nothing
        '***********************************************************
        x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas
        'PROTEGE LA HOJA DE EXCEL
        x1hoja.Protect(Password:="1582782", DrawingObjects:=True, _
        Contents:=True, Scenarios:=True)
        'GUARDA EL ARCHIVO DE EXCEL
        x1hoja.SaveAs("\\ROBOT\PREINFORMES\SUELOS\" & nroficha & ".xls")
        x1app.Visible = True
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub informe_bacteriologia()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
        x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(1)
        x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(1)
        x1hoja.PageSetup.Orientation = (Excel.XlPageOrientation.xlLandscape)
        Dim sa As New dSolicitudAnalisis
        Dim cli As New dCliente
        Dim na As New dNuevoAnalisis
        Dim na3 As New dNuevoAnalisis
        Dim met As New dMetodos
        Dim lista As New ArrayList
        Dim lista2 As New ArrayList
        Dim lista3 As New ArrayList
        Dim acreditado As Integer = 0
        Dim acreditado2 As Integer = 0
        Dim xanalisis As Integer = 0
        Dim vec(xanalisis) As Integer
        Dim informefinal As Integer = 0
        Dim nombre_operador As String = "José L. García"
        Dim nombre_tecnico As String = "Ing. Agr. Victor González"
        '*****************************
        nroficha = TextFicha.Text.Trim
        sa.ID = nroficha
        sa = sa.buscar
        lista = na.listarporfichamuestra(nroficha)
        lista3 = na3.listarporficha3(nroficha)
        '**********************************************
        If Not lista3 Is Nothing Then
            xanalisis = lista3.Count - 1
            ReDim vec(xanalisis)
            Dim i As Integer = 0
            For Each na3 In lista3
                vec(i) = na3.ANALISIS
                i = i + 1
            Next
        End If
        '***********************************************
        Dim fila As Integer
        Dim columna As Integer
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                fila = 1
                columna = 1
                'Poner Titulos
                columna = 2
                x1hoja.Cells(3, 1).columnwidth = 20
                x1hoja.Cells(3, 2).columnwidth = 11
                x1hoja.Cells(3, 3).columnwidth = 11
                x1hoja.Cells(3, 4).columnwidth = 11
                x1hoja.Cells(3, 5).columnwidth = 11
                x1hoja.Cells(3, 6).columnwidth = 11
                x1hoja.Cells(3, 7).columnwidth = 11
                x1hoja.Cells(3, 8).columnwidth = 11
                x1hoja.Cells(3, 9).columnwidth = 11
                x1hoja.Cells(3, 10).columnwidth = 11
                x1hoja.Cells(3, 11).columnwidth = 11
                fila = fila + 4
                columna = 1
                x1hoja.Cells(fila, columna).rowheight = 3
                fila = fila + 1
                x1hoja.Range("A" & fila, "K" & fila).Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).Formula = "INFORME DE BACTERIOLOGÍA DE TANQUE"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 12
                fila = fila + 1
                columna = 1
                x1hoja.Cells(fila, columna).Formula = "Nº Ficha: " & sa.ID
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 9
                x1hoja.Cells(fila, columna).Formula = "Fecha entrada: " & sa.FECHAINGRESO
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                cli.ID = sa.IDPRODUCTOR
                cli = cli.buscar
                x1hoja.Cells(fila, columna).Formula = "Cliente: " & cli.NOMBRE
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 9
                Dim nnaa As New dNuevoAnalisis
                Dim fechaproceso As String = ""
                Dim listannaa As New ArrayList
                listannaa = nnaa.listarporficha2(sa.ID)
                If Not listannaa Is Nothing Then
                    For Each nnaa In listannaa
                        fechaproceso = nnaa.FECHAPROCESO
                    Next
                End If
                nnaa = Nothing
                listannaa = Nothing
                x1hoja.Cells(fila, columna).Formula = "Fecha proceso: " & fechaproceso
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                If cli.DIRECCION <> "" Or cli.DIRECCION <> "No aportado" Then
                    x1hoja.Cells(fila, columna).Formula = "Dirección: " & cli.DIRECCION
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = columna + 9
                ElseIf cli.IDLOCALIDAD <> 999 Then
                    Dim loc As New dLocalidad
                    loc.ID = cli.IDLOCALIDAD
                    loc = loc.buscar
                    If Not loc Is Nothing Then
                        x1hoja.Cells(fila, columna).Formula = loc.NOMBRE
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 9
                        columna = columna + 9
                    End If
                ElseIf cli.IDDEPARTAMENTO <> 999 Then
                    Dim dep As New dDepartamento
                    dep.ID = cli.IDDEPARTAMENTO
                    dep = dep.buscar
                    If Not dep Is Nothing Then
                        x1hoja.Cells(fila, columna).Formula = dep.NOMBRE
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 9
                        columna = columna + 9
                    End If
                ElseIf cli.CELULAR <> "" Then
                    x1hoja.Cells(fila, columna).Formula = "Celular: " & cli.CELULAR
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = columna + 9
                Else
                    x1hoja.Cells(fila, columna).Formula = "No aportado"
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = columna + 9
                End If
                Dim fecha As Date = Now()
                Dim fecha2 As String = fecha.ToString("dd/MM/yyyy")
                x1hoja.Cells(fila, columna).Formula = "Fecha informe: " & fecha2
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                Dim mm As New dMuestras
                mm.ID = sa.IDMUESTRA
                mm = mm.buscar
                If Not mm Is Nothing Then
                    x1hoja.Cells(fila, columna).Formula = "Material recibido: " & mm.NOMBRE
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = columna + 2
                Else
                    x1hoja.Cells(fila, columna).Formula = "Material recibido: "
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    fila = fila + 1
                    columna = columna + 3
                End If
                x1hoja.Cells(fila, columna).Formula = "Total de muestras: " & sa.NMUESTRAS
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = 1
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Muestreo realizado por el cliente."
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = 1
                fila = fila + 1
                x1hoja.Range("A" & fila, "K" & fila).Merge()
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).rowheight = 1
                fila = fila + 1
                x1hoja.Cells(fila, columna).rowheight = 3
                fila = fila + 1
                columna = 1
                Dim cuenta As Integer = 1
                Dim detallemuestras As String = ""
                Dim idoperador As Integer = 0
                Dim operador As String = ""
                Dim iu As New dUsuario
                iu.ID = idoperador
                iu = iu.buscar
                If Not iu Is Nothing Then
                    operador = iu.NOMBRE
                End If
                x1hoja.Cells(fila, columna).Formula = "Id."
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeTop).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeLeft).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeRight).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).WrapText = True
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Muestra"
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeBottom).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeLeft).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeRight).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).WrapText = True
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                fila = fila - 1
                Dim listademetodos As String = ""
                Dim listadeabreviaturas As String = ""
                For Each na In lista3
                    Dim u As New dUsuario
                    u.ID = na.OPERADOR
                    u = u.buscar
                    If Not u Is Nothing Then
                        nombre_operador = u.NOMBRE
                    End If
                    Dim lp As New dListaPrecios
                    lp.ID = na.ANALISIS
                    lp = lp.buscar
                    Dim lm As New dListaMetodos
                    lm.ID = na.METODO
                    lm = lm.buscar
                    If Not lm Is Nothing Then
                        listademetodos = listademetodos & lp.DESCTECNICA & " - " & lm.METODO & " / "
                    End If
                    If lp.ABREVIATURA <> lp.DESCTECNICA Then
                        listadeabreviaturas = listadeabreviaturas & lp.ABREVIATURA & " - " & lp.DESCTECNICA & " / "
                    End If
                    Dim l As New dListaPrecios
                    l.ID = na.ANALISIS
                    l = l.buscar
                    If Not l Is Nothing Then
                        If l.ACREDITADO = 1 Then
                            x1hoja.Cells(fila, columna).Formula = l.ABREVIATURA
                            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                            x1hoja.Cells(fila, columna).WrapText = True
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            acreditado = 1
                        Else
                            x1hoja.Cells(fila, columna).Formula = "* " & l.ABREVIATURA
                            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                            x1hoja.Cells(fila, columna).WrapText = True
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                            x1hoja.Cells(fila, columna).Font.Size = 8
                        End If
                    End If
                    Dim au As New dAnalisisUnidad
                    au.ID = na.UNIDAD
                    au = au.buscar
                    If Not au Is Nothing Then
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).Formula = au.UNIDAD
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        x1hoja.Cells(fila, columna).Font.Size = 6
                        fila = fila - 1
                        columna = columna + 1
                    Else
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).Formula = ""
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        x1hoja.Cells(fila, columna).Font.Size = 6
                        fila = fila - 1
                        columna = columna + 1
                    End If
                    l = Nothing
                    lp = Nothing
                    lm = Nothing
                    au = Nothing
                Next
                columna = 1
                fila = fila + 2
                For Each na In lista
                    x1hoja.Cells(fila, columna).Formula = na.MUESTRA
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    Dim x As Integer = 0
                    Dim n As Integer = 0
                    x = vec.Length
                    For n = 1 To x
                        x1hoja.Cells(fila, columna).Formula = "-"
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    Next
                    columna = columna - x
                    Dim na2 As New dNuevoAnalisis
                    lista2 = na2.listarpormuestra(nroficha, na.MUESTRA)
                    For Each na2 In lista2
                        Dim ret As Integer = Array.IndexOf(vec, na2.ANALISIS)
                        columna = columna + ret
                        x1hoja.Cells(fila, columna).Formula = na2.RESULTADO & " " & na2.RESULTADO2
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        Dim a As New dAcreditacion
                        a.ANALISIS = na2.ANALISIS
                        a = a.buscar
                        If Not a Is Nothing Then
                            Dim desde As Double = a.DESDE
                            Dim hasta As Double = a.HASTA
                            If Val(na2.RESULTADO2) < desde Or Val(na2.RESULTADO2) > hasta Then
                                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                            Else
                                acreditado2 = 1
                            End If
                        End If
                        columna = columna - ret
                    Next
                    columna = 1
                    fila = fila + 1
                Next
                'META*********************************************************************************************
                x1hoja.Cells(fila, columna).Formula = "Meta"
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeBottom).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeLeft).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeRight).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).WrapText = True
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignRight
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 7
                columna = columna + 1
                For Each na In lista3
                    Dim m As New dMeta
                    m.ANALISIS = na.ANALISIS
                    m = m.buscar
                    If Not m Is Nothing Then
                        x1hoja.Cells(fila, columna).Formula = m.META
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 6
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).Formula = ""
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 6
                        columna = columna + 1
                    End If
                Next
                '***************************************************************************************************
                columna = 1
                fila = fila + 1
                x1hoja.Cells(fila, columna).rowheight = 3
                fila = fila + 1
                x1hoja.Range("A" & fila, "K" & fila).Merge()
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).rowheight = 1
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "(*)Ensayo no acreditado ISO 17025 O.U.A."
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Abreviaturas"
                x1hoja.Cells(fila, columna).Font.Bold = True
                fila = fila + 1
                x1hoja.Cells(fila, columna).rowheight = 30
                x1hoja.Cells(fila, columna).Formula = listadeabreviaturas
                x1hoja.Range("A" & fila, "K" & fila).WrapText = True
                x1hoja.Range("A" & fila, "K" & fila).Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Size = 7
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Métodos"
                x1hoja.Cells(fila, columna).Font.Bold = True
                fila = fila + 1
                x1hoja.Cells(fila, columna).rowheight = 30
                x1hoja.Cells(fila, columna).Formula = "Bacteriología de tanque - Collage of Cornell Veterinary Medicine / " & listademetodos
                x1hoja.Range("A" & fila, "K" & fila).WrapText = True
                x1hoja.Range("A" & fila, "K" & fila).Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Size = 7
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Posible fuente de contaminación:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                fila = fila + 1
                x1hoja.Cells(fila, columna).rowheight = 30
                x1hoja.Cells(fila, columna).Formula = "RC - ubre // RB - máquina, tanque, pezón, falta de frio // Coliformes - máquina, pezón // Termodúricos - máquina // Estrepto. Uberis - ubre // Estrepto. Dysgalactiae - ubre, pezón, ambiente // Estrepto. Agalactiae - ubre // Estaf. Aureus - ubre, pezón // Estaf. Coag. Neg - ubre, pezón // Psicrótrofos - agua, tanque, máquina, ubres sucias"
                x1hoja.Range("A" & fila, "K" & fila).WrapText = True
                x1hoja.Range("A" & fila, "K" & fila).Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Size = 7
                fila = fila + 1
                '*** OBSERVACIONES **************************************************
                If sa.OBSERVACIONES <> "" Then
                    x1hoja.Cells(fila, columna).rowheight = 25
                    x1hoja.Cells(fila, columna).Formula = "Observaciones: " & sa.OBSERVACIONES
                    x1hoja.Range("A" & fila, "K" & fila).WrapText = True
                    x1hoja.Range("A" & fila, "K" & fila).Merge()
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    fila = fila + 1
                End If
                '********************************************************************
                columna = 1
                'CABEZAL CON O SIN LOGO OUA
                x1hoja.Shapes.AddPicture("c:\Debug\encabezado_con_oua2.png", _
         Microsoft.Office.Core.MsoTriState.msoFalse, _
         Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 700, 50)
                columna = columna + 9
                x1hoja.Cells(fila, columna).Formula = "Operador: " & nombre_operador
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 2
                columna = 1
                '*** PONER FIRMA ********************************************************
                x1libro.Worksheets(1).cells(fila, columna).select()
                x1libro.ActiveSheet.pictures.Insert("c:\Debug\cecilia.jpg").select()
                x1libro.Worksheets(1).cells(2, 1).select()
                fila = fila + 6
                columna = 1
                '*** PIE DE PAGINA ******************************************************
                x1hoja.Cells(fila, columna).rowheight = 25
                x1hoja.Cells(fila, columna).Formula = "Este informe no podrá ser reproducido total o parcialmente sin la autorización escrita de COLAVECO. Los resultados consignados se refieren exclusivamente a la muestra recibida." & vbCrLf _
                    & "COLAVECO declina toda responsabilidad por el uso indebido o incorrecto que se hiciere a este informe, asi como el plan y procedimientos de muestreo aplicados por el cliente. Dra. Cecilia Abelenda (Directora Técnica)"
                x1hoja.Range("A" & fila, "K" & fila).WrapText = True
                x1hoja.Range("A" & fila, "K" & fila).Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Size = 6
                '************************************************************************
                fila = fila + 1
                x1hoja.Range("A" & fila, "K" & fila).Merge()
                x1hoja.Cells(fila, columna).Interior.Color = RGB(215, 219, 221)
                x1hoja.Cells(fila, columna).rowheight = 8
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Formula = "Fin del informe."
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 7
            End If
        End If
        'Insert tabla preinformes**************************
        Dim pi As New dPreinformes
        Dim fechaactual As Date = Now()
        Dim _fecha As String
        _fecha = Format(fechaactual, "yyyy-MM-dd")
        pi.FICHA = nroficha
        pi = pi.buscar

        If Not pi Is Nothing Then
            Dim pi2 As New dPreinformes
            pi2.FICHA = nroficha
            pi2.TIPO = 17
            pi2.CREADO = 1
            pi2.FECHA = _fecha
            pi2.modificar()
            pi2 = Nothing
        Else
            Dim pi2 As New dPreinformes
            pi2.FICHA = nroficha
            pi2.TIPO = 6
            pi2.CREADO = 1
            pi2.FECHA = _fecha
            pi2.guardar()
            pi2 = Nothing
        End If

        pi = Nothing
        '***********************************************************
        x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas
        'PROTEGE LA HOJA DE EXCEL
        x1hoja.Protect(Password:="1582782", DrawingObjects:=True, _
        Contents:=True, Scenarios:=True)
        'GUARDA EL ARCHIVO DE EXCEL
        x1hoja.SaveAs("\\ROBOT\PREINFORMES\BACTERIOLOGIA\" & nroficha & ".xls")
        x1app.Visible = True
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub informe_nutricion()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
        x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(1)
        x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(1)
        x1hoja.PageSetup.Orientation = (Excel.XlPageOrientation.xlLandscape)
        Dim sa As New dSolicitudAnalisis
        Dim cli As New dCliente
        Dim na As New dNuevoAnalisis
        Dim na3 As New dNuevoAnalisis
        Dim met As New dMetodos
        Dim lista As New ArrayList
        Dim lista2 As New ArrayList
        Dim lista3 As New ArrayList
        Dim acreditado As Integer = 0
        Dim acreditado2 As Integer = 0
        Dim xanalisis As Integer = 0
        Dim vec(xanalisis) As Integer
        Dim informefinal As Integer = 0
        Dim nombre_operador As String = "José L. García"
        Dim nombre_tecnico As String = "Ing. Agr. Victor González"
        'Dim nombre_tecnico2 As String = "PhD. Analía Pérez Ruchel"
        'Dim nombre_tecnico2 As String = "MSc Sebastián Brambillasca"
        Dim texto_facultad As String = "Dpto. de Nutrición, Fac. Veterinaria, UdelaR"
        '*****************************
        nroficha = TextFicha.Text.Trim
        sa.ID = nroficha
        sa = sa.buscar
        lista = na.listarporfichamuestra(nroficha)
        lista3 = na3.listarporficha3(nroficha)
        '**********************************************
        If Not lista3 Is Nothing Then
            xanalisis = lista3.Count - 1
            ReDim vec(xanalisis)
            Dim i As Integer = 0
            For Each na3 In lista3
                vec(i) = na3.ANALISIS
                i = i + 1
            Next
        End If
        '***********************************************
        Dim fila As Integer
        Dim columna As Integer
        Dim fila2 As Integer
        Dim columna2 As Integer
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                fila = 1
                columna = 1
                'Poner Titulos
                columna = 2
                x1hoja.Cells(3, 1).columnwidth = 20
                x1hoja.Cells(3, 2).columnwidth = 10
                x1hoja.Cells(3, 3).columnwidth = 7
                x1hoja.Cells(3, 4).columnwidth = 7
                x1hoja.Cells(3, 5).columnwidth = 7
                x1hoja.Cells(3, 6).columnwidth = 7
                x1hoja.Cells(3, 7).columnwidth = 7
                x1hoja.Cells(3, 8).columnwidth = 7
                x1hoja.Cells(3, 9).columnwidth = 7
                x1hoja.Cells(3, 10).columnwidth = 7
                x1hoja.Cells(3, 11).columnwidth = 7
                x1hoja.Cells(3, 12).columnwidth = 7
                x1hoja.Cells(3, 13).columnwidth = 7
                x1hoja.Cells(3, 14).columnwidth = 7
                x1hoja.Cells(3, 15).columnwidth = 7
                x1hoja.Cells(3, 16).columnwidth = 7
                x1hoja.Cells(3, 17).columnwidth = 7
                x1hoja.Cells(3, 18).columnwidth = 7
                fila = fila + 4
                columna = 1
                x1hoja.Cells(fila, columna).rowheight = 3
                fila = fila + 1
                x1hoja.Range("A" & fila, "P" & fila).Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).Formula = "INFORME DE NUTRICIÓN"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 12
                fila = fila + 1
                columna = 1
                x1hoja.Cells(fila, columna).Formula = "Nº Ficha: " & sa.ID
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 11
                x1hoja.Cells(fila, columna).Formula = "Fecha entrada: " & sa.FECHAINGRESO
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                cli.ID = sa.IDPRODUCTOR
                cli = cli.buscar
                x1hoja.Cells(fila, columna).Formula = "Cliente: " & cli.NOMBRE
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 11
                Dim nnaa As New dNuevoAnalisis
                Dim fechaproceso As String = ""
                Dim listannaa As New ArrayList
                listannaa = nnaa.listarporficha2(sa.ID)
                If Not listannaa Is Nothing Then
                    For Each nnaa In listannaa
                        fechaproceso = nnaa.FECHAPROCESO
                    Next
                End If
                nnaa = Nothing
                listannaa = Nothing
                x1hoja.Cells(fila, columna).Formula = "Fecha proceso: " & fechaproceso
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                If cli.DIRECCION <> "" Or cli.DIRECCION <> "No aportado" Then
                    x1hoja.Cells(fila, columna).Formula = "Dirección: " & cli.DIRECCION
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = columna + 11
                ElseIf cli.IDLOCALIDAD <> 999 Then
                    Dim loc As New dLocalidad
                    loc.ID = cli.IDLOCALIDAD
                    loc = loc.buscar
                    If Not loc Is Nothing Then
                        x1hoja.Cells(fila, columna).Formula = loc.NOMBRE
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 9
                        columna = columna + 11
                    End If
                ElseIf cli.IDDEPARTAMENTO <> 999 Then
                    Dim dep As New dDepartamento
                    dep.ID = cli.IDDEPARTAMENTO
                    dep = dep.buscar
                    If Not dep Is Nothing Then
                        x1hoja.Cells(fila, columna).Formula = dep.NOMBRE
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 9
                        columna = columna + 11
                    End If
                ElseIf cli.CELULAR <> "" Then
                    x1hoja.Cells(fila, columna).Formula = "Celular: " & cli.CELULAR
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = columna + 11
                Else
                    x1hoja.Cells(fila, columna).Formula = "No aportado"
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = columna + 11
                End If
                Dim fecha As Date = Now()
                Dim fecha2 As String = fecha.ToString("dd/MM/yyyy")
                x1hoja.Cells(fila, columna).Formula = "Fecha informe: " & fecha2
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                Dim mm As New dMuestras
                mm.ID = sa.IDMUESTRA
                mm = mm.buscar
                If Not mm Is Nothing Then
                    x1hoja.Cells(fila, columna).Formula = "Material recibido: " & mm.NOMBRE
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = columna + 2
                Else
                    x1hoja.Cells(fila, columna).Formula = "Material recibido: "
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    fila = fila + 1
                    columna = columna + 3
                End If
                x1hoja.Cells(fila, columna).Formula = "Total de muestras: " & sa.NMUESTRAS
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = 1
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Muestreo realizado por el cliente."
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = 1
                fila = fila + 1
                x1hoja.Range("A" & fila, "P" & fila).Merge()
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).rowheight = 1
                fila = fila + 1
                x1hoja.Cells(fila, columna).rowheight = 3
                fila = fila + 1
                columna = 1
                Dim cuenta As Integer = 1
                Dim detallemuestras As String = ""
                Dim idoperador As Integer = 0
                Dim operador As String = ""
                Dim iu As New dUsuario
                iu.ID = idoperador
                iu = iu.buscar
                If Not iu Is Nothing Then
                    operador = iu.NOMBRE
                End If
                x1hoja.Cells(fila, columna).Formula = "Id."
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeTop).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeLeft).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeRight).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).WrapText = True
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Muestra"
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeBottom).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeLeft).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeRight).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).WrapText = True
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "                                             Base"
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeBottom).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeLeft).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeRight).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).WrapText = True
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 7
                columna = columna + 1
                fila = fila - 2
                Dim listademetodos As String = ""
                Dim listadeabreviaturas As String = ""
                For Each na In lista3
                    Dim u As New dUsuario
                    u.ID = na.OPERADOR
                    u = u.buscar
                    If Not u Is Nothing Then
                        nombre_operador = u.NOMBRE
                    End If
                    Dim lp As New dListaPrecios
                    lp.ID = na.ANALISIS
                    lp = lp.buscar
                    Dim lm As New dListaMetodos
                    lm.ID = na.METODO
                    lm = lm.buscar
                    If Not lm Is Nothing Then
                        listademetodos = listademetodos & lp.DESCTECNICA & " - " & lm.METODO & " / "
                    End If
                    If lp.ABREVIATURA <> lp.DESCTECNICA Then
                        listadeabreviaturas = listadeabreviaturas & lp.ABREVIATURA & " - " & lp.DESCTECNICA & " / "
                    End If
                    Dim l As New dListaPrecios
                    l.ID = na.ANALISIS
                    l = l.buscar
                    If Not l Is Nothing Then
                        'If l.ACREDITADO = 1 Then
                        x1hoja.Cells(fila, columna).Formula = l.ABREVIATURA
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        acreditado = 1
                    End If
                    Dim au As New dAnalisisUnidad
                    au.ID = na.UNIDAD
                    au = au.buscar
                    If Not au Is Nothing Then
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).Formula = au.UNIDAD
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        x1hoja.Cells(fila, columna).Font.Size = 6
                    Else
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).Formula = ""
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        x1hoja.Cells(fila, columna).Font.Size = 6
                    End If
                    If na.M = 1 Then
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).Formula = "Fresca"
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        x1hoja.Cells(fila, columna).Font.Size = 6
                        fila = fila - 2
                        columna = columna + 1
                    Else
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).Formula = "Seca"
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        x1hoja.Cells(fila, columna).Font.Size = 6
                        fila = fila - 2
                        columna = columna + 1
                    End If
                    l = Nothing
                    lp = Nothing
                    lm = Nothing
                    au = Nothing
                Next
                columna = 1
                fila = fila + 3
                For Each na In lista
                    x1hoja.Cells(fila, columna).Formula = na.MUESTRA
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    Dim x As Integer = 0
                    Dim n As Integer = 0
                    x = vec.Length
                    For n = 1 To x
                        x1hoja.Cells(fila, columna).Formula = "-"
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    Next
                    columna = columna - x
                    Dim na2 As New dNuevoAnalisis
                    lista2 = na2.listarpormuestra(nroficha, na.MUESTRA)
                    For Each na2 In lista2
                        Dim ret As Integer = Array.IndexOf(vec, na2.ANALISIS)
                        columna = columna + ret
                        If na2.M = 1 Then
                            x1hoja.Cells(fila, columna).Formula = na2.RESULTADO
                            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).WrapText = True
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - ret
                        Else
                            x1hoja.Cells(fila, columna).Formula = na2.RESULTADO2
                            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).WrapText = True
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - ret
                        End If

                    Next
                    columna = 1
                    fila = fila + 1
                Next
                x1hoja.Cells(fila, columna).rowheight = 3
                fila = fila + 1
                x1hoja.Range("A" & fila, "P" & fila).Merge()
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).rowheight = 1
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Abreviaturas"
                x1hoja.Cells(fila, columna).Font.Bold = True
                fila = fila + 1
                fila2 = fila
                columna2 = columna
                x1hoja.Cells(fila, columna).rowheight = 30
                x1hoja.Cells(fila, columna).Formula = listadeabreviaturas
                x1hoja.Range("A" & fila, "P" & fila).WrapText = True
                x1hoja.Range("A" & fila, "P" & fila).Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Size = 7
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Métodos"
                x1hoja.Cells(fila, columna).Font.Bold = True
                fila = fila + 1
                x1hoja.Cells(fila, columna).rowheight = 30
                x1hoja.Cells(fila, columna).Formula = listademetodos
                x1hoja.Range("A" & fila, "P" & fila).WrapText = True
                x1hoja.Range("A" & fila, "P" & fila).Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Size = 7
                fila = fila + 1
                '*** OBSERVACIONES **************************************************
                If sa.OBSERVACIONES <> "" Then
                    x1hoja.Cells(fila, columna).rowheight = 25
                    x1hoja.Cells(fila, columna).Formula = "Observaciones: " & sa.OBSERVACIONES
                    x1hoja.Range("A" & fila, "P" & fila).WrapText = True
                    x1hoja.Range("A" & fila, "P" & fila).Merge()
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    fila = fila + 1
                End If
                '*** INTERPRETACIONES **************************************************
                If sa.INTERPRETACION <> "" Then
                    x1hoja.Cells(fila, columna).rowheight = 25
                    x1hoja.Cells(fila, columna).Formula = "Interpretación: " & sa.INTERPRETACION
                    x1hoja.Range("A" & fila, "P" & fila).WrapText = True
                    x1hoja.Range("A" & fila, "P" & fila).Merge()
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    fila = fila + 1
                End If
                '********************************************************************
                columna = 1
                'CABEZAL CON O SIN LOGO FACULTAD VETERINARIA
                Dim _micotoxinas As Integer = 0
                Dim _otros As Integer = 0
                Dim _na As New dNuevoAnalisis
                Dim _lista As New ArrayList
                _lista = _na.listarporficha2(nroficha)
                If Not _lista Is Nothing Then
                    For Each _na In _lista
                        If _na.ANALISIS = 288 Or _na.ANALISIS = 289 Or _na.ANALISIS = 290 Then
                            _micotoxinas = 1
                        Else
                            _otros = 1
                        End If
                    Next
                End If
                If _micotoxinas = 1 And _otros = 0 Then
                    acreditado = 0
                Else
                    acreditado = 1
                End If
                If _micotoxinas = 1 And _otros = 1 Then
                    acreditado2 = 2
                ElseIf _micotoxinas = 1 And _otros = 0 Then
                    acreditado2 = 1
                ElseIf _micotoxinas = 0 And _otros = 1 Then
                    acreditado2 = 0
                End If
                fila = fila + 1
                If acreditado = 1 Then
                    x1hoja.Shapes.AddPicture("c:\Debug\encabezado_con_vet.png", _
             Microsoft.Office.Core.MsoTriState.msoFalse, _
             Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 690, 45)
                Else
                    x1hoja.Shapes.AddPicture("c:\Debug\encabezado_sin_vet.png", _
             Microsoft.Office.Core.MsoTriState.msoFalse, _
             Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 690, 45)
                End If
                '*************************************************************************
                If acreditado2 = 0 Then
                    fila = fila - 1
                    columna = columna + 11
                    x1hoja.Cells(fila, columna).Formula = "Operador: " & nombre_operador
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    fila = fila + 1
                    columna = 1
                    columna = columna + 11
                    x1hoja.Cells(fila, columna).Formula = "Técnico resp: " & nombre_tecnico
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).Formula = texto_facultad
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = 1
                ElseIf acreditado2 = 1 Then
                    x1hoja.Cells(fila2, columna2).Formula = listadeabreviaturas & " ■ µg/Kg = ppb ■"
                    fila = fila - 1
                    columna = columna + 11
                    x1hoja.Cells(fila, columna).Formula = "Operador: " & nombre_operador
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    fila = fila + 1
                    columna = 1
                    columna = columna + 11
                    x1hoja.Cells(fila, columna).Formula = "Técnico resp: " & nombre_tecnico
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = 1
                ElseIf acreditado2 = 2 Then
                    x1hoja.Cells(fila2, columna2).Formula = listadeabreviaturas & " ■ µg/Kg = ppb ■"
                    fila = fila - 1
                    columna = columna + 11
                    x1hoja.Cells(fila, columna).Formula = "Operador: " & nombre_operador
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    fila = fila + 1
                    columna = 1
                    columna = columna + 11
                    x1hoja.Cells(fila, columna).Formula = "Técnico resp: " & nombre_tecnico
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).Formula = texto_facultad
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).Formula = "Técnico resp: " & nombre_tecnico
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = 1
                End If
                'ANALISIS TERCERIZADOS***************************************************
                Dim at As New dAnalisisTercerizado
                Dim listaat As New ArrayList
                listaat = at.listarporficha4(nroficha)
                If Not listaat Is Nothing Then
                    x1hoja.Cells(fila, columna).Formula = "ANÁLISIS TERCERIZADOS"
                    'x1hoja.Range("A" & fila, "M" & fila).Merge()
                    x1hoja.Cells(fila, columna).Interior.Color = RGB(215, 219, 221)
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).Formula = "Muestra"
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "Análisis"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 3
                    x1hoja.Cells(fila, columna).Formula = "Resultado"
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "Unidad"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "Método"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 4
                    x1hoja.Cells(fila, columna).Formula = "Laboratorio"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = 1
                    fila = fila + 1
                    For Each at In listaat
                        x1hoja.Cells(fila, columna).Formula = at.MUESTRA
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                        Dim att As New dAnalisisTercerizadoTipo
                        att.ID = at.ANALISIS
                        att = att.buscar
                        If Not att Is Nothing Then
                            x1hoja.Cells(fila, columna).Formula = att.NOMBRE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 3
                        Else
                            x1hoja.Cells(fila, columna).Formula = ""
                            x1hoja.Cells(fila, columna).WrapText = True
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 3
                        End If
                        x1hoja.Cells(fila, columna).Formula = at.RESULTADO
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = at.UNIDAD
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = at.METODO
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 4
                        Dim ol As New dOtrosLaboratorios
                        ol.ID = at.LABORATORIO
                        ol = ol.buscar
                        If Not ol Is Nothing Then
                            x1hoja.Cells(fila, columna).Formula = ol.NOMBRE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = 1
                            fila = fila + 1
                        Else
                            x1hoja.Cells(fila, columna).Formula = ""
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = 1
                            fila = fila + 1
                        End If
                    Next
                    fila = fila + 1
                End If
                '*** PONER FIRMA ********************************************************
                fila = fila - 1
                x1libro.Worksheets(1).cells(fila, columna).select()
                x1libro.ActiveSheet.pictures.Insert("c:\Debug\cecilia.jpg").select()
                x1libro.Worksheets(1).cells(2, 1).select()
                fila = fila + 6
                columna = 1
                '*** PIE DE PAGINA ******************************************************
                x1hoja.Cells(fila, columna).rowheight = 25
                x1hoja.Cells(fila, columna).Formula = "Este informe no podrá ser reproducido total o parcialmente sin la autorización escrita de COLAVECO. Los resultados consignados se refieren exclusivamente a la muestra recibida." & vbCrLf _
                    & "COLAVECO declina toda responsabilidad por el uso indebido o incorrecto que se hiciere a este informe, asi como el plan y procedimientos de muestreo aplicados por el cliente. Dra. Cecilia Abelenda (Directora Técnica)"
                x1hoja.Range("A" & fila, "K" & fila).WrapText = True
                x1hoja.Range("A" & fila, "K" & fila).Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Size = 6
                '************************************************************************
                fila = fila + 1
                x1hoja.Range("A" & fila, "P" & fila).Merge()
                x1hoja.Cells(fila, columna).Interior.Color = RGB(215, 219, 221)
                x1hoja.Cells(fila, columna).rowheight = 8
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Formula = "Fin del informe."
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 7
            End If
        End If
        'Insert tabla preinformes**************************
        Dim pi As New dPreinformes
        Dim fechaactual As Date = Now()
        Dim _fecha As String
        _fecha = Format(fechaactual, "yyyy-MM-dd")
        pi.FICHA = nroficha
        pi = pi.buscar
        If Not pi Is Nothing Then
        Else
            Dim pi2 As New dPreinformes
            pi2.FICHA = nroficha
            pi2.TIPO = 13
            pi2.CREADO = 1
            pi2.FECHA = _fecha
            pi2.guardar()
            pi2 = Nothing
        End If
        pi = Nothing
        '***********************************************************
        x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas
        'PROTEGE LA HOJA DE EXCEL
        x1hoja.Protect(Password:="1582782", DrawingObjects:=True, _
        Contents:=True, Scenarios:=True)
        'GUARDA EL ARCHIVO DE EXCEL
        x1hoja.SaveAs("\\ROBOT\PREINFORMES\NUTRICION\" & nroficha & ".xls")
        x1app.Visible = True
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub informe_agua()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
        x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(1)
        x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(1)
        x1hoja.PageSetup.Orientation = (Excel.XlPageOrientation.xlPortrait)
        Dim sa As New dSolicitudAnalisis
        Dim cli As New dCliente
        Dim na As New dNuevoAnalisis
        Dim na3 As New dNuevoAnalisis
        Dim met As New dMetodos
        Dim lista As New ArrayList
        Dim lista2 As New ArrayList
        Dim lista3 As New ArrayList
        Dim acreditado As Integer = 0
        Dim acreditado2 As Integer = 0
        Dim xanalisis As Integer = 0
        Dim vec(xanalisis) As Integer
        Dim informefinal As Integer = 0
        Dim nombre_operador As String = ""
        Dim nombre_tecnico As String = ""
        Dim listademetodos As String = ""
        Dim listadeabreviaturas As String = ""
        Dim unit As Integer = 0
        Dim unt As Integer = 0
        Dim max As Integer = 0
        '*****************************
        nroficha = TextFicha.Text.Trim
        sa.ID = nroficha
        sa = sa.buscar
        lista = na.listarporfichamuestra(nroficha) 'LISTA LAS DISTINTAS MUESTRAS
        lista3 = na3.listarporficha3(nroficha) 'LISTA LOS DISTINTOS ANALISIS
        '**********************************************
        'ORDENA LOS DISTINTOS ANALISIS EN UN VECTOR
        If Not lista3 Is Nothing Then
            xanalisis = lista3.Count - 1
            ReDim vec(xanalisis)
            Dim i As Integer = 0
            For Each na3 In lista3
                vec(i) = na3.ANALISIS
                i = i + 1
            Next
        End If
        '***********************************************
        Dim fila As Integer
        Dim columna As Integer
        Dim fila_tope As Integer
        'If Not lista Is Nothing Then
        '    If lista.Count > 0 Then
        fila = 1
        columna = 1
        'Poner Titulos
        columna = 2
        x1hoja.Cells(3, 1).columnwidth = 20
        x1hoja.Cells(3, 2).columnwidth = 20
        x1hoja.Cells(3, 3).columnwidth = 10
        x1hoja.Cells(3, 4).columnwidth = 10
        x1hoja.Cells(3, 5).columnwidth = 10
        x1hoja.Cells(3, 6).columnwidth = 10
        x1hoja.Cells(3, 7).columnwidth = 10
        fila = fila + 4
        columna = 1
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Formula = "INFORME DE AGUA"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 12

        fila = fila + 1
        columna = 1
        'x1hoja.Cells(fila, columna).Font.Name = font.Name
        x1hoja.Cells(fila, columna).Formula = "Nº Ficha: " & sa.ID
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        columna = columna + 4
        'x1hoja.Cells(fila, columna).Font.Name = font.Name
        x1hoja.Cells(fila, columna).Formula = "Fecha entrada: " & sa.FECHAINGRESO
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        fila = fila + 1
        columna = 1
        cli.ID = sa.IDPRODUCTOR
        cli = cli.buscar
        'x1hoja.Cells(fila, columna).Font.Name = font.Name
        x1hoja.Cells(fila, columna).Formula = "Cliente: " & cli.NOMBRE
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        columna = columna + 4
        Dim nnaa As New dNuevoAnalisis
        Dim fechaproceso As String = ""
        Dim listannaa As New ArrayList
        listannaa = nnaa.listarporficha2(sa.ID)
        If Not listannaa Is Nothing Then
            For Each nnaa In listannaa
                fechaproceso = nnaa.FECHAPROCESO
            Next
        End If
        nnaa = Nothing
        listannaa = Nothing
        'x1hoja.Cells(fila, columna).Font.Name = font.Name
        x1hoja.Cells(fila, columna).Formula = "Fecha proceso: " & fechaproceso
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        fila = fila + 1
        columna = 1
        If cli.DIRECCION <> "" Or cli.DIRECCION <> "No aportado" Then
            'x1hoja.Cells(fila, columna).Font.Name = font.Name
            x1hoja.Cells(fila, columna).Formula = "Dirección: " & cli.DIRECCION
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            columna = columna + 4
        ElseIf cli.IDLOCALIDAD <> 999 Then
            Dim loc As New dLocalidad
            loc.ID = cli.IDLOCALIDAD
            loc = loc.buscar
            If Not loc Is Nothing Then
                ' x1hoja.Cells(fila, columna).Font.Name = font.Name
                x1hoja.Cells(fila, columna).Formula = loc.NOMBRE
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 4
            End If
        ElseIf cli.IDDEPARTAMENTO <> 999 Then
            Dim dep As New dDepartamento
            dep.ID = cli.IDDEPARTAMENTO
            dep = dep.buscar
            If Not dep Is Nothing Then
                'x1hoja.Cells(fila, columna).Font.Name = font.Name
                x1hoja.Cells(fila, columna).Formula = dep.NOMBRE
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 4
            End If
        ElseIf cli.CELULAR <> "" Then
            'x1hoja.Cells(fila, columna).Font.Name = font.Name
            x1hoja.Cells(fila, columna).Formula = "Celular: " & cli.CELULAR
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            columna = columna + 4
        Else
            'x1hoja.Cells(fila, columna).Font.Name = font.Name
            x1hoja.Cells(fila, columna).Formula = "No aportado"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            columna = columna + 4
        End If
        Dim fecha As Date = Now()
        Dim fecha2 As String = fecha.ToString("dd/MM/yyyy")
        ' x1hoja.Cells(fila, columna).Font.Name = font.Name
        x1hoja.Cells(fila, columna).Formula = "Fecha informe: " & fecha2
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        fila = fila + 1
        columna = 1
        Dim mm As New dMuestras
        mm.ID = sa.IDMUESTRA
        mm = mm.buscar
        If Not mm Is Nothing Then
            'x1hoja.Cells(fila, columna).Font.Name = font.Name
            x1hoja.Cells(fila, columna).Formula = "Material recibido: " & mm.NOMBRE
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
        Else
            ' x1hoja.Cells(fila, columna).Font.Name = font.Name
            x1hoja.Cells(fila, columna).Formula = "Material recibido: "
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 1
        End If
        'x1hoja.Cells(fila, columna).Font.Name = font.Name
        x1hoja.Cells(fila, columna).Formula = "Total de muestras: " & sa.NMUESTRAS
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        columna = columna + 4
        Dim c2 As New dCliente
        c2.ID = sa.IDTECNICO
        c2 = c2.buscar
        'Dim font2 As System.Drawing.Font = GetFont(Me.GetType.Assembly, "Colaveco.Roboto-Thin.ttf", 12, FontStyle.Bold)
        If Not c2 Is Nothing Then
            'x1hoja.Cells(fila, columna).Font.Name = font2.Name
            x1hoja.Cells(fila, columna).Formula = "Técnico: " & c2.NOMBRE
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 1
            columna = 1
        Else
            'x1hoja.Cells(fila, columna).Font.Name = font2.Name
            x1hoja.Cells(fila, columna).Formula = "Técnico: "
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 1
            columna = 1
        End If
        'x1hoja.Cells(fila, columna).Font.Name = font.Name
        x1hoja.Cells(fila, columna).Formula = "Muestreo realizado por el cliente."
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        columna = columna + 4
        'x1hoja.Cells(fila, columna).Font.Name = font.Name
        x1hoja.Cells(fila, columna).Formula = "DICOSE: " & cli.DICOSE
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        fila = fila + 1
        columna = 1
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).rowheight = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).rowheight = 3
        fila = fila + 2
        columna = 1
        '******************************************************************************************************
        If Not lista Is Nothing Then 'cambio 18/11/2020
            If lista.Count > 0 Then

                fila_tope = fila
                fila = fila - 1
                Dim filax As Integer = fila_tope
                Dim columnax As Integer = 4
                For i = 1 To vec.Length
                    If lista.Count = 1 Then
                        x1hoja.Cells(filax, columnax).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(filax, columnax).Formula = "-"
                        x1hoja.Cells(filax, columnax).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(filax, columnax).VerticalAlignment = XlVAlign.xlVAlignTop
                        columnax = 4
                        filax = filax + 1
                    ElseIf lista.Count = 2 Then
                        x1hoja.Cells(filax, columnax).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(filax, columnax).Formula = "-"
                        x1hoja.Cells(filax, columnax).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(filax, columnax).VerticalAlignment = XlVAlign.xlVAlignTop
                        columnax = columnax + 1
                        x1hoja.Cells(filax, columnax).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(filax, columnax).Formula = "-"
                        x1hoja.Cells(filax, columnax).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(filax, columnax).VerticalAlignment = XlVAlign.xlVAlignTop
                        columnax = 4
                        filax = filax + 1
                    ElseIf lista.Count = 3 Then
                        x1hoja.Cells(filax, columnax).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(filax, columnax).Formula = "-"
                        x1hoja.Cells(filax, columnax).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(filax, columnax).VerticalAlignment = XlVAlign.xlVAlignTop
                        columnax = columnax + 1
                        x1hoja.Cells(filax, columnax).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(filax, columnax).Formula = "-"
                        x1hoja.Cells(filax, columnax).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(filax, columnax).VerticalAlignment = XlVAlign.xlVAlignTop
                        columnax = columnax + 1
                        x1hoja.Cells(filax, columnax).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(filax, columnax).Formula = "-"
                        x1hoja.Cells(filax, columnax).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(filax, columnax).VerticalAlignment = XlVAlign.xlVAlignTop
                        columnax = 4
                        filax = filax + 1
                    ElseIf lista.Count = 4 Then
                        x1hoja.Cells(filax, columnax).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(filax, columnax).Formula = "-"
                        x1hoja.Cells(filax, columnax).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(filax, columnax).VerticalAlignment = XlVAlign.xlVAlignTop
                        columnax = columnax + 1
                        x1hoja.Cells(filax, columnax).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(filax, columnax).Formula = "-"
                        x1hoja.Cells(filax, columnax).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(filax, columnax).VerticalAlignment = XlVAlign.xlVAlignTop
                        columnax = columnax + 1
                        x1hoja.Cells(filax, columnax).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(filax, columnax).Formula = "-"
                        x1hoja.Cells(filax, columnax).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(filax, columnax).VerticalAlignment = XlVAlign.xlVAlignTop
                        columnax = columnax + 1
                        x1hoja.Cells(filax, columnax).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(filax, columnax).Formula = "-"
                        x1hoja.Cells(filax, columnax).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(filax, columnax).VerticalAlignment = XlVAlign.xlVAlignTop
                        columnax = 4
                        filax = filax + 1
                    End If
                Next
                columna = 2
                x1hoja.Cells(fila, columna).Formula = "Métodos"
                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).WrapText = True
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                x1hoja.Cells(fila, columna).Formula = "Valor permitido"
                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).WrapText = True
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                For Each na In lista
                    x1hoja.Cells(fila, columna).Formula = na.MUESTRA
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                Next
                '****************************************************************************************************************************************

                fila = fila + 1
                Dim cuenta As Integer = 1
                Dim detallemuestras As String = ""
                Dim idoperador As Integer = 0
                Dim operador As String = ""
                Dim iu As New dUsuario
                iu.ID = idoperador
                iu = iu.buscar
                If Not iu Is Nothing Then
                    operador = iu.NOMBRE
                End If

                fila_tope = fila
                For Each na In lista3
                    If na.ANALISIS = 394 Then
                        unit = 1
                    End If
                    If na.ANALISIS = 264 Then
                        unt = 1
                        max = 1
                    End If
                    If na.ANALISIS = 265 Then
                        max = 1
                    End If
                    If na.ANALISIS = 266 Then
                        max = 1
                    End If
                    Dim u As New dUsuario
                    u.ID = na.OPERADOR
                    u = u.buscar
                    If Not u Is Nothing Then
                        nombre_operador = u.NOMBRE
                    End If
                    Dim lp As New dListaPrecios
                    lp.ID = na.ANALISIS
                    lp = lp.buscar
                    If lp.ABREVIATURA <> lp.DESCTECNICA Then
                        listadeabreviaturas = listadeabreviaturas & lp.ABREVIATURA & " - " & lp.DESCTECNICA & " / "
                    End If
                    Dim l As New dListaPrecios
                    l.ID = na.ANALISIS
                    l = l.buscar
                    Dim au As New dAnalisisUnidad
                    au.ID = na.UNIDAD
                    au = au.buscar
                    Dim unidad As String = ""
                    If Not au Is Nothing Then
                        unidad = au.UNIDAD
                    Else
                        unidad = ""
                    End If
                    columna = 1
                    If Not l Is Nothing Then
                        If l.ACREDITADO = 1 Then
                            x1hoja.Cells(fila, columna).Formula = l.ABREVIATURA & " " & unidad
                            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                            x1hoja.Cells(fila, columna).WrapText = True
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            acreditado = 1
                            fila = fila + 1
                        Else
                            x1hoja.Cells(fila, columna).Formula = "* " & l.ABREVIATURA & " " & unidad
                            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                            x1hoja.Cells(fila, columna).WrapText = True
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            fila = fila + 1
                        End If
                    End If
                    l = Nothing
                    lp = Nothing
                    u = Nothing
                Next
                'METODOS Y REFERENCIAS ******************************************************************
                fila = fila_tope
                columna = 2
                For Each na In lista3
                    Dim r As New dReferencias
                    r.ANALISIS = na.ANALISIS
                    r = r.buscar
                    If Not r Is Nothing Then
                        Dim a As New dAgua
                        a.FICHA = nroficha
                        a = a.buscarxficha
                        If Not a Is Nothing Then
                            If a.ENVASADA = 0 Then
                                Dim lm As New dListaMetodos
                                lm.ANALISIS = na.ANALISIS
                                lm.METODO = na.METODO
                                'lm = lm.buscarxanalisis
                                If lm.METODO <> 0 Then
                                    lm = lm.buscarxanalisisymetodo
                                Else
                                    lm = lm.buscarxanalisis
                                End If

                                If Not lm Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = lm.METODO
                                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8

                                    If cli.TIPOUSUARIO <> 2 Then
                                        columna = columna + 1
                                        x1hoja.Cells(fila, columna).Formula = r.REFERENCIA1
                                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                                        x1hoja.Cells(fila, columna).WrapText = True
                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                        x1hoja.Cells(fila, columna).Font.Size = 8
                                    Else
                                        columna = columna + 1
                                        x1hoja.Cells(fila, columna).Formula = "-"
                                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                                        x1hoja.Cells(fila, columna).WrapText = True
                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                        x1hoja.Cells(fila, columna).Font.Size = 8
                                    End If
                                    columna = 2
                                End If
                            Else
                                Dim lm As New dListaMetodos
                                lm.ANALISIS = na.ANALISIS
                                lm = lm.buscarxanalisis
                                If Not lm Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = lm.METODO
                                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8

                                    If cli.TIPOUSUARIO <> 2 Then
                                        columna = columna + 1
                                        x1hoja.Cells(fila, columna).Formula = r.REFERENCIA2
                                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                                        x1hoja.Cells(fila, columna).WrapText = True
                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                        x1hoja.Cells(fila, columna).Font.Size = 8
                                    Else
                                        columna = columna + 1
                                        x1hoja.Cells(fila, columna).Formula = "-"
                                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                                        x1hoja.Cells(fila, columna).WrapText = True
                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                        x1hoja.Cells(fila, columna).Font.Size = 8
                                    End If
                                    columna = 2
                                End If
                            End If
                        End If
                    Else '**************************************************************************
                        Dim a As New dAgua
                        a.FICHA = nroficha
                        a = a.buscarxficha
                        If Not a Is Nothing Then
                            If a.ENVASADA = 0 Then
                                Dim lm As New dListaMetodos
                                lm.ANALISIS = na.ANALISIS
                                lm = lm.buscarxanalisis
                                If Not lm Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = lm.METODO
                                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8

                                    columna = columna + 1
                                    x1hoja.Cells(fila, columna).Formula = "-"
                                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = 2
                                End If
                            Else
                                Dim lm As New dListaMetodos
                                lm.ANALISIS = na.ANALISIS
                                lm = lm.buscarxanalisis
                                If Not lm Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = lm.METODO
                                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8

                                    columna = columna + 1
                                    x1hoja.Cells(fila, columna).Formula = "-"
                                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = 2
                                End If
                            End If
                        End If
                        '************************************************************************************************
                    End If
                    fila = fila + 1
                Next
                '*******************************************************************************
                'End If  'cambio 18/11/2020
                columna = 4
                For Each na In lista

                    fila = fila_tope

                    Dim x As Integer = 0
                    Dim n As Integer = 0
                    x = vec.Length
                    Dim na2 As New dNuevoAnalisis
                    lista2 = na2.listarpormuestra(nroficha, na.MUESTRA)
                    For Each na2 In lista2
                        Dim ret As Integer = Array.IndexOf(vec, na2.ANALISIS)
                        fila = fila + ret
                        If na2.ANALISIS = 265 Then
                            If na2.RESULTADO <> "" Then
                                Dim culture As CultureInfo = New CultureInfo("en-US")
                                Dim valornitrato As Double = Double.Parse(na2.RESULTADO, culture) / 4.43
                                'Dim valornitrato As Double = na2.RESULTADO / 4.43
                                x1hoja.Cells(fila, columna).Formula = Math.Round(valornitrato, 2)
                                'x1hoja.Cells(fila, columna).Formula = na2.RESULTADO & " " & na2.RESULTADO2
                                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                fila = fila - ret
                            ElseIf na2.RESULTADO2 <> "" Then
                                Dim culture As CultureInfo = New CultureInfo("en-US")
                                Dim valornitrato As String = na2.RESULTADO2
                                'Dim valornitrato As Double = na2.RESULTADO / 4.43
                                'x1hoja.Cells(fila, columna).Formula = Math.Round(valornitrato, 2)
                                'x1hoja.Cells(fila, columna).Formula = na2.RESULTADO & " " & na2.RESULTADO2
                                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                fila = fila - ret
                            Else
                                na2.RESULTADO = "0"
                                Dim culture As CultureInfo = New CultureInfo("en-US")
                                Dim valornitrato As Double = Decimal.Parse(na2.RESULTADO, culture)
                                'Dim valornitrato As Double = na2.RESULTADO
                                x1hoja.Cells(fila, columna).Formula = Math.Round(valornitrato, 2)
                                'x1hoja.Cells(fila, columna).Formula = na2.RESULTADO & " " & na2.RESULTADO2
                                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                fila = fila - ret
                            End If
                        Else
                            x1hoja.Cells(fila, columna).Formula = na2.RESULTADO & " " & na2.RESULTADO2
                            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).WrapText = True
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            fila = fila - ret

                        End If

                    Next
                    columna = columna + 1
                Next

                fila = fila_tope
                fila = fila - 1
                columna = 1

                columna = 1
                fila = fila + vec.Length
                fila = fila + 1
                x1hoja.Cells(fila, columna).rowheight = 3
                fila = fila + 1
                x1hoja.Range("A" & fila, "G" & fila).Merge()
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).rowheight = 1
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Abreviaturas"
                x1hoja.Cells(fila, columna).Font.Bold = True
                fila = fila + 1
                If unt = 1 Then
                    listadeabreviaturas = listadeabreviaturas & " " & "U.N.T. - Unidades Nefelométricas de Turbiedad "
                End If
                If max = 1 Then
                    listadeabreviaturas = listadeabreviaturas & " / " & "Max - Máximo permitido"
                End If
                x1hoja.Cells(fila, columna).rowheight = 30
                x1hoja.Cells(fila, columna).Formula = listadeabreviaturas
                x1hoja.Range("A" & fila, "G" & fila).WrapText = True
                x1hoja.Range("A" & fila, "G" & fila).Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Size = 7
                fila = fila + 1


                'DATOS DE LA FUENTE ************************************************************************************************
                x1hoja.Cells(fila, columna).Formula = "Datos de la fuente:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = 1
                fila = fila + 1
                Dim id As Long = sa.ID
                Dim a1 As New dAgua
                a1.ID = id
                a1 = a1.buscar()
                Dim tp As New dTipoPozo
                tp.ID = a1.IDTIPOPOZO
                If a1.IDTIPOPOZO <> 0 Then
                    tp = tp.buscar()
                End If
                Dim mue As New dMuestraExtraida
                mue.ID = a1.IDMUESTRAEXTRAIDA
                mue = mue.buscar()
                Dim mfc As New dMuestraFueraCondicion
                mfc.ID = a1.IDMUESTRAFUERACONDICION
                mfc = mfc.buscar()
                Dim at As New dAguaTratada
                at.ID = a1.IDAGUATRATADA
                at = at.buscar()
                Dim ec As New dEstadoConservacion
                ec.ID = a1.IDESTADODECONSERVACION
                ec = ec.buscar()
                Dim textoMO As String
                If a1.MUESTRAOFICIAL = 0 Then
                    textoMO = "No"
                Else
                    textoMO = "Si"
                End If
                Dim textox As String = ""

                textox = "Tipo pozo:" & " " & tp.NOMBRE & " / " & "Antiguedad:" & " " & a1.ANTIGUEDAD & " / " & "Distancia pozo negro:" & " " & a1.DISTANCIAPOZONEGRO & " / " & "Distancia tambo:" & " " & a1.DISTANCIATAMBO & " / " & "Estado de conservación:" & " " & ec.NOMBRE & " / " & "Muestra extraída de:" & " " & mue.NOMBRE & " / " & "Muestra fuera de condición:" & " " & mfc.NOMBRE & " / " & "Profundidad:" & " " & a1.PROFUNDIDAD & " / " & "Agua tratada:" & " " & at.NOMBRE

                x1hoja.Cells(fila, columna).rowheight = 30
                x1hoja.Cells(fila, columna).Formula = textox
                x1hoja.Range("A" & fila, "G" & fila).WrapText = True
                x1hoja.Range("A" & fila, "G" & fila).Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Size = 7
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Temperatura de arribo de la/s muestra/s"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = 3
                If sa.TEMPERATURA > 8 Then
                    x1hoja.Cells(fila, columna).Formula = sa.TEMPERATURA & " " & "°C" & " " & "(Proceso autorizado por cliente)"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = 1
                    fila = fila + 1
                Else
                    x1hoja.Cells(fila, columna).Formula = sa.TEMPERATURA & " " & "°C"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = 1
                    fila = fila + 1
                End If
                If textoMO = "Si" Then
                    x1hoja.Cells(fila, columna).Formula = "Muestra oficial M.G.A.P.:" & " " & textoMO
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    fila = fila + 1
                End If

                '*** OBSERVACIONES **************************************************
                If sa.OBSERVACIONES <> "" Then
                    x1hoja.Cells(fila, columna).rowheight = 25
                    x1hoja.Cells(fila, columna).Formula = "Observaciones: " & sa.OBSERVACIONES
                    x1hoja.Range("A" & fila, "G" & fila).WrapText = True
                    x1hoja.Range("A" & fila, "G" & fila).Merge()
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    fila = fila + 1
                End If
                '********************************************************************
                x1hoja.Cells(fila, columna).Formula = "(*)Ensayo no acreditado ISO 17025 O.U.A."
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                columna = columna + 2
                fila = fila + 2
                x1hoja.Cells(fila, columna).Formula = "Referencias:"
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "-"
                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Bold = False
                columna = columna + 1
                x1hoja.Cells(fila, columna).Formula = "Análisis no requerido."
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 7
                fila = fila + 1
                columna = columna - 1
                x1hoja.Cells(fila, columna).Formula = "Valor permitido"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 7
                columna = columna + 1
                Dim texto As String = ""
                If unit = 1 Then
                    texto = "UNIT 833:2008"
                Else
                    texto = "Decreto 315/94 R.B.N. y sus modificaciones"
                End If
                x1hoja.Cells(fila, columna).Formula = "Según: " & texto
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 7


                columna = 1
                'CABEZAL CON O SIN LOGO OUA
                '    If acreditado = 1 Then
                '        x1hoja.Shapes.AddPicture("c:\Debug\encabezado_con_oua2.png", _
                'Microsoft.Office.Core.MsoTriState.msoFalse, _
                'Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 452, 42)
                '    Else
                '        x1hoja.Shapes.AddPicture("c:\Debug\encabezado_sin_oua2.png", _
                'Microsoft.Office.Core.MsoTriState.msoFalse, _
                'Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 452, 42)
                '    End If

                fila = fila - 4
                columna = columna + 4
                x1hoja.Cells(fila, columna).Formula = "Operador: " & nombre_operador
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 3
                columna = 1
                fila = fila + 2
            End If 'cambio 28/11/2020
        End If 'cambio 28/11/2020

        If acreditado = 1 Then
            x1hoja.Shapes.AddPicture("c:\Debug\encabezado_con_oua2.png", _
    Microsoft.Office.Core.MsoTriState.msoFalse, _
    Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 452, 42)
        Else
            x1hoja.Shapes.AddPicture("c:\Debug\encabezado_sin_oua2.png", _
    Microsoft.Office.Core.MsoTriState.msoFalse, _
    Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 452, 42)
        End If

        'ANALISIS TERCERIZADOS***************************************************
        Dim at2 As New dAnalisisTercerizado
        Dim listaat As New ArrayList
        listaat = at2.listarporficha4(nroficha)
        If Not listaat Is Nothing Then
            x1hoja.Cells(fila, columna).Formula = "ANÁLISIS TERCERIZADOS"
            x1hoja.Range("A" & fila, "G" & fila).Merge()
            x1hoja.Cells(fila, columna).Interior.Color = RGB(215, 219, 221)
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 10
            fila = fila + 1
            x1hoja.Cells(fila, columna).Formula = "Muestra"
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            columna = columna + 1
            x1hoja.Cells(fila, columna).Formula = "Análisis"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            columna = columna + 1
            x1hoja.Cells(fila, columna).Formula = "Resultado"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            columna = columna + 1
            x1hoja.Cells(fila, columna).Formula = "Unidad"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            columna = columna + 1
            x1hoja.Cells(fila, columna).Formula = "Método"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            columna = columna + 1
            x1hoja.Cells(fila, columna).Formula = "Laboratorio"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            columna = 1
            fila = fila + 1
            For Each at2 In listaat
                x1hoja.Cells(fila, columna).Formula = at2.MUESTRA
                x1hoja.Cells(fila, columna).WrapText = True
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                Dim att As New dAnalisisTercerizadoTipo
                att.ID = at2.ANALISIS
                att = att.buscar
                If Not att Is Nothing Then
                    x1hoja.Cells(fila, columna).Formula = att.NOMBRE
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).Formula = ""
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                End If
                x1hoja.Cells(fila, columna).Formula = at2.RESULTADO
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                x1hoja.Cells(fila, columna).Formula = at2.UNIDAD
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                x1hoja.Cells(fila, columna).Formula = at2.METODO
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                Dim ol As New dOtrosLaboratorios
                ol.ID = at2.LABORATORIO
                ol = ol.buscar
                If Not ol Is Nothing Then
                    x1hoja.Cells(fila, columna).Formula = ol.NOMBRE
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = 1
                    fila = fila + 1
                Else
                    x1hoja.Cells(fila, columna).Formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = 1
                    fila = fila + 1
                End If
            Next
            fila = fila + 1
        End If
        '************************************************************************************************************
        '*** PONER FIRMA ********************************************************
        x1libro.Worksheets(1).cells(fila, columna).select()
        x1libro.ActiveSheet.pictures.Insert("c:\Debug\cecilia.jpg").select()
        x1libro.Worksheets(1).cells(2, 1).select()
        fila = fila + 4
        columna = 1
        fila = fila + 1
        x1hoja.Range("A" & fila, "G" & fila).WrapText = True
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 8
        fila = fila + 1

        '*** PIE DE PAGINA ******************************************************
        x1hoja.Cells(fila, columna).rowheight = 25
        x1hoja.Cells(fila, columna).Formula = "Laboratorio habilitado RNL 0029 - MGAP" & " - Certificado vigente al 31/08/2022"
        x1hoja.Cells(fila, columna).Formula = "Este informe no podrá ser reproducido total o parcialmente sin la autorización escrita de COLAVECO. Los resultados consignados se refieren exclusivamente a la muestra recibida." & vbCrLf _
            & "COLAVECO declina toda responsabilidad por el uso indebido o incorrecto que se hiciere a este informe, asi como el plan y procedimientos de muestreo aplicados por el cliente. Dra. Cecilia Abelenda (Directora Técnica)"
        x1hoja.Range("A" & fila, "G" & fila).WrapText = True
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        '************************************************************************
        fila = fila + 1
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(215, 219, 221)
        x1hoja.Cells(fila, columna).rowheight = 8
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
        x1hoja.Cells(fila, columna).Formula = "Fin del informe."
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 7
        'End If cambio 18/11/2020
        'Insert tabla preinformes**************************
        Dim pi As New dPreinformes
        Dim fechaactual As Date = Now()
        Dim _fecha As String
        _fecha = Format(fechaactual, "yyyy-MM-dd")
        pi.FICHA = nroficha
        pi = pi.buscar
        If Not pi Is Nothing Then
        Else
            Dim pi2 As New dPreinformes
            pi2.FICHA = nroficha
            pi2.TIPO = 3
            pi2.CREADO = 1
            pi2.FECHA = _fecha
            pi2.guardar()
            pi2 = Nothing
        End If
        pi = Nothing
        '***********************************************************
        x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas
        'PROTEGE LA HOJA DE EXCEL
        x1hoja.Protect(Password:="1582782", DrawingObjects:=True, _
        Contents:=True, Scenarios:=True)
        'GUARDA EL ARCHIVO DE EXCEL
        x1hoja.SaveAs("\\ROBOT\PREINFORMES\AGUA\" & nroficha & ".xls")
        x1app.Visible = True
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub informe_agua_funciona_si_hay_analisis_propios()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
        x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(1)
        x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(1)
        x1hoja.PageSetup.Orientation = (Excel.XlPageOrientation.xlPortrait)
        Dim sa As New dSolicitudAnalisis
        Dim cli As New dCliente
        Dim na As New dNuevoAnalisis
        Dim na3 As New dNuevoAnalisis
        Dim met As New dMetodos
        Dim lista As New ArrayList
        Dim lista2 As New ArrayList
        Dim lista3 As New ArrayList
        Dim acreditado As Integer = 0
        Dim acreditado2 As Integer = 0
        Dim xanalisis As Integer = 0
        Dim vec(xanalisis) As Integer
        Dim informefinal As Integer = 0
        Dim nombre_operador As String = ""
        Dim nombre_tecnico As String = ""
        Dim listademetodos As String = ""
        Dim listadeabreviaturas As String = ""
        Dim unit As Integer = 0
        Dim unt As Integer = 0
        Dim max As Integer = 0
        '*****************************
        nroficha = TextFicha.Text.Trim
        sa.ID = nroficha
        sa = sa.buscar
        lista = na.listarporfichamuestra(nroficha) 'LISTA LAS DISTINTAS MUESTRAS
        lista3 = na3.listarporficha3(nroficha) 'LISTA LOS DISTINTOS ANALISIS
        '**********************************************
        'ORDENA LOS DISTINTOS ANALISIS EN UN VECTOR
        If Not lista3 Is Nothing Then
            xanalisis = lista3.Count - 1
            ReDim vec(xanalisis)
            Dim i As Integer = 0
            For Each na3 In lista3
                vec(i) = na3.ANALISIS
                i = i + 1
            Next
        End If
        '***********************************************
        Dim fila As Integer
        Dim columna As Integer
        Dim fila_tope As Integer
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                fila = 1
                columna = 1
                'Poner Titulos
                columna = 2
                x1hoja.Cells(3, 1).columnwidth = 20
                x1hoja.Cells(3, 2).columnwidth = 20
                x1hoja.Cells(3, 3).columnwidth = 10
                x1hoja.Cells(3, 4).columnwidth = 10
                x1hoja.Cells(3, 5).columnwidth = 10
                x1hoja.Cells(3, 6).columnwidth = 10
                x1hoja.Cells(3, 7).columnwidth = 10
                fila = fila + 4
                columna = 1
                x1hoja.Range("A" & fila, "G" & fila).Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).Formula = "INFORME DE AGUA"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 12
                fila = fila + 1
                columna = 1
                x1hoja.Cells(fila, columna).Formula = "Nº Ficha: " & sa.ID
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 4
                x1hoja.Cells(fila, columna).Formula = "Fecha entrada: " & sa.FECHAINGRESO
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                cli.ID = sa.IDPRODUCTOR
                cli = cli.buscar
                x1hoja.Cells(fila, columna).Formula = "Cliente: " & cli.NOMBRE
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 4
                Dim nnaa As New dNuevoAnalisis
                Dim fechaproceso As String = ""
                Dim listannaa As New ArrayList
                listannaa = nnaa.listarporficha2(sa.ID)
                If Not listannaa Is Nothing Then
                    For Each nnaa In listannaa
                        fechaproceso = nnaa.FECHAPROCESO
                    Next
                End If
                nnaa = Nothing
                listannaa = Nothing
                x1hoja.Cells(fila, columna).Formula = "Fecha proceso: " & fechaproceso
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                If cli.DIRECCION <> "" Or cli.DIRECCION <> "No aportado" Then
                    x1hoja.Cells(fila, columna).Formula = "Dirección: " & cli.DIRECCION
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = columna + 4
                ElseIf cli.IDLOCALIDAD <> 999 Then
                    Dim loc As New dLocalidad
                    loc.ID = cli.IDLOCALIDAD
                    loc = loc.buscar
                    If Not loc Is Nothing Then
                        x1hoja.Cells(fila, columna).Formula = loc.NOMBRE
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 9
                        columna = columna + 4
                    End If
                ElseIf cli.IDDEPARTAMENTO <> 999 Then
                    Dim dep As New dDepartamento
                    dep.ID = cli.IDDEPARTAMENTO
                    dep = dep.buscar
                    If Not dep Is Nothing Then
                        x1hoja.Cells(fila, columna).Formula = dep.NOMBRE
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 9
                        columna = columna + 4
                    End If
                ElseIf cli.CELULAR <> "" Then
                    x1hoja.Cells(fila, columna).Formula = "Celular: " & cli.CELULAR
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = columna + 4
                Else
                    x1hoja.Cells(fila, columna).Formula = "No aportado"
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = columna + 4
                End If
                Dim fecha As Date = Now()
                Dim fecha2 As String = fecha.ToString("dd/MM/yyyy")
                x1hoja.Cells(fila, columna).Formula = "Fecha informe: " & fecha2
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                Dim mm As New dMuestras
                mm.ID = sa.IDMUESTRA
                mm = mm.buscar
                If Not mm Is Nothing Then
                    x1hoja.Cells(fila, columna).Formula = "Material recibido: " & mm.NOMBRE
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                Else
                    x1hoja.Cells(fila, columna).Formula = "Material recibido: "
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    fila = fila + 1
                End If
                x1hoja.Cells(fila, columna).Formula = "Total de muestras: " & sa.NMUESTRAS
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 4
                Dim c2 As New dCliente
                c2.ID = sa.IDTECNICO
                c2 = c2.buscar
                If Not c2 Is Nothing Then
                    x1hoja.Cells(fila, columna).Formula = "Técnico: " & c2.NOMBRE
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    fila = fila + 1
                    columna = 1
                Else
                    x1hoja.Cells(fila, columna).Formula = "Técnico: "
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    fila = fila + 1
                    columna = 1
                End If
                x1hoja.Cells(fila, columna).Formula = "Muestreo realizado por el cliente."
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 4
                x1hoja.Cells(fila, columna).Formula = "DICOSE: " & cli.DICOSE
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                x1hoja.Range("A" & fila, "G" & fila).Merge()
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).rowheight = 1
                fila = fila + 1
                x1hoja.Cells(fila, columna).rowheight = 3
                fila = fila + 2
                columna = 1
                '******************************************************************************************************
                fila_tope = fila
                fila = fila - 1
                Dim filax As Integer = fila_tope
                Dim columnax As Integer = 4
                For i = 1 To vec.Length
                    If lista.Count = 1 Then
                        x1hoja.Cells(filax, columnax).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(filax, columnax).Formula = "-"
                        x1hoja.Cells(filax, columnax).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(filax, columnax).VerticalAlignment = XlVAlign.xlVAlignTop
                        columnax = 4
                        filax = filax + 1
                    ElseIf lista.Count = 2 Then
                        x1hoja.Cells(filax, columnax).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(filax, columnax).Formula = "-"
                        x1hoja.Cells(filax, columnax).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(filax, columnax).VerticalAlignment = XlVAlign.xlVAlignTop
                        columnax = columnax + 1
                        x1hoja.Cells(filax, columnax).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(filax, columnax).Formula = "-"
                        x1hoja.Cells(filax, columnax).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(filax, columnax).VerticalAlignment = XlVAlign.xlVAlignTop
                        columnax = 4
                        filax = filax + 1
                    ElseIf lista.Count = 3 Then
                        x1hoja.Cells(filax, columnax).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(filax, columnax).Formula = "-"
                        x1hoja.Cells(filax, columnax).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(filax, columnax).VerticalAlignment = XlVAlign.xlVAlignTop
                        columnax = columnax + 1
                        x1hoja.Cells(filax, columnax).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(filax, columnax).Formula = "-"
                        x1hoja.Cells(filax, columnax).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(filax, columnax).VerticalAlignment = XlVAlign.xlVAlignTop
                        columnax = columnax + 1
                        x1hoja.Cells(filax, columnax).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(filax, columnax).Formula = "-"
                        x1hoja.Cells(filax, columnax).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(filax, columnax).VerticalAlignment = XlVAlign.xlVAlignTop
                        columnax = 4
                        filax = filax + 1
                    ElseIf lista.Count = 4 Then
                        x1hoja.Cells(filax, columnax).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(filax, columnax).Formula = "-"
                        x1hoja.Cells(filax, columnax).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(filax, columnax).VerticalAlignment = XlVAlign.xlVAlignTop
                        columnax = columnax + 1
                        x1hoja.Cells(filax, columnax).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(filax, columnax).Formula = "-"
                        x1hoja.Cells(filax, columnax).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(filax, columnax).VerticalAlignment = XlVAlign.xlVAlignTop
                        columnax = columnax + 1
                        x1hoja.Cells(filax, columnax).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(filax, columnax).Formula = "-"
                        x1hoja.Cells(filax, columnax).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(filax, columnax).VerticalAlignment = XlVAlign.xlVAlignTop
                        columnax = columnax + 1
                        x1hoja.Cells(filax, columnax).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(filax, columnax).Formula = "-"
                        x1hoja.Cells(filax, columnax).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(filax, columnax).VerticalAlignment = XlVAlign.xlVAlignTop
                        columnax = 4
                        filax = filax + 1
                    End If
                Next
                columna = 2
                x1hoja.Cells(fila, columna).Formula = "Métodos"
                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).WrapText = True
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                x1hoja.Cells(fila, columna).Formula = "Valor permitido"
                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).WrapText = True
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                For Each na In lista
                    x1hoja.Cells(fila, columna).Formula = na.MUESTRA
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                Next
                '****************************************************************************************************************************************

                fila = fila + 1
                Dim cuenta As Integer = 1
                Dim detallemuestras As String = ""
                Dim idoperador As Integer = 0
                Dim operador As String = ""
                Dim iu As New dUsuario
                iu.ID = idoperador
                iu = iu.buscar
                If Not iu Is Nothing Then
                    operador = iu.NOMBRE
                End If

                fila_tope = fila
                For Each na In lista3
                    If na.ANALISIS = 394 Then
                        unit = 1
                    End If
                    If na.ANALISIS = 264 Then
                        unt = 1
                        max = 1
                    End If
                    If na.ANALISIS = 265 Then
                        max = 1
                    End If
                    If na.ANALISIS = 266 Then
                        max = 1
                    End If
                    Dim u As New dUsuario
                    u.ID = na.OPERADOR
                    u = u.buscar
                    If Not u Is Nothing Then
                        nombre_operador = u.NOMBRE
                    End If
                    Dim lp As New dListaPrecios
                    lp.ID = na.ANALISIS
                    lp = lp.buscar
                    If lp.ABREVIATURA <> lp.DESCTECNICA Then
                        listadeabreviaturas = listadeabreviaturas & lp.ABREVIATURA & " - " & lp.DESCTECNICA & " / "
                    End If
                    Dim l As New dListaPrecios
                    l.ID = na.ANALISIS
                    l = l.buscar
                    Dim au As New dAnalisisUnidad
                    au.ID = na.UNIDAD
                    au = au.buscar
                    Dim unidad As String = ""
                    If Not au Is Nothing Then
                        unidad = au.UNIDAD
                    Else
                        unidad = ""
                    End If
                    columna = 1
                    If Not l Is Nothing Then
                        If l.ACREDITADO = 1 Then
                            x1hoja.Cells(fila, columna).Formula = l.ABREVIATURA & " " & unidad
                            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                            x1hoja.Cells(fila, columna).WrapText = True
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            acreditado = 1
                            fila = fila + 1
                        Else
                            x1hoja.Cells(fila, columna).Formula = "* " & l.ABREVIATURA & " " & unidad
                            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                            x1hoja.Cells(fila, columna).WrapText = True
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            fila = fila + 1
                        End If
                    End If
                    l = Nothing
                    lp = Nothing
                    u = Nothing
                Next
                'METODOS Y REFERENCIAS ******************************************************************
                fila = fila_tope
                columna = 2
                For Each na In lista3
                    Dim r As New dReferencias
                    r.ANALISIS = na.ANALISIS
                    r = r.buscar
                    If Not r Is Nothing Then
                        Dim a As New dAgua
                        a.FICHA = nroficha
                        a = a.buscarxficha
                        If Not a Is Nothing Then
                            If a.ENVASADA = 0 Then
                                Dim lm As New dListaMetodos
                                lm.ANALISIS = na.ANALISIS
                                lm = lm.buscarxanalisis
                                If Not lm Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = lm.METODO
                                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8

                                    columna = columna + 1
                                    x1hoja.Cells(fila, columna).Formula = r.REFERENCIA1
                                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = 2
                                End If
                            Else
                                Dim lm As New dListaMetodos
                                lm.ANALISIS = na.ANALISIS
                                lm = lm.buscarxanalisis
                                If Not lm Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = lm.METODO
                                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8

                                    columna = columna + 1
                                    x1hoja.Cells(fila, columna).Formula = r.REFERENCIA2
                                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = 2
                                End If
                            End If
                        End If
                    Else '**************************************************************************
                        Dim a As New dAgua
                        a.FICHA = nroficha
                        a = a.buscarxficha
                        If Not a Is Nothing Then
                            If a.ENVASADA = 0 Then
                                Dim lm As New dListaMetodos
                                lm.ANALISIS = na.ANALISIS
                                lm = lm.buscarxanalisis
                                If Not lm Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = lm.METODO
                                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8

                                    columna = columna + 1
                                    x1hoja.Cells(fila, columna).Formula = "-"
                                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = 2
                                End If
                            Else
                                Dim lm As New dListaMetodos
                                lm.ANALISIS = na.ANALISIS
                                lm = lm.buscarxanalisis
                                If Not lm Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = lm.METODO
                                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8

                                    columna = columna + 1
                                    x1hoja.Cells(fila, columna).Formula = "-"
                                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = 2
                                End If
                            End If
                        End If
                        '************************************************************************************************
                    End If
                    fila = fila + 1
                Next
                '*******************************************************************************
            End If
            columna = 4
            For Each na In lista

                fila = fila_tope

                Dim x As Integer = 0
                Dim n As Integer = 0
                x = vec.Length
                Dim na2 As New dNuevoAnalisis
                lista2 = na2.listarpormuestra(nroficha, na.MUESTRA)
                For Each na2 In lista2
                    Dim ret As Integer = Array.IndexOf(vec, na2.ANALISIS)
                    fila = fila + ret
                    If na2.ANALISIS = 265 Then
                        If na2.RESULTADO <> "" Then
                            Dim valornitrato As Double = na2.RESULTADO / 4.43
                            x1hoja.Cells(fila, columna).Formula = Math.Round(valornitrato, 2)
                            'x1hoja.Cells(fila, columna).Formula = na2.RESULTADO & " " & na2.RESULTADO2
                            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).WrapText = True
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            fila = fila - ret
                        Else
                            Dim valornitrato As Double = na2.RESULTADO2
                            x1hoja.Cells(fila, columna).Formula = Math.Round(valornitrato, 2)
                            'x1hoja.Cells(fila, columna).Formula = na2.RESULTADO & " " & na2.RESULTADO2
                            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).WrapText = True
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            fila = fila - ret
                        End If
                    Else
                        x1hoja.Cells(fila, columna).Formula = na2.RESULTADO & " " & na2.RESULTADO2
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        fila = fila - ret

                    End If

                Next
                columna = columna + 1
            Next

            fila = fila_tope
            fila = fila - 1
            columna = 1

            columna = 1
            fila = fila + vec.Length
            fila = fila + 1
            x1hoja.Cells(fila, columna).rowheight = 3
            fila = fila + 1
            x1hoja.Range("A" & fila, "G" & fila).Merge()
            x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).rowheight = 1
            fila = fila + 1
            x1hoja.Cells(fila, columna).Formula = "Abreviaturas"
            x1hoja.Cells(fila, columna).Font.Bold = True
            fila = fila + 1
            If unt = 1 Then
                listadeabreviaturas = listadeabreviaturas & " " & "U.N.T. - Unidades Nefelométricas de Turbiedad "
            End If
            If max = 1 Then
                listadeabreviaturas = listadeabreviaturas & " / " & "Max - Máximo permitido"
            End If
            x1hoja.Cells(fila, columna).rowheight = 30
            x1hoja.Cells(fila, columna).Formula = listadeabreviaturas
            x1hoja.Range("A" & fila, "G" & fila).WrapText = True
            x1hoja.Range("A" & fila, "G" & fila).Merge()
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Size = 7
            fila = fila + 1

            'DATOS DE LA FUENTE ************************************************************************************************
            x1hoja.Cells(fila, columna).Formula = "Datos de la fuente:"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            columna = 1
            fila = fila + 1
            Dim id As Long = sa.ID
            Dim a1 As New dAgua
            a1.ID = id
            a1 = a1.buscar()
            Dim tp As New dTipoPozo
            tp.ID = a1.IDTIPOPOZO
            If a1.IDTIPOPOZO <> 0 Then
                tp = tp.buscar()
            End If
            Dim mue As New dMuestraExtraida
            mue.ID = a1.IDMUESTRAEXTRAIDA
            mue = mue.buscar()
            Dim mfc As New dMuestraFueraCondicion
            mfc.ID = a1.IDMUESTRAFUERACONDICION
            mfc = mfc.buscar()
            Dim at As New dAguaTratada
            at.ID = a1.IDAGUATRATADA
            at = at.buscar()
            Dim ec As New dEstadoConservacion
            ec.ID = a1.IDESTADODECONSERVACION
            ec = ec.buscar()
            Dim textoMO As String
            If a1.MUESTRAOFICIAL = 0 Then
                textoMO = "No"
            Else
                textoMO = "Si"
            End If
            Dim textox As String = ""

            textox = "Tipo pozo:" & " " & tp.NOMBRE & " / " & "Antiguedad:" & " " & a1.ANTIGUEDAD & " / " & "Distancia pozo negro:" & " " & a1.DISTANCIAPOZONEGRO & " / " & "Distancia tambo:" & " " & a1.DISTANCIATAMBO & " / " & "Estado de conservación:" & " " & ec.NOMBRE & " / " & "Muestra extraída de:" & " " & mue.NOMBRE & " / " & "Muestra fuera de condición:" & " " & mfc.NOMBRE & " / " & "Profundidad:" & " " & a1.PROFUNDIDAD & " / " & "Agua tratada:" & " " & at.NOMBRE

            x1hoja.Cells(fila, columna).rowheight = 30
            x1hoja.Cells(fila, columna).Formula = textox
            x1hoja.Range("A" & fila, "G" & fila).WrapText = True
            x1hoja.Range("A" & fila, "G" & fila).Merge()
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Size = 7
            fila = fila + 1
            x1hoja.Cells(fila, columna).Formula = "Temperatura de arribo de la/s muestra/s"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 8
            columna = 3
            If sa.TEMPERATURA > 8 Then
                x1hoja.Cells(fila, columna).Formula = sa.TEMPERATURA & " " & "°C" & " " & "(Proceso autorizado por cliente)"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = 1
                fila = fila + 1
            Else
                x1hoja.Cells(fila, columna).Formula = sa.TEMPERATURA & " " & "°C"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = 1
                fila = fila + 1
            End If
            If textoMO = "Si" Then
                x1hoja.Cells(fila, columna).Formula = "Muestra oficial M.G.A.P.:" & " " & textoMO
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
            End If

            '*** OBSERVACIONES **************************************************
            If sa.OBSERVACIONES <> "" Then
                x1hoja.Cells(fila, columna).rowheight = 25
                x1hoja.Cells(fila, columna).Formula = "Observaciones: " & sa.OBSERVACIONES
                x1hoja.Range("A" & fila, "G" & fila).WrapText = True
                x1hoja.Range("A" & fila, "G" & fila).Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Size = 8
                fila = fila + 1
            End If
            '********************************************************************
            x1hoja.Cells(fila, columna).Formula = "(*)Ensayo no acreditado ISO 17025 O.U.A."
            x1hoja.Cells(fila, columna).Font.Size = 8
            x1hoja.Cells(fila, columna).Font.Bold = True
            columna = columna + 2
            fila = fila + 2
            x1hoja.Cells(fila, columna).Formula = "Referencias:"
            x1hoja.Cells(fila, columna).Font.Size = 8
            x1hoja.Cells(fila, columna).Font.Bold = True
            fila = fila + 1
            x1hoja.Cells(fila, columna).Formula = "-"
            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).Font.Bold = False
            columna = columna + 1
            x1hoja.Cells(fila, columna).Formula = "Análisis no requerido."
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 7
            fila = fila + 1
            columna = columna - 1
            x1hoja.Cells(fila, columna).Formula = "Valor permitido"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 7
            columna = columna + 1
            Dim texto As String = ""
            If unit = 1 Then
                texto = "UNIT 833:2008"
            Else
                texto = "Decreto 315/94 R.B.N. y sus modificaciones"
            End If
            x1hoja.Cells(fila, columna).Formula = "Según: " & texto
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 7

            columna = 1
            'CABEZAL CON O SIN LOGO OUA
            If acreditado = 1 Then
                x1hoja.Shapes.AddPicture("c:\Debug\encabezado_con_oua2.png", _
        Microsoft.Office.Core.MsoTriState.msoFalse, _
        Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 452, 42)
            Else
                x1hoja.Shapes.AddPicture("c:\Debug\encabezado_sin_oua2.png", _
        Microsoft.Office.Core.MsoTriState.msoFalse, _
        Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 452, 42)
            End If

            fila = fila - 4
            columna = columna + 4
            x1hoja.Cells(fila, columna).Formula = "Operador: " & nombre_operador
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 3
            columna = 1
            fila = fila + 2

            'ANALISIS TERCERIZADOS***************************************************
            Dim at2 As New dAnalisisTercerizado
            Dim listaat As New ArrayList
            listaat = at2.listarporficha4(nroficha)
            If Not listaat Is Nothing Then
                x1hoja.Cells(fila, columna).Formula = "ANÁLISIS TERCERIZADOS"
                x1hoja.Range("A" & fila, "G" & fila).Merge()
                x1hoja.Cells(fila, columna).Interior.Color = RGB(215, 219, 221)
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Muestra"
                x1hoja.Cells(fila, columna).WrapText = True
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                x1hoja.Cells(fila, columna).Formula = "Análisis"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                x1hoja.Cells(fila, columna).Formula = "Resultado"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                x1hoja.Cells(fila, columna).Formula = "Unidad"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                x1hoja.Cells(fila, columna).Formula = "Método"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                x1hoja.Cells(fila, columna).Formula = "Laboratorio"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = 1
                fila = fila + 1
                For Each at2 In listaat
                    x1hoja.Cells(fila, columna).Formula = at2.MUESTRA
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    Dim att As New dAnalisisTercerizadoTipo
                    att.ID = at2.ANALISIS
                    att = att.buscar
                    If Not att Is Nothing Then
                        x1hoja.Cells(fila, columna).Formula = att.NOMBRE
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).Formula = ""
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    End If
                    x1hoja.Cells(fila, columna).Formula = at2.RESULTADO
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = at2.UNIDAD
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = at2.METODO
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    Dim ol As New dOtrosLaboratorios
                    ol.ID = at2.LABORATORIO
                    ol = ol.buscar
                    If Not ol Is Nothing Then
                        x1hoja.Cells(fila, columna).Formula = ol.NOMBRE
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = 1
                        fila = fila + 1
                    Else
                        x1hoja.Cells(fila, columna).Formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = 1
                        fila = fila + 1
                    End If
                Next
                fila = fila + 1
            End If
            '************************************************************************************************************
            '*** PONER FIRMA ********************************************************
            x1libro.Worksheets(1).cells(fila, columna).select()
            x1libro.ActiveSheet.pictures.Insert("c:\Debug\cecilia.jpg").select()
            x1libro.Worksheets(1).cells(2, 1).select()
            fila = fila + 4
            columna = 1
            fila = fila + 1
            x1hoja.Range("A" & fila, "G" & fila).WrapText = True
            x1hoja.Range("A" & fila, "G" & fila).Merge()
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Size = 8
            fila = fila + 1

            '*** PIE DE PAGINA ******************************************************
            x1hoja.Cells(fila, columna).rowheight = 25
            x1hoja.Cells(fila, columna).Formula = "Laboratorio habilitado RNL 0029 - MGAP" & " - Certificado vigente al 31/08/2022"
            x1hoja.Cells(fila, columna).Formula = "Este informe no podrá ser reproducido total o parcialmente sin la autorización escrita de COLAVECO. Los resultados consignados se refieren exclusivamente a la muestra recibida." & vbCrLf _
                & "COLAVECO declina toda responsabilidad por el uso indebido o incorrecto que se hiciere a este informe, asi como el plan y procedimientos de muestreo aplicados por el cliente. Dra. Cecilia Abelenda (Directora Técnica)"
            x1hoja.Range("A" & fila, "G" & fila).WrapText = True
            x1hoja.Range("A" & fila, "G" & fila).Merge()
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Size = 6
            '************************************************************************
            fila = fila + 1
            x1hoja.Range("A" & fila, "G" & fila).Merge()
            x1hoja.Cells(fila, columna).Interior.Color = RGB(215, 219, 221)
            x1hoja.Cells(fila, columna).rowheight = 8
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).Formula = "Fin del informe."
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 7
        End If
        'Insert tabla preinformes**************************
        Dim pi As New dPreinformes
        Dim fechaactual As Date = Now()
        Dim _fecha As String
        _fecha = Format(fechaactual, "yyyy-MM-dd")
        pi.FICHA = nroficha
        pi = pi.buscar
        If Not pi Is Nothing Then
        Else
            Dim pi2 As New dPreinformes
            pi2.FICHA = nroficha
            pi2.TIPO = 3
            pi2.CREADO = 1
            pi2.FECHA = _fecha
            pi2.guardar()
            pi2 = Nothing
        End If
        pi = Nothing
        '***********************************************************
        x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas
        'PROTEGE LA HOJA DE EXCEL
        x1hoja.Protect(Password:="1582782", DrawingObjects:=True, _
        Contents:=True, Scenarios:=True)
        'GUARDA EL ARCHIVO DE EXCEL
        x1hoja.SaveAs("\\ROBOT\PREINFORMES\AGUA\" & nroficha & ".xls")
        x1app.Visible = True
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub crea_informe_control()
        Dim idsol As Long = TextFicha.Text.Trim
        Dim Arch As String
        Arch = "\\ROBOT\PREINFORMES\CONTROL\p" & idsol & ".xls"
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Open(Arch), Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
        x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(1)
        x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(1)
        'x1hoja.PageSetup.Orientation = (Excel.XlPageOrientation.xlLandscape)
        Dim c As New dControl
        Dim sa As New dSolicitudAnalisis
        Dim pro As New dCliente
        Dim tec As New dCliente
        Dim lista As New ArrayList
        Dim lista2 As New ArrayList
        Dim lista3 As New ArrayList
        '*****************************
        sa.ID = idsol
        sa = sa.buscar
        '*****************************
        Dim fila As Integer
        Dim columna As Integer
        fila = 1
        columna = 2
        '********************************************************************
        'CABEZAL CON O SIN LOGO OUA
        Dim acreditado As Integer = 1
        If acreditado = 1 Then
            x1hoja.Shapes.AddPicture("c:\Debug\encabezado_con_oua2.png", _
     Microsoft.Office.Core.MsoTriState.msoFalse, _
     Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 452, 42)
        Else
            x1hoja.Shapes.AddPicture("c:\Debug\encabezado_sin_oua2.png", _
     Microsoft.Office.Core.MsoTriState.msoFalse, _
     Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 452, 42)
        End If
        x1hoja.Cells(1, 1).columnwidth = 6
        x1hoja.Cells(1, 2).columnwidth = 5
        x1hoja.Cells(1, 3).columnwidth = 5
        x1hoja.Cells(1, 4).columnwidth = 5
        x1hoja.Cells(1, 5).columnwidth = 5
        x1hoja.Cells(1, 6).columnwidth = 5
        x1hoja.Cells(1, 7).columnwidth = 5
        x1hoja.Cells(1, 8).columnwidth = 2.57
        x1hoja.Cells(1, 9).columnwidth = 6
        x1hoja.Cells(1, 10).columnwidth = 5
        x1hoja.Cells(1, 11).columnwidth = 5
        x1hoja.Cells(1, 12).columnwidth = 5
        x1hoja.Cells(1, 13).columnwidth = 5
        x1hoja.Cells(1, 14).columnwidth = 5
        x1hoja.Cells(1, 15).columnwidth = 5
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
        x1hoja.Range("H8", "N8").Merge()
        x1hoja.Range("H8", "N8").Borders.Color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).formula = "R. Celular x 1000cel/mL (Mét. IR - ISO 13366-2:2006)"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
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
        x1hoja.Range("H9", "N9").Merge()
        x1hoja.Range("H9", "N9").Borders.Color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).formula = "Gr, Pr, Lc* % peso/vol.(Mét. IR - ISO 9622 - IDF 141:2013)"
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
        x1hoja.Range("H10", "N10").Merge()
        x1hoja.Range("H10", "N10").Borders.Color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).formula = "MUN* mg/dL (Mét. IR - Boletín FIL 393:2003"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).Formula = "Fecha proceso:"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 7
        columna = columna + 2
        x1hoja.Range("C11", "D11").Merge()
        Dim fecha As Date = Now()
        Dim fecha2 As String = fecha.ToString("dd/MM/yyyy")
        Dim cx As New dControl
        Dim listacx As New ArrayList
        listacx = cx.listarfechaproceso(sa.ID)
        If Not listacx Is Nothing Then
            For Each cx In listacx
                x1hoja.Cells(fila, columna).formula = cx.FECHA
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 5
            Next
        Else
            x1hoja.Cells(fila, columna).formula = fecha2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Size = 8
            columna = columna + 5
        End If
        cx = Nothing
        listacx = Nothing
        x1hoja.Cells(fila, columna).formula = "Gr = Grasa, Pr = Proteina, Lc = Lactosa"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).Formula = "Fecha emisión:"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 7
        columna = columna + 2
        x1hoja.Range("C12", "D12").Merge()
        x1hoja.Cells(fila, columna).formula = fecha2
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        columna = columna + 5
        x1hoja.Cells(fila, columna).formula = "MUN = Nitrogeno ureico, Rc = Recuento celular"
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
        If idparatecnico5 = 1 Then
            paratecnico = paratecnico + "Virginia Ferreira - "
        End If
        If paratecnico <> "" Then
            x1hoja.Cells(fila, columna).formula = paratecnico
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Size = 8
        Else
            x1hoja.Cells(fila, columna).formula = ""
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Size = 8
        End If
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 7
        columna = columna + 5
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).formula = "* Ensayos no acreditados ISO 17025 por OUA"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        fila = fila + 2
        columna = 1
        lista = c.listarporsolicitud(idsol)
        lista2 = c.listarporrc(idsol)
        Dim libreinfeccion As Integer = 0
        Dim posibleinfeccion As Integer = 0
        Dim probableinfeccion As Integer = 0
        For Each c In lista2
            If c.RC <= 200 Then
                libreinfeccion = libreinfeccion + 1
            ElseIf c.RC > 200 Then
                probableinfeccion = probableinfeccion + 1
            End If
        Next
        fila = lista.Count + 18
        '***CALCULO PRECIO NUEVO ***************************************
        Dim ti As Integer = 0
        Dim sti As Integer = 0
        Dim ficha As Long = 0
        Dim muestrastotales As Integer = 0
        ficha = idsol
        sa.ID = idsol
        sa = sa.buscar
        If Not sa Is Nothing Then
            ti = sa.IDTIPOINFORME
            sti = sa.IDSUBINFORME
        End If
        Dim listamuestras As New ArrayList
        listamuestras = c.listarporsolicitud(idsol)
        muestrastotales = listamuestras.Count
        Dim minimomuestras As Integer = 0
        '*** CUENTA MUESTRAS NO APTAS ***************************************
        Dim mna As New dMuestrasNoAptas
        Dim cuenta_mna As Integer = 0
        Dim cuenta_rep As Integer = 0
        Dim faltan As Integer = 0
        lista3 = mna.listarporficha(idsol)
        If Not lista3 Is Nothing Then
            If lista3.Count > 0 Then
                For Each mna In lista3
                    If mna.MOTIVO = 8 Then
                        cuenta_rep = cuenta_rep + mna.CANTIDAD
                    End If
                    If mna.MOTIVO = 4 Or mna.MOTIVO = 6 Or mna.MOTIVO = 10 Then
                        faltan = faltan + mna.CANTIDAD
                    End If
                    If mna.MOTIVO = 1 Or mna.MOTIVO = 2 Or mna.MOTIVO = 3 Or mna.MOTIVO = 5 Or mna.MOTIVO = 7 Or mna.MOTIVO = 9 Then
                        cuenta_mna = cuenta_mna + mna.CANTIDAD
                    End If
                Next
            End If
        End If
        Dim muestrasanalizadas As Integer = 0
        muestrasanalizadas = muestrastotales - cuenta_mna
        muestrasanalizadas = muestrasanalizadas - faltan
        '********************************************************************
        Dim total1 As Double = 0
        Dim total2 As Double = 0
        Dim total3 As Double = 0
        Dim total4 As Double = 0
        Dim total As Double = 0
        Dim lp As New dListaPrecios
        Dim idrc_comp As Integer = 116
        Dim idrc_comp_urea As Integer = 117
        Dim idrc_comp_caseina As Integer = 157
        Dim idrc_comp_urea_caseina As Integer = 158
        Dim id_noprocesadas As Integer = 224
        Dim idtimbre As Integer = 86
        Dim preciorc_comp As Double
        Dim preciorc_comp_urea As Double
        Dim preciorc_comp_caseina As Double
        Dim preciorc_comp_urea_caseina As Double
        Dim precio_noprocesadas As Double
        Dim preciotimbre As Double
        Dim cli As New dCliente
        Dim precio As Integer = 0
        cli.ID = sa.IDPRODUCTOR
        cli = cli.buscar
        If Not cli Is Nothing Then
            precio = cli.FAC_LISTA
        End If
        If precio = 1 Then
            lp.ID = idrc_comp
            lp = lp.buscar
            preciorc_comp = lp.PRECIO1
            lp.ID = idrc_comp_urea
            lp = lp.buscar
            preciorc_comp_urea = lp.PRECIO1
            lp.ID = idrc_comp_caseina
            lp = lp.buscar
            preciorc_comp_caseina = lp.PRECIO1
            lp.ID = idrc_comp_urea_caseina
            lp = lp.buscar
            preciorc_comp_urea_caseina = lp.PRECIO1
        ElseIf precio = 2 Then
            lp.ID = idrc_comp
            lp = lp.buscar
            preciorc_comp = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciorc_comp = lp.PRECIO1
            End If
            lp.ID = idrc_comp_urea
            lp = lp.buscar
            preciorc_comp_urea = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciorc_comp_urea = lp.PRECIO1
            End If
            lp.ID = idrc_comp_caseina
            lp = lp.buscar
            preciorc_comp_caseina = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciorc_comp_caseina = lp.PRECIO1
            End If
            lp.ID = idrc_comp_urea_caseina
            lp = lp.buscar
            preciorc_comp_urea_caseina = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciorc_comp_urea_caseina = lp.PRECIO1
            End If
        ElseIf precio = 3 Then
            lp.ID = idrc_comp
            lp = lp.buscar
            preciorc_comp = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciorc_comp = lp.PRECIO1
            End If
            lp.ID = idrc_comp_urea
            lp = lp.buscar
            preciorc_comp_urea = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciorc_comp_urea = lp.PRECIO1
            End If
            lp.ID = idrc_comp_caseina
            lp = lp.buscar
            preciorc_comp_caseina = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciorc_comp_caseina = lp.PRECIO1
            End If
            lp.ID = idrc_comp_urea_caseina
            lp = lp.buscar
            preciorc_comp_urea_caseina = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciorc_comp_urea_caseina = lp.PRECIO1
            End If
        ElseIf precio = 4 Then
            lp.ID = idrc_comp
            lp = lp.buscar
            preciorc_comp = lp.PRECIO4
            lp.ID = idrc_comp_urea
            lp = lp.buscar
            preciorc_comp_urea = lp.PRECIO4
            lp.ID = idrc_comp_caseina
            lp = lp.buscar
            preciorc_comp_caseina = lp.PRECIO4
            lp.ID = idrc_comp_urea_caseina
            lp = lp.buscar
            preciorc_comp_urea_caseina = lp.PRECIO4
        ElseIf precio = 5 Then
            lp.ID = idrc_comp
            lp = lp.buscar
            preciorc_comp = lp.PRECIO5
            lp.ID = idrc_comp_urea
            lp = lp.buscar
            preciorc_comp_urea = lp.PRECIO5
            lp.ID = idrc_comp_caseina
            lp = lp.buscar
            preciorc_comp_caseina = lp.PRECIO5
            lp.ID = idrc_comp_urea_caseina
            lp = lp.buscar
            preciorc_comp_urea_caseina = lp.PRECIO5
        ElseIf precio = 6 Then
            lp.ID = idrc_comp
            lp = lp.buscar
            preciorc_comp = lp.PRECIO6
            lp.ID = idrc_comp_urea
            lp = lp.buscar
            preciorc_comp_urea = lp.PRECIO6
            lp.ID = idrc_comp_caseina
            lp = lp.buscar
            preciorc_comp_caseina = lp.PRECIO6
            lp.ID = idrc_comp_urea_caseina
            lp = lp.buscar
            preciorc_comp_urea_caseina = lp.PRECIO6
        ElseIf precio = 7 Then
            lp.ID = idrc_comp
            lp = lp.buscar
            preciorc_comp = lp.PRECIO7
            lp.ID = idrc_comp_urea
            lp = lp.buscar
            preciorc_comp_urea = lp.PRECIO7
            lp.ID = idrc_comp_caseina
            lp = lp.buscar
            preciorc_comp_caseina = lp.PRECIO7
            lp.ID = idrc_comp_urea_caseina
            lp = lp.buscar
            preciorc_comp_urea_caseina = lp.PRECIO7
        End If
        lp.ID = id_noprocesadas
        lp = lp.buscar
        precio_noprocesadas = lp.PRECIO1
        lp.ID = idtimbre
        lp = lp.buscar
        preciotimbre = lp.PRECIO1
        If muestrasanalizadas > 0 And muestrasanalizadas < 20 Then
            muestrasanalizadas = 20
        End If
        Dim subtipo As Integer
        subtipo = sti
        If subtipo = 1 Then
            total1 = muestrasanalizadas * preciorc_comp
        ElseIf subtipo = 32 Then
            total2 = muestrasanalizadas * preciorc_comp_urea
        ElseIf subtipo = 53 Then
            total3 = muestrasanalizadas * preciorc_comp_caseina
        ElseIf subtipo = 54 Then
            total4 = muestrasanalizadas * preciorc_comp_urea_caseina
        End If
        Dim analisis As Integer = 0
        Dim precio1 As Double = 0
        Dim precio2 As Double = 0
        Dim precio3 As Double = 0
        Dim precio4 As Double = 0
        Dim subtotal As Double = 0
        If sti = 1 Then
            analisis = 116
            precio1 = preciorc_comp
            Dim f1 As New dFacturacion
            f1.FICHA = ficha
            f1.CANTIDAD = muestrasanalizadas
            f1.ANALISIS = analisis
            f1.PRECIO = precio1
            f1.SUBTOTAL = total1
            f1.FACTURA = 0
            'f1.guardar(Usuario)
            total = total + total1
            f1 = Nothing
        ElseIf sti = 32 Then
            analisis = 117
            precio2 = preciorc_comp_urea
            Dim f2 As New dFacturacion
            f2.FICHA = ficha
            f2.CANTIDAD = muestrasanalizadas
            f2.ANALISIS = analisis
            f2.PRECIO = precio2
            f2.SUBTOTAL = total2
            f2.FACTURA = 0
            'f2.guardar(Usuario)
            total = total + total2
            f2 = Nothing
        ElseIf sti = 53 Then
            analisis = 157
            precio3 = preciorc_comp_caseina
            Dim f3 As New dFacturacion
            f3.FICHA = ficha
            f3.CANTIDAD = muestrasanalizadas
            f3.ANALISIS = analisis
            f3.PRECIO = precio3
            f3.SUBTOTAL = total3
            f3.FACTURA = 0
            'f3.guardar(Usuario)
            total = total + total3
            f3 = Nothing
        ElseIf sti = 54 Then
            analisis = 158
            precio4 = preciorc_comp_urea_caseina
            Dim f4 As New dFacturacion
            f4.FICHA = ficha
            f4.CANTIDAD = muestrasanalizadas
            f4.ANALISIS = analisis
            f4.PRECIO = precio4
            f4.SUBTOTAL = total4
            f4.FACTURA = 0
            'f4.guardar(Usuario)
            total = total + total4
            f4 = Nothing
        End If
        If cuenta_mna > 0 Then
            MsgBox("Hay muestras no aptas para hacer Nota de Crédito!")
            If sti = 1 Then
                'analisis = 116
                analisis = 224
                'precio1 = preciorc_comp * 0.5
                precio1 = precio_noprocesadas
                Dim f1 As New dFacturacion
                f1.FICHA = ficha
                f1.CANTIDAD = cuenta_mna
                f1.ANALISIS = analisis
                f1.PRECIO = precio1
                f1.SUBTOTAL = cuenta_mna * precio1
                f1.FACTURA = 0
                f1.guardar(Usuario)
                total = total + f1.SUBTOTAL
                f1 = Nothing
            ElseIf sti = 32 Then
                'analisis = 117
                analisis = 224
                'precio2 = preciorc_comp_urea * 0.5
                precio2 = precio_noprocesadas
                Dim f2 As New dFacturacion
                f2.FICHA = ficha
                f2.CANTIDAD = cuenta_mna
                f2.ANALISIS = analisis
                f2.PRECIO = precio2
                f2.SUBTOTAL = cuenta_mna * precio2
                f2.FACTURA = 0
                f2.guardar(Usuario)
                total = total + f2.SUBTOTAL
                f2 = Nothing
            ElseIf sti = 53 Then
                'analisis = 157
                analisis = 224
                'precio3 = preciorc_comp_caseina * 0.5
                precio3 = precio_noprocesadas
                Dim f3 As New dFacturacion
                f3.FICHA = ficha
                f3.CANTIDAD = cuenta_mna
                f3.ANALISIS = analisis
                f3.PRECIO = precio3
                f3.SUBTOTAL = cuenta_mna * precio3
                f3.FACTURA = 0
                f3.guardar(Usuario)
                total = total + f3.SUBTOTAL
                f3 = Nothing
            ElseIf sti = 54 Then
                'analisis = 158
                analisis = 224
                'precio4 = preciorc_comp_urea_caseina * 0.5
                precio4 = precio_noprocesadas
                Dim f4 As New dFacturacion
                f4.FICHA = ficha
                f4.CANTIDAD = cuenta_mna
                f4.ANALISIS = analisis
                f4.PRECIO = precio4
                f4.SUBTOTAL = cuenta_mna * precio4
                f4.FACTURA = 0
                f4.guardar(Usuario)
                total = total + f4.SUBTOTAL
                f4 = Nothing
            End If
        End If
        total = total + preciotimbre
        '***************************************************************
        '/* Actualiza el importe en la solicitud 
        Dim saimp As New dSolicitudAnalisis
        Dim importesa As Double = total
        saimp.ID = idsol
        saimp.actualizarimporte(importesa)
        '***************************************/
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
        x1hoja.Cells(fila, columna).formula = "Valor fuera de rango (<2.5 o >40 Proteína <2.5 o >5 Grasa %)"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 7
        x1hoja.Cells(fila, columna).Font.Bold = False
        columna = 1
        fila = fila + 1
        columna = columna + 6
        x1hoja.Cells(fila, columna).formula = "La indicación ''Fuera de rango''. está fuera del alcance de la acreditación"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 6
        x1hoja.Cells(fila, columna).Font.Bold = True
        columna = 1
        fila = fila + 1
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
        x1libro.Worksheets(1).cells(fila, columna).select()
        x1libro.ActiveSheet.pictures.Insert("c:\Debug\cecilia.jpg").select()
        x1libro.Worksheets(1).cells(2, 1).select()
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
        vallibreinfeccion = (libreinfeccion / muestrastotales) * 100
        valposibleinfeccion = (posibleinfeccion / muestrastotales) * 100
        valprobableinfeccion = (probableinfeccion / muestrastotales) * 100
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
        x1hoja.Cells(fila, columna).formula = "<=200: vacas sanas:" & " " & libreinfeccion & " " & "(" & Math.Round(vallibreinfeccion, 0) & " %" & ")"
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
        x1hoja.Cells(fila, columna).formula = ">200: vacas infectadas:" & " " & probableinfeccion & " " & "(" & Math.Round(valprobableinfeccion, 0) & " %" & ")"
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
        fila = fila + 1
        columna = 7
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).formula = "Valores de 30 en RC, corresponden a <=30 (menor o igual)"
        '** SI HAY MUESTRAS NO APTAS ***************************************
        If cuenta_mna > 0 Or cuenta_rep > 0 Then
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
        x1hoja.Cells(fila, columna).formula = "asi como el plan y procedimientos de muestreo aplicados por el cliente. Dra. Cecilia Abelenda (Directora Técnica)."
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 6
        fila = fila + 1
        x1hoja.Range("A" & fila, "O" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(215, 219, 221)
        x1hoja.Cells(fila, columna).rowheight = 8
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
        x1hoja.Cells(fila, columna).Formula = "Fin del informe."
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 7
        '**************************************************************************
        'PROTEGE LA HOJA DE EXCEL
        x1hoja.Protect(Password:="1582782", DrawingObjects:=True, _
            Contents:=True, Scenarios:=True)
        'GUARDA EL ARCHIVO DE EXCEL
        x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas
        'x1hoja.SaveAs("\\ROBOT\PREINFORMES\CONTROL\" & idsol & ".xls")
        x1app.Visible = True
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub informe_alimentos()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
        x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(1)
        x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(1)
        x1hoja.PageSetup.Orientation = (Excel.XlPageOrientation.xlLandscape)
        Dim sa As New dSolicitudAnalisis
        Dim cli As New dCliente
        Dim na As New dNuevoAnalisis
        Dim na3 As New dNuevoAnalisis
        Dim met As New dMetodos
        Dim lista As New ArrayList
        Dim lista2 As New ArrayList
        Dim lista3 As New ArrayList
        Dim acreditado As Integer = 0
        Dim acreditado2 As Integer = 0
        Dim xanalisis As Integer = 0
        Dim vec(xanalisis) As Integer
        Dim informefinal As Integer = 0
        Dim nombre_operador As String = ""
        Dim nombre_tecnico As String = "xxx xxx xxx xxx"
        Dim todos_acreditados As Integer = 1
        '*****************************
        nroficha = TextFicha.Text.Trim
        sa.ID = nroficha
        sa = sa.buscar
        lista = na.listarporfichamuestra(nroficha)
        lista3 = na3.listarporficha3(nroficha)
        '**********************************************
        If Not lista3 Is Nothing Then
            xanalisis = lista3.Count - 1
            ReDim vec(xanalisis)
            Dim i As Integer = 0
            For Each na3 In lista3
                vec(i) = na3.ANALISIS
                i = i + 1
            Next
        End If
        '***********************************************
        Dim fila As Integer
        Dim columna As Integer
        'If Not lista Is Nothing Then
        '    If lista.Count > 0 Then
        fila = 1
        columna = 1
        'Poner Titulos
        columna = 2
        x1hoja.Cells(3, 1).columnwidth = 30
        x1hoja.Cells(3, 2).columnwidth = 8
        x1hoja.Cells(3, 3).columnwidth = 8
        x1hoja.Cells(3, 4).columnwidth = 8
        x1hoja.Cells(3, 5).columnwidth = 8
        x1hoja.Cells(3, 6).columnwidth = 8
        x1hoja.Cells(3, 7).columnwidth = 8
        x1hoja.Cells(3, 8).columnwidth = 8
        x1hoja.Cells(3, 9).columnwidth = 8
        x1hoja.Cells(3, 10).columnwidth = 8
        x1hoja.Cells(3, 11).columnwidth = 8
        x1hoja.Cells(3, 12).columnwidth = 8
        x1hoja.Cells(3, 13).columnwidth = 8
        x1hoja.Cells(3, 14).columnwidth = 8
        x1hoja.Cells(3, 15).columnwidth = 8
        fila = fila + 4
        columna = 1
        x1hoja.Cells(fila, columna).rowheight = 3
        fila = fila + 1
        x1hoja.Range("A" & fila, "M" & fila).Merge()
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Formula = "INFORME DE ALIMENTOS E INDICADORES"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 12
        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).Formula = "Nº Ficha: " & sa.ID
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        columna = columna + 10
        x1hoja.Cells(fila, columna).Formula = "Fecha entrada: " & sa.FECHAINGRESO
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        fila = fila + 1
        columna = 1
        cli.ID = sa.IDPRODUCTOR
        cli = cli.buscar
        x1hoja.Cells(fila, columna).Formula = "Cliente: " & cli.NOMBRE
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        columna = columna + 10
        Dim nnaa As New dNuevoAnalisis
        Dim fechaproceso As String = ""
        Dim listannaa As New ArrayList
        listannaa = nnaa.listarporficha2(sa.ID)
        If Not listannaa Is Nothing Then
            For Each nnaa In listannaa
                fechaproceso = nnaa.FECHAPROCESO
            Next
        Else
            Dim atx As New dAnalisisTercerizado
            Dim listaatx As New ArrayList
            listaatx = atx.listarporficha4(nroficha)
            If Not listaatx Is Nothing Then
                For Each atx In listaatx
                    fechaproceso = atx.FECHAPROCESO
                Next
            End If
        End If
        nnaa = Nothing
        listannaa = Nothing
        x1hoja.Cells(fila, columna).Formula = "Fecha proceso: " & fechaproceso
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        fila = fila + 1
        columna = 1
        If cli.DIRECCION <> "" Or cli.DIRECCION <> "No aportado" Then
            x1hoja.Cells(fila, columna).Formula = "Dirección: " & cli.DIRECCION
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            columna = columna + 10
        ElseIf cli.IDLOCALIDAD <> 999 Then
            Dim loc As New dLocalidad
            loc.ID = cli.IDLOCALIDAD
            loc = loc.buscar
            If Not loc Is Nothing Then
                x1hoja.Cells(fila, columna).Formula = loc.NOMBRE
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 10
            End If
        ElseIf cli.IDDEPARTAMENTO <> 999 Then
            Dim dep As New dDepartamento
            dep.ID = cli.IDDEPARTAMENTO
            dep = dep.buscar
            If Not dep Is Nothing Then
                x1hoja.Cells(fila, columna).Formula = dep.NOMBRE
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 10
            End If
        ElseIf cli.CELULAR <> "" Then
            x1hoja.Cells(fila, columna).Formula = "Celular: " & cli.CELULAR
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            columna = columna + 10
        Else
            x1hoja.Cells(fila, columna).Formula = "No aportado"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            columna = columna + 10
        End If
        Dim fecha As Date = Now()
        Dim fecha2 As String = fecha.ToString("dd/MM/yyyy")
        x1hoja.Cells(fila, columna).Formula = "Fecha informe: " & fecha2
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        fila = fila + 1
        columna = 1
        Dim mm As New dMuestras
        mm.ID = sa.IDMUESTRA
        mm = mm.buscar
        If Not mm Is Nothing Then
            x1hoja.Cells(fila, columna).Formula = "Material recibido: " & mm.NOMBRE
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 1
        Else
            x1hoja.Cells(fila, columna).Formula = "Material recibido: "
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 2
        End If
        x1hoja.Cells(fila, columna).Formula = "Total de muestras: " & sa.NMUESTRAS
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        columna = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).Formula = "Temperatura de arribo de las muestras: " & sa.TEMPERATURA & " ºC"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        fila = fila + 1
        x1hoja.Cells(fila, columna).Formula = "Muestreo realizado por el cliente"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        columna = 1
        fila = fila + 1
        x1hoja.Range("A" & fila, "M" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).rowheight = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).rowheight = 3
        fila = fila + 1
        columna = 1
        Dim cuenta As Integer = 1
        Dim detallemuestras As String = ""
        Dim idoperador As Integer = 0
        Dim operador As String = ""
        Dim iu As New dUsuario
        iu.ID = idoperador
        iu = iu.buscar
        If Not iu Is Nothing Then
            operador = iu.NOMBRE
        End If
        If Not lista Is Nothing Then
            x1hoja.Cells(fila, columna).Formula = "Id. Muestra"
            x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeTop).Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeLeft).Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeRight).Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignBottom
            x1hoja.Cells(fila, columna).Font.Size = 8
            fila = fila + 1
            x1hoja.Cells(fila, columna).Formula = ""
            x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeBottom).Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeLeft).Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeRight).Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).Font.Size = 8
            columna = columna + 1
            fila = fila - 1
        End If
        Dim listademetodos As String = ""
        Dim listadeabreviaturas As String = ""
        If Not lista3 Is Nothing Then
            For Each na In lista3
                Dim u As New dUsuario
                u.ID = na.OPERADOR
                u = u.buscar
                If Not u Is Nothing Then
                    nombre_operador = u.NOMBRE
                End If
                Dim lp As New dListaPrecios
                lp.ID = na.ANALISIS
                lp = lp.buscar
                Dim lm As New dListaMetodos
                lm.ID = na.METODO
                lm = lm.buscar
                If Not lm Is Nothing Then
                    listademetodos = listademetodos & lp.DESCTECNICA & " - " & lm.METODO & " / "
                End If
                If lp.ABREVIATURA <> lp.DESCTECNICA Then
                    listadeabreviaturas = listadeabreviaturas & lp.ABREVIATURA & " - " & lp.DESCTECNICA & " / "
                End If
                Dim l As New dListaPrecios
                l.ID = na.ANALISIS
                l = l.buscar

                If Not l Is Nothing Then
                    If sa.LOGO = 1 Then
                        If l.ACREDITADO = 1 Then
                            x1hoja.Cells(fila, columna).Formula = l.ABREVIATURA
                            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                            x1hoja.Cells(fila, columna).WrapText = True
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            acreditado = 1
                            'SI ES ESTAF. COAG. POS. EN MATRIZ DIFERENTE A QUESO ***********************
                            If na.ANALISIS = 24 Then
                                If sa.IDMUESTRA <> 26 Then
                                    x1hoja.Cells(fila, columna).Formula = "* " & l.ABREVIATURA
                                End If
                            End If
                            '**************************************************************************
                        Else
                            x1hoja.Cells(fila, columna).Formula = "* " & l.ABREVIATURA
                            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                            x1hoja.Cells(fila, columna).WrapText = True
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            todos_acreditados = 0
                        End If
                    Else
                        x1hoja.Cells(fila, columna).Formula = l.ABREVIATURA
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        'SI ES ESTAF. COAG. POS. EN MATRIZ DIFERENTE A QUESO **********************
                        If na.ANALISIS = 24 Then
                            If sa.IDMUESTRA <> 26 Then
                                x1hoja.Cells(fila, columna).Formula = "* " & l.ABREVIATURA
                            End If
                        End If
                        '**************************************************************************
                    End If
                End If
        l = Nothing
        Dim au As New dAnalisisUnidad
        au.ID = na.UNIDAD
        au = au.buscar
        If Not au Is Nothing Then
            fila = fila + 1
            x1hoja.Cells(fila, columna).Formula = au.UNIDAD
            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).Font.Size = 6
            fila = fila - 1
            columna = columna + 1
        Else
            fila = fila + 1
            x1hoja.Cells(fila, columna).Formula = ""
            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).Font.Size = 6
            fila = fila - 1
            columna = columna + 1
        End If
        lp = Nothing
        lm = Nothing
        u = Nothing
            Next
        End If
        columna = 1
        fila = fila + 2
        If Not lista Is Nothing Then
            For Each na In lista
                x1hoja.Cells(fila, columna).Formula = na.DETALLEMUESTRA
                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).WrapText = True
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                Dim na2 As New dNuevoAnalisis
                lista2 = na2.listarpormuestra(nroficha, na.MUESTRA)
                For Each na2 In lista2
                    Dim ret As Integer = Array.IndexOf(vec, na2.ANALISIS)
                    columna = columna + ret
                    x1hoja.Cells(fila, columna).Formula = na2.RESULTADO & " " & na2.RESULTADO2
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    Dim a As New dAcreditacion
                    a.ANALISIS = na2.ANALISIS
                    a = a.buscar
                    columna = columna - ret
                Next
                columna = 1
                fila = fila + 1
            Next
        End If
        If Not lista Is Nothing Then
            x1hoja.Cells(fila, columna).rowheight = 3
            fila = fila + 1
            x1hoja.Range("A" & fila, "M" & fila).Merge()
            x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).rowheight = 1
            fila = fila + 1
            If todos_acreditados = 0 Then
                x1hoja.Cells(fila, columna).Formula = "(*)Ensayo no acreditado ISO 17025 O.U.A."
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                fila = fila + 1
            Else
                fila = fila + 1
            End If
            If listadeabreviaturas <> "" Then
                x1hoja.Cells(fila, columna).Formula = "Abreviaturas"
                x1hoja.Cells(fila, columna).Font.Bold = True
                fila = fila + 1
            End If
            x1hoja.Cells(fila, columna).rowheight = 30
            x1hoja.Cells(fila, columna).Formula = listadeabreviaturas
            x1hoja.Range("A" & fila, "M" & fila).WrapText = True
            x1hoja.Range("A" & fila, "M" & fila).Merge()
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Size = 7
            fila = fila + 1
            x1hoja.Cells(fila, columna).Formula = "Métodos"
            x1hoja.Cells(fila, columna).Font.Bold = True
            fila = fila + 1
            x1hoja.Cells(fila, columna).rowheight = 30
            x1hoja.Cells(fila, columna).Formula = listademetodos
            x1hoja.Range("A" & fila, "M" & fila).WrapText = True
            x1hoja.Range("A" & fila, "M" & fila).Merge()
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Size = 7
            fila = fila + 1
        End If
        '*** OBSERVACIONES **************************************************
        If sa.OBSERVACIONES <> "" Then
            x1hoja.Cells(fila, columna).rowheight = 25
            x1hoja.Cells(fila, columna).Formula = "Observaciones: " & sa.OBSERVACIONES
            x1hoja.Range("A" & fila, "M" & fila).WrapText = True
            x1hoja.Range("A" & fila, "M" & fila).Merge()
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Size = 8
            fila = fila + 1
        End If
        '********************************************************************
        If Not lista Is Nothing Then
            columna = columna + 10
            x1hoja.Cells(fila, columna).Formula = "Operador: " & nombre_operador
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 2
            columna = 1

        End If
        'CABEZAL CON O SIN LOGO OUA
        If sa.LOGO = 1 Then
            x1hoja.Shapes.AddPicture("c:\Debug\encabezado_con_oua2.png", _
         Microsoft.Office.Core.MsoTriState.msoFalse, _
         Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 700, 50)
        Else
            x1hoja.Shapes.AddPicture("c:\Debug\encabezado_sin_oua2.png", _
     Microsoft.Office.Core.MsoTriState.msoFalse, _
     Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 700, 50)
        End If
        'ANALISIS TERCERIZADOS***************************************************
        Dim at As New dAnalisisTercerizado
        Dim listaat As New ArrayList
        listaat = at.listarporficha4(nroficha)
        If Not listaat Is Nothing Then
            x1hoja.Cells(fila, columna).Formula = "ANÁLISIS TERCERIZADOS"
            x1hoja.Range("A" & fila, "M" & fila).Merge()
            x1hoja.Cells(fila, columna).Interior.Color = RGB(215, 219, 221)
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 10
            fila = fila + 1
            x1hoja.Cells(fila, columna).Formula = "Muestra"
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            columna = columna + 1
            x1hoja.Cells(fila, columna).Formula = "Análisis"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            columna = columna + 3
            x1hoja.Cells(fila, columna).Formula = "Resultado"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            columna = columna + 1
            x1hoja.Cells(fila, columna).Formula = "Unidad"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            columna = columna + 1
            x1hoja.Cells(fila, columna).Formula = "Método"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            columna = columna + 4
            x1hoja.Cells(fila, columna).Formula = "Laboratorio"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            columna = 1
            fila = fila + 1
            For Each at In listaat
                x1hoja.Cells(fila, columna).Formula = at.MUESTRA
                x1hoja.Cells(fila, columna).WrapText = True
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                Dim att As New dAnalisisTercerizadoTipo
                att.ID = at.ANALISIS
                att = att.buscar
                If Not att Is Nothing Then
                    x1hoja.Cells(fila, columna).Formula = att.NOMBRE
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 3
                Else
                    x1hoja.Cells(fila, columna).Formula = ""
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 3
                End If
                x1hoja.Cells(fila, columna).Formula = at.RESULTADO
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                x1hoja.Cells(fila, columna).Formula = at.UNIDAD
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                x1hoja.Cells(fila, columna).Formula = at.METODO
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 4
                Dim ol As New dOtrosLaboratorios
                ol.ID = at.LABORATORIO
                ol = ol.buscar
                If Not ol Is Nothing Then
                    x1hoja.Cells(fila, columna).Formula = ol.NOMBRE
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = 1
                    fila = fila + 1
                Else
                    x1hoja.Cells(fila, columna).Formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = 1
                    fila = fila + 1
                End If
            Next
            fila = fila + 1
        End If
        '*** PONER FIRMA ********************************************************
        x1libro.Worksheets(1).cells(fila, columna).select()
        x1libro.ActiveSheet.pictures.Insert("c:\Debug\cecilia.jpg").select()
        x1libro.Worksheets(1).cells(2, 1).select()
        fila = fila + 6
        columna = 1
        '*** PIE DE PAGINA ******************************************************
        x1hoja.Cells(fila, columna).rowheight = 25
        x1hoja.Cells(fila, columna).Formula = "Este informe no podrá ser reproducido total o parcialmente sin la autorización escrita de COLAVECO. Los resultados consignados se refieren exclusivamente a la muestra recibida." & vbCrLf _
            & "COLAVECO declina toda responsabilidad por el uso indebido o incorrecto que se hiciere a este informe, asi como el plan y procedimientos de muestreo aplicados por el cliente. Dra. Cecilia Abelenda (Directora Técnica)"
        x1hoja.Range("A" & fila, "M" & fila).WrapText = True
        x1hoja.Range("A" & fila, "M" & fila).Merge()
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        '************************************************************************
        fila = fila + 1
        x1hoja.Range("A" & fila, "M" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(215, 219, 221)
        x1hoja.Cells(fila, columna).rowheight = 8
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
        x1hoja.Cells(fila, columna).Formula = "Fin del informe."
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 7
        '    End If
        'End If
        'Insert tabla preinformes**************************
        Dim pi As New dPreinformes
        Dim fechaactual As Date = Now()
        Dim _fecha As String
        _fecha = Format(fechaactual, "yyyy-MM-dd")
        pi.FICHA = nroficha
        pi = pi.buscar
        If Not pi Is Nothing Then
        Else
            Dim pi2 As New dPreinformes
            pi2.FICHA = nroficha
            pi2.TIPO = 7
            pi2.CREADO = 1
            pi2.FECHA = _fecha
            pi2.guardar()
            pi2 = Nothing
        End If
        pi = Nothing
        '***********************************************************
        x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas
        'PROTEGE LA HOJA DE EXCEL
        x1hoja.Protect(Password:="1582782", DrawingObjects:=True, _
        Contents:=True, Scenarios:=True)
        'GUARDA EL ARCHIVO DE EXCEL
        x1hoja.SaveAs("\\ROBOT\PREINFORMES\ALIMENTOS\" & nroficha & ".xls")
        x1app.Visible = True
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub informe_toxicologia()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
        x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(1)
        x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(1)
        x1hoja.PageSetup.Orientation = (Excel.XlPageOrientation.xlLandscape)
        Dim sa As New dSolicitudAnalisis
        Dim cli As New dCliente
        Dim na As New dNuevoAnalisis
        Dim na3 As New dNuevoAnalisis
        Dim met As New dMetodos
        Dim lista As New ArrayList
        Dim lista2 As New ArrayList
        Dim lista3 As New ArrayList
        Dim acreditado As Integer = 0
        Dim acreditado2 As Integer = 0
        Dim xanalisis As Integer = 0
        Dim vec(xanalisis) As Integer
        Dim informefinal As Integer = 0
        Dim nombre_operador As String = ""
        Dim nombre_tecnico As String = "xxx xxx xxx xxx"
        Dim todos_acreditados As Integer = 1
        '*****************************
        nroficha = TextFicha.Text.Trim
        sa.ID = nroficha
        sa = sa.buscar
        lista = na.listarporfichamuestra(nroficha)
        lista3 = na3.listarporficha3(nroficha)
        '**********************************************
        If Not lista3 Is Nothing Then
            xanalisis = lista3.Count - 1
            ReDim vec(xanalisis)
            Dim i As Integer = 0
            For Each na3 In lista3
                vec(i) = na3.ANALISIS
                i = i + 1
            Next
        End If
        '***********************************************
        Dim fila As Integer
        Dim columna As Integer
        'If Not lista Is Nothing Then
        '    If lista.Count > 0 Then
        fila = 1
        columna = 1
        'Poner Titulos
        columna = 2
        x1hoja.Cells(3, 1).columnwidth = 30
        x1hoja.Cells(3, 2).columnwidth = 20 '8
        x1hoja.Cells(3, 3).columnwidth = 4 '8
        x1hoja.Cells(3, 4).columnwidth = 4 '8
        x1hoja.Cells(3, 5).columnwidth = 4 '8
        x1hoja.Cells(3, 6).columnwidth = 8
        x1hoja.Cells(3, 7).columnwidth = 8
        x1hoja.Cells(3, 8).columnwidth = 8
        x1hoja.Cells(3, 9).columnwidth = 8
        x1hoja.Cells(3, 10).columnwidth = 8
        x1hoja.Cells(3, 11).columnwidth = 8
        x1hoja.Cells(3, 12).columnwidth = 8
        x1hoja.Cells(3, 13).columnwidth = 8
        x1hoja.Cells(3, 14).columnwidth = 8
        x1hoja.Cells(3, 15).columnwidth = 8
        fila = fila + 4
        columna = 1
        x1hoja.Cells(fila, columna).rowheight = 3
        fila = fila + 1
        x1hoja.Range("A" & fila, "M" & fila).Merge()
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Formula = "INFORME DE ANÁLISIS DE TOXICOLOGÍA"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 12
        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).Formula = "Nº Ficha: " & sa.ID
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        columna = columna + 10
        x1hoja.Cells(fila, columna).Formula = "Fecha entrada: " & sa.FECHAINGRESO
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        fila = fila + 1
        columna = 1
        cli.ID = sa.IDPRODUCTOR
        cli = cli.buscar
        x1hoja.Cells(fila, columna).Formula = "Cliente: " & cli.NOMBRE
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        columna = columna + 10
        Dim nnaa As New dNuevoAnalisis
        Dim fechaproceso As String = ""
        Dim listannaa As New ArrayList
        listannaa = nnaa.listarporficha2(sa.ID)
        If Not listannaa Is Nothing Then
            For Each nnaa In listannaa
                fechaproceso = nnaa.FECHAPROCESO
            Next
        Else
            Dim atx As New dAnalisisTercerizado
            Dim listaatx As New ArrayList
            listaatx = atx.listarporficha4(nroficha)
            If Not listaatx Is Nothing Then
                For Each atx In listaatx
                    fechaproceso = atx.FECHAPROCESO
                Next
            End If
        End If
        nnaa = Nothing
        listannaa = Nothing
        x1hoja.Cells(fila, columna).Formula = "Fecha proceso: " & fechaproceso
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        fila = fila + 1
        columna = 1
        If cli.DIRECCION <> "" Or cli.DIRECCION <> "No aportado" Then
            x1hoja.Cells(fila, columna).Formula = "Dirección: " & cli.DIRECCION
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            columna = columna + 10
        ElseIf cli.IDLOCALIDAD <> 999 Then
            Dim loc As New dLocalidad
            loc.ID = cli.IDLOCALIDAD
            loc = loc.buscar
            If Not loc Is Nothing Then
                x1hoja.Cells(fila, columna).Formula = loc.NOMBRE
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 10
            End If
        ElseIf cli.IDDEPARTAMENTO <> 999 Then
            Dim dep As New dDepartamento
            dep.ID = cli.IDDEPARTAMENTO
            dep = dep.buscar
            If Not dep Is Nothing Then
                x1hoja.Cells(fila, columna).Formula = dep.NOMBRE
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 10
            End If
        ElseIf cli.CELULAR <> "" Then
            x1hoja.Cells(fila, columna).Formula = "Celular: " & cli.CELULAR
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            columna = columna + 10
        Else
            x1hoja.Cells(fila, columna).Formula = "No aportado"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            columna = columna + 10
        End If
        Dim fecha As Date = Now()
        Dim fecha2 As String = fecha.ToString("dd/MM/yyyy")
        x1hoja.Cells(fila, columna).Formula = "Fecha informe: " & fecha2
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        fila = fila + 1
        columna = 1
        Dim mm As New dMuestras
        mm.ID = sa.IDMUESTRA
        mm = mm.buscar
        If Not mm Is Nothing Then
            x1hoja.Cells(fila, columna).Formula = "Material recibido: " & mm.NOMBRE
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 1
        Else
            x1hoja.Cells(fila, columna).Formula = "Material recibido: "
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 1
            fila = fila + 1
        End If
        x1hoja.Cells(fila, columna).Formula = "Total de muestras: " & sa.NMUESTRAS
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        columna = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).Formula = "Muestreo realizado por el cliente"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        columna = 1
        fila = fila + 1
        x1hoja.Range("A" & fila, "M" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).rowheight = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).rowheight = 3
        fila = fila + 1
        columna = 1
        Dim cuenta As Integer = 1
        Dim detallemuestras As String = ""
        Dim idoperador As Integer = 0
        Dim operador As String = ""
        Dim iu As New dUsuario
        iu.ID = idoperador
        iu = iu.buscar
        If Not iu Is Nothing Then
            operador = iu.NOMBRE
        End If
        If Not lista Is Nothing Then
            x1hoja.Cells(fila, columna).Formula = "Id. Muestra"
            x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeTop).Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeLeft).Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeRight).Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignBottom
            x1hoja.Cells(fila, columna).Font.Size = 8
            fila = fila + 1
            x1hoja.Cells(fila, columna).Formula = ""
            x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeBottom).Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeLeft).Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeRight).Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).Font.Size = 8
            columna = columna + 1
            fila = fila - 1
        End If
        Dim listademetodos As String = ""
        Dim listadeabreviaturas As String = ""
        If Not lista3 Is Nothing Then
            For Each na In lista3
                Dim u As New dUsuario
                u.ID = na.OPERADOR
                u = u.buscar
                If Not u Is Nothing Then
                    nombre_operador = u.NOMBRE
                End If
                Dim lp As New dListaPrecios
                lp.ID = na.ANALISIS
                lp = lp.buscar
                Dim lm As New dListaMetodos
                lm.ID = na.METODO
                lm = lm.buscar
                If Not lm Is Nothing Then
                    listademetodos = listademetodos & lp.DESCTECNICA & " - " & lm.METODO & " / "
                End If
                If lp.ABREVIATURA <> lp.DESCTECNICA Then
                    listadeabreviaturas = listadeabreviaturas & lp.ABREVIATURA & " - " & lp.DESCTECNICA & " / "
                End If
                Dim l As New dListaPrecios
                l.ID = na.ANALISIS
                l = l.buscar
                If Not l Is Nothing Then
                    If sa.LOGO = 1 Then
                        If l.ACREDITADO = 1 Then
                            x1hoja.Cells(fila, columna).Formula = l.ABREVIATURA
                            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                            x1hoja.Cells(fila, columna).WrapText = True
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            acreditado = 1
                            'SI ES ESTAF. COAG. POS. EN MATRIZ DIFERENTE A QUESO ***********************
                            If na.ANALISIS = 24 Then
                                If sa.IDMUESTRA <> 26 Then
                                    x1hoja.Cells(fila, columna).Formula = "* " & l.ABREVIATURA
                                End If
                            End If
                            '**************************************************************************
                        Else
                            x1hoja.Cells(fila, columna).Formula = "* " & l.ABREVIATURA
                            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                            x1hoja.Cells(fila, columna).WrapText = True
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            todos_acreditados = 0
                        End If
                    Else
                        x1hoja.Cells(fila, columna).Formula = l.ABREVIATURA
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        'SI ES ESTAF. COAG. POS. EN MATRIZ DIFERENTE A QUESO **********************
                        If na.ANALISIS = 24 Then
                            If sa.IDMUESTRA <> 26 Then
                                x1hoja.Cells(fila, columna).Formula = "* " & l.ABREVIATURA
                            End If
                        End If
                        '**************************************************************************
                    End If
                End If
                l = Nothing
                Dim au As New dAnalisisUnidad
                au.ID = na.UNIDAD
                au = au.buscar
                If Not au Is Nothing Then
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).Formula = au.UNIDAD
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 6
                    fila = fila - 1
                    columna = columna + 1
                Else
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).Formula = ""
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 6
                    fila = fila - 1
                    columna = columna + 1
                End If
                lp = Nothing
                lm = Nothing
                u = Nothing
            Next
        End If
        columna = 1
        fila = fila + 2
        If Not lista Is Nothing Then
            For Each na In lista
                x1hoja.Cells(fila, columna).Formula = na.DETALLEMUESTRA
                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).WrapText = True
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                Dim na2 As New dNuevoAnalisis
                lista2 = na2.listarpormuestra(nroficha, na.MUESTRA)
                For Each na2 In lista2
                    Dim ret As Integer = Array.IndexOf(vec, na2.ANALISIS)
                    columna = columna + ret
                    x1hoja.Cells(fila, columna).Formula = na2.RESULTADO & " " & na2.RESULTADO2
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    Dim a As New dAcreditacion
                    a.ANALISIS = na2.ANALISIS
                    a = a.buscar
                    columna = columna - ret
                Next
                columna = 1
                fila = fila + 1
            Next
        End If
        If Not lista Is Nothing Then
            x1hoja.Cells(fila, columna).rowheight = 3
            fila = fila + 1
            x1hoja.Range("A" & fila, "M" & fila).Merge()
            x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).rowheight = 1
            fila = fila + 1
            If todos_acreditados = 0 Then
                x1hoja.Cells(fila, columna).Formula = "(*)Ensayo no acreditado ISO 17025 O.U.A."
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                fila = fila + 1
            Else
                fila = fila + 1
            End If
            If listadeabreviaturas <> "" Then
                x1hoja.Cells(fila, columna).Formula = "Abreviaturas"
                x1hoja.Cells(fila, columna).Font.Bold = True
                fila = fila + 1
            End If
            x1hoja.Cells(fila, columna).rowheight = 30
            x1hoja.Cells(fila, columna).Formula = listadeabreviaturas
            x1hoja.Range("A" & fila, "M" & fila).WrapText = True
            x1hoja.Range("A" & fila, "M" & fila).Merge()
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Size = 7
            fila = fila + 1
            x1hoja.Cells(fila, columna).Formula = "Métodos"
            x1hoja.Cells(fila, columna).Font.Bold = True
            fila = fila + 1
            x1hoja.Cells(fila, columna).rowheight = 30
            x1hoja.Cells(fila, columna).Formula = listademetodos
            x1hoja.Range("A" & fila, "M" & fila).WrapText = True
            x1hoja.Range("A" & fila, "M" & fila).Merge()
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Size = 7
            fila = fila + 1
        End If
        '*** OBSERVACIONES **************************************************
        If sa.OBSERVACIONES <> "" Then
            x1hoja.Cells(fila, columna).rowheight = 25
            x1hoja.Cells(fila, columna).Formula = "Observaciones: " & sa.OBSERVACIONES
            x1hoja.Range("A" & fila, "M" & fila).WrapText = True
            x1hoja.Range("A" & fila, "M" & fila).Merge()
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Size = 8
            fila = fila + 1
        End If
        '********************************************************************
        If Not lista Is Nothing Then
            columna = columna + 10
            x1hoja.Cells(fila, columna).Formula = "Operador: " & nombre_operador
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 2
            columna = 1
        End If
        'CABEZAL CON O SIN LOGO OUA
        If sa.LOGO = 1 Then
            x1hoja.Shapes.AddPicture("c:\Debug\encabezado_con_oua2.png", _
         Microsoft.Office.Core.MsoTriState.msoFalse, _
         Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 700, 50)
        Else
            x1hoja.Shapes.AddPicture("c:\Debug\encabezado_sin_oua2.png", _
     Microsoft.Office.Core.MsoTriState.msoFalse, _
     Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 700, 50)
        End If
        'ANALISIS TERCERIZADOS***************************************************
        Dim at As New dAnalisisTercerizado
        Dim listaat As New ArrayList
        listaat = at.listarporficha4(nroficha)
        If Not listaat Is Nothing Then
            x1hoja.Cells(fila, columna).Formula = "ANÁLISIS TERCERIZADOS"
            x1hoja.Range("A" & fila, "M" & fila).Merge()
            x1hoja.Cells(fila, columna).Interior.Color = RGB(215, 219, 221)
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 10
            fila = fila + 1
            x1hoja.Cells(fila, columna).Formula = "Muestra"
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            columna = columna + 1
            x1hoja.Cells(fila, columna).Formula = "Análisis"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            columna = columna + 3
            x1hoja.Cells(fila, columna).Formula = "Resultado"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            columna = columna + 1
            x1hoja.Cells(fila, columna).Formula = "Unidad"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            columna = columna + 1
            x1hoja.Cells(fila, columna).Formula = "Método"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            columna = columna + 4
            x1hoja.Cells(fila, columna).Formula = "Laboratorio"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            columna = 1
            fila = fila + 1
            For Each at In listaat
                x1hoja.Cells(fila, columna).Formula = at.MUESTRA
                x1hoja.Cells(fila, columna).WrapText = True
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                Dim att As New dAnalisisTercerizadoTipo
                att.ID = at.ANALISIS
                att = att.buscar
                If Not att Is Nothing Then
                    x1hoja.Cells(fila, columna).Formula = att.NOMBRE
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 3
                Else
                    x1hoja.Cells(fila, columna).Formula = ""
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 3
                End If
                x1hoja.Cells(fila, columna).Formula = at.RESULTADO
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                x1hoja.Cells(fila, columna).Formula = at.UNIDAD
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                x1hoja.Cells(fila, columna).Formula = at.METODO
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 4
                Dim ol As New dOtrosLaboratorios
                ol.ID = at.LABORATORIO
                ol = ol.buscar
                If Not ol Is Nothing Then
                    x1hoja.Cells(fila, columna).Formula = ol.NOMBRE
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = 1
                    fila = fila + 1
                Else
                    x1hoja.Cells(fila, columna).Formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = 1
                    fila = fila + 1
                End If
            Next
            fila = fila + 1
        End If
        '*** PONER FIRMA ********************************************************
        x1libro.Worksheets(1).cells(fila, columna).select()
        x1libro.ActiveSheet.pictures.Insert("c:\Debug\cecilia.jpg").select()
        x1libro.Worksheets(1).cells(2, 1).select()
        fila = fila + 6
        columna = 1
        '*** PIE DE PAGINA ******************************************************
        x1hoja.Cells(fila, columna).rowheight = 25
        x1hoja.Cells(fila, columna).Formula = "Este informe no podrá ser reproducido total o parcialmente sin la autorización escrita de COLAVECO. Los resultados consignados se refieren exclusivamente a la muestra recibida." & vbCrLf _
            & "COLAVECO declina toda responsabilidad por el uso indebido o incorrecto que se hiciere a este informe, asi como el plan y procedimientos de muestreo aplicados por el cliente. Dra. Cecilia Abelenda (Directora Técnica)"
        x1hoja.Range("A" & fila, "M" & fila).WrapText = True
        x1hoja.Range("A" & fila, "M" & fila).Merge()
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        '************************************************************************
        fila = fila + 1
        x1hoja.Range("A" & fila, "M" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(215, 219, 221)
        x1hoja.Cells(fila, columna).rowheight = 8
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
        x1hoja.Cells(fila, columna).Formula = "Fin del informe."
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 7
        '    End If
        'End If
        'Insert tabla preinformes**************************
        Dim pi As New dPreinformes
        Dim fechaactual As Date = Now()
        Dim _fecha As String
        _fecha = Format(fechaactual, "yyyy-MM-dd")
        pi.FICHA = nroficha
        pi = pi.buscar
        If Not pi Is Nothing Then
        Else
            Dim pi2 As New dPreinformes
            pi2.FICHA = nroficha
            pi2.TIPO = 20
            pi2.CREADO = 1
            pi2.FECHA = _fecha
            pi2.guardar()
            pi2 = Nothing
        End If
        pi = Nothing
        '***********************************************************
        x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas
        'PROTEGE LA HOJA DE EXCEL
        x1hoja.Protect(Password:="1582782", DrawingObjects:=True, _
        Contents:=True, Scenarios:=True)
        'GUARDA EL ARCHIVO DE EXCEL
        x1hoja.SaveAs("\\ROBOT\PREINFORMES\TOXICOLOGIA\" & nroficha & ".xls")
        x1app.Visible = True
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub informe_ambiental()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
        x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(1)
        x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(1)
        x1hoja.PageSetup.Orientation = (Excel.XlPageOrientation.xlLandscape)
        Dim sa As New dSolicitudAnalisis
        Dim cli As New dCliente
        Dim na As New dNuevoAnalisis
        Dim na3 As New dNuevoAnalisis
        Dim met As New dMetodos
        Dim lista As New ArrayList
        Dim lista2 As New ArrayList
        Dim lista3 As New ArrayList
        Dim acreditado As Integer = 0
        Dim acreditado2 As Integer = 0
        Dim xanalisis As Integer = 0
        Dim vec(xanalisis) As Integer
        Dim informefinal As Integer = 0
        Dim nombre_operador As String = ""
        Dim nombre_tecnico As String = "xxx xxx xxx xxx"
        '*****************************
        nroficha = TextFicha.Text.Trim
        sa.ID = nroficha
        sa = sa.buscar
        lista = na.listarporfichamuestra(nroficha)
        lista3 = na3.listarporficha3(nroficha)
        '**********************************************
        If Not lista3 Is Nothing Then
            xanalisis = lista3.Count - 1
            ReDim vec(xanalisis)
            Dim i As Integer = 0
            For Each na3 In lista3
                vec(i) = na3.ANALISIS
                i = i + 1
            Next
        End If
        '***********************************************
        Dim fila As Integer
        Dim columna As Integer
        fila = 1
        columna = 1
        'Poner Titulos
        columna = 2
        x1hoja.Cells(3, 1).columnwidth = 30
        x1hoja.Cells(3, 2).columnwidth = 12
        x1hoja.Cells(3, 3).columnwidth = 12
        x1hoja.Cells(3, 4).columnwidth = 12
        x1hoja.Cells(3, 5).columnwidth = 12
        x1hoja.Cells(3, 6).columnwidth = 12
        x1hoja.Cells(3, 7).columnwidth = 12
        x1hoja.Cells(3, 8).columnwidth = 12
        x1hoja.Cells(3, 9).columnwidth = 12
        x1hoja.Cells(3, 10).columnwidth = 14
        fila = fila + 4
        columna = 1
        x1hoja.Cells(fila, columna).rowheight = 3
        fila = fila + 1
        x1hoja.Range("A" & fila, "I" & fila).Merge()
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Formula = "INFORME AMBIENTAL"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 12
        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).Formula = "Nº Ficha: " & sa.ID
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        columna = columna + 7
        x1hoja.Cells(fila, columna).Formula = "Fecha entrada: " & sa.FECHAINGRESO
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        fila = fila + 1
        columna = 1
        cli.ID = sa.IDPRODUCTOR
        cli = cli.buscar
        x1hoja.Cells(fila, columna).Formula = "Cliente: " & cli.NOMBRE
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        columna = columna + 7
        Dim nnaa As New dNuevoAnalisis
        Dim fechaproceso As String = ""
        Dim listannaa As New ArrayList
        listannaa = nnaa.listarporficha2(sa.ID)
        If Not listannaa Is Nothing Then
            For Each nnaa In listannaa
                fechaproceso = nnaa.FECHAPROCESO
            Next
        Else
            Dim atx As New dAnalisisTercerizado
            Dim listaatx As New ArrayList
            listaatx = atx.listarporficha4(nroficha)
            If Not listaatx Is Nothing Then
                For Each atx In listaatx
                    fechaproceso = atx.FECHAPROCESO
                Next
            End If
        End If
        nnaa = Nothing
        listannaa = Nothing
        x1hoja.Cells(fila, columna).Formula = "Fecha proceso: " & fechaproceso
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        fila = fila + 1
        columna = 1
        If cli.DIRECCION <> "" Or cli.DIRECCION <> "No aportado" Then
            x1hoja.Cells(fila, columna).Formula = "Dirección: " & cli.DIRECCION
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            columna = columna + 7
        ElseIf cli.IDLOCALIDAD <> 999 Then
            Dim loc As New dLocalidad
            loc.ID = cli.IDLOCALIDAD
            loc = loc.buscar
            If Not loc Is Nothing Then
                x1hoja.Cells(fila, columna).Formula = loc.NOMBRE
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 7
            End If
        ElseIf cli.IDDEPARTAMENTO <> 999 Then
            Dim dep As New dDepartamento
            dep.ID = cli.IDDEPARTAMENTO
            dep = dep.buscar
            If Not dep Is Nothing Then
                x1hoja.Cells(fila, columna).Formula = dep.NOMBRE
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 7
            End If
        ElseIf cli.CELULAR <> "" Then
            x1hoja.Cells(fila, columna).Formula = "Celular: " & cli.CELULAR
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            columna = columna + 7
        Else
            x1hoja.Cells(fila, columna).Formula = "No aportado"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            columna = columna + 7
        End If
        Dim fecha As Date = Now()
        Dim fecha2 As String = fecha.ToString("dd/MM/yyyy")
        x1hoja.Cells(fila, columna).Formula = "Fecha informe: " & fecha2
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        fila = fila + 1
        columna = 1
        Dim mm As New dMuestras
        mm.ID = sa.IDMUESTRA
        mm = mm.buscar
        If Not mm Is Nothing Then
            x1hoja.Cells(fila, columna).Formula = "Material recibido: " & mm.NOMBRE
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 1
        Else
            x1hoja.Cells(fila, columna).Formula = "Material recibido: "
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 1
            fila = fila + 1
        End If
        x1hoja.Cells(fila, columna).Formula = "Total de muestras: " & sa.NMUESTRAS
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        columna = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).Formula = "Temperatura de arribo de las muestras: " & sa.TEMPERATURA & " ºC"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        fila = fila + 1
        x1hoja.Cells(fila, columna).Formula = "Muestreo realizado por el cliente"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        columna = 1
        fila = fila + 1
        x1hoja.Range("A" & fila, "I" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).rowheight = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).rowheight = 3
        fila = fila + 1
        columna = 1
        Dim cuenta As Integer = 1
        Dim detallemuestras As String = ""
        Dim idoperador As Integer = 0
        Dim operador As String = ""
        Dim iu As New dUsuario
        iu.ID = idoperador
        iu = iu.buscar
        If Not iu Is Nothing Then
            operador = iu.NOMBRE
        End If
        If Not lista Is Nothing Then
            x1hoja.Cells(fila, columna).Formula = "Id. Muestra"
            x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeTop).Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeLeft).Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeRight).Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignBottom
            x1hoja.Cells(fila, columna).Font.Size = 8
            fila = fila + 1
            x1hoja.Cells(fila, columna).Formula = ""
            x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeBottom).Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeLeft).Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeRight).Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).Font.Size = 8
            columna = columna + 1
            fila = fila - 1
        End If
        Dim listademetodos As String = ""
        Dim listadeabreviaturas As String = ""
        If Not lista3 Is Nothing Then
            For Each na In lista3
                Dim u As New dUsuario
                u.ID = na.OPERADOR
                u = u.buscar
                If Not u Is Nothing Then
                    nombre_operador = u.NOMBRE
                End If
                Dim lp As New dListaPrecios
                lp.ID = na.ANALISIS
                lp = lp.buscar
                Dim lm As New dListaMetodos
                lm.ID = na.METODO
                lm = lm.buscar
                If Not lm Is Nothing Then
                    listademetodos = listademetodos & lp.DESCTECNICA & " - " & lm.METODO & " / "
                End If
                If lp.ABREVIATURA <> lp.DESCTECNICA Then
                    listadeabreviaturas = listadeabreviaturas & lp.ABREVIATURA & " - " & lp.DESCTECNICA & " / "
                End If
                Dim l As New dListaPrecios
                l.ID = na.ANALISIS
                l = l.buscar
                If Not l Is Nothing Then
                    x1hoja.Cells(fila, columna).Formula = l.ABREVIATURA
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 8
                End If
                l = Nothing
                Dim au As New dAnalisisUnidad
                au.ID = na.UNIDAD
                au = au.buscar
                If Not au Is Nothing Then
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).Formula = au.UNIDAD
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 6
                    fila = fila - 1
                    columna = columna + 1
                Else
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).Formula = ""
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 6
                    fila = fila - 1
                    columna = columna + 1
                End If
                lp = Nothing
                lm = Nothing
                u = Nothing
            Next
        End If
        columna = 1
        fila = fila + 2
        If Not lista Is Nothing Then
            For Each na In lista
                x1hoja.Cells(fila, columna).Formula = na.DETALLEMUESTRA
                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).WrapText = True
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                Dim na2 As New dNuevoAnalisis
                lista2 = na2.listarpormuestra(nroficha, na.MUESTRA)
                For Each na2 In lista2
                    Dim ret As Integer = Array.IndexOf(vec, na2.ANALISIS)
                    columna = columna + ret
                    If na2.RESULTADO2 = "" Then
                        x1hoja.Cells(fila, columna).Formula = na2.RESULTADO
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                    Else
                        x1hoja.Cells(fila, columna).Formula = na2.RESULTADO2
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                    End If
                    Dim a As New dAcreditacion
                    a.ANALISIS = na2.ANALISIS
                    a = a.buscar
                    columna = columna - ret
                Next
                columna = 1
                fila = fila + 1
            Next
        End If
        If Not lista Is Nothing Then
            x1hoja.Cells(fila, columna).rowheight = 3
            fila = fila + 1
            x1hoja.Range("A" & fila, "I" & fila).Merge()
            x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).rowheight = 1
            fila = fila + 1
            If listadeabreviaturas <> "" Then
                x1hoja.Cells(fila, columna).Formula = "Abreviaturas"
                x1hoja.Cells(fila, columna).Font.Bold = True
                fila = fila + 1
                x1hoja.Cells(fila, columna).rowheight = 30
                x1hoja.Cells(fila, columna).Formula = listadeabreviaturas
                x1hoja.Range("A" & fila, "I" & fila).WrapText = True
                x1hoja.Range("A" & fila, "I" & fila).Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Size = 7
                fila = fila + 1
            End If
            x1hoja.Cells(fila, columna).Formula = "Métodos"
            x1hoja.Cells(fila, columna).Font.Bold = True
            fila = fila + 1
            x1hoja.Cells(fila, columna).rowheight = 30
            x1hoja.Cells(fila, columna).Formula = listademetodos
            x1hoja.Range("A" & fila, "I" & fila).WrapText = True
            x1hoja.Range("A" & fila, "I" & fila).Merge()
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Size = 7
            fila = fila + 1
        End If
        '*** OBSERVACIONES **************************************************
        If sa.OBSERVACIONES <> "" Then
            x1hoja.Cells(fila, columna).rowheight = 25
            x1hoja.Cells(fila, columna).Formula = "Observaciones: " & sa.OBSERVACIONES
            x1hoja.Range("A" & fila, "I" & fila).WrapText = True
            x1hoja.Range("A" & fila, "I" & fila).Merge()
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Size = 8
            fila = fila + 1
        End If
        '********************************************************************
        If Not lista Is Nothing Then
            x1hoja.Cells(fila, columna).Formula = "" '"(*)Ensayo no acreditado ISO 17025 O.U.A."
            x1hoja.Cells(fila, columna).Font.Size = 8
            x1hoja.Cells(fila, columna).Font.Bold = True
            columna = columna + 7
            x1hoja.Cells(fila, columna).Formula = "Operador: " & nombre_operador
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 2
            columna = 1
        End If
        'CABEZAL CON O SIN LOGO OUA
        x1hoja.Shapes.AddPicture("c:\Debug\encabezado_sin_oua2.png", _
 Microsoft.Office.Core.MsoTriState.msoFalse, _
 Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 690, 40)

        'ANALISIS TERCERIZADOS***************************************************
        Dim at As New dAnalisisTercerizado
        Dim listaat As New ArrayList
        listaat = at.listarporficha4(nroficha)
        If Not listaat Is Nothing Then
            x1hoja.Cells(fila, columna).Formula = "ANÁLISIS TERCERIZADOS"
            x1hoja.Range("A" & fila, "I" & fila).Merge()
            x1hoja.Cells(fila, columna).Interior.Color = RGB(215, 219, 221)
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 10
            fila = fila + 1
            x1hoja.Cells(fila, columna).Formula = "Muestra"
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            columna = columna + 1
            x1hoja.Cells(fila, columna).Formula = "Análisis"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            columna = columna + 3
            x1hoja.Cells(fila, columna).Formula = "Resultado"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            columna = columna + 1
            x1hoja.Cells(fila, columna).Formula = "Unidad"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            columna = columna + 1
            x1hoja.Cells(fila, columna).Formula = "Método"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            columna = columna + 4
            x1hoja.Cells(fila, columna).Formula = "Laboratorio"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            columna = 1
            fila = fila + 1
            For Each at In listaat
                x1hoja.Cells(fila, columna).Formula = at.MUESTRA
                x1hoja.Cells(fila, columna).WrapText = True
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                Dim att As New dAnalisisTercerizadoTipo
                att.ID = at.ANALISIS
                att = att.buscar
                If Not att Is Nothing Then
                    x1hoja.Cells(fila, columna).Formula = att.NOMBRE
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 3
                Else
                    x1hoja.Cells(fila, columna).Formula = ""
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 3
                End If
                x1hoja.Cells(fila, columna).Formula = at.RESULTADO
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                x1hoja.Cells(fila, columna).Formula = at.UNIDAD
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                x1hoja.Cells(fila, columna).Formula = at.METODO
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 4
                Dim ol As New dOtrosLaboratorios
                ol.ID = at.LABORATORIO
                ol = ol.buscar
                If Not ol Is Nothing Then
                    x1hoja.Cells(fila, columna).Formula = ol.NOMBRE
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = 1
                    fila = fila + 1
                Else
                    x1hoja.Cells(fila, columna).Formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = 1
                    fila = fila + 1
                End If
            Next
            fila = fila + 1
        End If
        '*** PONER FIRMA ********************************************************
        x1libro.Worksheets(1).cells(fila, columna).select()
        x1libro.ActiveSheet.pictures.Insert("c:\Debug\cecilia.jpg").select()
        x1libro.Worksheets(1).cells(2, 1).select()
        fila = fila + 6
        columna = 1
        '*** PIE DE PAGINA ******************************************************
        x1hoja.Cells(fila, columna).rowheight = 25
        x1hoja.Cells(fila, columna).Formula = "Este informe no podrá ser reproducido total o parcialmente sin la autorización escrita de COLAVECO. Los resultados consignados se refieren exclusivamente a la muestra recibida." & vbCrLf _
            & "COLAVECO declina toda responsabilidad por el uso indebido o incorrecto que se hiciere a este informe, asi como el plan y procedimientos de muestreo aplicados por el cliente. Dra. Cecilia Abelenda (Directora Técnica)"
        x1hoja.Range("A" & fila, "I" & fila).WrapText = True
        x1hoja.Range("A" & fila, "I" & fila).Merge()
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        '************************************************************************
        fila = fila + 1
        x1hoja.Range("A" & fila, "I" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(215, 219, 221)
        x1hoja.Cells(fila, columna).rowheight = 8
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
        x1hoja.Cells(fila, columna).Formula = "Fin del informe."
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 7
        'Insert tabla preinformes**************************
        Dim pi As New dPreinformes
        Dim fechaactual As Date = Now()
        Dim _fecha As String
        _fecha = Format(fechaactual, "yyyy-MM-dd")
        pi.FICHA = nroficha
        pi = pi.buscar
        If Not pi Is Nothing Then
        Else
            Dim pi2 As New dPreinformes
            pi2.FICHA = nroficha
            pi2.TIPO = 11
            pi2.CREADO = 1
            pi2.FECHA = _fecha
            pi2.guardar()
            pi2 = Nothing
        End If
        pi = Nothing
        '***********************************************************
        x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas
        'PROTEGE LA HOJA DE EXCEL
        x1hoja.Protect(Password:="1582782", DrawingObjects:=True, _
        Contents:=True, Scenarios:=True)
        'GUARDA EL ARCHIVO DE EXCEL
        x1hoja.SaveAs("\\ROBOT\PREINFORMES\AMBIENTAL\" & nroficha & ".xls")
        x1app.Visible = True
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub creainformetxt()
        Dim idficha As Long = TextFicha.Text.Trim
        Dim oSW As New StreamWriter("\\ROBOT\PREINFORMES\CONTROL\" & idficha & ".txt")
        Dim c As New dControl
        Dim lista4 As New ArrayList
        lista4 = c.listarporsolicitud(idficha)
        Dim secuencial As Integer = 1

        If Not lista4 Is Nothing Then
            If lista4.Count > 0 Then
                Dim cs As New dControlSolicitud
                cs.FICHA = idficha
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
    Private Sub informe_efluentes()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
        x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(1)
        x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(1)
        x1hoja.PageSetup.Orientation = (Excel.XlPageOrientation.xlLandscape)
        Dim sa As New dSolicitudAnalisis
        Dim cli As New dCliente
        Dim na As New dNuevoAnalisis
        Dim na3 As New dNuevoAnalisis
        Dim met As New dMetodos
        Dim lista As New ArrayList
        Dim lista2 As New ArrayList
        Dim lista3 As New ArrayList
        Dim acreditado As Integer = 0
        Dim acreditado2 As Integer = 0
        Dim xanalisis As Integer = 0
        Dim vec(xanalisis) As Integer
        Dim informefinal As Integer = 0
        Dim nombre_operador As String = ""
        Dim nombre_tecnico As String = "xxx xxx xxx xxx"
        Dim todos_acreditados As Integer = 1
        '*****************************
        nroficha = TextFicha.Text.Trim
        sa.ID = nroficha
        sa = sa.buscar
        lista = na.listarporfichamuestra(nroficha)
        lista3 = na3.listarporficha3(nroficha)
        '**********************************************
        If Not lista3 Is Nothing Then
            xanalisis = lista3.Count - 1
            ReDim vec(xanalisis)
            Dim i As Integer = 0
            For Each na3 In lista3
                vec(i) = na3.ANALISIS
                i = i + 1
            Next
        End If
        '***********************************************
        Dim fila As Integer
        Dim columna As Integer
        'If Not lista Is Nothing Then
        '    If lista.Count > 0 Then
        fila = 1
        columna = 1
        'Poner Titulos
        columna = 2
        x1hoja.Cells(3, 1).columnwidth = 30
        x1hoja.Cells(3, 2).columnwidth = 8
        x1hoja.Cells(3, 3).columnwidth = 8
        x1hoja.Cells(3, 4).columnwidth = 8
        x1hoja.Cells(3, 5).columnwidth = 8
        x1hoja.Cells(3, 6).columnwidth = 8
        x1hoja.Cells(3, 7).columnwidth = 8
        x1hoja.Cells(3, 8).columnwidth = 8
        x1hoja.Cells(3, 9).columnwidth = 8
        x1hoja.Cells(3, 10).columnwidth = 8
        x1hoja.Cells(3, 11).columnwidth = 8
        x1hoja.Cells(3, 12).columnwidth = 8
        x1hoja.Cells(3, 13).columnwidth = 8
        x1hoja.Cells(3, 14).columnwidth = 8
        x1hoja.Cells(3, 15).columnwidth = 8
        'x1hoja.Cells(3, 16).columnwidth = 7
        fila = fila + 4
        columna = 1
        x1hoja.Range("A5", "M5").Merge()
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Formula = "INFORME DE EFLUENTES"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 12
        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).Formula = "Nº Ficha: " & sa.ID
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        columna = columna + 10
        x1hoja.Cells(fila, columna).Formula = "Fecha entrada: " & sa.FECHAINGRESO
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        fila = fila + 1
        columna = 1
        cli.ID = sa.IDPRODUCTOR
        cli = cli.buscar
        x1hoja.Cells(fila, columna).Formula = "Cliente: " & cli.NOMBRE
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        columna = columna + 10
        Dim nnaa As New dNuevoAnalisis
        Dim fechaproceso As String = ""
        Dim listannaa As New ArrayList
        listannaa = nnaa.listarporficha2(sa.ID)
        If Not listannaa Is Nothing Then
            For Each nnaa In listannaa
                fechaproceso = nnaa.FECHAPROCESO
            Next
        Else
            Dim atx As New dAnalisisTercerizado
            Dim listaatx As New ArrayList
            listaatx = atx.listarporficha4(nroficha)
            If Not listaatx Is Nothing Then
                For Each atx In listaatx
                    fechaproceso = atx.FECHAPROCESO
                Next
            End If
        End If
        nnaa = Nothing
        listannaa = Nothing
        x1hoja.Cells(fila, columna).Formula = "Fecha proceso: " & fechaproceso
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        fila = fila + 1
        columna = 1
        If cli.DIRECCION <> "" Or cli.DIRECCION <> "No aportado" Then
            x1hoja.Cells(fila, columna).Formula = "Dirección: " & cli.DIRECCION
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            columna = columna + 10
        ElseIf cli.IDLOCALIDAD <> 999 Then
            Dim loc As New dLocalidad
            loc.ID = cli.IDLOCALIDAD
            loc = loc.buscar
            If Not loc Is Nothing Then
                x1hoja.Cells(fila, columna).Formula = loc.NOMBRE
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 10
            End If
        ElseIf cli.IDDEPARTAMENTO <> 999 Then
            Dim dep As New dDepartamento
            dep.ID = cli.IDDEPARTAMENTO
            dep = dep.buscar
            If Not dep Is Nothing Then
                x1hoja.Cells(fila, columna).Formula = dep.NOMBRE
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 10
            End If
        ElseIf cli.CELULAR <> "" Then
            x1hoja.Cells(fila, columna).Formula = "Celular: " & cli.CELULAR
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            columna = columna + 10
        Else
            x1hoja.Cells(fila, columna).Formula = "No aportado"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            columna = columna + 10
        End If
        Dim fecha As Date = Now()
        Dim fecha2 As String = fecha.ToString("dd/MM/yyyy")
        x1hoja.Cells(fila, columna).Formula = "Fecha informe: " & fecha2
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        fila = fila + 1
        columna = 1
        Dim mm As New dMuestras
        mm.ID = sa.IDMUESTRA
        mm = mm.buscar
        If Not mm Is Nothing Then
            x1hoja.Cells(fila, columna).Formula = "Material recibido: " & mm.NOMBRE
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 1
        Else
            x1hoja.Cells(fila, columna).Formula = "Material recibido: "
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 1
            fila = fila + 1
        End If
        x1hoja.Cells(fila, columna).Formula = "Total de muestras: " & sa.NMUESTRAS
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        columna = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).Formula = "Temperatura de arribo de las muestras: " & sa.TEMPERATURA & " ºC"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        fila = fila + 1
        x1hoja.Cells(fila, columna).Formula = "Muestreo realizado por el cliente"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        columna = 1
        fila = fila + 1
        x1hoja.Range("A" & fila, "M" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).rowheight = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).rowheight = 3
        fila = fila + 1
        columna = 1
        Dim cuenta As Integer = 1
        Dim detallemuestras As String = ""
        Dim idoperador As Integer = 0
        Dim operador As String = ""
        Dim iu As New dUsuario
        iu.ID = idoperador
        iu = iu.buscar
        If Not iu Is Nothing Then
            operador = iu.NOMBRE
        End If
        If Not lista Is Nothing Then
            x1hoja.Cells(fila, columna).Formula = "Id. Muestra"
            x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeTop).Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeLeft).Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeRight).Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignBottom
            x1hoja.Cells(fila, columna).Font.Size = 8
            fila = fila + 1
            x1hoja.Cells(fila, columna).Formula = ""
            x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeBottom).Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeLeft).Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeRight).Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).Font.Size = 8
            columna = columna + 1
            fila = fila - 1
        End If
        Dim listademetodos As String = ""
        Dim listadeabreviaturas As String = ""
        If Not lista3 Is Nothing Then
            For Each na In lista3
                Dim u As New dUsuario
                u.ID = na.OPERADOR
                u = u.buscar
                If Not u Is Nothing Then
                    nombre_operador = u.NOMBRE
                End If
                Dim lp As New dListaPrecios
                lp.ID = na.ANALISIS
                lp = lp.buscar
                Dim lm As New dListaMetodos
                lm.ID = na.METODO
                lm = lm.buscar
                If Not lm Is Nothing Then
                    listademetodos = listademetodos & lp.DESCTECNICA & " - " & lm.METODO & " / "
                End If
                If lp.ABREVIATURA <> lp.DESCTECNICA Then
                    listadeabreviaturas = listadeabreviaturas & lp.ABREVIATURA & " - " & lp.DESCTECNICA & " / "
                End If
                Dim l As New dListaPrecios
                l.ID = na.ANALISIS
                l = l.buscar

                If Not l Is Nothing Then
                    x1hoja.Cells(fila, columna).Formula = l.ABREVIATURA
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 8
                End If
                l = Nothing
                Dim au As New dAnalisisUnidad
                au.ID = na.UNIDAD
                au = au.buscar
                If Not au Is Nothing Then
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).Formula = au.UNIDAD
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 6
                    fila = fila - 1
                    columna = columna + 1
                Else
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).Formula = ""
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 6
                    fila = fila - 1
                    columna = columna + 1
                End If
                lp = Nothing
                lm = Nothing
                u = Nothing
            Next
        End If
        columna = 1
        fila = fila + 2
        If Not lista Is Nothing Then
            For Each na In lista
                x1hoja.Cells(fila, columna).Formula = na.DETALLEMUESTRA
                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).WrapText = True
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                Dim na2 As New dNuevoAnalisis
                lista2 = na2.listarpormuestra(nroficha, na.MUESTRA)
                For Each na2 In lista2
                    Dim ret As Integer = Array.IndexOf(vec, na2.ANALISIS)
                    columna = columna + ret
                    x1hoja.Cells(fila, columna).Formula = na2.RESULTADO & " " & na2.RESULTADO2
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    Dim a As New dAcreditacion
                    a.ANALISIS = na2.ANALISIS
                    a = a.buscar
                    columna = columna - ret
                Next
                columna = 1
                fila = fila + 1
            Next
        End If
        If Not lista Is Nothing Then
            x1hoja.Cells(fila, columna).rowheight = 3
            fila = fila + 1
            x1hoja.Range("A" & fila, "M" & fila).Merge()
            x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).rowheight = 1
            fila = fila + 1
            x1hoja.Cells(fila, columna).Formula = "Abreviaturas"
            x1hoja.Cells(fila, columna).Font.Bold = True
            fila = fila + 1
            x1hoja.Cells(fila, columna).rowheight = 30
            x1hoja.Cells(fila, columna).Formula = listadeabreviaturas
            x1hoja.Range("A" & fila, "M" & fila).WrapText = True
            x1hoja.Range("A" & fila, "M" & fila).Merge()
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Size = 7
            fila = fila + 1
            x1hoja.Cells(fila, columna).Formula = "Métodos"
            x1hoja.Cells(fila, columna).Font.Bold = True
            fila = fila + 1
            x1hoja.Cells(fila, columna).rowheight = 30
            x1hoja.Cells(fila, columna).Formula = listademetodos
            x1hoja.Range("A" & fila, "M" & fila).WrapText = True
            x1hoja.Range("A" & fila, "M" & fila).Merge()
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Size = 7
            fila = fila + 1
        End If
        '*** OBSERVACIONES **************************************************
        If sa.OBSERVACIONES <> "" Then
            x1hoja.Cells(fila, columna).rowheight = 25
            x1hoja.Cells(fila, columna).Formula = "Observaciones: " & sa.OBSERVACIONES
            x1hoja.Range("A" & fila, "M" & fila).WrapText = True
            x1hoja.Range("A" & fila, "M" & fila).Merge()
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Size = 8
            fila = fila + 1
        End If
        '********************************************************************
        If Not lista Is Nothing Then
            x1hoja.Cells(fila, columna).Formula = "" '"(*)Ensayo no acreditado ISO 17025 O.U.A."
            x1hoja.Cells(fila, columna).Font.Size = 8
            x1hoja.Cells(fila, columna).Font.Bold = True
            columna = columna + 10
            x1hoja.Cells(fila, columna).Formula = "Operador: " & nombre_operador
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        fila = fila + 2
        columna = 1
        End If
        x1hoja.Shapes.AddPicture("c:\Debug\encabezado_sin_oua2.png", _
 Microsoft.Office.Core.MsoTriState.msoFalse, _
 Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 700, 50)
        'ANALISIS TERCERIZADOS***************************************************
        Dim at As New dAnalisisTercerizado
        Dim listaat As New ArrayList
        listaat = at.listarporficha4(nroficha)
        If Not listaat Is Nothing Then
            x1hoja.Cells(fila, columna).Formula = "ANÁLISIS TERCERIZADOS"
            x1hoja.Range("A" & fila, "M" & fila).Merge()
            x1hoja.Cells(fila, columna).Interior.Color = RGB(215, 219, 221)
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 10
            fila = fila + 1
            x1hoja.Cells(fila, columna).Formula = "Muestra"
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            columna = columna + 1
            x1hoja.Cells(fila, columna).Formula = "Análisis"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            columna = columna + 3
            x1hoja.Cells(fila, columna).Formula = "Resultado"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            columna = columna + 1
            x1hoja.Cells(fila, columna).Formula = "Unidad"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            columna = columna + 1
            x1hoja.Cells(fila, columna).Formula = "Método"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            columna = columna + 4
            x1hoja.Cells(fila, columna).Formula = "Laboratorio"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            columna = 1
            fila = fila + 1
            For Each at In listaat
                x1hoja.Cells(fila, columna).Formula = at.MUESTRA
                x1hoja.Cells(fila, columna).WrapText = True
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                Dim att As New dAnalisisTercerizadoTipo
                att.ID = at.ANALISIS
                att = att.buscar
                If Not att Is Nothing Then
                    x1hoja.Cells(fila, columna).Formula = att.NOMBRE
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 3
                Else
                    x1hoja.Cells(fila, columna).Formula = ""
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 3
                End If
                x1hoja.Cells(fila, columna).Formula = at.RESULTADO
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                x1hoja.Cells(fila, columna).Formula = at.UNIDAD
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                x1hoja.Cells(fila, columna).Formula = at.METODO
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 4
                Dim ol As New dOtrosLaboratorios
                ol.ID = at.LABORATORIO
                ol = ol.buscar
                If Not ol Is Nothing Then
                    x1hoja.Cells(fila, columna).Formula = ol.NOMBRE
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = 1
                    fila = fila + 1
                Else
                    x1hoja.Cells(fila, columna).Formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = 1
                    fila = fila + 1
                End If
            Next
            fila = fila + 1
        End If
        '*** PONER FIRMA ********************************************************
        x1libro.Worksheets(1).cells(fila, columna).select()
        x1libro.ActiveSheet.pictures.Insert("c:\Debug\cecilia.jpg").select()
        x1libro.Worksheets(1).cells(2, 1).select()
        fila = fila + 6
        columna = 1
        '*** PIE DE PAGINA ******************************************************
        x1hoja.Cells(fila, columna).rowheight = 25
        x1hoja.Cells(fila, columna).Formula = "Este informe no podrá ser reproducido total o parcialmente sin la autorización escrita de COLAVECO. Los resultados consignados se refieren exclusivamente a la muestra recibida." & vbCrLf _
            & "COLAVECO declina toda responsabilidad por el uso indebido o incorrecto que se hiciere a este informe, asi como el plan y procedimientos de muestreo aplicados por el cliente. Dra. Cecilia Abelenda (Directora Técnica)"
        x1hoja.Range("A" & fila, "M" & fila).WrapText = True
        x1hoja.Range("A" & fila, "M" & fila).Merge()
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        '************************************************************************
        fila = fila + 1
        x1hoja.Range("A" & fila, "M" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(215, 219, 221)
        x1hoja.Cells(fila, columna).rowheight = 8
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
        x1hoja.Cells(fila, columna).Formula = "Fin del informe."
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 7
        'Insert tabla preinformes**************************
        Dim pi As New dPreinformes
        Dim fechaactual As Date = Now()
        Dim _fecha As String
        _fecha = Format(fechaactual, "yyyy-MM-dd")
        pi.FICHA = nroficha
        pi = pi.buscar
        If Not pi Is Nothing Then
        Else
            Dim pi2 As New dPreinformes
            pi2.FICHA = nroficha
            pi2.TIPO = 16
            pi2.CREADO = 1
            pi2.FECHA = _fecha
            pi2.guardar()
            pi2 = Nothing
        End If
        pi = Nothing
        '***********************************************************
        x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas
        'PROTEGE LA HOJA DE EXCEL
        x1hoja.Protect(Password:="1582782", DrawingObjects:=True, _
        Contents:=True, Scenarios:=True)
        'GUARDA EL ARCHIVO DE EXCEL
        x1hoja.SaveAs("\\ROBOT\PREINFORMES\EFLUENTES\" & nroficha & ".xls")
        x1app.Visible = True
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub informe_serologia()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
        x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(1)
        x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(1)
        x1hoja.PageSetup.Orientation = (Excel.XlPageOrientation.xlLandscape)
        Dim sa As New dSolicitudAnalisis
        Dim cli As New dCliente
        Dim na As New dNuevoAnalisis
        Dim na3 As New dNuevoAnalisis
        Dim met As New dMetodos
        Dim lista As New ArrayList
        Dim lista2 As New ArrayList
        Dim lista3 As New ArrayList
        Dim acreditado As Integer = 0
        Dim acreditado2 As Integer = 0
        Dim xanalisis As Integer = 0
        Dim vec(xanalisis) As Integer
        Dim informefinal As Integer = 0
        Dim nombre_operador As String = ""
        Dim nombre_tecnico As String = ""
        Dim todos_acreditados As Integer = 1
        '*****************************
        nroficha = TextFicha.Text.Trim
        sa.ID = nroficha
        sa = sa.buscar
        lista = na.listarporfichamuestra(nroficha)
        lista3 = na3.listarporficha3(nroficha)
        '**********************************************
        If Not lista3 Is Nothing Then
            xanalisis = lista3.Count - 1
            ReDim vec(xanalisis)
            Dim i As Integer = 0
            For Each na3 In lista3
                vec(i) = na3.ANALISIS
                i = i + 1
            Next
        End If
        '***********************************************
        Dim fila As Integer
        Dim columna As Integer
        fila = 1
        columna = 1
        'Poner Titulos
        columna = 2
        x1hoja.Cells(3, 1).columnwidth = 30
        x1hoja.Cells(3, 2).columnwidth = 8
        x1hoja.Cells(3, 3).columnwidth = 8
        x1hoja.Cells(3, 4).columnwidth = 8
        x1hoja.Cells(3, 5).columnwidth = 8
        x1hoja.Cells(3, 6).columnwidth = 8
        x1hoja.Cells(3, 7).columnwidth = 8
        x1hoja.Cells(3, 8).columnwidth = 8
        x1hoja.Cells(3, 9).columnwidth = 8
        x1hoja.Cells(3, 10).columnwidth = 8
        x1hoja.Cells(3, 11).columnwidth = 8
        x1hoja.Cells(3, 12).columnwidth = 8
        x1hoja.Cells(3, 13).columnwidth = 8
        x1hoja.Cells(3, 14).columnwidth = 8
        x1hoja.Cells(3, 15).columnwidth = 8
        fila = fila + 4
        columna = 1
        x1hoja.Range("A5", "M5").Merge()
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Formula = "INFORME DE SEROLOGÍA"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 12
        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).Formula = "Nº Ficha: " & sa.ID
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        columna = columna + 10
        x1hoja.Cells(fila, columna).Formula = "Fecha entrada: " & sa.FECHAINGRESO
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        fila = fila + 1
        columna = 1
        cli.ID = sa.IDPRODUCTOR
        cli = cli.buscar
        x1hoja.Cells(fila, columna).Formula = "Cliente: " & cli.NOMBRE
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        columna = columna + 10
        Dim nnaa As New dNuevoAnalisis
        Dim fechaproceso As String = ""
        Dim listannaa As New ArrayList
        listannaa = nnaa.listarporficha2(sa.ID)
        If Not listannaa Is Nothing Then
            For Each nnaa In listannaa
                fechaproceso = nnaa.FECHAPROCESO
            Next
        Else
            Dim atx As New dAnalisisTercerizado
            Dim listaatx As New ArrayList
            listaatx = atx.listarporficha4(nroficha)
            If Not listaatx Is Nothing Then
                For Each atx In listaatx
                    fechaproceso = atx.FECHAPROCESO
                Next
            End If
        End If
        nnaa = Nothing
        listannaa = Nothing
        x1hoja.Cells(fila, columna).Formula = "Fecha proceso: " & fechaproceso
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        fila = fila + 1
        columna = 1
        If cli.DIRECCION <> "" Or cli.DIRECCION <> "No aportado" Then
            x1hoja.Cells(fila, columna).Formula = "Dirección: " & cli.DIRECCION
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            columna = columna + 10
        ElseIf cli.IDLOCALIDAD <> 999 Then
            Dim loc As New dLocalidad
            loc.ID = cli.IDLOCALIDAD
            loc = loc.buscar
            If Not loc Is Nothing Then
                x1hoja.Cells(fila, columna).Formula = loc.NOMBRE
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 10
            End If
        ElseIf cli.IDDEPARTAMENTO <> 999 Then
            Dim dep As New dDepartamento
            dep.ID = cli.IDDEPARTAMENTO
            dep = dep.buscar
            If Not dep Is Nothing Then
                x1hoja.Cells(fila, columna).Formula = dep.NOMBRE
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 10
            End If
        ElseIf cli.CELULAR <> "" Then
            x1hoja.Cells(fila, columna).Formula = "Celular: " & cli.CELULAR
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            columna = columna + 10
        Else
            x1hoja.Cells(fila, columna).Formula = "No aportado"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            columna = columna + 10
        End If
        Dim fecha As Date = Now()
        Dim fecha2 As String = fecha.ToString("dd/MM/yyyy")
        x1hoja.Cells(fila, columna).Formula = "Fecha informe: " & fecha2
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        fila = fila + 1
        columna = 1
        Dim mm As New dMuestras
        mm.ID = sa.IDMUESTRA
        mm = mm.buscar
        If Not mm Is Nothing Then
            x1hoja.Cells(fila, columna).Formula = "Material recibido: " & mm.NOMBRE
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
        Else
            x1hoja.Cells(fila, columna).Formula = "Material recibido: "
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
        End If
        columna = columna + 10
        x1hoja.Cells(fila, columna).Formula = "DICOSE: " & cli.DICOSE
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).Formula = "Total de muestras: " & sa.NMUESTRAS
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        columna = columna + 10
        Dim t As New dCliente
        t.ID = cli.TECNICO1
        t = t.buscar
        x1hoja.Cells(fila, columna).Formula = "Técnico: " & t.NOMBRE
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        columna = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).Formula = "Muestreo realizado por el cliente"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        columna = 1
        fila = fila + 1
        x1hoja.Range("A" & fila, "M" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).rowheight = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).rowheight = 3
        fila = fila + 1
        columna = 1
        Dim cuenta As Integer = 1
        Dim detallemuestras As String = ""
        Dim idoperador As Integer = 0
        Dim operador As String = ""
        Dim iu As New dUsuario
        iu.ID = idoperador
        iu = iu.buscar
        If Not iu Is Nothing Then
            operador = iu.NOMBRE
        End If
        If Not lista Is Nothing Then
            x1hoja.Cells(fila, columna).Formula = "Id. Muestra"
            x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeTop).Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeLeft).Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeRight).Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignBottom
            x1hoja.Cells(fila, columna).Font.Size = 8
            fila = fila + 1
            x1hoja.Cells(fila, columna).Formula = ""
            x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeBottom).Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeLeft).Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeRight).Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).Font.Size = 8
            columna = columna + 1
            fila = fila - 1
        End If
        Dim listademetodos As String = ""
        Dim listadeabreviaturas As String = ""
        If Not lista3 Is Nothing Then
            For Each na In lista3
                Dim u As New dUsuario
                u.ID = na.OPERADOR
                u = u.buscar
                If Not u Is Nothing Then
                    nombre_operador = u.NOMBRE
                End If
                Dim lp As New dListaPrecios
                lp.ID = na.ANALISIS
                lp = lp.buscar
                Dim lm As New dListaMetodos
                lm.ID = na.METODO
                lm = lm.buscar
                If Not lm Is Nothing Then
                    listademetodos = listademetodos & lp.DESCTECNICA & " - " & lm.METODO & " / "
                End If
                If lp.ABREVIATURA <> lp.DESCTECNICA Then
                    listadeabreviaturas = listadeabreviaturas & lp.ABREVIATURA & " - " & lp.DESCTECNICA & " / "
                End If
                Dim l As New dListaPrecios
                l.ID = na.ANALISIS
                l = l.buscar
                If Not l Is Nothing Then
                    x1hoja.Cells(fila, columna).Formula = l.ABREVIATURA
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 8
                End If
                l = Nothing
                Dim au As New dAnalisisUnidad
                au.ID = na.UNIDAD
                au = au.buscar
                If Not au Is Nothing Then
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).Formula = au.UNIDAD
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 6
                    fila = fila - 1
                    columna = columna + 1
                Else
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).Formula = ""
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 6
                    fila = fila - 1
                    columna = columna + 1
                End If
                lp = Nothing
                lm = Nothing
                u = Nothing
            Next
            columna = 1
            fila = fila + 2
        End If
        
        If Not lista Is Nothing Then
            For Each na In lista
                x1hoja.Cells(fila, columna).Formula = na.DETALLEMUESTRA
                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).WrapText = True
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                Dim na2 As New dNuevoAnalisis
                lista2 = na2.listarpormuestra(nroficha, na.MUESTRA)
                For Each na2 In lista2
                    Dim ret As Integer = Array.IndexOf(vec, na2.ANALISIS)
                    columna = columna + ret
                    x1hoja.Cells(fila, columna).Formula = na2.RESULTADO & " " & na2.RESULTADO2
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    Dim a As New dAcreditacion
                    a.ANALISIS = na2.ANALISIS
                    a = a.buscar
                    columna = columna - ret
                Next
                columna = 1
                fila = fila + 1
            Next
        End If
        If Not lista Is Nothing Then
            x1hoja.Cells(fila, columna).rowheight = 3
            fila = fila + 1
            x1hoja.Range("A" & fila, "M" & fila).Merge()
            x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).rowheight = 1
            fila = fila + 1
            x1hoja.Cells(fila, columna).Formula = "Abreviaturas"
            x1hoja.Cells(fila, columna).Font.Bold = True
            fila = fila + 1
            x1hoja.Cells(fila, columna).rowheight = 30
            x1hoja.Cells(fila, columna).Formula = listadeabreviaturas
            x1hoja.Range("A" & fila, "M" & fila).WrapText = True
            x1hoja.Range("A" & fila, "M" & fila).Merge()
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Size = 7
            fila = fila + 1
            x1hoja.Cells(fila, columna).Formula = "Métodos"
            x1hoja.Cells(fila, columna).Font.Bold = True
            fila = fila + 1
            x1hoja.Cells(fila, columna).rowheight = 30
            x1hoja.Cells(fila, columna).Formula = listademetodos
            x1hoja.Range("A" & fila, "M" & fila).WrapText = True
            x1hoja.Range("A" & fila, "M" & fila).Merge()
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Size = 7
            fila = fila + 1
        End If
    
        '********************************************************************
        If Not lista Is Nothing Then
            x1hoja.Cells(fila, columna).Formula = "" '"(*)Ensayo no acreditado ISO 17025 O.U.A."
            x1hoja.Cells(fila, columna).Font.Size = 8
            x1hoja.Cells(fila, columna).Font.Bold = True
            columna = columna + 10
            x1hoja.Cells(fila, columna).Formula = "Operador: " & nombre_operador
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 2
            columna = 1
        End If
        x1hoja.Shapes.AddPicture("c:\Debug\encabezado_sin_oua2.png", _
 Microsoft.Office.Core.MsoTriState.msoFalse, _
 Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 700, 50)
        'ANALISIS TERCERIZADOS***************************************************
        Dim filax As Integer = 0
        Dim at6 As New dAnalisisTercerizado
        Dim at5 As New dAnalisisTercerizado
        Dim listaat6 As New ArrayList
        Dim listaat5 As New ArrayList
        listaat6 = at6.listarporficha6(nroficha)
        listaat5 = at5.listarporficha5(nroficha)
        If Not listaat5 Is Nothing Then
            x1hoja.Cells(fila, columna).Formula = "ANÁLISIS TERCERIZADOS"
            x1hoja.Range("A" & fila, "M" & fila).Merge()
            x1hoja.Cells(fila, columna).Interior.Color = RGB(215, 219, 221)
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 10
            fila = fila + 1
            x1hoja.Cells(fila, columna).Formula = "Muestra"
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
            columna = columna + 1
            For Each at5 In listaat5
                Dim ater As New dAnalisisTercerizadoTipo
                ater.ID = at5.ANALISIS
                ater = ater.buscar
                x1hoja.Cells(fila, columna).Formula = ater.NOMBRE
                x1hoja.Cells(fila, columna).WrapText = True
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                columna = columna + 1
            Next
            columna = 1
            fila = fila + 1
            filax = fila
            For Each at6 In listaat6
                x1hoja.Cells(fila, columna).Formula = at6.MUESTRA
                x1hoja.Cells(fila, columna).WrapText = True
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                columna = columna + 1
                Dim at7 As New dAnalisisTercerizado
                Dim listaxmuestra As New ArrayList
                listaxmuestra = at7.listarporfichamuestra2(nroficha, at6.MUESTRA)
                For Each at7 In listaxmuestra
                    If at7.RESULTADO <> "" Then
                        x1hoja.Cells(fila, columna).Formula = at7.RESULTADO
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).Formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        'x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        columna = columna + 1
                    End If
                Next
                columna = 1
                fila = fila + 1
            Next
        End If
        fila = fila + 1
        'LABORATORIOS*********************************************************************************************
        Dim atz As New dAnalisisTercerizado
        Dim listaatz As New ArrayList
        listaatz = atz.listarlaboratorios(nroficha)
        Dim laboratorios As String = ""
        If Not listaatz Is Nothing Then
            For Each atz In listaatz
                Dim ol As New dOtrosLaboratorios
                ol.ID = atz.LABORATORIO
                ol = ol.buscar
                If Not ol Is Nothing Then
                    laboratorios = laboratorios & ol.NOMBRE & " - "
                End If
            Next
        End If
        x1hoja.Cells(fila, columna).Formula = "Las muestras fueron procesadas por: " & laboratorios
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        'METODOS**************************************************************************************
        Dim aty As New dAnalisisTercerizado
        Dim listaaty As New ArrayList
        listaaty = aty.listaranalisisnoeliminados(nroficha)
        Dim metodos As String = ""
        If Not listaaty Is Nothing Then
            Dim lepto As Integer = 0
            For Each aty In listaaty
                Dim attx As New dAnalisisTercerizadoTipo
                attx.ID = aty.ANALISIS
                attx = attx.buscar
                If attx.DEPENDE = 13 Then
                    Dim attx2 As New dAnalisisTercerizadoTipo
                    attx2.ID = 13
                    attx2 = attx2.buscar
                    If lepto <> 1 Then
                        metodos = metodos & attx2.NOMBRE & " - " & attx2.METODO & " / "
                    End If
                    attx2 = Nothing
                Else
                    metodos = metodos & attx.NOMBRE & " - " & attx.METODO & " / "
                End If
                If attx.DEPENDE = 13 Then
                    lepto = 1
                End If
            Next
        End If
        listademetodos = metodos
        x1hoja.Cells(fila, columna).Formula = "Métodos"
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        x1hoja.Cells(fila, columna).rowheight = 30
        x1hoja.Cells(fila, columna).Formula = listademetodos
        x1hoja.Range("A" & fila, "M" & fila).WrapText = True
        x1hoja.Range("A" & fila, "M" & fila).Merge()
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 7
        fila = fila + 1
        '*** OBSERVACIONES **************************************************
        If sa.OBSERVACIONES <> "" Then
            x1hoja.Cells(fila, columna).rowheight = 25
            x1hoja.Cells(fila, columna).Formula = "Observaciones: " & sa.OBSERVACIONES
            x1hoja.Range("A" & fila, "M" & fila).WrapText = True
            x1hoja.Range("A" & fila, "M" & fila).Merge()
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Size = 8
            fila = fila + 1
        End If
        '*** PONER FIRMA Y REFERENCIAS********************************************************
        x1libro.Worksheets(1).cells(fila, columna).select()
        x1libro.ActiveSheet.pictures.Insert("c:\Debug\cecilia.jpg").select()
        x1libro.Worksheets(1).cells(2, 1).select()
        columna = columna + 2
        fila = fila + 1
        x1hoja.Cells(fila, columna).Formula = "Referencias:"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
        x1hoja.Cells(fila, columna).Font.Size = 8
        fila = fila + 1
        x1hoja.Cells(fila, columna).Formula = "N/R = No reactivo"
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
        x1hoja.Cells(fila, columna).Font.Size = 8
        fila = fila + 1
        x1hoja.Cells(fila, columna).Formula = "+ = Positivo"
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
        x1hoja.Cells(fila, columna).Font.Size = 8
        fila = fila + 1
        x1hoja.Cells(fila, columna).Formula = "+++ = Fuertemente positivo"
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
        x1hoja.Cells(fila, columna).Font.Size = 8
        fila = fila + 2
        columna = 1
        '*** PIE DE PAGINA ******************************************************
        x1hoja.Cells(fila, columna).rowheight = 25
        x1hoja.Cells(fila, columna).Formula = "Este informe no podrá ser reproducido total o parcialmente sin la autorización escrita de COLAVECO. Los resultados consignados se refieren exclusivamente a la muestra recibida." & vbCrLf _
            & "COLAVECO declina toda responsabilidad por el uso indebido o incorrecto que se hiciere a este informe, asi como el plan y procedimientos de muestreo aplicados por el cliente. Dra. Cecilia Abelenda (Directora Técnica)"
        x1hoja.Range("A" & fila, "M" & fila).WrapText = True
        x1hoja.Range("A" & fila, "M" & fila).Merge()
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        '************************************************************************
        fila = fila + 1
        x1hoja.Range("A" & fila, "M" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(215, 219, 221)
        x1hoja.Cells(fila, columna).rowheight = 8
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
        x1hoja.Cells(fila, columna).Formula = "Fin del informe."
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 7
        'Insert tabla preinformes**************************
        Dim pi As New dPreinformes
        Dim fechaactual As Date = Now()
        Dim _fecha As String
        _fecha = Format(fechaactual, "yyyy-MM-dd")
        pi.FICHA = nroficha
        pi = pi.buscar
        If Not pi Is Nothing Then
        Else
            Dim pi2 As New dPreinformes
            pi2.FICHA = nroficha
            pi2.TIPO = 8
            pi2.CREADO = 1
            pi2.FECHA = _fecha
            pi2.guardar()
            pi2 = Nothing
        End If
        pi = Nothing
        '***********************************************************
        x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas
        'PROTEGE LA HOJA DE EXCEL
        x1hoja.Protect(Password:="1582782", DrawingObjects:=True, _
        Contents:=True, Scenarios:=True)
        'GUARDA EL ARCHIVO DE EXCEL
        x1hoja.SaveAs("\\ROBOT\PREINFORMES\SEROLOGIA\" & nroficha & ".xls")
        x1app.Visible = True
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
   
    Private Sub informe_parasitologia()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
        x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(1)
        x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(1)
        x1hoja.PageSetup.Orientation = (Excel.XlPageOrientation.xlLandscape)
        Dim sa As New dSolicitudAnalisis
        Dim cli As New dCliente
        Dim na As New dNuevoAnalisis
        Dim na3 As New dNuevoAnalisis
        Dim met As New dMetodos
        Dim lista As New ArrayList
        Dim lista2 As New ArrayList
        Dim lista3 As New ArrayList
        Dim acreditado As Integer = 0
        Dim acreditado2 As Integer = 0
        Dim xanalisis As Integer = 0
        Dim vec(xanalisis) As Integer
        Dim informefinal As Integer = 0
        Dim nombre_operador As String = ""
        Dim nombre_tecnico As String = ""
        '*****************************
        nroficha = TextFicha.Text.Trim
        sa.ID = nroficha
        sa = sa.buscar
        lista = na.listarporfichamuestra(nroficha)
        lista3 = na3.listarporficha3(nroficha)
        '**********************************************
        If Not lista3 Is Nothing Then
            xanalisis = lista3.Count - 1
            ReDim vec(xanalisis)
            Dim i As Integer = 0
            For Each na3 In lista3
                vec(i) = na3.ANALISIS
                i = i + 1
            Next
        End If
        '***********************************************
        Dim fila As Integer
        Dim columna As Integer
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                fila = 1
                columna = 1
                'Poner Titulos
                columna = 2
                x1hoja.Cells(3, 1).columnwidth = 20
                x1hoja.Cells(3, 2).columnwidth = 10
                x1hoja.Cells(3, 3).columnwidth = 10
                x1hoja.Cells(3, 4).columnwidth = 10
                x1hoja.Cells(3, 5).columnwidth = 10
                x1hoja.Cells(3, 6).columnwidth = 10
                x1hoja.Cells(3, 7).columnwidth = 10
                x1hoja.Cells(3, 8).columnwidth = 10
                x1hoja.Cells(3, 9).columnwidth = 10
                x1hoja.Cells(3, 10).columnwidth = 10
                x1hoja.Cells(3, 11).columnwidth = 10
                x1hoja.Cells(3, 12).columnwidth = 10
                fila = fila + 4
                x1hoja.Cells(fila, columna).rowheight = 3
                fila = fila + 1
                columna = 1
                x1hoja.Range("A" & fila, "L" & fila).Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).Formula = "INFORME DE PARASITOLOGÍA"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 12
                fila = fila + 1
                columna = 1
                x1hoja.Cells(fila, columna).Formula = "Nº Ficha: " & sa.ID
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 9
                x1hoja.Cells(fila, columna).Formula = "Fecha entrada: " & sa.FECHAINGRESO
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                cli.ID = sa.IDPRODUCTOR
                cli = cli.buscar
                x1hoja.Cells(fila, columna).Formula = "Cliente: " & cli.NOMBRE
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 9
                Dim nnaa As New dNuevoAnalisis
                Dim fechaproceso As String = ""
                Dim listannaa As New ArrayList
                listannaa = nnaa.listarporficha2(sa.ID)
                If Not listannaa Is Nothing Then
                    For Each nnaa In listannaa
                        fechaproceso = nnaa.FECHAPROCESO
                    Next
                End If
                nnaa = Nothing
                listannaa = Nothing
                x1hoja.Cells(fila, columna).Formula = "Fecha proceso: " & fechaproceso
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                If cli.DIRECCION <> "" Or cli.DIRECCION <> "No aportado" Then
                    x1hoja.Cells(fila, columna).Formula = "Dirección: " & cli.DIRECCION
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = columna + 9
                ElseIf cli.IDLOCALIDAD <> 999 Then
                    Dim loc As New dLocalidad
                    loc.ID = cli.IDLOCALIDAD
                    loc = loc.buscar
                    If Not loc Is Nothing Then
                        x1hoja.Cells(fila, columna).Formula = loc.NOMBRE
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 9
                        columna = columna + 9
                    End If
                ElseIf cli.IDDEPARTAMENTO <> 999 Then
                    Dim dep As New dDepartamento
                    dep.ID = cli.IDDEPARTAMENTO
                    dep = dep.buscar
                    If Not dep Is Nothing Then
                        x1hoja.Cells(fila, columna).Formula = dep.NOMBRE
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 9
                        columna = columna + 9
                    End If
                ElseIf cli.CELULAR <> "" Then
                    x1hoja.Cells(fila, columna).Formula = "Celular: " & cli.CELULAR
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = columna + 9
                Else
                    x1hoja.Cells(fila, columna).Formula = "No aportado"
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = columna + 9
                End If
                Dim fecha As Date = Now()
                Dim fecha2 As String = fecha.ToString("dd/MM/yyyy")
                x1hoja.Cells(fila, columna).Formula = "Fecha informe: " & fecha2
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                Dim mm As New dMuestras
                mm.ID = sa.IDMUESTRA
                mm = mm.buscar
                If Not mm Is Nothing Then
                    x1hoja.Cells(fila, columna).Formula = "Material recibido: " & mm.NOMBRE
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = columna + 2
                Else
                    x1hoja.Cells(fila, columna).Formula = "Material recibido: "
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    fila = fila + 1
                    columna = columna + 3
                End If
                x1hoja.Cells(fila, columna).Formula = "Total de muestras: " & sa.NMUESTRAS
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = 1
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Muestreo realizado por el cliente."
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                x1hoja.Range("A" & fila, "L" & fila).Merge()
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).rowheight = 1
                fila = fila + 1
                x1hoja.Cells(fila, columna).rowheight = 3
                fila = fila + 1
                columna = 1
                Dim cuenta As Integer = 1
                Dim detallemuestras As String = ""
                Dim idoperador As Integer = 0
                Dim operador As String = ""
                Dim iu As New dUsuario
                iu.ID = idoperador
                iu = iu.buscar
                If Not iu Is Nothing Then
                    operador = iu.NOMBRE
                End If
                x1hoja.Cells(fila, columna).Formula = "Id."
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeTop).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeLeft).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeRight).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).WrapText = True
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Muestra"
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeBottom).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeLeft).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeRight).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).WrapText = True
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                fila = fila - 1
                Dim listademetodos As String = ""
                Dim listadeabreviaturas As String = ""
                For Each na In lista3
                    Dim u As New dUsuario
                    u.ID = na.OPERADOR
                    u = u.buscar
                    If Not u Is Nothing Then
                        nombre_operador = u.NOMBRE
                    End If
                    Dim lp As New dListaPrecios
                    lp.ID = na.ANALISIS
                    lp = lp.buscar
                    Dim lm As New dListaMetodos
                    lm.ID = na.METODO
                    lm = lm.buscar
                    If Not lm Is Nothing Then
                        listademetodos = listademetodos & lp.DESCTECNICA & " - " & lm.METODO & " / "
                    End If
                    If lp.ABREVIATURA <> lp.DESCTECNICA Then
                        listadeabreviaturas = listadeabreviaturas & lp.ABREVIATURA & " - " & lp.DESCTECNICA & " / "
                    End If
                    Dim l As New dListaPrecios
                    l.ID = na.ANALISIS
                    l = l.buscar
                    x1hoja.Cells(fila, columna).Formula = l.ABREVIATURA
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    acreditado = 1
                    l = Nothing
                    Dim au As New dAnalisisUnidad
                    au.ID = na.UNIDAD
                    au = au.buscar
                    If Not au Is Nothing Then
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).Formula = au.UNIDAD
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        x1hoja.Cells(fila, columna).Font.Size = 6
                        fila = fila - 1
                        columna = columna + 1
                    Else
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).Formula = ""
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        x1hoja.Cells(fila, columna).Font.Size = 6
                        fila = fila - 1
                        columna = columna + 1
                    End If
                    lp = Nothing
                    lm = Nothing
                    u = Nothing
                Next
                columna = 1
                fila = fila + 2
                For Each na In lista
                    x1hoja.Cells(fila, columna).Formula = na.DETALLEMUESTRA
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    Dim x As Integer = 0
                    Dim n As Integer = 0
                    x = vec.Length
                    For n = 1 To x
                        x1hoja.Cells(fila, columna).Formula = "-"
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    Next
                    columna = columna - x
                    Dim na2 As New dNuevoAnalisis
                    lista2 = na2.listarpormuestra(nroficha, na.MUESTRA)
                    For Each na2 In lista2
                        Dim ret As Integer = Array.IndexOf(vec, na2.ANALISIS)
                        columna = columna + ret
                        x1hoja.Cells(fila, columna).Formula = na2.RESULTADO & " " & na2.RESULTADO2
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        Dim a As New dAcreditacion
                        a.ANALISIS = na2.ANALISIS
                        a = a.buscar
                        If Not a Is Nothing Then
                            Dim desde As Double = a.DESDE
                            Dim hasta As Double = a.HASTA
                            If Val(na2.RESULTADO2) < desde Or Val(na2.RESULTADO2) > hasta Then
                                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                            Else
                                acreditado2 = 1
                            End If
                        End If
                        columna = columna - ret
                    Next
                    columna = 1
                    fila = fila + 1
                Next
                x1hoja.Cells(fila, columna).rowheight = 3
                fila = fila + 1
                x1hoja.Range("A" & fila, "L" & fila).Merge()
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).rowheight = 1
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Abreviaturas"
                x1hoja.Cells(fila, columna).Font.Bold = True
                fila = fila + 1
                x1hoja.Cells(fila, columna).rowheight = 30
                x1hoja.Cells(fila, columna).Formula = listadeabreviaturas
                x1hoja.Range("A" & fila, "L" & fila).WrapText = True
                x1hoja.Range("A" & fila, "L" & fila).Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Size = 7
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Métodos"
                x1hoja.Cells(fila, columna).Font.Bold = True
                fila = fila + 1
                x1hoja.Cells(fila, columna).rowheight = 30
                x1hoja.Cells(fila, columna).Formula = listademetodos
                x1hoja.Range("A" & fila, "L" & fila).WrapText = True
                x1hoja.Range("A" & fila, "L" & fila).Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Size = 7
                fila = fila + 1
                '*** OBSERVACIONES **************************************************
                If sa.OBSERVACIONES <> "" Then
                    x1hoja.Cells(fila, columna).rowheight = 25
                    x1hoja.Cells(fila, columna).Formula = "Observaciones: " & sa.OBSERVACIONES
                    x1hoja.Range("A" & fila, "L" & fila).WrapText = True
                    x1hoja.Range("A" & fila, "L" & fila).Merge()
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    fila = fila + 1
                End If
                '********************************************************************
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                columna = columna + 3
                x1hoja.Cells(fila, columna).Formula = "Referencias:"
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "-"
                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Bold = False
                columna = columna + 1
                x1hoja.Cells(fila, columna).Formula = "Análisis no requerido."
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 7
                columna = 1
                'CABEZAL CON O SIN LOGO OUA
                x1hoja.Shapes.AddPicture("c:\Debug\encabezado_sin_oua2.png", _
             Microsoft.Office.Core.MsoTriState.msoFalse, _
             Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 700, 50)
                '*** IMPORTE ********************************************************
                Dim f As New dFacturacion
                Dim listast As New ArrayList
                listast = f.listarxficha(nroficha)
                Dim total As Double = 0
                Dim lp2 As New dListaPrecios
                lp2.ID = 86
                lp2 = lp2.buscar
                If Not lp2 Is Nothing Then
                    total = total + lp2.PRECIO1
                End If
                f = Nothing
                lp2 = Nothing
                columna = columna + 9
                x1hoja.Cells(fila, columna).Formula = "Operador: " & nombre_operador
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = 1
                '*** PONER FIRMA ********************************************************
                x1libro.Worksheets(1).cells(fila, columna).select()
                x1libro.ActiveSheet.pictures.Insert("c:\Debug\cecilia.jpg").select()
                x1libro.Worksheets(1).cells(2, 1).select()
                fila = fila + 6
                columna = 1
                '*** DETALLE DEL MUESTREO **************************************************
                If sa.MUESTREO = 1 Then
                    Dim dm As New dDetalleMuestreo
                    dm.FICHA = sa.ID
                    dm = dm.buscar
                    If Not dm Is Nothing Then
                        x1hoja.Cells(fila, columna).rowheight = 45
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Formula = "Fecha de muestreo: " & dm.FECHA & vbCrLf _
            & dm.OBSERVACIONES
                        x1hoja.Range("A" & fila, "L" & fila).WrapText = True
                        x1hoja.Range("A" & fila, "L" & fila).Merge()
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        fila = fila + 1
                    End If
                Else
                    x1hoja.Cells(fila, columna).rowheight = 13
                    x1hoja.Cells(fila, columna).Formula = "Muestreo realizado por el cliente."
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Range("A" & fila, "L" & fila).WrapText = True
                    x1hoja.Range("A" & fila, "L" & fila).Merge()
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    fila = fila + 1
                End If
                '********************************************************************
                '*** PIE DE PAGINA ******************************************************
                x1hoja.Cells(fila, columna).rowheight = 25
                x1hoja.Cells(fila, columna).Formula = "Este informe no podrá ser reproducido total o parcialmente sin la autorización escrita de COLAVECO. Los resultados consignados se refieren exclusivamente a la muestra recibida." & vbCrLf _
                    & "COLAVECO declina toda responsabilidad por el uso indebido o incorrecto que se hiciere a este informe, asi como el plan y procedimientos de muestreo aplicados por el cliente. Dra. Cecilia Abelenda (Directora Técnica)"
                x1hoja.Range("A" & fila, "L" & fila).WrapText = True
                x1hoja.Range("A" & fila, "L" & fila).Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Size = 6
                '************************************************************************
                fila = fila + 1
                x1hoja.Range("A" & fila, "L" & fila).Merge()
                x1hoja.Cells(fila, columna).Interior.Color = RGB(215, 219, 221)
                x1hoja.Cells(fila, columna).rowheight = 8
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Formula = "Fin del informe."
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 7
            End If
        End If
        'Insert tabla preinformes**************************
        Dim pi As New dPreinformes
        Dim fechaactual As Date = Now()
        Dim _fecha As String
        _fecha = Format(fechaactual, "yyyy-MM-dd")
        pi.FICHA = nroficha
        pi = pi.buscar
        If Not pi Is Nothing Then
            Dim pi2 As New dPreinformes
            pi2.FICHA = nroficha
            pi2.TIPO = 6
            pi2.CREADO = 1
            pi2.FECHA = _fecha
            pi2.modificar()
            pi2 = Nothing
        Else
            Dim pi2 As New dPreinformes
            pi2.FICHA = nroficha
            pi2.TIPO = 6
            pi2.CREADO = 1
            pi2.FECHA = _fecha
            pi2.guardar()
            pi2 = Nothing
        End If
        pi = Nothing
        '***********************************************************
        x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas
        'PROTEGE LA HOJA DE EXCEL
        x1hoja.Protect(Password:="1582782", DrawingObjects:=True, _
        Contents:=True, Scenarios:=True)
        'GUARDA EL ARCHIVO DE EXCEL
        x1hoja.SaveAs("\\ROBOT\PREINFORMES\PARASITOLOGIA\" & nroficha & ".xls")
        x1app.Visible = True
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub informe_bacteriologia_clinica_aerobica_no_usar()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
        x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(1)
        x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(1)
        x1hoja.PageSetup.Orientation = (Excel.XlPageOrientation.xlLandscape)
        Dim sa As New dSolicitudAnalisis
        Dim cli As New dCliente
        Dim na As New dNuevoAnalisis
        Dim na3 As New dNuevoAnalisis
        Dim met As New dMetodos
        Dim lista As New ArrayList
        Dim lista2 As New ArrayList
        Dim lista3 As New ArrayList
        Dim acreditado As Integer = 0
        Dim acreditado2 As Integer = 0
        Dim xanalisis As Integer = 0
        Dim vec(xanalisis) As Integer
        Dim informefinal As Integer = 0
        Dim nombre_operador As String = ""
        Dim nombre_tecnico As String = "xxx xxx xxx xxx"
        '*****************************
        nroficha = TextFicha.Text.Trim
        sa.ID = nroficha
        sa = sa.buscar
        lista = na.listarporfichamuestra(nroficha)
        lista3 = na3.listarporficha3(nroficha)
        '**********************************************
        If Not lista3 Is Nothing Then
            xanalisis = lista3.Count - 1
            ReDim vec(xanalisis)
            Dim i As Integer = 0
            For Each na3 In lista3
                vec(i) = na3.ANALISIS
                i = i + 1
            Next
        End If
        '***********************************************
        Dim fila As Integer
        Dim columna As Integer
        fila = 1
        columna = 1
        'Poner Titulos
        columna = 2
        x1hoja.Cells(3, 1).columnwidth = 30
        x1hoja.Cells(3, 2).columnwidth = 12
        x1hoja.Cells(3, 3).columnwidth = 12
        x1hoja.Cells(3, 4).columnwidth = 12
        x1hoja.Cells(3, 5).columnwidth = 12
        x1hoja.Cells(3, 6).columnwidth = 12
        x1hoja.Cells(3, 7).columnwidth = 12
        x1hoja.Cells(3, 8).columnwidth = 12
        x1hoja.Cells(3, 9).columnwidth = 12
        x1hoja.Cells(3, 10).columnwidth = 14
        fila = fila + 4
        columna = 1
        x1hoja.Cells(fila, columna).rowheight = 3
        fila = fila + 1
        x1hoja.Range("A" & fila, "I" & fila).Merge()
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Formula = "INFORME BACTERIOLOGÍA CLÍNICA AERÓBICA"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 12
        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).Formula = "Nº Ficha: " & sa.ID
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        columna = columna + 7
        x1hoja.Cells(fila, columna).Formula = "Fecha entrada: " & sa.FECHAINGRESO
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        fila = fila + 1
        columna = 1
        cli.ID = sa.IDPRODUCTOR
        cli = cli.buscar
        x1hoja.Cells(fila, columna).Formula = "Cliente: " & cli.NOMBRE
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        columna = columna + 7
        Dim nnaa As New dNuevoAnalisis
        Dim fechaproceso As String = ""
        Dim listannaa As New ArrayList
        listannaa = nnaa.listarporficha2(sa.ID)
        If Not listannaa Is Nothing Then
            For Each nnaa In listannaa
                fechaproceso = nnaa.FECHAPROCESO
            Next
        Else
            Dim atx As New dAnalisisTercerizado
            Dim listaatx As New ArrayList
            listaatx = atx.listarporficha4(nroficha)
            If Not listaatx Is Nothing Then
                For Each atx In listaatx
                    fechaproceso = atx.FECHAPROCESO
                Next
            End If
        End If
        nnaa = Nothing
        listannaa = Nothing
        x1hoja.Cells(fila, columna).Formula = "Fecha proceso: " & fechaproceso
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        fila = fila + 1
        columna = 1
        If cli.DIRECCION <> "" Or cli.DIRECCION <> "No aportado" Then
            x1hoja.Cells(fila, columna).Formula = "Dirección: " & cli.DIRECCION
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            columna = columna + 7
        ElseIf cli.IDLOCALIDAD <> 999 Then
            Dim loc As New dLocalidad
            loc.ID = cli.IDLOCALIDAD
            loc = loc.buscar
            If Not loc Is Nothing Then
                x1hoja.Cells(fila, columna).Formula = loc.NOMBRE
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 7
            End If
        ElseIf cli.IDDEPARTAMENTO <> 999 Then
            Dim dep As New dDepartamento
            dep.ID = cli.IDDEPARTAMENTO
            dep = dep.buscar
            If Not dep Is Nothing Then
                x1hoja.Cells(fila, columna).Formula = dep.NOMBRE
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 7
            End If
        ElseIf cli.CELULAR <> "" Then
            x1hoja.Cells(fila, columna).Formula = "Celular: " & cli.CELULAR
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            columna = columna + 7
        Else
            x1hoja.Cells(fila, columna).Formula = "No aportado"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            columna = columna + 7
        End If
        Dim fecha As Date = Now()
        Dim fecha2 As String = fecha.ToString("dd/MM/yyyy")
        x1hoja.Cells(fila, columna).Formula = "Fecha informe: " & fecha2
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        fila = fila + 1
        columna = 1
        Dim mm As New dMuestras
        mm.ID = sa.IDMUESTRA
        mm = mm.buscar
        If Not mm Is Nothing Then
            x1hoja.Cells(fila, columna).Formula = "Material recibido: " & mm.NOMBRE
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 1
        Else
            x1hoja.Cells(fila, columna).Formula = "Material recibido: "
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 1
            fila = fila + 1
        End If
        x1hoja.Cells(fila, columna).Formula = "Total de muestras: " & sa.NMUESTRAS
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        columna = columna + 7
        Dim c2 As New dCliente
        c2.ID = sa.IDTECNICO
        c2 = c2.buscar
        If Not c2 Is Nothing Then
            x1hoja.Cells(fila, columna).Formula = "Téc.: " & c2.NOMBRE
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            columna = 1
        Else
            x1hoja.Cells(fila, columna).Formula = "Téc.: "
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            columna = 1
        End If
        fila = fila + 1
        x1hoja.Cells(fila, columna).Formula = "Muestreo realizado por el cliente"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        columna = columna + 7
        x1hoja.Cells(fila, columna).Formula = "DICOSE:" & cli.DICOSE
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        columna = 1
        fila = fila + 1
        x1hoja.Range("A" & fila, "I" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).rowheight = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).rowheight = 3
        fila = fila + 1
        columna = 1
        Dim cuenta As Integer = 1
        Dim detallemuestras As String = ""
        Dim idoperador As Integer = 0
        Dim operador As String = ""
        Dim iu As New dUsuario
        iu.ID = idoperador
        iu = iu.buscar
        If Not iu Is Nothing Then
            operador = iu.NOMBRE
        End If
        If Not lista Is Nothing Then
            x1hoja.Cells(fila, columna).Formula = "Id. Muestra"
            x1hoja.Range("A" & fila, "A" & fila).Borders.Color = RGB(0, 0, 0)
            x1hoja.Range("A" & fila, "A" & fila).Interior.Color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignBottom
            x1hoja.Cells(fila, columna).Font.Size = 8
            x1hoja.Cells(fila, columna).Font.Bold = True
            columna = columna + 1
        End If
        Dim listademetodos As String = ""
        Dim listadeabreviaturas As String = ""
        If Not lista3 Is Nothing Then
            For Each na In lista3
                Dim u As New dUsuario
                u.ID = na.OPERADOR
                u = u.buscar
                If Not u Is Nothing Then
                    nombre_operador = u.NOMBRE
                End If
                Dim lp As New dListaPrecios
                lp.ID = na.ANALISIS
                lp = lp.buscar
                Dim lm As New dListaMetodos
                lm.ID = na.METODO
                lm = lm.buscar
                If Not lm Is Nothing Then
                    listademetodos = listademetodos & lp.DESCTECNICA & " - " & lm.METODO & " / "
                End If
                If lp.ABREVIATURA <> lp.DESCTECNICA Then
                    listadeabreviaturas = listadeabreviaturas & lp.ABREVIATURA & " - " & lp.DESCTECNICA & " / "
                End If
                Dim l As New dListaPrecios
                l.ID = na.ANALISIS
                l = l.buscar
                If Not l Is Nothing Then
                    x1hoja.Range("B" & fila, "G" & fila).WrapText = True
                    x1hoja.Range("B" & fila, "G" & fila).Merge()
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                    x1hoja.Cells(fila, columna).Formula = l.ABREVIATURA
                    x1hoja.Range("B" & fila, "G" & fila).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 8
                End If
                l = Nothing
                lp = Nothing
                lm = Nothing
                u = Nothing
            Next
        End If
        columna = 1
        fila = fila + 1
        If Not lista Is Nothing Then
            For Each na In lista
                x1hoja.Range("A" & fila, "A" & fila).WrapText = True
                x1hoja.Range("A" & fila, "A" & fila).Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Formula = na.DETALLEMUESTRA
                x1hoja.Range("A" & fila, "A" & fila).Borders.Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                Dim na2 As New dNuevoAnalisis
                lista2 = na2.listarpormuestra(nroficha, na.MUESTRA)
                For Each na2 In lista2
                    Dim ret As Integer = Array.IndexOf(vec, na2.ANALISIS)
                    columna = columna + ret
                    If na2.RESULTADO <> "" Then
                        x1hoja.Range("B" & fila, "G" & fila).WrapText = True
                        x1hoja.Range("B" & fila, "G" & fila).Merge()
                        x1hoja.Range("B" & fila, "G" & fila).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        x1hoja.Cells(fila, columna).Formula = na2.RESULTADO
                        x1hoja.Cells(fila, columna).Font.Size = 8
                    Else
                        x1hoja.Range("B" & fila, "G" & fila).WrapText = True
                        x1hoja.Range("B" & fila, "G" & fila).Merge()
                        x1hoja.Range("B" & fila, "G" & fila).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        x1hoja.Cells(fila, columna).Formula = na2.RESULTADO2
                        x1hoja.Cells(fila, columna).Font.Size = 8
                    End If
                    Dim a As New dAcreditacion
                    a.ANALISIS = na2.ANALISIS
                    a = a.buscar
                    columna = columna - ret
                Next
                columna = 1
                fila = fila + 1
            Next
        End If
        If Not lista Is Nothing Then
            x1hoja.Cells(fila, columna).rowheight = 3
            fila = fila + 1
            x1hoja.Range("A" & fila, "I" & fila).Merge()
            x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).rowheight = 1
            fila = fila + 1
            If listadeabreviaturas <> "" Then
                x1hoja.Cells(fila, columna).Formula = "Abreviaturas"
                x1hoja.Cells(fila, columna).Font.Bold = True
                fila = fila + 1
                x1hoja.Cells(fila, columna).rowheight = 30
                x1hoja.Cells(fila, columna).Formula = listadeabreviaturas
                x1hoja.Range("A" & fila, "I" & fila).WrapText = True
                x1hoja.Range("A" & fila, "I" & fila).Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Size = 7
                fila = fila + 1
            End If
            x1hoja.Cells(fila, columna).Formula = "Métodos"
            x1hoja.Cells(fila, columna).Font.Bold = True
            fila = fila + 1
            x1hoja.Cells(fila, columna).rowheight = 30
            x1hoja.Cells(fila, columna).Formula = listademetodos
            x1hoja.Range("A" & fila, "I" & fila).WrapText = True
            x1hoja.Range("A" & fila, "I" & fila).Merge()
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Size = 7
            fila = fila + 1
        End If
        '*** OBSERVACIONES **************************************************
        If sa.OBSERVACIONES <> "" Then
            x1hoja.Cells(fila, columna).rowheight = 25
            x1hoja.Range("A" & fila, "I" & fila).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Formula = "Observaciones: " & sa.OBSERVACIONES
            x1hoja.Range("A" & fila, "I" & fila).WrapText = True
            x1hoja.Range("A" & fila, "I" & fila).Merge()
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Size = 8
            fila = fila + 1
        End If
        '********************************************************************
        If Not lista Is Nothing Then
            x1hoja.Cells(fila, columna).Formula = "" '"(*)Ensayo no acreditado ISO 17025 O.U.A."
            x1hoja.Cells(fila, columna).Font.Size = 8
            x1hoja.Cells(fila, columna).Font.Bold = True
            columna = columna + 7
            x1hoja.Cells(fila, columna).Formula = "Operador: " & nombre_operador
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 2
            columna = 1
        End If
        'CABEZAL CON O SIN LOGO OUA
        x1hoja.Shapes.AddPicture("c:\Debug\encabezado_sin_oua2.png", _
 Microsoft.Office.Core.MsoTriState.msoFalse, _
 Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 690, 40)
        'ANALISIS TERCERIZADOS***************************************************
        Dim at As New dAnalisisTercerizado
        Dim listaat As New ArrayList
        listaat = at.listarporficha4(nroficha)
        If Not listaat Is Nothing Then
            x1hoja.Cells(fila, columna).Formula = "ANÁLISIS TERCERIZADOS"
            x1hoja.Range("A" & fila, "I" & fila).Merge()
            x1hoja.Cells(fila, columna).Interior.Color = RGB(215, 219, 221)
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 10
            fila = fila + 1
            x1hoja.Cells(fila, columna).Formula = "Muestra"
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            columna = columna + 1
            x1hoja.Cells(fila, columna).Formula = "Análisis"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            columna = columna + 3
            x1hoja.Cells(fila, columna).Formula = "Resultado"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            columna = columna + 1
            x1hoja.Cells(fila, columna).Formula = "Unidad"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            columna = columna + 1
            x1hoja.Cells(fila, columna).Formula = "Método"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            columna = columna + 4
            x1hoja.Cells(fila, columna).Formula = "Laboratorio"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            columna = 1
            fila = fila + 1
            For Each at In listaat
                x1hoja.Cells(fila, columna).Formula = at.MUESTRA
                x1hoja.Cells(fila, columna).WrapText = True
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                Dim att As New dAnalisisTercerizadoTipo
                att.ID = at.ANALISIS
                att = att.buscar
                If Not att Is Nothing Then
                    x1hoja.Cells(fila, columna).Formula = att.NOMBRE
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 3
                Else
                    x1hoja.Cells(fila, columna).Formula = ""
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 3
                End If
                x1hoja.Cells(fila, columna).Formula = at.RESULTADO
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                x1hoja.Cells(fila, columna).Formula = at.UNIDAD
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                x1hoja.Cells(fila, columna).Formula = at.METODO
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 4
                Dim ol As New dOtrosLaboratorios
                ol.ID = at.LABORATORIO
                ol = ol.buscar
                If Not ol Is Nothing Then
                    x1hoja.Cells(fila, columna).Formula = ol.NOMBRE
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = 1
                    fila = fila + 1
                Else
                    x1hoja.Cells(fila, columna).Formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = 1
                    fila = fila + 1
                End If
            Next
            fila = fila + 1
        End If
        '*** PONER FIRMA ********************************************************
        x1libro.Worksheets(1).cells(fila, columna).select()
        x1libro.ActiveSheet.pictures.Insert("c:\Debug\cecilia.jpg").select()
        x1libro.Worksheets(1).cells(2, 1).select()
        fila = fila + 6
        columna = 1
        '*** PIE DE PAGINA ******************************************************
        x1hoja.Cells(fila, columna).rowheight = 25
        x1hoja.Cells(fila, columna).Formula = "Este informe no podrá ser reproducido total o parcialmente sin la autorización escrita de COLAVECO. Los resultados consignados se refieren exclusivamente a la muestra recibida." & vbCrLf _
            & "COLAVECO declina toda responsabilidad por el uso indebido o incorrecto que se hiciere a este informe, asi como el plan y procedimientos de muestreo aplicados por el cliente. Dra. Cecilia Abelenda (Directora Técnica)"
        x1hoja.Range("A" & fila, "I" & fila).WrapText = True
        x1hoja.Range("A" & fila, "I" & fila).Merge()
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        '************************************************************************
        fila = fila + 1
        x1hoja.Range("A" & fila, "I" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(215, 219, 221)
        x1hoja.Cells(fila, columna).rowheight = 8
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
        x1hoja.Cells(fila, columna).Formula = "Fin del informe."
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 7
        'Insert tabla preinformes**************************
        Dim pi As New dPreinformes
        Dim fechaactual As Date = Now()
        Dim _fecha As String
        _fecha = Format(fechaactual, "yyyy-MM-dd")
        pi.FICHA = nroficha
        pi = pi.buscar
        If Not pi Is Nothing Then
        Else
            Dim pi2 As New dPreinformes
            pi2.FICHA = nroficha
            pi2.TIPO = 11
            pi2.CREADO = 1
            pi2.FECHA = _fecha
            pi2.guardar()
            pi2 = Nothing
        End If
        pi = Nothing
        '***********************************************************
        x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas
        'PROTEGE LA HOJA DE EXCEL
        x1hoja.Protect(Password:="1582782", DrawingObjects:=True, _
        Contents:=True, Scenarios:=True)
        'GUARDA EL ARCHIVO DE EXCEL
        x1hoja.SaveAs("\\ROBOT\PREINFORMES\AMBIENTAL\" & nroficha & ".xls")
        x1app.Visible = True
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub informe_patologia()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
        x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(1)
        x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(1)
        x1hoja.PageSetup.Orientation = (Excel.XlPageOrientation.xlLandscape)
        Dim sa As New dSolicitudAnalisis
        Dim cli As New dCliente
        Dim na As New dNuevoAnalisis
        Dim na3 As New dNuevoAnalisis
        Dim met As New dMetodos
        Dim lista As New ArrayList
        Dim lista2 As New ArrayList
        Dim lista3 As New ArrayList
        Dim acreditado As Integer = 0
        Dim acreditado2 As Integer = 0
        Dim xanalisis As Integer = 0
        Dim vec(xanalisis) As Integer
        Dim informefinal As Integer = 0
        Dim nombre_operador As String = ""
        Dim nombre_tecnico As String = ""
        Dim todos_acreditados As Integer = 1
        '*****************************
        nroficha = TextFicha.Text.Trim
        sa.ID = nroficha
        sa = sa.buscar
        lista = na.listarporfichamuestra(nroficha)
        lista3 = na3.listarporficha3(nroficha)
        '**********************************************
        If Not lista3 Is Nothing Then
            xanalisis = lista3.Count - 1
            ReDim vec(xanalisis)
            Dim i As Integer = 0
            For Each na3 In lista3
                vec(i) = na3.ANALISIS
                i = i + 1
            Next
        End If
        '***********************************************
        Dim fila As Integer
        Dim columna As Integer
        fila = 1
        columna = 1
        'Poner Titulos
        columna = 2
        x1hoja.Cells(3, 1).columnwidth = 24.71
        x1hoja.Cells(3, 2).columnwidth = 16.29
        x1hoja.Cells(3, 3).columnwidth = 59.71
        x1hoja.Cells(3, 4).columnwidth = 16.57
        x1hoja.Cells(3, 5).columnwidth = 16
        fila = fila + 4
        columna = 1
        x1hoja.Range("A5", "E5").Merge()
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Formula = "INFORME DE PATOLOGÍA"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 12
        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).Formula = "Nº Ficha: " & sa.ID
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        columna = columna + 3
        x1hoja.Cells(fila, columna).Formula = "Fecha entrada: " & sa.FECHAINGRESO
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        fila = fila + 1
        columna = 1
        cli.ID = sa.IDPRODUCTOR
        cli = cli.buscar
        x1hoja.Cells(fila, columna).Formula = "Cliente: " & cli.NOMBRE
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        columna = columna + 3
        Dim nnaa As New dNuevoAnalisis
        Dim fechaproceso As String = ""
        Dim listannaa As New ArrayList
        listannaa = nnaa.listarporficha2(sa.ID)
        If Not listannaa Is Nothing Then
            For Each nnaa In listannaa
                fechaproceso = nnaa.FECHAPROCESO
            Next
        Else
            Dim atx As New dAnalisisTercerizado
            Dim listaatx As New ArrayList
            listaatx = atx.listarporficha4(nroficha)
            If Not listaatx Is Nothing Then
                For Each atx In listaatx
                    fechaproceso = atx.FECHAPROCESO
                Next
            End If
        End If
        nnaa = Nothing
        listannaa = Nothing
        x1hoja.Cells(fila, columna).Formula = "Fecha proceso: " & fechaproceso
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        fila = fila + 1
        columna = 1
        If cli.DIRECCION <> "" Or cli.DIRECCION <> "No aportado" Then
            x1hoja.Cells(fila, columna).Formula = "Dirección: " & cli.DIRECCION
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            columna = columna + 3
        ElseIf cli.IDLOCALIDAD <> 999 Then
            Dim loc As New dLocalidad
            loc.ID = cli.IDLOCALIDAD
            loc = loc.buscar
            If Not loc Is Nothing Then
                x1hoja.Cells(fila, columna).Formula = loc.NOMBRE
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 3
            End If
        ElseIf cli.IDDEPARTAMENTO <> 999 Then
            Dim dep As New dDepartamento
            dep.ID = cli.IDDEPARTAMENTO
            dep = dep.buscar
            If Not dep Is Nothing Then
                x1hoja.Cells(fila, columna).Formula = dep.NOMBRE
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 3
            End If
        ElseIf cli.CELULAR <> "" Then
            x1hoja.Cells(fila, columna).Formula = "Celular: " & cli.CELULAR
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            columna = columna + 3
        Else
            x1hoja.Cells(fila, columna).Formula = "No aportado"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            columna = columna + 3
        End If
        Dim fecha As Date = Now()
        Dim fecha2 As String = fecha.ToString("dd/MM/yyyy")
        x1hoja.Cells(fila, columna).Formula = "Fecha informe: " & fecha2
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        fila = fila + 1
        columna = 1
        Dim mm As New dMuestras
        mm.ID = sa.IDMUESTRA
        mm = mm.buscar
        If Not mm Is Nothing Then
            x1hoja.Cells(fila, columna).Formula = "Material recibido: " & mm.NOMBRE
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 1
        Else
            x1hoja.Cells(fila, columna).Formula = "Material recibido: "
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 1
        End If
        x1hoja.Cells(fila, columna).Formula = "Total de muestras: " & sa.NMUESTRAS
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        columna = columna + 3
        Dim c2 As New dCliente
        c2.ID = sa.IDTECNICO
        c2 = c2.buscar
        If Not c2 Is Nothing Then
            x1hoja.Cells(fila, columna).Formula = "Téc.: " & c2.NOMBRE
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            columna = 1
        Else
            x1hoja.Cells(fila, columna).Formula = "Téc.: "
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            columna = 1
        End If
        columna = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).Formula = "Muestreo realizado por el cliente"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        columna = columna + 3
        x1hoja.Cells(fila, columna).Formula = "DICOSE:" & cli.DICOSE
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        columna = 1
        fila = fila + 1
        x1hoja.Range("A" & fila, "E" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).rowheight = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).rowheight = 3
        fila = fila + 1
        columna = 1
        Dim cuenta As Integer = 1
        Dim detallemuestras As String = ""
        Dim idoperador As Integer = 0
        Dim operador As String = ""
        Dim iu As New dUsuario
        iu.ID = idoperador
        iu = iu.buscar
        If Not iu Is Nothing Then
            operador = iu.NOMBRE
        End If
        If Not lista Is Nothing Then
            x1hoja.Cells(fila, columna).Formula = "Id. Muestra"
            x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeTop).Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeLeft).Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeRight).Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignBottom
            x1hoja.Cells(fila, columna).Font.Size = 8
            fila = fila + 1
            x1hoja.Cells(fila, columna).Formula = ""
            x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeBottom).Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeLeft).Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeRight).Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).Font.Size = 8
            columna = columna + 1
            fila = fila - 1
        End If
        Dim listademetodos As String = ""
        Dim listadeabreviaturas As String = ""
        If Not lista3 Is Nothing Then
            For Each na In lista3
                Dim u As New dUsuario
                u.ID = na.OPERADOR
                u = u.buscar
                If Not u Is Nothing Then
                    nombre_operador = u.NOMBRE
                End If
                Dim lp As New dListaPrecios
                lp.ID = na.ANALISIS
                lp = lp.buscar
                Dim lm As New dListaMetodos
                lm.ID = na.METODO
                lm = lm.buscar
                If Not lm Is Nothing Then
                    listademetodos = listademetodos & lp.DESCTECNICA & " - " & lm.METODO & " / "
                End If
                If lp.ABREVIATURA <> lp.DESCTECNICA Then
                    listadeabreviaturas = listadeabreviaturas & lp.ABREVIATURA & " - " & lp.DESCTECNICA & " / "
                End If
                Dim l As New dListaPrecios
                l.ID = na.ANALISIS
                l = l.buscar
                If Not l Is Nothing Then
                    x1hoja.Range("B" & fila, "C" & fila).WrapText = True
                    x1hoja.Range("B" & fila, "C" & fila).Merge()
                    x1hoja.Cells(fila, columna).Formula = "RESULTADOS" 'l.ABREVIATURA
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 8
                End If
                l = Nothing
                Dim au As New dAnalisisUnidad
                au.ID = na.UNIDAD
                au = au.buscar
                If Not au Is Nothing Then
                    fila = fila + 1
                    x1hoja.Range("B" & fila, "C" & fila).WrapText = True
                    x1hoja.Range("B" & fila, "C" & fila).Merge()
                    x1hoja.Cells(fila, columna).Formula = au.UNIDAD
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 6
                    fila = fila - 1
                    columna = columna + 1
                Else
                    fila = fila + 1
                    x1hoja.Range("B" & fila, "C" & fila).WrapText = True
                    x1hoja.Range("B" & fila, "C" & fila).Merge()
                    x1hoja.Cells(fila, columna).Formula = ""
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 6
                    fila = fila - 1
                    columna = columna + 1
                End If
                lp = Nothing
                lm = Nothing
                u = Nothing
            Next
        End If
        columna = 1
        fila = fila + 2
        If Not lista Is Nothing Then
            For Each na In lista
                x1hoja.Cells(fila, columna).Formula = na.DETALLEMUESTRA
                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).WrapText = True
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                Dim na2 As New dNuevoAnalisis
                lista2 = na2.listarpormuestra(nroficha, na.MUESTRA)
                For Each na2 In lista2
                    Dim ret As Integer = Array.IndexOf(vec, na2.ANALISIS)
                    columna = columna + ret
                    If na2.RESULTADO <> "" Then
                        x1hoja.Cells(fila, columna).rowheight = 48
                        x1hoja.Range("B" & fila, "C" & fila).WrapText = True
                        x1hoja.Range("B" & fila, "C" & fila).Merge()
                        x1hoja.Range("B" & fila, "C" & fila).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        x1hoja.Cells(fila, columna).Formula = na2.RESULTADO
                        x1hoja.Cells(fila, columna).Font.Size = 8
                    Else
                        x1hoja.Cells(fila, columna).rowheight = 48
                        x1hoja.Range("B" & fila, "C" & fila).WrapText = True
                        x1hoja.Range("B" & fila, "C" & fila).Merge()
                        x1hoja.Range("B" & fila, "C" & fila).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        x1hoja.Cells(fila, columna).Formula = na2.RESULTADO2
                        x1hoja.Cells(fila, columna).Font.Size = 8
                    End If

                    Dim a As New dAcreditacion
                    a.ANALISIS = na2.ANALISIS
                    a = a.buscar
                    columna = columna - ret
                Next
                columna = 1
                fila = fila + 1
            Next
        End If
        If Not lista Is Nothing Then
            x1hoja.Cells(fila, columna).rowheight = 3
            fila = fila + 1
            x1hoja.Range("A" & fila, "E" & fila).Merge()
            x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).rowheight = 1
            fila = fila + 1
            If listadeabreviaturas <> "" Then
                x1hoja.Cells(fila, columna).Formula = "Abreviaturas"
                x1hoja.Cells(fila, columna).Font.Bold = True
                fila = fila + 1
                x1hoja.Cells(fila, columna).rowheight = 30
                x1hoja.Cells(fila, columna).Formula = listadeabreviaturas
                x1hoja.Range("A" & fila, "E" & fila).WrapText = True
                x1hoja.Range("A" & fila, "E" & fila).Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Size = 7
                fila = fila + 1
            End If
            x1hoja.Cells(fila, columna).Formula = "Métodos"
            x1hoja.Cells(fila, columna).Font.Bold = True
            fila = fila + 1
            x1hoja.Cells(fila, columna).rowheight = 30
            x1hoja.Cells(fila, columna).Formula = listademetodos
            x1hoja.Range("A" & fila, "E" & fila).WrapText = True
            x1hoja.Range("A" & fila, "E" & fila).Merge()
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Size = 7
            fila = fila + 1
        End If
     
        If Not lista Is Nothing Then
            x1hoja.Cells(fila, columna).Formula = "" '"(*)Ensayo no acreditado ISO 17025 O.U.A."
            x1hoja.Cells(fila, columna).Font.Size = 8
            x1hoja.Cells(fila, columna).Font.Bold = True
            columna = columna + 3
            x1hoja.Cells(fila, columna).Formula = "Operador: " & nombre_operador
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 2
            columna = 1
        End If
        x1hoja.Shapes.AddPicture("c:\Debug\encabezado_sin_oua2.png", _
 Microsoft.Office.Core.MsoTriState.msoFalse, _
 Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 700, 50)
        'ANALISIS TERCERIZADOS***************************************************
        Dim at As New dAnalisisTercerizado
        Dim listaat As New ArrayList
        listaat = at.listarporficha4(nroficha)
        If Not listaat Is Nothing Then
            x1hoja.Cells(fila, columna).Formula = "ANÁLISIS TERCERIZADOS"
            x1hoja.Range("A" & fila, "E" & fila).Merge()
            x1hoja.Cells(fila, columna).Interior.Color = RGB(215, 219, 221)
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 10
            fila = fila + 1
            x1hoja.Cells(fila, columna).Formula = "Muestra"
            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            columna = columna + 1
            x1hoja.Cells(fila, columna).Formula = "Análisis"
            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            columna = columna + 1
            x1hoja.Cells(fila, columna).Formula = "Resultado"
            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            columna = columna + 1
            x1hoja.Cells(fila, columna).Formula = "Método"
            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            columna = columna + 1
            x1hoja.Cells(fila, columna).Formula = "Laboratorio"
            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            columna = 1
            fila = fila + 1
            For Each at In listaat
                x1hoja.Cells(fila, columna).Formula = at.MUESTRA
                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).WrapText = True
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                Dim att As New dAnalisisTercerizadoTipo
                att.ID = at.ANALISIS
                att = att.buscar
                If Not att Is Nothing Then
                    x1hoja.Cells(fila, columna).Formula = att.NOMBRE
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).Formula = ""
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                End If
                x1hoja.Cells(fila, columna).Formula = at.RESULTADO
                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).WrapText = True
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                x1hoja.Cells(fila, columna).Formula = at.METODO
                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).WrapText = True
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                Dim ol As New dOtrosLaboratorios
                ol.ID = at.LABORATORIO
                ol = ol.buscar
                If Not ol Is Nothing Then
                    x1hoja.Cells(fila, columna).Formula = ol.NOMBRE
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = 1
                    fila = fila + 1
                Else
                    x1hoja.Cells(fila, columna).Formula = ""
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = 1
                    fila = fila + 1
                End If
            Next
            fila = fila + 1
        End If
        '*** OBSERVACIONES **************************************************
        If sa.OBSERVACIONES <> "" Then
            x1hoja.Cells(fila, columna).rowheight = 25
            x1hoja.Cells(fila, columna).Formula = "Observaciones: " & sa.OBSERVACIONES
            x1hoja.Range("A" & fila, "E" & fila).WrapText = True
            x1hoja.Range("A" & fila, "E" & fila).Merge()
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Size = 8
            fila = fila + 1
        End If
        '***CONCLUSIONES**************************************************************
        Dim con As New dConclusiones
        con.FICHA = nroficha
        con = con.buscar
        If Not con Is Nothing Then
            If sa.OBSERVACIONES <> "" Then
                x1hoja.Cells(fila, columna).rowheight = 25
                x1hoja.Cells(fila, columna).Formula = "Conclusiones: " & con.CONCLUSION
                x1hoja.Range("A" & fila, "E" & fila).WrapText = True
                x1hoja.Range("A" & fila, "E" & fila).Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Size = 8
                fila = fila + 1
            End If
        End If
        '************************************************************************************
        '*** PONER FIRMA ********************************************************
        x1libro.Worksheets(1).cells(fila, columna).select()
        x1libro.ActiveSheet.pictures.Insert("c:\Debug\cecilia.jpg").select()
        x1libro.Worksheets(1).cells(2, 1).select()
        fila = fila + 6
        columna = 1
        '*** PIE DE PAGINA ******************************************************
        x1hoja.Cells(fila, columna).rowheight = 25
        x1hoja.Cells(fila, columna).Formula = "Este informe no podrá ser reproducido total o parcialmente sin la autorización escrita de COLAVECO. Los resultados consignados se refieren exclusivamente a la muestra recibida." & vbCrLf _
            & "COLAVECO declina toda responsabilidad por el uso indebido o incorrecto que se hiciere a este informe, asi como el plan y procedimientos de muestreo aplicados por el cliente. Dra. Cecilia Abelenda (Directora Técnica)"
        x1hoja.Range("A" & fila, "E" & fila).WrapText = True
        x1hoja.Range("A" & fila, "E" & fila).Merge()
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        '************************************************************************
        fila = fila + 1
        x1hoja.Range("A" & fila, "E" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(215, 219, 221)
        x1hoja.Cells(fila, columna).rowheight = 8
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
        x1hoja.Cells(fila, columna).Formula = "Fin del informe."
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 7
        'Insert tabla preinformes**************************
        Dim pi As New dPreinformes
        Dim fechaactual As Date = Now()
        Dim _fecha As String
        _fecha = Format(fechaactual, "yyyy-MM-dd")
        pi.FICHA = nroficha
        pi = pi.buscar

        If Not pi Is Nothing Then
            Dim pi2 As New dPreinformes
            pi2.FICHA = nroficha
            pi2.TIPO = 9
            pi2.CREADO = 1
            pi2.FECHA = _fecha
            pi2.modificar()
            pi2 = Nothing
        Else
            Dim pi2 As New dPreinformes
            pi2.FICHA = nroficha
            pi2.TIPO = 6
            pi2.CREADO = 1
            pi2.FECHA = _fecha
            pi2.guardar()
            pi2 = Nothing
        End If

        pi = Nothing
        '***********************************************************
        x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas
        'PROTEGE LA HOJA DE EXCEL
        x1hoja.Protect(Password:="1582782", DrawingObjects:=True, _
        Contents:=True, Scenarios:=True)
        'GUARDA EL ARCHIVO DE EXCEL
        x1hoja.SaveAs("\\ROBOT\PREINFORMES\PATOLOGIA\" & nroficha & ".xls")
        x1hoja.SaveAs("\\ROBOT\INFORMES PARA SUBIR\" & nroficha & ".xls")
        x1app.Visible = True
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub informe_leucosis()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
        x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(1)
        x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(1)
        x1hoja.PageSetup.Orientation = (Excel.XlPageOrientation.xlLandscape)
        Dim sa As New dSolicitudAnalisis
        Dim cli As New dCliente
        Dim na As New dNuevoAnalisis
        Dim na_ As New dNuevoAnalisis
        Dim na3 As New dNuevoAnalisis
        Dim met As New dMetodos
        Dim lista As New ArrayList
        Dim lista_ As New ArrayList
        Dim lista2 As New ArrayList
        Dim lista3 As New ArrayList
        Dim lista_positivos As New ArrayList
        Dim lista_negativos As New ArrayList
        Dim acreditado As Integer = 0
        Dim acreditado2 As Integer = 0
        Dim xanalisis As Integer = 0
        Dim vec(xanalisis) As Integer
        Dim informefinal As Integer = 0
        Dim nombre_operador As String = "XXX"
        Dim nombre_tecnico As String = "Cecilia Abelenda"
        Dim sin_asterisco As Integer = 1
        '*****************************
        nroficha = TextFicha.Text.Trim
        sa.ID = nroficha
        sa = sa.buscar
        lista = na.listarporfichamuestra(nroficha)
        lista3 = na3.listarporficha3(nroficha)
        lista_ = na_.listarporficha3(nroficha)
        lista_positivos = na.listarpositivo(nroficha)
        lista_negativos = na.listarnegativo(nroficha)
        '**********************************************
        If Not lista3 Is Nothing Then
            xanalisis = lista3.Count - 1
            ReDim vec(xanalisis)
            Dim i As Integer = 0
            For Each na3 In lista3
                vec(i) = na3.ANALISIS
                i = i + 1
            Next
        End If
        '***********************************************
        If Not lista_ Is Nothing Then
            For Each na_ In lista_
                Dim lp_ As New dListaPrecios
                lp_.ID = na_.ANALISIS
                lp_ = lp_.buscar
                If Not lp_ Is Nothing Then
                    If lp_.ACREDITADO = 1 Then
                        sin_asterisco = 0
                    End If
                End If
            Next
        End If
        '***********************************************
        Dim fila As Integer
        Dim columna As Integer
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                fila = 1
                columna = 1
                'Poner Titulos
                columna = 2
                x1hoja.Cells(3, 1).columnwidth = 20
                x1hoja.Cells(3, 2).columnwidth = 13
                x1hoja.Cells(3, 3).columnwidth = 7
                x1hoja.Cells(3, 4).columnwidth = 20
                x1hoja.Cells(3, 5).columnwidth = 13
                x1hoja.Cells(3, 6).columnwidth = 4
                x1hoja.Cells(3, 7).columnwidth = 4
                x1hoja.Cells(3, 8).columnwidth = 4
                x1hoja.Cells(3, 9).columnwidth = 4
                x1hoja.Cells(3, 10).columnwidth = 4
                x1hoja.Cells(3, 11).columnwidth = 7
                x1hoja.Cells(3, 12).columnwidth = 7
                x1hoja.Cells(3, 13).columnwidth = 7
                x1hoja.Cells(3, 14).columnwidth = 7
                x1hoja.Cells(3, 15).columnwidth = 7
                x1hoja.Cells(3, 16).columnwidth = 7
                fila = fila + 4
                columna = 1
                x1hoja.Cells(fila, columna).rowheight = 3
                fila = fila + 1
                x1hoja.Range("A" & fila, "O" & fila).Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).Formula = "INFORME DE LEUCOSIS"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 12
                fila = fila + 1
                columna = 1
                x1hoja.Cells(fila, columna).Formula = "Nº Ficha: " & sa.ID
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 11
                x1hoja.Cells(fila, columna).Formula = "Fecha entrada: " & sa.FECHAINGRESO
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                cli.ID = sa.IDPRODUCTOR
                cli = cli.buscar
                x1hoja.Cells(fila, columna).Formula = "Cliente: " & cli.NOMBRE
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 11
                Dim nnaa As New dNuevoAnalisis
                Dim fechaproceso As String = ""
                Dim listannaa As New ArrayList
                listannaa = nnaa.listarporficha2(sa.ID)
                If Not listannaa Is Nothing Then
                    For Each nnaa In listannaa
                        fechaproceso = nnaa.FECHAPROCESO
                    Next
                End If
                nnaa = Nothing
                listannaa = Nothing
                x1hoja.Cells(fila, columna).Formula = "Fecha proceso: " & fechaproceso
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                If cli.DIRECCION <> "" Or cli.DIRECCION <> "No aportado" Then
                    x1hoja.Cells(fila, columna).Formula = "Dirección: " & cli.DIRECCION
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = columna + 11
                ElseIf cli.IDLOCALIDAD <> 999 Then
                    Dim loc As New dLocalidad
                    loc.ID = cli.IDLOCALIDAD
                    loc = loc.buscar
                    If Not loc Is Nothing Then
                        x1hoja.Cells(fila, columna).Formula = loc.NOMBRE
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 9
                        columna = columna + 11
                    End If
                ElseIf cli.IDDEPARTAMENTO <> 999 Then
                    Dim dep As New dDepartamento
                    dep.ID = cli.IDDEPARTAMENTO
                    dep = dep.buscar
                    If Not dep Is Nothing Then
                        x1hoja.Cells(fila, columna).Formula = dep.NOMBRE
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 9
                        columna = columna + 11
                    End If
                ElseIf cli.CELULAR <> "" Then
                    x1hoja.Cells(fila, columna).Formula = "Celular: " & cli.CELULAR
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = columna + 11
                Else
                    x1hoja.Cells(fila, columna).Formula = "No aportado"
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = columna + 11
                End If
                Dim fecha As Date = Now()
                Dim fecha2 As String = fecha.ToString("dd/MM/yyyy")
                x1hoja.Cells(fila, columna).Formula = "Fecha informe: " & fecha2
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                Dim mm As New dMuestras
                mm.ID = sa.IDMUESTRA
                mm = mm.buscar
                If Not mm Is Nothing Then
                    x1hoja.Cells(fila, columna).Formula = "Material recibido: " & mm.NOMBRE
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    fila = fila + 1
                Else
                    x1hoja.Cells(fila, columna).Formula = "Material recibido: "
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    fila = fila + 1
                End If
                x1hoja.Cells(fila, columna).Formula = "Total de muestras: " & sa.NMUESTRAS
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 11
                Dim c2 As New dCliente
                c2.ID = sa.IDTECNICO
                c2 = c2.buscar
                If Not c2 Is Nothing Then
                    x1hoja.Cells(fila, columna).Formula = "Téc.: " & c2.NOMBRE
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = 1
                Else
                    x1hoja.Cells(fila, columna).Formula = "Téc.: "
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = 1
                End If
                columna = 1
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Muestreo realizado por el cliente"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 11
                x1hoja.Cells(fila, columna).Formula = "DICOSE:" & cli.DICOSE
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = 1
                fila = fila + 1
                x1hoja.Range("A" & fila, "O" & fila).Merge()
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).rowheight = 1
                fila = fila + 1
                x1hoja.Cells(fila, columna).rowheight = 3
                fila = fila + 1
                columna = 1
                Dim cuenta As Integer = 1
                Dim detallemuestras As String = ""
                Dim idoperador As Integer = 0
                Dim operador As String = ""
                Dim iu As New dUsuario
                iu.ID = idoperador
                iu = iu.buscar
                If Not iu Is Nothing Then
                    operador = iu.NOMBRE
                End If
                x1hoja.Cells(fila, columna).Formula = "Id."
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeTop).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeLeft).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeRight).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).WrapText = True
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Muestra"
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeBottom).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeLeft).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeRight).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).WrapText = True
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 3
                fila = fila - 1
                x1hoja.Cells(fila, columna).Formula = "Id."
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeTop).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeLeft).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeRight).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).WrapText = True
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Muestra"
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeBottom).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeLeft).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Borders(Excel.XlBordersIndex.xlEdgeRight).Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).WrapText = True
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna - 2
                fila = fila - 1
                Dim listademetodos As String = ""
                Dim listadeabreviaturas As String = ""
                For Each na In lista3
                    Dim u As New dUsuario
                    u.ID = na.OPERADOR
                    u = u.buscar
                    If Not u Is Nothing Then
                        nombre_operador = u.NOMBRE
                    End If
                    Dim lp As New dListaPrecios
                    lp.ID = na.ANALISIS
                    lp = lp.buscar
                    Dim lm As New dListaMetodos
                    lm.ID = na.METODO
                    lm = lm.buscar
                    If Not lm Is Nothing Then
                        listademetodos = listademetodos & lp.DESCTECNICA & " - " & lm.METODO & " / "
                    End If
                    If lp.ABREVIATURA <> lp.DESCTECNICA Then
                        listadeabreviaturas = listadeabreviaturas & lp.ABREVIATURA & " - " & lp.DESCTECNICA & " / "
                    End If
                    Dim l As New dListaPrecios
                    l.ID = na.ANALISIS
                    l = l.buscar
                    If Not l Is Nothing Then
                        x1hoja.Cells(fila, columna).Formula = l.ABREVIATURA
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        x1hoja.Cells(fila, columna).Font.Size = 8
                    End If
                    l = Nothing
                    Dim au As New dAnalisisUnidad
                    au.ID = na.UNIDAD
                    au = au.buscar
                    If Not au Is Nothing Then
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).Formula = au.UNIDAD
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        x1hoja.Cells(fila, columna).Font.Size = 6
                        fila = fila - 1
                        columna = columna + 1
                    Else
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).Formula = ""
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        x1hoja.Cells(fila, columna).Font.Size = 6
                        fila = fila - 1
                        columna = columna + 1
                    End If
                    lp = Nothing
                    lm = Nothing
                    u = Nothing
                Next
                '****************************************************************************************************
                columna = 5
                For Each na In lista3
                    Dim lp As New dListaPrecios
                    lp.ID = na.ANALISIS
                    lp = lp.buscar
                    Dim lm As New dListaMetodos
                    lm.ID = na.METODO
                    lm = lm.buscar
                    Dim l As New dListaPrecios
                    l.ID = na.ANALISIS
                    l = l.buscar
                    If Not l Is Nothing Then
                        x1hoja.Cells(fila, columna).Formula = l.ABREVIATURA
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        x1hoja.Cells(fila, columna).Font.Size = 8
                    End If
                    l = Nothing
                    Dim au As New dAnalisisUnidad
                    au.ID = na.UNIDAD
                    au = au.buscar
                    If Not au Is Nothing Then
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).Formula = au.UNIDAD
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        x1hoja.Cells(fila, columna).Font.Size = 6
                        fila = fila - 1
                        columna = columna + 1
                    Else
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).Formula = ""
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                        x1hoja.Cells(fila, columna).Font.Size = 6
                        fila = fila - 1
                        columna = columna + 1
                    End If
                    lp = Nothing
                    lm = Nothing
                Next
                '***************************************************************************************
                columna = 1
                fila = fila + 2
                'LISTA LOS ANALISIS NEGATIVOS
                For Each na In lista_negativos
                    x1hoja.Cells(fila, columna).Formula = na.MUESTRA
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    Dim x As Integer = 0
                    Dim n As Integer = 0
                    x = vec.Length
                    For n = 1 To x
                        x1hoja.Cells(fila, columna).Formula = "-"
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    Next
                    columna = columna - x
                    Dim na2 As New dNuevoAnalisis
                    lista2 = na2.listarpormuestra(nroficha, na.MUESTRA)
                    For Each na2 In lista2
                        Dim ret As Integer = Array.IndexOf(vec, na2.ANALISIS)
                        columna = columna + ret
                        x1hoja.Cells(fila, columna).Formula = na2.RESULTADO & " " & na2.RESULTADO2
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        Dim a As New dAcreditacion
                        a.ANALISIS = na2.ANALISIS
                        a = a.buscar
                        If Not a Is Nothing Then
                            Dim desde As Double = a.DESDE
                            Dim hasta As Double = a.HASTA
                            If Val(na2.RESULTADO2) < desde Or Val(na2.RESULTADO2) > hasta Then
                                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                            Else
                                acreditado2 = 1
                            End If
                        End If
                        columna = columna - ret
                    Next
                    columna = 1
                    fila = fila + 1
                Next
                columna = 4
                fila = fila - lista_negativos.Count
                'LISTA LOS ANALISIS POSITIVOS
                For Each na In lista_positivos
                    x1hoja.Cells(fila, columna).Formula = na.MUESTRA
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    Dim x As Integer = 0
                    Dim n As Integer = 0
                    x = vec.Length
                    For n = 1 To x
                        x1hoja.Cells(fila, columna).Formula = "-"
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    Next
                    columna = columna - x
                    Dim na2 As New dNuevoAnalisis
                    lista2 = na2.listarpormuestra(nroficha, na.MUESTRA)
                    For Each na2 In lista2
                        Dim ret As Integer = Array.IndexOf(vec, na2.ANALISIS)
                        columna = columna + ret
                        x1hoja.Cells(fila, columna).Formula = na2.RESULTADO & " " & na2.RESULTADO2
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        Dim a As New dAcreditacion
                        a.ANALISIS = na2.ANALISIS
                        a = a.buscar
                        If Not a Is Nothing Then
                            Dim desde As Double = a.DESDE
                            Dim hasta As Double = a.HASTA
                            If Val(na2.RESULTADO2) < desde Or Val(na2.RESULTADO2) > hasta Then
                                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                            Else
                                acreditado2 = 1
                            End If
                        End If
                        columna = columna - ret
                    Next
                    columna = 4
                    fila = fila + 1
                Next
                Dim positivos As Integer = 0
                Dim negativos As Integer = 0
                Dim diferencia As Integer = 0
                positivos = lista_positivos.Count
                negativos = lista_negativos.Count
                If negativos >= positivos Then
                    diferencia = negativos - positivos
                Else
                    diferencia = 1
                End If
                fila = fila + diferencia
                x1hoja.Cells(fila, columna).rowheight = 3
                fila = fila + 1
                columna = 1
                x1hoja.Range("A" & fila, "O" & fila).Merge()
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).rowheight = 1
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Métodos"
                x1hoja.Cells(fila, columna).Font.Bold = True
                fila = fila + 1
                x1hoja.Cells(fila, columna).rowheight = 30
                x1hoja.Cells(fila, columna).Formula = listademetodos
                x1hoja.Range("A" & fila, "O" & fila).WrapText = True
                x1hoja.Range("A" & fila, "O" & fila).Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Size = 7
                fila = fila + 1
                '*** OBSERVACIONES **************************************************
                If sa.OBSERVACIONES <> "" Then
                    x1hoja.Cells(fila, columna).rowheight = 25
                    x1hoja.Cells(fila, columna).Formula = "Observaciones: " & sa.OBSERVACIONES
                    x1hoja.Range("A" & fila, "O" & fila).WrapText = True
                    x1hoja.Range("A" & fila, "O" & fila).Merge()
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    fila = fila + 1
                End If
                '********************************************************************
                columna = 1
                'CABEZAL CON O SIN LOGO OUA
                x1hoja.Shapes.AddPicture("c:\Debug\encabezado_sin_oua2.png", _
             Microsoft.Office.Core.MsoTriState.msoFalse, _
             Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 700, 50)
                columna = 3
                x1hoja.Cells(fila, columna).Formula = "Muestras positivas: " & positivos
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9

                columna = columna + 8
                x1hoja.Cells(fila, columna).Formula = "Técnico resp: " & nombre_tecnico
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = 3
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Muestras negativas: " & negativos
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = 1
                '*** PONER FIRMA ********************************************************
                x1libro.Worksheets(1).cells(fila, columna).select()
                x1libro.ActiveSheet.pictures.Insert("c:\Debug\cecilia.jpg").select()
                x1libro.Worksheets(1).cells(2, 1).select()
                fila = fila + 6
                columna = 1
                '*** PIE DE PAGINA ******************************************************
                x1hoja.Cells(fila, columna).rowheight = 25
                x1hoja.Cells(fila, columna).Formula = "Este informe no podrá ser reproducido total o parcialmente sin la autorización escrita de COLAVECO. Los resultados consignados se refieren exclusivamente a la muestra recibida." & vbCrLf _
                    & "COLAVECO declina toda responsabilidad por el uso indebido o incorrecto que se hiciere a este informe, asi como el plan y procedimientos de muestreo aplicados por el cliente. Dra. Cecilia Abelenda (Directora Técnica)"
                x1hoja.Range("A" & fila, "O" & fila).WrapText = True
                x1hoja.Range("A" & fila, "O" & fila).Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Size = 6
                '************************************************************************
                fila = fila + 1
                x1hoja.Range("A" & fila, "O" & fila).Merge()
                x1hoja.Cells(fila, columna).Interior.Color = RGB(215, 219, 221)
                x1hoja.Cells(fila, columna).rowheight = 8
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Formula = "Fin del informe."
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 7
            End If
        End If
        'Insert tabla preinformes**************************
        Dim pi As New dPreinformes
        Dim fechaactual As Date = Now()
        Dim _fecha As String
        _fecha = Format(fechaactual, "yyyy-MM-dd")
        pi.FICHA = nroficha
        pi = pi.buscar
        If Not pi Is Nothing Then
        Else
            Dim pi2 As New dPreinformes
            pi2.FICHA = nroficha
            pi2.TIPO = 8
            pi2.CREADO = 1
            pi2.FECHA = _fecha
            pi2.guardar()
            pi2 = Nothing
        End If
        pi = Nothing
        '***********************************************************
        x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas
        'PROTEGE LA HOJA DE EXCEL
        x1hoja.Protect(Password:="1582782", DrawingObjects:=True, _
        Contents:=True, Scenarios:=True)
        'GUARDA EL ARCHIVO DE EXCEL
        x1hoja.SaveAs("\\ROBOT\PREINFORMES\SEROLOGIA\" & nroficha & ".xls")
        x1app.Visible = True
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub informe_atb()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
        x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(1)
        x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(1)
        x1hoja.PageSetup.Orientation = (Excel.XlPageOrientation.xlLandscape)
        Dim sa As New dSolicitudAnalisis
        Dim cli As New dCliente
        Dim na As New dNuevoAnalisis
        Dim atb As New dATB
        Dim met As New dMetodos
        Dim lista As New ArrayList
        Dim lista2 As New ArrayList
        Dim acreditado As Integer = 0
        Dim acreditado2 As Integer = 0
        Dim xanalisis As Integer = 0
        Dim vec(xanalisis) As Integer
        Dim informefinal As Integer = 0
        Dim nombre_operador As String = ""
        Dim nombre_tecnico As String = ""
        Dim sin_asterisco As Integer = 1
        '*****************************
        nroficha = TextFicha.Text.Trim
        sa.ID = nroficha
        sa = sa.buscar
        lista = na.listarporfichamuestra(nroficha)
        lista2 = atb.listarxficha(nroficha)
        Dim solo_aislamiento As Integer = 0
        If sa.IDSUBINFORME = 34 Then
            solo_aislamiento = 1
        End If
        '***********************************************
        Dim fila As Integer
        Dim columna As Integer
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                fila = 1
                columna = 1
                'Poner Titulos
                columna = 2
                x1hoja.Cells(3, 1).columnwidth = 10
                x1hoja.Cells(3, 2).columnwidth = 30
                x1hoja.Cells(3, 3).columnwidth = 5
                x1hoja.Cells(3, 4).columnwidth = 5
                x1hoja.Cells(3, 5).columnwidth = 5
                x1hoja.Cells(3, 6).columnwidth = 5
                x1hoja.Cells(3, 7).columnwidth = 5
                x1hoja.Cells(3, 8).columnwidth = 5
                x1hoja.Cells(3, 9).columnwidth = 5
                x1hoja.Cells(3, 10).columnwidth = 5
                x1hoja.Cells(3, 11).columnwidth = 5
                x1hoja.Cells(3, 12).columnwidth = 5
                x1hoja.Cells(3, 13).columnwidth = 5
                x1hoja.Cells(3, 14).columnwidth = 4
                x1hoja.Cells(3, 15).columnwidth = 4
                x1hoja.Cells(3, 16).columnwidth = 4
                x1hoja.Cells(3, 17).columnwidth = 16
                fila = fila + 4
                columna = 1
                x1hoja.Cells(fila, columna).rowheight = 3
                fila = fila + 1
                x1hoja.Range("A" & fila, "P" & fila).Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).Formula = "INFORME DE AISLAMIENTO Y ANTIBIOGRAMA"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 12
                fila = fila + 1
                columna = 1
                x1hoja.Cells(fila, columna).Formula = "Nº Ficha: " & sa.ID
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 13
                x1hoja.Cells(fila, columna).Formula = "Fecha entrada: " & sa.FECHAINGRESO
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                cli.ID = sa.IDPRODUCTOR
                cli = cli.buscar
                x1hoja.Cells(fila, columna).Formula = "Cliente: " & cli.NOMBRE
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 13
                Dim nnaa As New dNuevoAnalisis
                Dim fechaproceso As String = ""
                Dim listannaa As New ArrayList
                listannaa = nnaa.listarporficha2(sa.ID)
                If Not listannaa Is Nothing Then
                    For Each nnaa In listannaa
                        fechaproceso = nnaa.FECHAPROCESO
                    Next
                End If
                nnaa = Nothing
                listannaa = Nothing
                x1hoja.Cells(fila, columna).Formula = "Fecha proceso: " & fechaproceso
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                If cli.DIRECCION <> "" Or cli.DIRECCION <> "No aportado" Then
                    x1hoja.Cells(fila, columna).Formula = "Dirección: " & cli.DIRECCION
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = columna + 13
                ElseIf cli.IDLOCALIDAD <> 999 Then
                    Dim loc As New dLocalidad
                    loc.ID = cli.IDLOCALIDAD
                    loc = loc.buscar
                    If Not loc Is Nothing Then
                        x1hoja.Cells(fila, columna).Formula = loc.NOMBRE
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 9
                        columna = columna + 13
                    End If
                ElseIf cli.IDDEPARTAMENTO <> 999 Then
                    Dim dep As New dDepartamento
                    dep.ID = cli.IDDEPARTAMENTO
                    dep = dep.buscar
                    If Not dep Is Nothing Then
                        x1hoja.Cells(fila, columna).Formula = dep.NOMBRE
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 9
                        columna = columna + 13
                    End If
                ElseIf cli.CELULAR <> "" Then
                    x1hoja.Cells(fila, columna).Formula = "Celular: " & cli.CELULAR
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = columna + 13
                Else
                    x1hoja.Cells(fila, columna).Formula = "No aportado"
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = columna + 13
                End If
                Dim fecha As Date = Now()
                Dim fecha2 As String = fecha.ToString("dd/MM/yyyy")
                x1hoja.Cells(fila, columna).Formula = "Fecha informe: " & fecha2
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                Dim mm As New dMuestras
                mm.ID = sa.IDMUESTRA
                mm = mm.buscar
                If Not mm Is Nothing Then
                    x1hoja.Cells(fila, columna).Formula = "Material recibido: " & mm.NOMBRE
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = columna + 2
                Else
                    x1hoja.Cells(fila, columna).Formula = "Material recibido: "
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    fila = fila + 1
                    columna = columna + 3
                End If
                x1hoja.Cells(fila, columna).Formula = "Total de muestras: " & sa.NMUESTRAS
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = 1
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Muestreo realizado por el cliente."
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 2
                x1hoja.Cells(fila, columna).Formula = "Temperatura de arribo de las muestras: " & sa.TEMPERATURA & " °C"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = 1
                fila = fila + 1
                x1hoja.Range("A" & fila, "P" & fila).Merge()
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).rowheight = 1
                fila = fila + 1
                x1hoja.Cells(fila, columna).rowheight = 3
                fila = fila + 1
                columna = 1
                Dim cuenta As Integer = 1
                Dim detallemuestras As String = ""
                x1hoja.Cells(fila, columna).Formula = "Muestra"
                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Interior.Color = RGB(220, 220, 220)
                x1hoja.Cells(fila, columna).WrapText = True
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                x1hoja.Cells(fila, columna).Formula = "Microorganismo"
                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Interior.Color = RGB(220, 220, 220)
                x1hoja.Cells(fila, columna).WrapText = True
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                If solo_aislamiento = 0 Then
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "Cf"
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).Interior.Color = RGB(220, 220, 220)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "E"
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).Interior.Color = RGB(220, 220, 220)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "Ox"
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).Interior.Color = RGB(220, 220, 220)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "P"
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).Interior.Color = RGB(220, 220, 220)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "Ra"
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).Interior.Color = RGB(220, 220, 220)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "Sxt"
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).Interior.Color = RGB(220, 220, 220)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "T"
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).Interior.Color = RGB(220, 220, 220)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "Amc"
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).Interior.Color = RGB(220, 220, 220)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "Eno"
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).Interior.Color = RGB(220, 220, 220)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "Gm"
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).Interior.Color = RGB(220, 220, 220)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "Am"
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).Interior.Color = RGB(220, 220, 220)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 8
                End If
                Dim listademetodos As String = "Aislamiento: National Mastitis Council-2017 / Antibiograma: CLSI M31-A3 2008"
                Dim listadeabreviaturas As String = "Am: Ampicilina - Amc: Amoxicilina + Ác. Clavulánico - Cf: Cefalotina - E: Eritromicina - Eno: Enrofloxacina - Gm: Gentamicina - Ox: Cloxacilina - P: Penicilina - Ra: Rifampin - Sxt: Trimetoprim sulfametoxazol - T: Oxytetraciclina"
                columna = 1
                Dim m As String = ""
                Dim a As Integer = 0
                For Each atb In lista2
                    If m <> atb.MUESTRA Or a <> atb.AISLAMIENTO Then
                        fila = fila + 1
                    End If
                    m = atb.MUESTRA
                    a = atb.AISLAMIENTO
                    x1hoja.Cells(fila, columna).Formula = atb.MUESTRA
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    Dim moa As New dMOA24
                    moa.ID = atb.AISLAMIENTO
                    moa = moa.buscar
                    If Not moa Is Nothing Then
                        x1hoja.Cells(fila, columna).Formula = moa.NOMBRE
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                    Else
                        x1hoja.Cells(fila, columna).Formula = ""
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                    End If
                    moa = Nothing
                    If solo_aislamiento = 0 Then
                        columna = columna + 1
                        If atb.ATB = 3 Then
                            x1hoja.Cells(fila, columna).Formula = atb.RESISTENCIA
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                            x1hoja.Cells(fila, columna).Interior.Color = RGB(255, 255, 255)
                            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        Else
                            If x1hoja.Cells(fila, columna).Formula <> "" Then
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                            End If
                        End If
                        columna = columna + 1
                        If atb.ATB = 4 Then
                            x1hoja.Cells(fila, columna).Formula = atb.RESISTENCIA
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                            x1hoja.Cells(fila, columna).Interior.Color = RGB(255, 255, 255)
                            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        Else
                            If x1hoja.Cells(fila, columna).Formula <> "" Then
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                            End If
                        End If
                        columna = columna + 1
                        If atb.ATB = 7 Then
                            x1hoja.Cells(fila, columna).Formula = atb.RESISTENCIA
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                            x1hoja.Cells(fila, columna).Interior.Color = RGB(255, 255, 255)
                            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        Else
                            If x1hoja.Cells(fila, columna).Formula <> "" Then
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                            End If
                        End If
                        columna = columna + 1
                        If atb.ATB = 8 Then
                            x1hoja.Cells(fila, columna).Formula = atb.RESISTENCIA
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                            x1hoja.Cells(fila, columna).Interior.Color = RGB(255, 255, 255)
                            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        Else
                            If x1hoja.Cells(fila, columna).Formula <> "" Then
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                            End If
                        End If
                        columna = columna + 1
                        If atb.ATB = 9 Then
                            x1hoja.Cells(fila, columna).Formula = atb.RESISTENCIA
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                            x1hoja.Cells(fila, columna).Interior.Color = RGB(255, 255, 255)
                            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        Else
                            If x1hoja.Cells(fila, columna).Formula <> "" Then
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                            End If
                        End If
                        columna = columna + 1
                        If atb.ATB = 10 Then
                            x1hoja.Cells(fila, columna).Formula = atb.RESISTENCIA
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                            x1hoja.Cells(fila, columna).Interior.Color = RGB(255, 255, 255)
                            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        Else
                            If x1hoja.Cells(fila, columna).Formula <> "" Then
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                            End If
                        End If
                        columna = columna + 1
                        If atb.ATB = 11 Then
                            x1hoja.Cells(fila, columna).Formula = atb.RESISTENCIA
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                            x1hoja.Cells(fila, columna).Interior.Color = RGB(255, 255, 255)
                            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        Else
                            If x1hoja.Cells(fila, columna).Formula <> "" Then
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                            End If
                        End If
                        columna = columna + 1
                        If atb.ATB = 2 Then
                            x1hoja.Cells(fila, columna).Formula = atb.RESISTENCIA
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                            x1hoja.Cells(fila, columna).Interior.Color = RGB(255, 255, 255)
                            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        Else
                            If x1hoja.Cells(fila, columna).Formula <> "" Then
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                            End If
                        End If
                        columna = columna + 1
                        If atb.ATB = 5 Then
                            x1hoja.Cells(fila, columna).Formula = atb.RESISTENCIA
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                            x1hoja.Cells(fila, columna).Interior.Color = RGB(255, 255, 255)
                            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        Else
                            If x1hoja.Cells(fila, columna).Formula <> "" Then
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                            End If
                        End If
                        columna = columna + 1
                        If atb.ATB = 6 Then
                            x1hoja.Cells(fila, columna).Formula = atb.RESISTENCIA
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                            x1hoja.Cells(fila, columna).Interior.Color = RGB(255, 255, 255)
                            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        Else
                            If x1hoja.Cells(fila, columna).Formula <> "" Then
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                            End If
                        End If
                        columna = columna + 1
                        If atb.ATB = 1 Then
                            x1hoja.Cells(fila, columna).Formula = atb.RESISTENCIA
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                            x1hoja.Cells(fila, columna).Interior.Color = RGB(255, 255, 255)
                            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        Else
                            If x1hoja.Cells(fila, columna).Formula <> "" Then
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                            End If
                        End If
                    End If
                    columna = 1
                Next
                columna = 1
                fila = fila + 1
                x1hoja.Cells(fila, columna).rowheight = 3
                fila = fila + 1
                x1hoja.Range("A" & fila, "P" & fila).Merge()
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).rowheight = 1
                fila = fila + 1
                If solo_aislamiento = 0 Then
                    x1hoja.Cells(fila, columna).Formula = "Abreviaturas"
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).rowheight = 30
                    x1hoja.Cells(fila, columna).Formula = listadeabreviaturas
                    x1hoja.Range("A" & fila, "P" & fila).WrapText = True
                    x1hoja.Range("A" & fila, "P" & fila).Merge()
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                    x1hoja.Cells(fila, columna).Font.Size = 7
                    fila = fila + 1
                End If
                x1hoja.Cells(fila, columna).Formula = "Métodos"
                x1hoja.Cells(fila, columna).Font.Bold = True
                fila = fila + 1
                x1hoja.Cells(fila, columna).rowheight = 30
                x1hoja.Cells(fila, columna).Formula = listademetodos
                x1hoja.Range("A" & fila, "P" & fila).WrapText = True
                x1hoja.Range("A" & fila, "P" & fila).Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Size = 7
                fila = fila + 1
                Dim sr As New dSolicitudRodeo
                sr.FICHA = nroficha
                sr = sr.buscar
                If Not sr Is Nothing Then
                    x1hoja.Cells(fila, columna).Formula = "Tipo de mastitis: " & sr.MASTITIS
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    columna = columna + 2
                    If sr.RODEO > 0 Then
                        x1hoja.Cells(fila, columna).Formula = "Rodeo: " & sr.RODEO
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        columna = 1
                        fila = fila + 1
                    Else
                        x1hoja.Cells(fila, columna).Formula = ""
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        columna = 1
                        fila = fila + 1
                    End If
                End If

                '*** OBSERVACIONES **************************************************
                If sa.OBSERVACIONES <> "" Then
                    x1hoja.Cells(fila, columna).rowheight = 25
                    x1hoja.Cells(fila, columna).Formula = "Observaciones: " & sa.OBSERVACIONES
                    x1hoja.Range("A" & fila, "P" & fila).WrapText = True
                    x1hoja.Range("A" & fila, "p" & fila).Merge()
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    fila = fila + 1
                End If
                '********************************************************************
                If solo_aislamiento = 0 Then
                    columna = 3
                    x1hoja.Cells(fila, columna).Formula = "Referencias:"
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).Formula = ""
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "No testeado."
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 7
                    fila = fila + 1
                    columna = columna - 1
                    x1hoja.Cells(fila, columna).Formula = "-"
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "No corresponde testeo."
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 7
                    columna = 1
                End If
                'CABEZAL CON O SIN LOGO OUA
                x1hoja.Shapes.AddPicture("c:\Debug\encabezado_sin_oua2.png", _
             Microsoft.Office.Core.MsoTriState.msoFalse, _
             Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 700, 50)
                If solo_aislamiento = 0 Then
                    fila = fila - 2
                End If
                columna = columna + 13
                Dim na2 As New dNuevoAnalisis
                na2.FICHA = nroficha
                na2 = na2.buscarxficha
                If Not na2 Is Nothing Then
                    Dim usu As New dUsuario
                    usu.ID = na2.OPERADOR
                    usu = usu.buscar
                    If Not usu Is Nothing Then
                        nombre_operador = usu.NOMBRE
                    End If
                    usu = Nothing
                End If
                na2 = Nothing
                x1hoja.Cells(fila, columna).Formula = "Operador: " & nombre_operador
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                '*** PONER FIRMA ********************************************************
                x1libro.Worksheets(1).cells(fila, columna).select()
                x1libro.ActiveSheet.pictures.Insert("c:\Debug\cecilia.jpg").select()
                x1libro.Worksheets(1).cells(2, 1).select()
                fila = fila + 6
                columna = 1
                '*** PIE DE PAGINA ******************************************************
                x1hoja.Cells(fila, columna).rowheight = 25
                x1hoja.Cells(fila, columna).Formula = "Este informe no podrá ser reproducido total o parcialmente sin la autorización escrita de COLAVECO. Los resultados consignados se refieren exclusivamente a la muestra recibida." & vbCrLf _
                    & "COLAVECO declina toda responsabilidad por el uso indebido o incorrecto que se hiciere a este informe, asi como el plan y procedimientos de muestreo aplicados por el cliente. Dra. Cecilia Abelenda (Directora Técnica)"
                x1hoja.Range("A" & fila, "O" & fila).WrapText = True
                x1hoja.Range("A" & fila, "O" & fila).Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Size = 6
                '************************************************************************
                fila = fila + 1
                x1hoja.Range("A" & fila, "P" & fila).Merge()
                x1hoja.Cells(fila, columna).Interior.Color = RGB(215, 219, 221)
                x1hoja.Cells(fila, columna).rowheight = 8
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Formula = "Fin del informe."
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 7
            End If
        End If
        'Insert tabla preinformes**************************
        Dim pi As New dPreinformes
        Dim fechaactual As Date = Now()
        Dim _fecha As String
        _fecha = Format(fechaactual, "yyyy-MM-dd")
        pi.FICHA = nroficha
        pi = pi.buscar
        If Not pi Is Nothing Then
        Else
            Dim pi2 As New dPreinformes
            pi2.FICHA = nroficha
            pi2.TIPO = 4
            pi2.CREADO = 1
            pi2.FECHA = _fecha
            pi2.guardar()
            pi2 = Nothing
        End If
        pi = Nothing
        '***********************************************************
        x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas
        'PROTEGE LA HOJA DE EXCEL
        x1hoja.Protect(Password:="1582782", DrawingObjects:=True, _
        Contents:=True, Scenarios:=True)
        'GUARDA EL ARCHIVO DE EXCEL
        x1hoja.SaveAs("\\ROBOT\PREINFORMES\ANTIBIOGRAMA\" & nroficha & ".xls")
        x1app.Visible = True
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub informe_atb_viejo()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
        x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(1)
        x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(1)
        x1hoja.PageSetup.Orientation = (Excel.XlPageOrientation.xlLandscape)
        Dim sa As New dSolicitudAnalisis
        Dim cli As New dCliente
        Dim na As New dNuevoAnalisis
        Dim atb As New dATB
        Dim met As New dMetodos
        Dim lista As New ArrayList
        Dim lista2 As New ArrayList
        Dim acreditado As Integer = 0
        Dim acreditado2 As Integer = 0
        Dim xanalisis As Integer = 0
        Dim vec(xanalisis) As Integer
        Dim informefinal As Integer = 0
        Dim nombre_operador As String = ""
        Dim nombre_tecnico As String = ""
        Dim sin_asterisco As Integer = 1
        '*****************************
        nroficha = TextFicha.Text.Trim
        sa.ID = nroficha
        sa = sa.buscar
        lista = na.listarporfichamuestra(nroficha)
        lista2 = atb.listarxficha(nroficha)
        Dim solo_aislamiento As Integer = 0
        If sa.IDSUBINFORME = 34 Then
            solo_aislamiento = 1
        End If
        '***********************************************
        Dim fila As Integer
        Dim columna As Integer
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                fila = 1
                columna = 1
                'Poner Titulos
                columna = 2
                x1hoja.Cells(3, 1).columnwidth = 10
                x1hoja.Cells(3, 2).columnwidth = 30
                x1hoja.Cells(3, 3).columnwidth = 5
                x1hoja.Cells(3, 4).columnwidth = 5
                x1hoja.Cells(3, 5).columnwidth = 5
                x1hoja.Cells(3, 6).columnwidth = 5
                x1hoja.Cells(3, 7).columnwidth = 5
                x1hoja.Cells(3, 8).columnwidth = 5
                x1hoja.Cells(3, 9).columnwidth = 5
                x1hoja.Cells(3, 10).columnwidth = 5
                x1hoja.Cells(3, 11).columnwidth = 5
                x1hoja.Cells(3, 12).columnwidth = 5
                x1hoja.Cells(3, 13).columnwidth = 5
                x1hoja.Cells(3, 14).columnwidth = 4
                x1hoja.Cells(3, 15).columnwidth = 4
                x1hoja.Cells(3, 16).columnwidth = 4
                x1hoja.Cells(3, 17).columnwidth = 16
                fila = fila + 4
                columna = 1
                x1hoja.Cells(fila, columna).rowheight = 3
                fila = fila + 1
                x1hoja.Range("A" & fila, "P" & fila).Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).Formula = "INFORME DE AISLAMIENTO Y ANTIBIOGRAMA"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 12
                fila = fila + 1
                columna = 1
                x1hoja.Cells(fila, columna).Formula = "Nº Ficha: " & sa.ID
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 13
                x1hoja.Cells(fila, columna).Formula = "Fecha entrada: " & sa.FECHAINGRESO
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                cli.ID = sa.IDPRODUCTOR
                cli = cli.buscar
                x1hoja.Cells(fila, columna).Formula = "Cliente: " & cli.NOMBRE
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 13
                Dim nnaa As New dNuevoAnalisis
                Dim fechaproceso As String = ""
                Dim listannaa As New ArrayList
                listannaa = nnaa.listarporficha2(sa.ID)
                If Not listannaa Is Nothing Then
                    For Each nnaa In listannaa
                        fechaproceso = nnaa.FECHAPROCESO
                    Next
                End If
                nnaa = Nothing
                listannaa = Nothing
                x1hoja.Cells(fila, columna).Formula = "Fecha proceso: " & fechaproceso
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                If cli.DIRECCION <> "" Or cli.DIRECCION <> "No aportado" Then
                    x1hoja.Cells(fila, columna).Formula = "Dirección: " & cli.DIRECCION
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = columna + 13
                ElseIf cli.IDLOCALIDAD <> 999 Then
                    Dim loc As New dLocalidad
                    loc.ID = cli.IDLOCALIDAD
                    loc = loc.buscar
                    If Not loc Is Nothing Then
                        x1hoja.Cells(fila, columna).Formula = loc.NOMBRE
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 9
                        columna = columna + 13
                    End If
                ElseIf cli.IDDEPARTAMENTO <> 999 Then
                    Dim dep As New dDepartamento
                    dep.ID = cli.IDDEPARTAMENTO
                    dep = dep.buscar
                    If Not dep Is Nothing Then
                        x1hoja.Cells(fila, columna).Formula = dep.NOMBRE
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 9
                        columna = columna + 13
                    End If
                ElseIf cli.CELULAR <> "" Then
                    x1hoja.Cells(fila, columna).Formula = "Celular: " & cli.CELULAR
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = columna + 13
                Else
                    x1hoja.Cells(fila, columna).Formula = "No aportado"
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = columna + 13
                End If
                Dim fecha As Date = Now()
                Dim fecha2 As String = fecha.ToString("dd/MM/yyyy")
                x1hoja.Cells(fila, columna).Formula = "Fecha informe: " & fecha2
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                Dim mm As New dMuestras
                mm.ID = sa.IDMUESTRA
                mm = mm.buscar
                If Not mm Is Nothing Then
                    x1hoja.Cells(fila, columna).Formula = "Material recibido: " & mm.NOMBRE
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = columna + 2
                Else
                    x1hoja.Cells(fila, columna).Formula = "Material recibido: "
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    fila = fila + 1
                    columna = columna + 3
                End If
                x1hoja.Cells(fila, columna).Formula = "Total de muestras: " & sa.NMUESTRAS
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = 1
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Muestreo realizado por el cliente."
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 2
                x1hoja.Cells(fila, columna).Formula = "Temperatura de arribo de las muestras: " & sa.TEMPERATURA & " °C"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = 1
                fila = fila + 1
                x1hoja.Range("A" & fila, "P" & fila).Merge()
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).rowheight = 1
                fila = fila + 1
                x1hoja.Cells(fila, columna).rowheight = 3
                fila = fila + 1
                columna = 1
                Dim cuenta As Integer = 1
                Dim detallemuestras As String = ""
                x1hoja.Cells(fila, columna).Formula = "Muestra"
                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Interior.Color = RGB(220, 220, 220)
                x1hoja.Cells(fila, columna).WrapText = True
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 1
                x1hoja.Cells(fila, columna).Formula = "Microorganismo"
                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Interior.Color = RGB(220, 220, 220)
                x1hoja.Cells(fila, columna).WrapText = True
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Font.Size = 8
                If solo_aislamiento = 0 Then
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "Am"
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).Interior.Color = RGB(220, 220, 220)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "Amc"
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).Interior.Color = RGB(220, 220, 220)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "Cf"
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).Interior.Color = RGB(220, 220, 220)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "E"
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).Interior.Color = RGB(220, 220, 220)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "Eno"
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).Interior.Color = RGB(220, 220, 220)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "Gm"
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).Interior.Color = RGB(220, 220, 220)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "Ox"
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).Interior.Color = RGB(220, 220, 220)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "P"
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).Interior.Color = RGB(220, 220, 220)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "Ra"
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).Interior.Color = RGB(220, 220, 220)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "Sxt"
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).Interior.Color = RGB(220, 220, 220)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "T"
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).Interior.Color = RGB(220, 220, 220)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Size = 8
                End If
                Dim listademetodos As String = "Aislamiento: National Mastitis council-1999 / Antibiograma: NCCLS-M31-A"
                Dim listadeabreviaturas As String = "Am: Ampicilina - Amc: Amoxicilina + Ác. Clavulánico - Cf: Cefalotina - E: Eritromicina - Eno: Enrofloxacina - Gm: Gentamicina - Ox: Cloxacilina - P: Penicilina - Ra: Rifampin - Sxt: Trimetoprim sulfametoxazol - T: Oxytetraciclina"
                columna = 1
                Dim m As String = ""
                Dim a As Integer = 0
                For Each atb In lista2
                    If m <> atb.MUESTRA Or a <> atb.AISLAMIENTO Then
                        fila = fila + 1
                    End If
                    m = atb.MUESTRA
                    a = atb.AISLAMIENTO
                    x1hoja.Cells(fila, columna).Formula = atb.MUESTRA
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).WrapText = True
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    Dim moa As New dMOA24
                    moa.ID = atb.AISLAMIENTO
                    moa = moa.buscar
                    If Not moa Is Nothing Then
                        x1hoja.Cells(fila, columna).Formula = moa.NOMBRE
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                    Else
                        x1hoja.Cells(fila, columna).Formula = ""
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                    End If
                    moa = Nothing
                    If solo_aislamiento = 0 Then
                        columna = columna + 1
                        If atb.ATB = 1 Then
                            x1hoja.Cells(fila, columna).Formula = atb.RESISTENCIA
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                            x1hoja.Cells(fila, columna).Interior.Color = RGB(255, 255, 255)
                            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        Else
                            If x1hoja.Cells(fila, columna).Formula <> "" Then
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                            End If
                        End If
                        columna = columna + 1
                        If atb.ATB = 2 Then
                            x1hoja.Cells(fila, columna).Formula = atb.RESISTENCIA
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                            x1hoja.Cells(fila, columna).Interior.Color = RGB(255, 255, 255)
                            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        Else
                            If x1hoja.Cells(fila, columna).Formula <> "" Then
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                            End If
                        End If
                        columna = columna + 1
                        If atb.ATB = 3 Then
                            x1hoja.Cells(fila, columna).Formula = atb.RESISTENCIA
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                            x1hoja.Cells(fila, columna).Interior.Color = RGB(255, 255, 255)
                            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        Else
                            If x1hoja.Cells(fila, columna).Formula <> "" Then
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                            End If
                        End If
                        columna = columna + 1
                        If atb.ATB = 4 Then
                            x1hoja.Cells(fila, columna).Formula = atb.RESISTENCIA
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                            x1hoja.Cells(fila, columna).Interior.Color = RGB(255, 255, 255)
                            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        Else
                            If x1hoja.Cells(fila, columna).Formula <> "" Then
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                            End If
                        End If
                        columna = columna + 1
                        If atb.ATB = 5 Then
                            x1hoja.Cells(fila, columna).Formula = atb.RESISTENCIA
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                            x1hoja.Cells(fila, columna).Interior.Color = RGB(255, 255, 255)
                            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        Else
                            If x1hoja.Cells(fila, columna).Formula <> "" Then
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                            End If
                        End If
                        columna = columna + 1
                        If atb.ATB = 6 Then
                            x1hoja.Cells(fila, columna).Formula = atb.RESISTENCIA
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                            x1hoja.Cells(fila, columna).Interior.Color = RGB(255, 255, 255)
                            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        Else
                            If x1hoja.Cells(fila, columna).Formula <> "" Then
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                            End If
                        End If
                        columna = columna + 1
                        If atb.ATB = 7 Then
                            x1hoja.Cells(fila, columna).Formula = atb.RESISTENCIA
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                            x1hoja.Cells(fila, columna).Interior.Color = RGB(255, 255, 255)
                            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        Else
                            If x1hoja.Cells(fila, columna).Formula <> "" Then
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                            End If
                        End If
                        columna = columna + 1
                        If atb.ATB = 8 Then
                            x1hoja.Cells(fila, columna).Formula = atb.RESISTENCIA
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                            x1hoja.Cells(fila, columna).Interior.Color = RGB(255, 255, 255)
                            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        Else
                            If x1hoja.Cells(fila, columna).Formula <> "" Then
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                            End If
                        End If
                        columna = columna + 1
                        If atb.ATB = 9 Then
                            x1hoja.Cells(fila, columna).Formula = atb.RESISTENCIA
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                            x1hoja.Cells(fila, columna).Interior.Color = RGB(255, 255, 255)
                            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        Else
                            If x1hoja.Cells(fila, columna).Formula <> "" Then
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                            End If
                        End If
                        columna = columna + 1
                        If atb.ATB = 10 Then
                            x1hoja.Cells(fila, columna).Formula = atb.RESISTENCIA
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                            x1hoja.Cells(fila, columna).Interior.Color = RGB(255, 255, 255)
                            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        Else
                            If x1hoja.Cells(fila, columna).Formula <> "" Then
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                            End If
                        End If
                        columna = columna + 1
                        If atb.ATB = 11 Then
                            x1hoja.Cells(fila, columna).Formula = atb.RESISTENCIA
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                            x1hoja.Cells(fila, columna).Interior.Color = RGB(255, 255, 255)
                            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        Else
                            If x1hoja.Cells(fila, columna).Formula <> "" Then
                            Else
                                x1hoja.Cells(fila, columna).Formula = ""
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                            End If
                        End If
                    End If
                    columna = 1
                Next
                columna = 1
                fila = fila + 1
                x1hoja.Cells(fila, columna).rowheight = 3
                fila = fila + 1
                x1hoja.Range("A" & fila, "P" & fila).Merge()
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                x1hoja.Cells(fila, columna).rowheight = 1
                fila = fila + 1
                If solo_aislamiento = 0 Then
                    x1hoja.Cells(fila, columna).Formula = "Abreviaturas"
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).rowheight = 30
                    x1hoja.Cells(fila, columna).Formula = listadeabreviaturas
                    x1hoja.Range("A" & fila, "P" & fila).WrapText = True
                    x1hoja.Range("A" & fila, "P" & fila).Merge()
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                    x1hoja.Cells(fila, columna).Font.Size = 7
                    fila = fila + 1
                End If
                x1hoja.Cells(fila, columna).Formula = "Métodos"
                x1hoja.Cells(fila, columna).Font.Bold = True
                fila = fila + 1
                x1hoja.Cells(fila, columna).rowheight = 30
                x1hoja.Cells(fila, columna).Formula = listademetodos
                x1hoja.Range("A" & fila, "P" & fila).WrapText = True
                x1hoja.Range("A" & fila, "P" & fila).Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Size = 7
                fila = fila + 1
                Dim sr As New dSolicitudRodeo
                sr.FICHA = nroficha
                sr = sr.buscar
                If Not sr Is Nothing Then
                    x1hoja.Cells(fila, columna).Formula = "Tipo de mastitis: " & sr.MASTITIS
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    columna = columna + 2
                    If sr.RODEO > 0 Then
                        x1hoja.Cells(fila, columna).Formula = "Rodeo: " & sr.RODEO
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        columna = 1
                        fila = fila + 1
                    Else
                        x1hoja.Cells(fila, columna).Formula = ""
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        columna = 1
                        fila = fila + 1
                    End If
                End If
                '*** OBSERVACIONES **************************************************
                If sa.OBSERVACIONES <> "" Then
                    x1hoja.Cells(fila, columna).rowheight = 25
                    x1hoja.Cells(fila, columna).Formula = "Observaciones: " & sa.OBSERVACIONES
                    x1hoja.Range("A" & fila, "P" & fila).WrapText = True
                    x1hoja.Range("A" & fila, "p" & fila).Merge()
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    fila = fila + 1
                End If
                '********************************************************************
                If solo_aislamiento = 0 Then
                    columna = 3
                    x1hoja.Cells(fila, columna).Formula = "Referencias:"
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).Formula = ""
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "No testeado."
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 7
                    fila = fila + 1
                    columna = columna - 1
                    x1hoja.Cells(fila, columna).Formula = "-"
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "No corresponde testeo."
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 7
                    columna = 1
                End If
                'CABEZAL CON O SIN LOGO OUA
                x1hoja.Shapes.AddPicture("c:\Debug\encabezado_sin_oua2.png", _
             Microsoft.Office.Core.MsoTriState.msoFalse, _
             Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 700, 50)
                If solo_aislamiento = 0 Then
                    fila = fila - 2
                End If
                columna = columna + 13
                Dim na2 As New dNuevoAnalisis
                na2.FICHA = nroficha
                na2 = na2.buscarxficha
                If Not na2 Is Nothing Then
                    Dim usu As New dUsuario
                    usu.ID = na2.OPERADOR
                    usu = usu.buscar
                    If Not usu Is Nothing Then
                        nombre_operador = usu.NOMBRE
                    End If
                    usu = Nothing
                End If
                na2 = Nothing
                x1hoja.Cells(fila, columna).Formula = "Operador: " & nombre_operador
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                '*** PONER FIRMA ********************************************************
                x1libro.Worksheets(1).cells(fila, columna).select()
                x1libro.ActiveSheet.pictures.Insert("c:\Debug\cecilia.jpg").select()
                x1libro.Worksheets(1).cells(2, 1).select()
                fila = fila + 6
                columna = 1
                '*** PIE DE PAGINA ******************************************************
                x1hoja.Cells(fila, columna).rowheight = 25
                x1hoja.Cells(fila, columna).Formula = "Este informe no podrá ser reproducido total o parcialmente sin la autorización escrita de COLAVECO. Los resultados consignados se refieren exclusivamente a la muestra recibida." & vbCrLf _
                    & "COLAVECO declina toda responsabilidad por el uso indebido o incorrecto que se hiciere a este informe, asi como el plan y procedimientos de muestreo aplicados por el cliente. Dra. Cecilia Abelenda (Directora Técnica)"
                x1hoja.Range("A" & fila, "O" & fila).WrapText = True
                x1hoja.Range("A" & fila, "O" & fila).Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Size = 6
                '************************************************************************
                fila = fila + 1
                x1hoja.Range("A" & fila, "P" & fila).Merge()
                x1hoja.Cells(fila, columna).Interior.Color = RGB(215, 219, 221)
                x1hoja.Cells(fila, columna).rowheight = 8
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Formula = "Fin del informe."
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 7
            End If
        End If
        'Insert tabla preinformes**************************
        'Dim pi As New dPreinformes
        'Dim fechaactual As Date = Now()
        'Dim _fecha As String
        '_fecha = Format(fechaactual, "yyyy-MM-dd")
        'pi.FICHA = nroficha
        'pi = pi.buscar
        'If Not pi Is Nothing Then
        'Else
        '    Dim pi2 As New dPreinformes
        '    pi2.FICHA = nroficha
        '    pi2.TIPO = 14
        '    pi2.CREADO = 1
        '    pi2.FECHA = _fecha
        '    pi2.guardar()
        '    pi2 = Nothing
        'End If
        'pi = Nothing
        '***********************************************************
        x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas
        'PROTEGE LA HOJA DE EXCEL
        x1hoja.Protect(Password:="1582782", DrawingObjects:=True, _
        Contents:=True, Scenarios:=True)
        'GUARDA EL ARCHIVO DE EXCEL
        'x1hoja.SaveAs("\\ROBOT\PREINFORMES\ANTIBIOGRAMA\" & nroficha & ".xls")
        x1app.Visible = True
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class