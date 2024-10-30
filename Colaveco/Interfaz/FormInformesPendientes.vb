Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Public Class FormInformesPendientes

    Private _sesion As New dSesion
    Private _usuario As dUsuario
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property
    Public Property Sesion() As dSesion
        Get
            Return _sesion
        End Get
        Set(ByVal value As dSesion)
            _sesion = value
        End Set
    End Property
#Region "Constructores"
    Public Sub New(ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u

        If u.TIPOUSUARIO = u.TIPOUSUARIO = 98 Then
            listarpendientes(True)
        Else
            listarpendientes(False)
        End If


    End Sub
#End Region
    Private Sub listarpendientes(ByVal pPorUsu As Boolean)
        Dim s As New dSolicitudAnalisis
        Dim p As New dCliente
        Dim t As New dTiempos
        Dim hoy As Date = Now.Date.ToString("yyyy-MM-dd")
        Dim dias As Integer = 0
        Dim lista As New ArrayList
        Dim lista2 As New ArrayList
        lista = s.listarpendientes
        lista2 = t.listar
        Dim control As Integer = 0
        Dim calidad As Integer = 0
        Dim agua As Integer = 0
        Dim antibiograma As Integer = 0
        Dim pal As Integer = 0
        Dim parasitologia As Integer = 0
        Dim productos As Integer = 0
        Dim serologia_leucosis As Integer = 0
        Dim patologia As Integer = 0
        Dim ambiental As Integer = 0
        Dim lactometros As Integer = 0
        Dim nutricion As Integer = 0
        Dim otros As Integer = 0
        Dim suelos As Integer = 0
        Dim serologia_brucelosis As Integer = 0
        Dim serologia_otros As Integer = 0
        Dim sp_salmonella_listeria As Integer = 0
        Dim sp_mohos_levaduras As Integer = 0
        Dim esporulados As Integer = 0
        Dim brucelosis_leche As Integer = 0
        Dim efluentes As Integer = 0


        Dim cuenta_control As Integer = 0
        Dim cuenta_calidad As Integer = 0
        Dim cuenta_agua As Integer = 0
        Dim cuenta_antibiograma As Integer = 0
        Dim cuenta_pal As Integer = 0
        Dim cuenta_parasitologia As Integer = 0
        Dim cuenta_productos As Integer = 0
        Dim cuenta_serologia_leucosis As Integer = 0
        Dim cuenta_patologia As Integer = 0
        Dim cuenta_ambiental As Integer = 0
        Dim cuenta_lactometros As Integer = 0
        Dim cuenta_nutricion As Integer = 0
        Dim cuenta_otros As Integer = 0
        Dim cuenta_suelos As Integer = 0
        Dim cuenta_serologia_brucelosis As Integer = 0
        Dim cuenta_serologia_otros As Integer = 0
        Dim cuenta_sp_salmonella_listeria As Integer = 0
        Dim cuenta_sp_mohos_levaduras As Integer = 0
        Dim cuenta_esporulados As Integer = 0
        Dim cuenta_brucelosis_leche As Integer = 0
        Dim cuenta_efluentes As Integer = 0



        For Each t In lista2

            control = t.CONTROL
            calidad = t.CALIDAD
            agua = t.AGUA
            antibiograma = t.ANTIBIOGRAMA
            pal = t.PAL
            parasitologia = t.PARASITOLOGIA
            productos = t.PRODUCTOS
            serologia_leucosis = t.SEROLOGIA_LEUCOSIS
            patologia = t.PATOLOGIA
            ambiental = t.AMBIENTAL
            lactometros = t.LACTOMETROS
            nutricion = t.NUTRICION
            otros = t.OTROS
            suelos = t.SUELOS
            serologia_brucelosis = t.SEROLOGIA_BRUCELOSIS
            serologia_otros = t.SEROLOGIA_OTROS
            sp_salmonella_listeria = t.SP_SALMONELLA_LISTERIA
            sp_mohos_levaduras = t.SP_MOHOS_LEVADURAS
            esporulados = t.ESPORULADOS
            brucelosis_leche = t.BRUCELOSIS_LECHE
            efluentes = t.EFLUENTES
        Next
        DataGridView1.Rows.Clear()
        'ListPendientes.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each s In lista
                    If pPorUsu And s.OPERADOR = Usuario.ID Then
                        DateHoy.Value = Now
                        DateSolicitud.Value = s.FECHAINGRESO
                        Dim fechahoy As Date = DateHoy.Value.ToString("yyyy-MM-dd")
                        Dim fechaingreso As Date = DateSolicitud.Value.ToString("yyyy-MM-dd")
                        dias = DateDiff(DateInterval.Day, fechaingreso, fechahoy)
                        Dim diasatraso As Integer = 0
                        Dim diasinforme As Integer = 0
                        Dim informe As String = ""
                        If s.IDTIPOINFORME = 1 Then
                            diasinforme = control
                            informe = "Control lechero"
                            cuenta_control = cuenta_control + 1
                        ElseIf s.IDTIPOINFORME = 10 Then
                            Dim csm As New dCalidadSolicitudMuestra
                            csm.FICHA = s.ID
                            csm = csm.buscarxsolicitud
                            If Not csm Is Nothing Then
                                If csm.ESPORULADOS = 1 Then
                                    diasinforme = esporulados
                                    informe = "Calidad de leche / Esporulados"
                                    cuenta_esporulados = cuenta_esporulados + 1
                                Else
                                    diasinforme = calidad
                                    informe = "Calidad de leche"
                                    cuenta_calidad = cuenta_calidad + 1
                                End If
                            End If
                            csm = Nothing
                        ElseIf s.IDTIPOINFORME = 3 Then
                            diasinforme = agua
                            informe = "Agua"
                            cuenta_agua = cuenta_agua + 1
                        ElseIf s.IDTIPOINFORME = 4 Then
                            diasinforme = antibiograma
                            informe = "Antibiograma"
                            cuenta_antibiograma = cuenta_antibiograma + 1
                        ElseIf s.IDTIPOINFORME = 5 Then
                            diasinforme = pal
                            informe = "PAL"
                            cuenta_pal = cuenta_pal + 1
                        ElseIf s.IDTIPOINFORME = 6 Then
                            diasinforme = parasitologia
                            informe = "Parasitología"
                            cuenta_parasitologia = cuenta_parasitologia + 1
                        ElseIf s.IDTIPOINFORME = 7 Then
                            Dim sp As New dSubproducto
                            sp.FICHA = s.ID
                            sp = sp.buscarxsolicitud()
                            If Not sp Is Nothing Then
                                If sp.SALMONELLA = 1 Or sp.LISTERIASPP = 1 Then
                                    diasinforme = sp_salmonella_listeria
                                    informe = "Alimentos / Salmonella - Listeria"
                                    cuenta_sp_salmonella_listeria = cuenta_sp_salmonella_listeria + 1
                                ElseIf sp.MOHOSYLEVADURAS = 1 Then
                                    diasinforme = sp_mohos_levaduras
                                    informe = "Alimentos / Mohos y levaduras"
                                    cuenta_sp_mohos_levaduras = cuenta_sp_mohos_levaduras + 1
                                Else
                                    diasinforme = productos
                                    informe = "Alimentos"
                                    cuenta_productos = cuenta_productos + 1
                                End If
                            Else
                                diasinforme = productos
                                informe = "Alimentos"
                                cuenta_productos = cuenta_productos + 1
                            End If
                            sp = Nothing
                        ElseIf s.IDTIPOINFORME = 8 Then
                            If s.IDSUBINFORME = 22 Then
                                diasinforme = serologia_otros
                                informe = "Serología RDB"
                                cuenta_serologia_otros = cuenta_serologia_otros + 1
                            Else
                                diasinforme = serologia_leucosis
                                informe = "Serología Leucosis"
                                cuenta_serologia_leucosis = cuenta_serologia_leucosis + 1
                            End If

                        ElseIf s.IDTIPOINFORME = 9 Then
                            diasinforme = patologia
                            informe = "Patología"
                            cuenta_patologia = cuenta_patologia + 1
                        ElseIf s.IDTIPOINFORME = 11 Then
                            diasinforme = ambiental
                            informe = "Ambiental"
                            cuenta_ambiental = cuenta_ambiental + 1
                        ElseIf s.IDTIPOINFORME = 12 Then
                            diasinforme = lactometros
                            informe = "Lactómetros"
                            cuenta_lactometros = cuenta_lactometros + 1
                        ElseIf s.IDTIPOINFORME = 13 Then
                            diasinforme = nutricion
                            informe = "Nutrición"
                            cuenta_nutricion = cuenta_nutricion + 1
                        ElseIf s.IDTIPOINFORME = 14 Then
                            diasinforme = suelos
                            informe = "Suelos"
                            cuenta_suelos = cuenta_suelos + 1
                        ElseIf s.IDTIPOINFORME = 15 Then
                            diasinforme = brucelosis_leche
                            informe = "Brucelosis en leche"
                            cuenta_brucelosis_leche = cuenta_brucelosis_leche + 1
                        ElseIf s.IDTIPOINFORME = 16 Then
                            diasinforme = 0
                            informe = "Efluentes"
                            cuenta_efluentes = cuenta_efluentes + 1
                        ElseIf s.IDTIPOINFORME = 99 Then
                            diasinforme = otros
                            informe = "Otros servicios"
                            cuenta_otros = cuenta_otros + 1
                        End If
                        If dias < diasinforme Then
                            diasatraso = 0
                        Else
                            diasatraso = dias - diasinforme
                        End If
                        p.ID = s.IDPRODUCTOR
                        p = p.buscar

                        'ListPendientes.Items.Add(s.FECHAINGRESO & Chr(9) & diasatraso & Chr(9) & p.NOMBRE & Chr(9) & informe & Chr(9) & s.ID)

                        ' *** Según usuario se desbloquean las secciones correspondientes.-
                        Dim u As dUsuario = Sesion.Usuario
                        'DataGridView1.ColumnCount = 7

                        DataGridView1(columna, fila).Value = s.FECHAINGRESO
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = diasatraso
                        columna = columna + 1

                        If Usuario.TIPOUSUARIO = 99 Or Usuario.TIPOUSUARIO = 97 Then
                            DataGridView1(columna, fila).Value = p.NOMBRE
                            columna = columna + 1
                        Else
                            DataGridView1(columna, fila).Value = " - "
                            columna = columna + 1
                        End If
                        DataGridView1(columna, fila).Value = informe
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = s.ID
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = s.NMUESTRAS
                        columna = columna + 1
                        'Analisis

                        ' Crear una lista temporal para almacenar las descripciones de los análisis
                        Dim analisis As New dNuevoAnalisis
                        Dim listaAnalisisFicha As ArrayList
                        listaAnalisisFicha = analisis.listarporficha3(s.ID)
                        Dim listaDescripciones As New List(Of String)

                        ' Recorrer cada elemento en la lista de análisis
                        For Each analisis In listaAnalisisFicha
                            ' Crear el objeto y obtener la descripción
                            Dim nombreAnalisis As New dListaPrecios
                            nombreAnalisis.ID = analisis.ANALISIS
                            nombreAnalisis = nombreAnalisis.buscar()

                            ' Agregar la descripción obtenida a la lista de descripciones
                            If Not String.IsNullOrEmpty(nombreAnalisis.DESCRIPCION) Then
                                listaDescripciones.Add(nombreAnalisis.DESCRIPCION)
                            End If
                        Next

                        Dim textoConcatenado As String = String.Join(" - ", listaDescripciones.ToArray())
                        DataGridView1(columna, fila).Value = textoConcatenado

                        ' Calcular el ancho de la columna basado en la longitud de la cadena concatenada
                        Dim anchoEstimado As Integer = textoConcatenado.Length * 12 ' Ajusta el valor multiplicador según el tamaño de fuente

                        ' Asignar el ancho estimado a la columna
                        DataGridView1.Columns(columna).Width = anchoEstimado

                        columna = 0
                        fila = fila + 1
                    Else
                        DateHoy.Value = Now
                        DateSolicitud.Value = s.FECHAINGRESO
                        Dim fechahoy As Date = DateHoy.Value.ToString("yyyy-MM-dd")
                        Dim fechaingreso As Date = DateSolicitud.Value.ToString("yyyy-MM-dd")
                        dias = DateDiff(DateInterval.Day, fechaingreso, fechahoy)
                        Dim diasatraso As Integer = 0
                        Dim diasinforme As Integer = 0
                        Dim informe As String = ""
                        If s.IDTIPOINFORME = 1 Then
                            diasinforme = control
                            informe = "Control lechero"
                            cuenta_control = cuenta_control + 1
                        ElseIf s.IDTIPOINFORME = 10 Then
                            Dim csm As New dCalidadSolicitudMuestra
                            csm.FICHA = s.ID
                            csm = csm.buscarxsolicitud
                            If Not csm Is Nothing Then
                                If csm.ESPORULADOS = 1 Then
                                    diasinforme = esporulados
                                    informe = "Calidad de leche / Esporulados"
                                    cuenta_esporulados = cuenta_esporulados + 1
                                Else
                                    diasinforme = calidad
                                    informe = "Calidad de leche"
                                    cuenta_calidad = cuenta_calidad + 1
                                End If
                            End If
                            csm = Nothing
                        ElseIf s.IDTIPOINFORME = 3 Then
                            diasinforme = agua
                            informe = "Agua"
                            cuenta_agua = cuenta_agua + 1
                        ElseIf s.IDTIPOINFORME = 4 Then
                            diasinforme = antibiograma
                            informe = "Antibiograma"
                            cuenta_antibiograma = cuenta_antibiograma + 1
                        ElseIf s.IDTIPOINFORME = 5 Then
                            diasinforme = pal
                            informe = "PAL"
                            cuenta_pal = cuenta_pal + 1
                        ElseIf s.IDTIPOINFORME = 6 Then
                            diasinforme = parasitologia
                            informe = "Parasitología"
                            cuenta_parasitologia = cuenta_parasitologia + 1
                        ElseIf s.IDTIPOINFORME = 7 Then
                            Dim sp As New dSubproducto
                            sp.FICHA = s.ID
                            sp = sp.buscarxsolicitud()
                            If Not sp Is Nothing Then
                                If sp.SALMONELLA = 1 Or sp.LISTERIASPP = 1 Then
                                    diasinforme = sp_salmonella_listeria
                                    informe = "Alimentos / Salmonella - Listeria"
                                    cuenta_sp_salmonella_listeria = cuenta_sp_salmonella_listeria + 1
                                ElseIf sp.MOHOSYLEVADURAS = 1 Then
                                    diasinforme = sp_mohos_levaduras
                                    informe = "Alimentos / Mohos y levaduras"
                                    cuenta_sp_mohos_levaduras = cuenta_sp_mohos_levaduras + 1
                                Else
                                    diasinforme = productos
                                    informe = "Alimentos"
                                    cuenta_productos = cuenta_productos + 1
                                End If
                            Else
                                diasinforme = productos
                                informe = "Alimentos"
                                cuenta_productos = cuenta_productos + 1
                            End If
                            sp = Nothing
                        ElseIf s.IDTIPOINFORME = 8 Then
                            If s.IDSUBINFORME = 22 Then
                                diasinforme = serologia_otros
                                informe = "Serología RDB"
                                cuenta_serologia_otros = cuenta_serologia_otros + 1
                            Else
                                diasinforme = serologia_leucosis
                                informe = "Serología Leucosis"
                                cuenta_serologia_leucosis = cuenta_serologia_leucosis + 1
                            End If

                        ElseIf s.IDTIPOINFORME = 9 Then
                            diasinforme = patologia
                            informe = "Patología"
                            cuenta_patologia = cuenta_patologia + 1
                        ElseIf s.IDTIPOINFORME = 11 Then
                            diasinforme = ambiental
                            informe = "Ambiental"
                            cuenta_ambiental = cuenta_ambiental + 1
                        ElseIf s.IDTIPOINFORME = 12 Then
                            diasinforme = lactometros
                            informe = "Lactómetros"
                            cuenta_lactometros = cuenta_lactometros + 1
                        ElseIf s.IDTIPOINFORME = 13 Then
                            diasinforme = nutricion
                            informe = "Nutrición"
                            cuenta_nutricion = cuenta_nutricion + 1
                        ElseIf s.IDTIPOINFORME = 14 Then
                            diasinforme = suelos
                            informe = "Suelos"
                            cuenta_suelos = cuenta_suelos + 1
                        ElseIf s.IDTIPOINFORME = 15 Then
                            diasinforme = brucelosis_leche
                            informe = "Brucelosis en leche"
                            cuenta_brucelosis_leche = cuenta_brucelosis_leche + 1
                        ElseIf s.IDTIPOINFORME = 16 Then
                            diasinforme = 0
                            informe = "Efluentes"
                            cuenta_efluentes = cuenta_efluentes + 1
                        ElseIf s.IDTIPOINFORME = 99 Then
                            diasinforme = otros
                            informe = "Otros servicios"
                            cuenta_otros = cuenta_otros + 1
                        End If
                        If dias < diasinforme Then
                            diasatraso = 0
                        Else
                            diasatraso = dias - diasinforme
                        End If
                        p.ID = s.IDPRODUCTOR
                        p = p.buscar

                        'ListPendientes.Items.Add(s.FECHAINGRESO & Chr(9) & diasatraso & Chr(9) & p.NOMBRE & Chr(9) & informe & Chr(9) & s.ID)

                        ' *** Según usuario se desbloquean las secciones correspondientes.-
                        Dim u As dUsuario = Sesion.Usuario
                        'DataGridView1.ColumnCount = 7

                        DataGridView1(columna, fila).Value = s.FECHAINGRESO
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = diasatraso
                        columna = columna + 1

                        If Usuario.TIPOUSUARIO = 99 Or Usuario.TIPOUSUARIO = 97 Then
                            DataGridView1(columna, fila).Value = p.NOMBRE
                            columna = columna + 1
                        Else
                            DataGridView1(columna, fila).Value = " - "
                            columna = columna + 1
                        End If
                        DataGridView1(columna, fila).Value = informe
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = s.ID
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = s.NMUESTRAS
                        columna = columna + 1
                        'Analisis

                        ' Crear una lista temporal para almacenar las descripciones de los análisis
                        Dim analisis As New dNuevoAnalisis
                        Dim listaAnalisisFicha As ArrayList
                        listaAnalisisFicha = analisis.listarporficha3(s.ID)
                        Dim listaDescripciones As New List(Of String)

                        ' Recorrer cada elemento en la lista de análisis
                        For Each analisis In listaAnalisisFicha
                            ' Crear el objeto y obtener la descripción
                            Dim nombreAnalisis As New dListaPrecios
                            nombreAnalisis.ID = analisis.ANALISIS
                            nombreAnalisis = nombreAnalisis.buscar()

                            ' Agregar la descripción obtenida a la lista de descripciones
                            If Not String.IsNullOrEmpty(nombreAnalisis.DESCRIPCION) Then
                                listaDescripciones.Add(nombreAnalisis.DESCRIPCION)
                            End If
                        Next

                        Dim textoConcatenado As String = String.Join(" - ", listaDescripciones.ToArray())
                        DataGridView1(columna, fila).Value = textoConcatenado

                        ' Calcular el ancho de la columna basado en la longitud de la cadena concatenada
                        Dim anchoEstimado As Integer = textoConcatenado.Length * 12 ' Ajusta el valor multiplicador según el tamaño de fuente

                        ' Asignar el ancho estimado a la columna
                        DataGridView1.Columns(columna).Width = anchoEstimado

                        columna = 0
                        fila = fila + 1
                    End If
                Next
                DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Descending)
                TextControl.Text = cuenta_control
                TextCalidad.Text = cuenta_calidad
                TextAgua.Text = cuenta_agua
                TextAntibiograma.Text = cuenta_antibiograma
                TextPal.Text = cuenta_pal
                TextParasitologia.Text = cuenta_parasitologia
                TextProductos.Text = cuenta_productos
                TextSerologiaLeucosis.Text = cuenta_serologia_leucosis
                TextPatologia.Text = cuenta_patologia
                TextAmbiental.Text = cuenta_ambiental
                TextLactometros.Text = cuenta_lactometros
                TextAgroNutricion.Text = cuenta_nutricion
                TextOtros.Text = cuenta_otros
                TextAgroSuelos.Text = cuenta_suelos
                TextSerologiaBrucelosis.Text = cuenta_serologia_brucelosis
                TextSerologiaOtros.Text = cuenta_serologia_otros
                TextSPSalmonellaListeria.Text = cuenta_sp_salmonella_listeria
                TextSPMohosLevaduras.Text = cuenta_sp_mohos_levaduras
                TextEsporulados.Text = cuenta_esporulados
                TextBrucelosisLeche.Text = cuenta_brucelosis_leche
                TextEfluentes.Text = cuenta_efluentes
            End If
        End If
    End Sub

    Private Sub ButtonImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonImprimir.Click
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

        Dim s As New dSolicitudAnalisis
        Dim p As New dCliente
        Dim t As New dTiempos
        Dim hoy As Date = Now.Date.ToString("yyyy-MM-dd")
        Dim dias As Integer = 0
        Dim lista As New ArrayList
        Dim lista2 As New ArrayList
        lista = s.listarpendientes
        lista2 = t.listar
        Dim control As Integer = 0
        Dim calidad As Integer = 0
        Dim agua As Integer = 0
        Dim antibiograma As Integer = 0
        Dim pal As Integer = 0
        Dim parasitologia As Integer = 0
        Dim productos As Integer = 0
        Dim serologia_leucosis As Integer = 0
        Dim patologia As Integer = 0
        Dim ambiental As Integer = 0
        Dim lactometros As Integer = 0
        Dim nutricion As Integer = 0
        Dim otros As Integer = 0
        Dim suelos As Integer = 0
        Dim serologia_brucelosis As Integer = 0
        Dim serologia_otros As Integer = 0
        Dim sp_salmonella_listeria As Integer = 0
        Dim sp_mohos_levaduras As Integer = 0
        Dim esporulados As Integer = 0
        Dim brucelosis_leche As Integer = 0
        Dim efluentes As Integer = 0


        Dim cuenta_control As Integer = 0
        Dim cuenta_calidad As Integer = 0
        Dim cuenta_agua As Integer = 0
        Dim cuenta_antibiograma As Integer = 0
        Dim cuenta_pal As Integer = 0
        Dim cuenta_parasitologia As Integer = 0
        Dim cuenta_productos As Integer = 0
        Dim cuenta_serologia_leucosis As Integer = 0
        Dim cuenta_patologia As Integer = 0
        Dim cuenta_ambiental As Integer = 0
        Dim cuenta_lactometros As Integer = 0
        Dim cuenta_nutricion As Integer = 0
        Dim cuenta_otros As Integer = 0
        Dim cuenta_suelos As Integer = 0
        Dim cuenta_serologia_brucelosis As Integer = 0
        Dim cuenta_serologia_otros As Integer = 0
        Dim cuenta_sp_salmonella_listeria As Integer = 0
        Dim cuenta_sp_mohos_levaduras As Integer = 0
        Dim cuenta_esporulados As Integer = 0
        Dim cuenta_brucelosis_leche As Integer = 0
        Dim cuenta_efluentes As Integer = 0

        For Each t In lista2

            control = t.CONTROL
            calidad = t.CALIDAD
            agua = t.AGUA
            antibiograma = t.ANTIBIOGRAMA
            pal = t.PAL
            parasitologia = t.PARASITOLOGIA
            productos = t.PRODUCTOS
            serologia_leucosis = t.SEROLOGIA_LEUCOSIS
            patologia = t.PATOLOGIA
            ambiental = t.AMBIENTAL
            lactometros = t.LACTOMETROS
            nutricion = t.NUTRICION
            otros = t.OTROS
            suelos = t.SUELOS
            serologia_brucelosis = t.SEROLOGIA_BRUCELOSIS
            serologia_otros = t.SEROLOGIA_OTROS
            sp_salmonella_listeria = t.SP_SALMONELLA_LISTERIA
            sp_mohos_levaduras = t.SP_MOHOS_LEVADURAS
            esporulados = t.ESPORULADOS
            brucelosis_leche = t.BRUCELOSIS_LECHE
            efluentes = t.EFLUENTES

        Next
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                x1hoja.Shapes.AddPicture("c:\Debug\logo.jpg", _
                 Microsoft.Office.Core.MsoTriState.msoFalse, _
                Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 80, 35)
                Dim fila As Integer = 1
                Dim columna As Integer = 3

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
                x1hoja.Range("B5", "C5").Merge()
                fila = fila + 2
                columna = 1


                x1hoja.Cells(1, 1).columnwidth = 10
                x1hoja.Cells(1, 2).columnwidth = 6
                x1hoja.Cells(1, 3).columnwidth = 40
                x1hoja.Cells(1, 4).columnwidth = 16
                x1hoja.Cells(1, 5).columnwidth = 6

                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Control lechero: " & TextControl.Text & " / " & "Calidad de leche: " & TextCalidad.Text & " / " & "Agua: " & TextAgua.Text
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                'x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Antibiograma: " & TextAntibiograma.Text & " / " & "PAL: " & TextPal.Text & " / " & "Parasitología: " & TextParasitologia.Text
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                'x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Alimentos: " & TextProductos.Text & " / " & "Serología Leucosis: " & TextSerologiaLeucosis.Text & " / " & "Patología: " & TextPatologia.Text
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                'x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Ambiental: " & TextAmbiental.Text & " / " & "Lactómetros: " & TextLactometros.Text & " / " & "Nutrición: " & TextAgroNutricion.Text
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                'x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Otros servicios: " & TextOtros.Text & " / " & "Suelos: " & TextAgroSuelos.Text & " / " & "Serología Brucelosis: " & TextSerologiaBrucelosis.Text
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                'x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Serología otros: " & TextSerologiaOtros.Text & " / " & "Salmonella - Listeria: " & TextSPSalmonellaListeria.Text & " / " & "Mohos y levaduras: " & TextSPMohosLevaduras.Text
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                'x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Esporulados: " & TextEsporulados.Text & " / " & "Brucelosis en leche: " & TextBrucelosisLeche.Text
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                'x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Efluentes: " & TextEfluentes.Text & " "
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                'x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                fila = fila + 1
                columna = 1
                x1hoja.Range("A12", "C12").Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Formula = Now
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 8

                fila = fila + 1


                x1hoja.Cells(fila, columna).formula = "Fecha"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Atraso"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Productor"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Informe"
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
                columna = 1
                fila = fila + 1
                For Each s In lista
                    If Usuario.TIPOUSUARIO = 98 And s.OPERADOR = Usuario.ID Then
                        DateHoy.Value = Now
                        DateSolicitud.Value = s.FECHAINGRESO
                        Dim fechahoy As Date = DateHoy.Value.ToString("yyyy-MM-dd")
                        Dim fechaingreso As Date = DateSolicitud.Value.ToString("yyyy-MM-dd")
                        dias = DateDiff(DateInterval.Day, fechaingreso, fechahoy)
                        Dim diasatraso As Integer = 0
                        Dim diasinforme As Integer = 0
                        Dim informe As String = ""
                        If s.IDTIPOINFORME = 1 Then
                            diasinforme = control
                            informe = "Control lechero"
                        ElseIf s.IDTIPOINFORME = 10 Then
                            Dim csm As New dCalidadSolicitudMuestra
                            csm.FICHA = s.ID
                            csm = csm.buscarxsolicitud
                            If Not csm Is Nothing Then
                                If csm.ESPORULADOS = 1 Then
                                    diasinforme = esporulados
                                    informe = "Esporulados"
                                    cuenta_esporulados = cuenta_esporulados + 1
                                Else
                                    diasinforme = calidad
                                    informe = "Calidad de leche"
                                    cuenta_calidad = cuenta_calidad + 1
                                End If
                            End If
                            csm = Nothing
                            'ElseIf s.IDTIPOINFORME = 10 Then
                            '    diasinforme = calidad
                            '    informe = "Calidad de leche"
                        ElseIf s.IDTIPOINFORME = 3 Then
                            diasinforme = agua
                            informe = "Agua"
                        ElseIf s.IDTIPOINFORME = 4 Then
                            diasinforme = antibiograma
                            informe = "Antibiograma"
                        ElseIf s.IDTIPOINFORME = 5 Then
                            diasinforme = pal
                            informe = "PAL"
                        ElseIf s.IDTIPOINFORME = 6 Then
                            diasinforme = parasitologia
                            informe = "Parasitología"
                        ElseIf s.IDTIPOINFORME = 7 Then
                            Dim sp As New dSubproducto
                            sp.FICHA = s.ID
                            sp = sp.buscarxsolicitud()
                            If Not sp Is Nothing Then
                                If sp.SALMONELLA = 1 Or sp.LISTERIASPP = 1 Then
                                    diasinforme = sp_salmonella_listeria
                                    informe = "Salmonella - Listeria"
                                    cuenta_sp_salmonella_listeria = cuenta_sp_salmonella_listeria + 1
                                ElseIf sp.MOHOSYLEVADURAS = 1 Then
                                    diasinforme = sp_mohos_levaduras
                                    informe = "Mohos y levaduras"
                                    cuenta_sp_mohos_levaduras = cuenta_sp_mohos_levaduras + 1
                                Else
                                    diasinforme = productos
                                    informe = "Alimentos"
                                    cuenta_productos = cuenta_productos + 1
                                End If
                            Else
                                diasinforme = productos
                                informe = "Alimentos"
                                cuenta_productos = cuenta_productos + 1
                            End If
                            sp = Nothing
                            'ElseIf s.IDTIPOINFORME = 7 Then
                            '    diasinforme = productos
                            '    informe = "Productos lácteos"
                        ElseIf s.IDTIPOINFORME = 8 Then
                            diasinforme = serologia_leucosis
                            informe = "Serología Leucosis"
                        ElseIf s.IDTIPOINFORME = 9 Then
                            diasinforme = patologia
                            informe = "Patología"
                        ElseIf s.IDTIPOINFORME = 11 Then
                            diasinforme = ambiental
                            informe = "Ambiental"
                        ElseIf s.IDTIPOINFORME = 12 Then
                            diasinforme = lactometros
                            informe = "Lactómetros"
                        ElseIf s.IDTIPOINFORME = 13 Then
                            diasinforme = nutricion
                            informe = "Nutrición"
                        ElseIf s.IDTIPOINFORME = 14 Then
                            diasinforme = suelos
                            informe = "Suelos"
                        ElseIf s.IDTIPOINFORME = 15 Then
                            diasinforme = brucelosis_leche
                            informe = "Brucelosis en leche"
                        ElseIf s.IDTIPOINFORME = 16 Then
                            diasinforme = efluentes
                            informe = "Efluentes"
                        ElseIf s.IDTIPOINFORME = 99 Then
                            diasinforme = otros
                            informe = "Otros servicios"
                        End If
                        If dias < diasinforme Then
                            diasatraso = 0
                        Else
                            diasatraso = dias - diasinforme
                        End If
                        p.ID = s.IDPRODUCTOR
                        p = p.buscar

                        x1hoja.Cells(fila, columna).formula = s.FECHAINGRESO
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        'x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = diasatraso
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        'x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = p.NOMBRE
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        'x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = informe
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        'x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = s.ID
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        'x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = 1
                        fila = fila + 1
                    Else
                        DateHoy.Value = Now
                        DateSolicitud.Value = s.FECHAINGRESO
                        Dim fechahoy As Date = DateHoy.Value.ToString("yyyy-MM-dd")
                        Dim fechaingreso As Date = DateSolicitud.Value.ToString("yyyy-MM-dd")
                        dias = DateDiff(DateInterval.Day, fechaingreso, fechahoy)
                        Dim diasatraso As Integer = 0
                        Dim diasinforme As Integer = 0
                        Dim informe As String = ""
                        If s.IDTIPOINFORME = 1 Then
                            diasinforme = control
                            informe = "Control lechero"
                        ElseIf s.IDTIPOINFORME = 10 Then
                            Dim csm As New dCalidadSolicitudMuestra
                            csm.FICHA = s.ID
                            csm = csm.buscarxsolicitud
                            If Not csm Is Nothing Then
                                If csm.ESPORULADOS = 1 Then
                                    diasinforme = esporulados
                                    informe = "Esporulados"
                                    cuenta_esporulados = cuenta_esporulados + 1
                                Else
                                    diasinforme = calidad
                                    informe = "Calidad de leche"
                                    cuenta_calidad = cuenta_calidad + 1
                                End If
                            End If
                            csm = Nothing
                            'ElseIf s.IDTIPOINFORME = 10 Then
                            '    diasinforme = calidad
                            '    informe = "Calidad de leche"
                        ElseIf s.IDTIPOINFORME = 3 Then
                            diasinforme = agua
                            informe = "Agua"
                        ElseIf s.IDTIPOINFORME = 4 Then
                            diasinforme = antibiograma
                            informe = "Antibiograma"
                        ElseIf s.IDTIPOINFORME = 5 Then
                            diasinforme = pal
                            informe = "PAL"
                        ElseIf s.IDTIPOINFORME = 6 Then
                            diasinforme = parasitologia
                            informe = "Parasitología"
                        ElseIf s.IDTIPOINFORME = 7 Then
                            Dim sp As New dSubproducto
                            sp.FICHA = s.ID
                            sp = sp.buscarxsolicitud()
                            If Not sp Is Nothing Then
                                If sp.SALMONELLA = 1 Or sp.LISTERIASPP = 1 Then
                                    diasinforme = sp_salmonella_listeria
                                    informe = "Salmonella - Listeria"
                                    cuenta_sp_salmonella_listeria = cuenta_sp_salmonella_listeria + 1
                                ElseIf sp.MOHOSYLEVADURAS = 1 Then
                                    diasinforme = sp_mohos_levaduras
                                    informe = "Mohos y levaduras"
                                    cuenta_sp_mohos_levaduras = cuenta_sp_mohos_levaduras + 1
                                Else
                                    diasinforme = productos
                                    informe = "Alimentos"
                                    cuenta_productos = cuenta_productos + 1
                                End If
                            Else
                                diasinforme = productos
                                informe = "Alimentos"
                                cuenta_productos = cuenta_productos + 1
                            End If
                            sp = Nothing
                            'ElseIf s.IDTIPOINFORME = 7 Then
                            '    diasinforme = productos
                            '    informe = "Productos lácteos"
                        ElseIf s.IDTIPOINFORME = 8 Then
                            diasinforme = serologia_leucosis
                            informe = "Serología Leucosis"
                        ElseIf s.IDTIPOINFORME = 9 Then
                            diasinforme = patologia
                            informe = "Patología"
                        ElseIf s.IDTIPOINFORME = 11 Then
                            diasinforme = ambiental
                            informe = "Ambiental"
                        ElseIf s.IDTIPOINFORME = 12 Then
                            diasinforme = lactometros
                            informe = "Lactómetros"
                        ElseIf s.IDTIPOINFORME = 13 Then
                            diasinforme = nutricion
                            informe = "Nutrición"
                        ElseIf s.IDTIPOINFORME = 14 Then
                            diasinforme = suelos
                            informe = "Suelos"
                        ElseIf s.IDTIPOINFORME = 15 Then
                            diasinforme = brucelosis_leche
                            informe = "Brucelosis en leche"
                        ElseIf s.IDTIPOINFORME = 16 Then
                            diasinforme = efluentes
                            informe = "Efluentes"
                        ElseIf s.IDTIPOINFORME = 99 Then
                            diasinforme = otros
                            informe = "Otros servicios"
                        End If
                        If dias < diasinforme Then
                            diasatraso = 0
                        Else
                            diasatraso = dias - diasinforme
                        End If
                        p.ID = s.IDPRODUCTOR
                        p = p.buscar

                        x1hoja.Cells(fila, columna).formula = s.FECHAINGRESO
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        'x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = diasatraso
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        'x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = p.NOMBRE
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        'x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = informe
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        'x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = s.ID
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        'x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = 1
                        fila = fila + 1
                    End If
                Next
            End If
        End If

        x1app.Visible = True
        x1libro.PrintPreview()

        'x1hoja.PrintOut()
        'x1libro.Close()
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub

    
    Private Sub Label21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label21.Click

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class