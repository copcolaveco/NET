
Public Class FormCMI
    Private _usuario As dUsuario
    Private _anio As Integer
    Private iddimension As Long
    Private idobjgral As Long
    Private idobjesp As Long
    Private idactividad As Long
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

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        calcularano()
        listardimension()
        listarobjgenerales()
        listarobjespecificos()
        'listaractividades()
        listarindicadores()


    End Sub
#End Region
    Private Sub calcularano()
        Dim hoy As Date = Now
        Dim ano As Integer = 0
        ano = hoy.Year
        _anio = hoy.Year
        NumericAno.Value = ano
       
    End Sub
    Private Sub listardimension()
        Dim d As New dDimension
        Dim lista As New ArrayList
        lista = d.listarxano(_anio)

        DataGridDimension.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridDimension.ColumnCount = 2
                DataGridDimension.Columns(0).Name = "Id"
                DataGridDimension.Columns(0).Width = 150
                DataGridDimension.Columns(0).Visible = False
                DataGridDimension.Columns(1).Name = "Dimensiones"
                DataGridDimension.Columns(1).Width = 150
                DataGridDimension.Rows.Add(lista.Count)
                For Each d In lista
                    DataGridDimension(columna, fila).Value = d.ID
                    columna = columna + 1
                    DataGridDimension(columna, fila).Value = d.NOMBRE
                    columna = 0
                    fila = fila + 1
                Next
                DataGridDimension.Sort(DataGridDimension.Columns(1), System.ComponentModel.ListSortDirection.Ascending)

            End If
        End If
    End Sub
    Private Sub listarobjgenerales()
        Dim og As New dObjGral
        Dim lista As New ArrayList
        lista = og.listarxano(_anio)

        DataGridObjGral.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridObjGral.ColumnCount = 3
                DataGridObjGral.Columns(0).Name = "Id"
                DataGridObjGral.Columns(0).Width = 300
                DataGridObjGral.Columns(0).Visible = False
                DataGridObjGral.Columns(1).Name = "Objetivos generales"
                DataGridObjGral.Columns(1).Width = 300
                DataGridObjGral.Columns(2).Name = "Dimensión"
                DataGridObjGral.Columns(2).Width = 300
                DataGridObjGral.Columns(2).Visible = False

                DataGridObjGral.Rows.Add(lista.Count)

                For Each og In lista
                    Dim d As New dDimension
                    DataGridObjGral(columna, fila).Value = og.ID
                    columna = columna + 1
                    DataGridObjGral(columna, fila).Value = og.NOMBRE
                    columna = columna + 1
                    d.ID = og.IDDIMENSION
                    d = d.buscar
                    If Not d Is Nothing Then
                        DataGridObjGral(columna, fila).Value = d.NOMBRE
                        columna = 0
                    Else
                        DataGridObjGral(columna, fila).Value = ""
                        columna = 0
                    End If
                    fila = fila + 1
                Next
                DataGridObjGral.Sort(DataGridObjGral.Columns(2), System.ComponentModel.ListSortDirection.Ascending)

            End If
        End If
    End Sub
    Private Sub listarobjespecificos()
        Dim oe As New dObjEspecifico
        Dim lista As New ArrayList
        lista = oe.listarxano(_anio)

        DataGridObjEspecifico.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridObjEspecifico.ColumnCount = 3
                DataGridObjEspecifico.Columns(0).Name = "Id"
                DataGridObjEspecifico.Columns(0).Width = 200
                DataGridObjEspecifico.Columns(0).Visible = False
                DataGridObjEspecifico.Columns(1).Name = "Objetivos específicos"
                DataGridObjEspecifico.Columns(1).Width = 400
                DataGridObjEspecifico.Columns(2).Name = "Objetivos generales"
                DataGridObjEspecifico.Columns(2).Width = 300
                DataGridObjEspecifico.Columns(2).Visible = False
                DataGridObjEspecifico.Rows.Add(lista.Count)

                For Each oe In lista
                    Dim og As New dObjGral
                    DataGridObjEspecifico(columna, fila).Value = oe.ID
                    columna = columna + 1
                    DataGridObjEspecifico(columna, fila).Value = oe.NOMBRE
                    columna = columna + 1
                    og.ID = oe.IDOBJGRAL
                    og = og.buscar
                    If Not og Is Nothing Then
                        DataGridObjEspecifico(columna, fila).Value = og.NOMBRE
                        columna = 0
                    Else
                        DataGridObjGral(columna, fila).Value = ""
                        columna = 0
                    End If
                    fila = fila + 1
                Next
                DataGridObjEspecifico.Sort(DataGridObjEspecifico.Columns(0), System.ComponentModel.ListSortDirection.Ascending)

            End If
        End If
    End Sub
    Private Sub listaractividades()
        Dim a As New dActividades
        Dim lista As New ArrayList
        lista = a.listarxano(_anio)

        DataGridActividades.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridActividades.ColumnCount = 9
                DataGridActividades.Columns(0).Name = "Id"
                DataGridActividades.Columns(0).Width = 50
                DataGridActividades.Columns(0).Visible = False
                DataGridActividades.Columns(1).Name = "Actividad"
                DataGridActividades.Columns(1).Width = 150
                DataGridActividades.Columns(2).Name = "Indicador"
                DataGridActividades.Columns(2).Width = 100
                DataGridActividades.Columns(3).Name = "Año"
                DataGridActividades.Columns(3).Width = 50
                DataGridActividades.Columns(4).Name = "Objetivo específico"
                DataGridActividades.Columns(4).Width = 250
                DataGridActividades.Columns(5).Name = "Meta"
                DataGridActividades.Columns(5).Width = 100
                DataGridActividades.Columns(6).Name = "Responsable"
                DataGridActividades.Columns(6).Width = 150
                DataGridActividades.Columns(7).Name = "Plazo"
                DataGridActividades.Columns(7).Width = 70
                DataGridActividades.Columns(8).Name = "Finaliza"
                DataGridActividades.Columns(8).Width = 50
                DataGridActividades.Rows.Add(lista.Count)

                Dim oe As New dObjEspecifico
                For Each a In lista
                    DataGridActividades(columna, fila).Value = a.ID
                    columna = columna + 1
                    DataGridActividades(columna, fila).Value = a.NOMBRE
                    columna = columna + 1
                    DataGridActividades(columna, fila).Value = a.INDICADOR
                    columna = columna + 1
                    DataGridActividades(columna, fila).Value = a.ANO
                    columna = columna + 1
                    oe.ID = a.IDOBJESPECIFICO
                    oe = oe.buscar
                    If Not oe Is Nothing Then
                        DataGridActividades(columna, fila).Value = oe.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridActividades(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    DataGridActividades(columna, fila).Value = a.META
                    columna = columna + 1
                    DataGridActividades(columna, fila).Value = a.RESPONSABLE
                    columna = columna + 1
                    DataGridActividades(columna, fila).Value = a.PLAZO
                    columna = columna + 1
                    DataGridActividades(columna, fila).Value = a.FINALIZA
                    columna = 0
                    fila = fila + 1

                Next
                DataGridObjEspecifico.Sort(DataGridObjEspecifico.Columns(0), System.ComponentModel.ListSortDirection.Ascending)

            End If
        End If
    End Sub
    Private Sub listarindicadores()
        Dim a As New dActividades
        Dim i As New dIndicadores
        Dim lista As New ArrayList
        Dim lista2 As New ArrayList
        lista = a.listarxano(_anio)

        DataGridActividades.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridActividades.ColumnCount = 23
                DataGridActividades.Columns(0).Name = "Id"
                DataGridActividades.Columns(0).Width = 50
                DataGridActividades.Columns(0).Visible = False
                DataGridActividades.Columns(1).Name = "Dimensión"
                DataGridActividades.Columns(1).Width = 70
                DataGridActividades.Columns(2).Name = "Actividad"
                DataGridActividades.Columns(2).Width = 150
                DataGridActividades.Columns(3).Name = "Indicador"
                DataGridActividades.Columns(3).Width = 100
                DataGridActividades.Columns(4).Name = "Año"
                DataGridActividades.Columns(4).Width = 50
                DataGridActividades.Columns(4).Visible = False
                DataGridActividades.Columns(5).Name = "Objetivo específico"
                DataGridActividades.Columns(5).Width = 200
                DataGridActividades.Columns(6).Name = "IdIndicador"
                DataGridActividades.Columns(6).Width = 250
                DataGridActividades.Columns(6).Visible = False
                DataGridActividades.Columns(7).Name = "Ene"
                DataGridActividades.Columns(7).Width = 30
                DataGridActividades.Columns(8).Name = "Feb"
                DataGridActividades.Columns(8).Width = 30
                DataGridActividades.Columns(9).Name = "Mar"
                DataGridActividades.Columns(9).Width = 30
                DataGridActividades.Columns(10).Name = "Abr"
                DataGridActividades.Columns(10).Width = 30
                DataGridActividades.Columns(11).Name = "May"
                DataGridActividades.Columns(11).Width = 30
                DataGridActividades.Columns(12).Name = "Jun"
                DataGridActividades.Columns(12).Width = 30
                DataGridActividades.Columns(13).Name = "Jul"
                DataGridActividades.Columns(13).Width = 30
                DataGridActividades.Columns(14).Name = "Ago"
                DataGridActividades.Columns(14).Width = 30
                DataGridActividades.Columns(15).Name = "Set"
                DataGridActividades.Columns(15).Width = 30
                DataGridActividades.Columns(16).Name = "Oct"
                DataGridActividades.Columns(16).Width = 30
                DataGridActividades.Columns(17).Name = "Nov"
                DataGridActividades.Columns(17).Width = 30
                DataGridActividades.Columns(18).Name = "Dic"
                DataGridActividades.Columns(18).Width = 30
                DataGridActividades.Columns(19).Name = "Meta"
                DataGridActividades.Columns(19).Width = 50
                DataGridActividades.Columns(20).Name = "Acep."
                DataGridActividades.Columns(20).Width = 50
                DataGridActividades.Columns(21).Name = "Responsable"
                DataGridActividades.Columns(21).Width = 60
                DataGridActividades.Columns(22).Name = "Final."
                DataGridActividades.Columns(22).Width = 50
                DataGridActividades.Rows.Add(lista.Count)


                For Each a In lista
                    DataGridActividades(columna, fila).Value = a.ID
                    columna = columna + 1
                    Dim dimen As New dDimension
                    dimen.ID = a.IDDIMENSION
                    dimen = dimen.buscar
                    If Not dimen Is Nothing Then
                        DataGridActividades(columna, fila).Value = dimen.NOMBRE
                        columna = columna + 1
                    End If
                    DataGridActividades(columna, fila).Value = a.NOMBRE
                    columna = columna + 1
                    DataGridActividades(columna, fila).Value = a.INDICADOR
                    columna = columna + 1
                    DataGridActividades(columna, fila).Value = a.ANO
                    columna = columna + 1
                    Dim oe As New dObjEspecifico
                    oe.ID = a.IDOBJESPECIFICO
                    oe = oe.buscar
                    If Not oe Is Nothing Then
                        DataGridActividades(columna, fila).Value = oe.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridActividades(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    Dim idact As Long = 0
                    idact = a.ID
                    lista2 = i.listarxactividad(idact)
                    If Not lista2 Is Nothing Then
                        If lista2.Count > 0 Then
                            DataGridActividades(columna, fila).Value = i.ID
                            columna = columna + 1
                            For Each i In lista2

                                DataGridActividades(columna, fila).Value = i.INDICADOR
                                If i.INDICADOR < a.ACEPTABLE Then
                                    DataGridActividades(columna, fila).Style.BackColor = Color.Red
                                ElseIf i.INDICADOR >= a.ACEPTABLE And i.INDICADOR < a.META Then
                                    DataGridActividades(columna, fila).Style.BackColor = Color.Yellow
                                ElseIf i.INDICADOR >= a.META Then
                                    DataGridActividades(columna, fila).Style.BackColor = Color.Green
                                End If
                                columna = columna + 1
                            Next
                        End If
                    End If
                    DataGridActividades(columna, fila).Value = a.META
                    columna = columna + 1
                    DataGridActividades(columna, fila).Value = a.ACEPTABLE
                    columna = columna + 1
                    DataGridActividades(columna, fila).Value = a.RESPONSABLE
                    columna = columna + 1
                    DataGridActividades(columna, fila).Value = a.FINALIZA
                    columna = 0
                    fila = fila + 1

                Next
                DataGridObjEspecifico.Sort(DataGridObjEspecifico.Columns(0), System.ComponentModel.ListSortDirection.Ascending)

            End If
        End If
    End Sub

    Private Sub MantenimientoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MantenimientoToolStripMenuItem.Click
        Dim v As New FormDimension(Usuario)
        v.Show()
    End Sub


    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub DimensiónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub ObjetivosGeneralesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub NumericAno_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericAno.ValueChanged
        _anio = NumericAno.Value
        listardimension()
        listarobjgenerales()
        listarobjespecificos()
        'listaractividades()
        listarindicadores()
    End Sub

    Private Sub ObjetivosEspecíficosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ActividadesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub DataGridDimension_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridDimension.CellContentClick
        If DataGridDimension.Columns(e.ColumnIndex).Name = "Dimensiones" Then
            Dim row As DataGridViewRow = DataGridDimension.Rows(e.RowIndex)
            'Dim id As Long = 0
            'Dim d As New dDimension
            iddimension = row.Cells("Id").Value
            listarobjgralxdimension()
            listarobjespxdimension()
            listaractividadesxdimension()
        End If
    End Sub
    Private Sub listarobjgralxdimension()
        Dim og As New dObjGral
        Dim lista As New ArrayList
        lista = og.listarxdimension(iddimension)

        DataGridObjGral.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridObjGral.ColumnCount = 2
                DataGridObjGral.Columns(0).Name = "Id"
                DataGridObjGral.Columns(0).Width = 300
                DataGridObjGral.Columns(0).Visible = False
                DataGridObjGral.Columns(1).Name = "Objetivos generales"
                DataGridObjGral.Columns(1).Width = 300

                DataGridObjGral.Rows.Add(lista.Count)
                Dim d As New dDimension
                For Each og In lista
                    DataGridObjGral(columna, fila).Value = og.ID
                    columna = columna + 1
                    DataGridObjGral(columna, fila).Value = og.NOMBRE
                    columna = 0
                    fila = fila + 1
                Next
                DataGridObjGral.Sort(DataGridObjGral.Columns(0), System.ComponentModel.ListSortDirection.Ascending)

            End If
        End If
    End Sub
    Private Sub listarobjespxobjgral()
        Dim oe As New dObjEspecifico
        Dim lista As New ArrayList
        lista = oe.listarxobjgral(idobjgral)

        DataGridObjEspecifico.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridObjEspecifico.ColumnCount = 3
                DataGridObjEspecifico.Columns(0).Name = "Id"
                DataGridObjEspecifico.Columns(0).Width = 200
                DataGridObjEspecifico.Columns(0).Visible = False
                DataGridObjEspecifico.Columns(1).Name = "Objetivos específicos"
                DataGridObjEspecifico.Columns(1).Width = 300
                DataGridObjEspecifico.Columns(2).Name = "Objetivos generales"
                DataGridObjEspecifico.Columns(2).Width = 300
                DataGridObjEspecifico.Columns(2).Visible = False

                DataGridObjEspecifico.Rows.Add(lista.Count)
                Dim og As New dObjGral
                For Each oe In lista
                    DataGridObjEspecifico(columna, fila).Value = oe.ID
                    columna = columna + 1
                    DataGridObjEspecifico(columna, fila).Value = oe.NOMBRE
                    columna = columna + 1
                    og.ID = oe.IDOBJGRAL
                    og = og.buscar
                    If Not og Is Nothing Then
                        DataGridObjEspecifico(columna, fila).Value = og.NOMBRE
                        columna = 0
                    Else
                        DataGridObjGral(columna, fila).Value = ""
                        columna = 0
                    End If
                    fila = fila + 1
                Next
                DataGridObjGral.Sort(DataGridObjGral.Columns(0), System.ComponentModel.ListSortDirection.Ascending)

            End If
        End If
    End Sub
    Private Sub listarobjespxdimension()
        Dim oe As New dObjEspecifico
        Dim lista As New ArrayList
        lista = oe.listarxdimension(iddimension)

        DataGridObjEspecifico.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridObjEspecifico.ColumnCount = 3
                DataGridObjEspecifico.Columns(0).Name = "Id"
                DataGridObjEspecifico.Columns(0).Width = 200
                DataGridObjEspecifico.Columns(0).Visible = False
                DataGridObjEspecifico.Columns(1).Name = "Objetivos específicos"
                DataGridObjEspecifico.Columns(1).Width = 300
                DataGridObjEspecifico.Columns(2).Name = "Objetivos generales"
                DataGridObjEspecifico.Columns(2).Width = 300
                DataGridObjEspecifico.Columns(2).Visible = False

                DataGridObjEspecifico.Rows.Add(lista.Count)
                Dim og As New dObjGral
                For Each oe In lista
                    DataGridObjEspecifico(columna, fila).Value = oe.ID
                    columna = columna + 1
                    DataGridObjEspecifico(columna, fila).Value = oe.NOMBRE
                    columna = columna + 1
                    og.ID = oe.IDOBJGRAL
                    og = og.buscar
                    If Not og Is Nothing Then
                        DataGridObjEspecifico(columna, fila).Value = og.NOMBRE
                        columna = 0
                    Else
                        DataGridObjGral(columna, fila).Value = ""
                        columna = 0
                    End If
                    fila = fila + 1
                Next
                DataGridObjGral.Sort(DataGridObjGral.Columns(0), System.ComponentModel.ListSortDirection.Ascending)

            End If
        End If
    End Sub
    Private Sub listaractividadesxobjesp()
        Dim a As New dActividades
        Dim i As New dIndicadores
        Dim lista As New ArrayList
        Dim lista2 As New ArrayList
        lista = a.listarxobjesp(idobjesp)

        DataGridActividades.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridActividades.ColumnCount = 22
                DataGridActividades.Columns(0).Name = "Id"
                DataGridActividades.Columns(0).Width = 50
                DataGridActividades.Columns(0).Visible = False
                DataGridActividades.Columns(1).Name = "Dimensión"
                DataGridActividades.Columns(1).Width = 70
                DataGridActividades.Columns(2).Name = "Actividad"
                DataGridActividades.Columns(2).Width = 150
                DataGridActividades.Columns(3).Name = "Indicador"
                DataGridActividades.Columns(3).Width = 100
                DataGridActividades.Columns(4).Name = "Año"
                DataGridActividades.Columns(4).Width = 50
                DataGridActividades.Columns(4).Visible = False
                DataGridActividades.Columns(5).Name = "Objetivo específico"
                DataGridActividades.Columns(5).Width = 200
                DataGridActividades.Columns(6).Name = "IdIndicador"
                DataGridActividades.Columns(6).Width = 250
                DataGridActividades.Columns(6).Visible = False
                DataGridActividades.Columns(7).Name = "Ene"
                DataGridActividades.Columns(7).Width = 30
                DataGridActividades.Columns(8).Name = "Feb"
                DataGridActividades.Columns(8).Width = 30
                DataGridActividades.Columns(9).Name = "Mar"
                DataGridActividades.Columns(9).Width = 30
                DataGridActividades.Columns(10).Name = "Abr"
                DataGridActividades.Columns(10).Width = 30
                DataGridActividades.Columns(11).Name = "May"
                DataGridActividades.Columns(11).Width = 30
                DataGridActividades.Columns(12).Name = "Jun"
                DataGridActividades.Columns(12).Width = 30
                DataGridActividades.Columns(13).Name = "Jul"
                DataGridActividades.Columns(13).Width = 30
                DataGridActividades.Columns(14).Name = "Ago"
                DataGridActividades.Columns(14).Width = 30
                DataGridActividades.Columns(15).Name = "Set"
                DataGridActividades.Columns(15).Width = 30
                DataGridActividades.Columns(16).Name = "Oct"
                DataGridActividades.Columns(16).Width = 30
                DataGridActividades.Columns(17).Name = "Nov"
                DataGridActividades.Columns(17).Width = 30
                DataGridActividades.Columns(18).Name = "Dic"
                DataGridActividades.Columns(18).Width = 30
                DataGridActividades.Columns(19).Name = "Meta"
                DataGridActividades.Columns(19).Width = 50
                DataGridActividades.Columns(20).Name = "Acep."
                DataGridActividades.Columns(20).Width = 50
                DataGridActividades.Columns(21).Name = "Responsable"
                DataGridActividades.Columns(21).Width = 70
                DataGridActividades.Rows.Add(lista.Count)


                Dim oe As New dObjEspecifico

                For Each a In lista
                    DataGridActividades(columna, fila).Value = a.ID
                    columna = columna + 1
                    Dim dimen As New dDimension
                    dimen.ID = a.IDDIMENSION
                    dimen = dimen.buscar
                    If Not dimen Is Nothing Then
                        DataGridActividades(columna, fila).Value = dimen.NOMBRE
                        columna = columna + 1
                    End If
                    DataGridActividades(columna, fila).Value = a.NOMBRE
                    columna = columna + 1
                    DataGridActividades(columna, fila).Value = a.INDICADOR
                    columna = columna + 1
                    DataGridActividades(columna, fila).Value = a.ANO
                    columna = columna + 1
                    oe.ID = a.IDOBJESPECIFICO
                    oe = oe.buscar
                    If Not oe Is Nothing Then
                        DataGridActividades(columna, fila).Value = oe.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridActividades(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    Dim idact As Long = 0
                    idact = a.ID
                    lista2 = i.listarxactividad(idact)
                    If Not lista2 Is Nothing Then
                        If lista2.Count > 0 Then
                            DataGridActividades(columna, fila).Value = i.ID
                            columna = columna + 1
                            For Each i In lista2

                                DataGridActividades(columna, fila).Value = i.INDICADOR
                                If i.INDICADOR < a.ACEPTABLE Then
                                    DataGridActividades(columna, fila).Style.BackColor = Color.Red
                                ElseIf i.INDICADOR >= a.ACEPTABLE And i.INDICADOR < a.META Then
                                    DataGridActividades(columna, fila).Style.BackColor = Color.Yellow
                                ElseIf i.INDICADOR >= a.META Then
                                    DataGridActividades(columna, fila).Style.BackColor = Color.Green
                                End If
                                columna = columna + 1
                            Next
                        End If
                    End If
                    DataGridActividades(columna, fila).Value = a.META
                    columna = columna + 1
                    DataGridActividades(columna, fila).Value = a.ACEPTABLE
                    columna = columna + 1
                    DataGridActividades(columna, fila).Value = a.RESPONSABLE
                    columna = 0
                    fila = fila + 1

                Next
                DataGridObjEspecifico.Sort(DataGridObjEspecifico.Columns(0), System.ComponentModel.ListSortDirection.Ascending)

            End If
        End If
    End Sub
    Private Sub listaractividadesxdimension()
        Dim a As New dActividades
        Dim i As New dIndicadores
        Dim lista As New ArrayList
        Dim lista2 As New ArrayList
        lista = a.listarxdimension(iddimension)

        DataGridActividades.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridActividades.ColumnCount = 22
                DataGridActividades.Columns(0).Name = "Id"
                DataGridActividades.Columns(0).Width = 50
                DataGridActividades.Columns(0).Visible = False
                DataGridActividades.Columns(1).Name = "Dimensión"
                DataGridActividades.Columns(1).Width = 70
                DataGridActividades.Columns(2).Name = "Actividad"
                DataGridActividades.Columns(2).Width = 150
                DataGridActividades.Columns(3).Name = "Indicador"
                DataGridActividades.Columns(3).Width = 100
                DataGridActividades.Columns(4).Name = "Año"
                DataGridActividades.Columns(4).Width = 50
                DataGridActividades.Columns(4).Visible = False
                DataGridActividades.Columns(5).Name = "Objetivo específico"
                DataGridActividades.Columns(5).Width = 200
                DataGridActividades.Columns(6).Name = "IdIndicador"
                DataGridActividades.Columns(6).Width = 250
                DataGridActividades.Columns(6).Visible = False
                DataGridActividades.Columns(7).Name = "Ene"
                DataGridActividades.Columns(7).Width = 30
                DataGridActividades.Columns(8).Name = "Feb"
                DataGridActividades.Columns(8).Width = 30
                DataGridActividades.Columns(9).Name = "Mar"
                DataGridActividades.Columns(9).Width = 30
                DataGridActividades.Columns(10).Name = "Abr"
                DataGridActividades.Columns(10).Width = 30
                DataGridActividades.Columns(11).Name = "May"
                DataGridActividades.Columns(11).Width = 30
                DataGridActividades.Columns(12).Name = "Jun"
                DataGridActividades.Columns(12).Width = 30
                DataGridActividades.Columns(13).Name = "Jul"
                DataGridActividades.Columns(13).Width = 30
                DataGridActividades.Columns(14).Name = "Ago"
                DataGridActividades.Columns(14).Width = 30
                DataGridActividades.Columns(15).Name = "Set"
                DataGridActividades.Columns(15).Width = 30
                DataGridActividades.Columns(16).Name = "Oct"
                DataGridActividades.Columns(16).Width = 30
                DataGridActividades.Columns(17).Name = "Nov"
                DataGridActividades.Columns(17).Width = 30
                DataGridActividades.Columns(18).Name = "Dic"
                DataGridActividades.Columns(18).Width = 30
                DataGridActividades.Columns(19).Name = "Meta"
                DataGridActividades.Columns(19).Width = 50
                DataGridActividades.Columns(20).Name = "Acep."
                DataGridActividades.Columns(20).Width = 50
                DataGridActividades.Columns(21).Name = "Responsable"
                DataGridActividades.Columns(21).Width = 70
                DataGridActividades.Rows.Add(lista.Count)

                Dim oe As New dObjEspecifico

                For Each a In lista
                    DataGridActividades(columna, fila).Value = a.ID
                    columna = columna + 1
                    Dim dimen As New dDimension
                    dimen.ID = a.IDDIMENSION
                    dimen = dimen.buscar
                    If Not dimen Is Nothing Then
                        DataGridActividades(columna, fila).Value = dimen.NOMBRE
                        columna = columna + 1
                    End If
                    DataGridActividades(columna, fila).Value = a.NOMBRE
                    columna = columna + 1
                    DataGridActividades(columna, fila).Value = a.INDICADOR
                    columna = columna + 1
                    DataGridActividades(columna, fila).Value = a.ANO
                    columna = columna + 1
                    oe.ID = a.IDOBJESPECIFICO
                    oe = oe.buscar
                    If Not oe Is Nothing Then
                        DataGridActividades(columna, fila).Value = oe.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridActividades(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    Dim idact As Long = 0
                    idact = a.ID
                    lista2 = i.listarxactividad(idact)
                    If Not lista2 Is Nothing Then
                        If lista2.Count > 0 Then
                            DataGridActividades(columna, fila).Value = i.ID
                            columna = columna + 1
                            For Each i In lista2

                                DataGridActividades(columna, fila).Value = i.INDICADOR
                                If i.INDICADOR < a.ACEPTABLE Then
                                    DataGridActividades(columna, fila).Style.BackColor = Color.Red
                                ElseIf i.INDICADOR >= a.ACEPTABLE And i.INDICADOR < a.META Then
                                    DataGridActividades(columna, fila).Style.BackColor = Color.Yellow
                                ElseIf i.INDICADOR >= a.META Then
                                    DataGridActividades(columna, fila).Style.BackColor = Color.Green
                                End If
                                columna = columna + 1
                            Next
                        End If
                    End If
                    DataGridActividades(columna, fila).Value = a.META
                    columna = columna + 1
                    DataGridActividades(columna, fila).Value = a.ACEPTABLE
                    columna = columna + 1
                    DataGridActividades(columna, fila).Value = a.RESPONSABLE
                    columna = 0
                    fila = fila + 1

                Next
                DataGridObjEspecifico.Sort(DataGridObjEspecifico.Columns(0), System.ComponentModel.ListSortDirection.Ascending)

            End If
        End If
    End Sub
    Private Sub DataGridObjGral_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridObjGral.CellContentClick
        If DataGridObjGral.Columns(e.ColumnIndex).Name = "Objetivos generales" Then
            Dim row As DataGridViewRow = DataGridObjGral.Rows(e.RowIndex)
            'Dim id As Long = 0
            'Dim d As New dDimension
            idobjgral = row.Cells("Id").Value
            listarobjespxobjgral()
        End If
    End Sub

    Private Sub ButtonMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonMostrar.Click
        listardimension()
        listarobjgenerales()
        listarobjespecificos()
        'listaractividades()
        listarindicadores()
    End Sub

    Private Sub DataGridObjEspecifico_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridObjEspecifico.CellContentClick
        If DataGridObjEspecifico.Columns(e.ColumnIndex).Name = "Objetivos específicos" Then
            Dim row As DataGridViewRow = DataGridObjEspecifico.Rows(e.RowIndex)
            'Dim id As Long = 0
            'Dim d As New dDimension
            idobjesp = row.Cells("Id").Value
            listaractividadesxobjesp()
        End If
    End Sub

    Private Sub DataGridActividades_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridActividades.CellValueChanged

        If DataGridActividades.Columns(e.ColumnIndex).Name = "Actividad" Then
            Dim row As DataGridViewRow = DataGridActividades.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim valor As String = ""
            Dim a As New dActividades
            id = row.Cells("Id").Value
            valor = row.Cells("Actividad").Value
            a.ID = id
            a.NOMBRE = valor
            a.modificaractividad(Usuario)
        End If
        If DataGridActividades.Columns(e.ColumnIndex).Name = "Indicador" Then
            Dim row As DataGridViewRow = DataGridActividades.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim valor As String = ""
            Dim a As New dActividades
            id = row.Cells("Id").Value
            valor = row.Cells("Indicador").Value
            a.ID = id
            a.INDICADOR = valor
            a.modificarindicador(Usuario)
        End If
        If DataGridActividades.Columns(e.ColumnIndex).Name = "Responsable" Then
            Dim row As DataGridViewRow = DataGridActividades.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim valor As String = ""
            Dim a As New dActividades
            id = row.Cells("Id").Value
            valor = row.Cells("Responsable").Value
            a.ID = id
            a.RESPONSABLE = valor
            a.modificarresponsable(Usuario)
        End If
        If DataGridActividades.Columns(e.ColumnIndex).Name = "Acep." Then
            Dim row As DataGridViewRow = DataGridActividades.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim valor As Integer = 0
            Dim a As New dActividades
            id = row.Cells("Id").Value
            valor = row.Cells("Acep.").Value
            a.ID = id
            a.ACEPTABLE = valor
            a.modificaraceptable(Usuario)
        End If
        If DataGridActividades.Columns(e.ColumnIndex).Name = "Meta" Then
            Dim row As DataGridViewRow = DataGridActividades.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim valor As Integer = 0
            Dim a As New dActividades
            id = row.Cells("Id").Value
            valor = row.Cells("Meta").Value
            a.ID = id
            a.META = valor
            a.modificarmeta(Usuario)
        End If
        If DataGridActividades.Columns(e.ColumnIndex).Name = "Ene" Then
            Dim row As DataGridViewRow = DataGridActividades.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim valor As Integer = 0
            Dim i As New dIndicadores
            id = row.Cells("Id").Value
            valor = row.Cells("Ene").Value
            For x = 1 To 12
                i.IDACTIVIDAD = id
                i.MES = x
                i.INDICADOR = valor
                i.modificar2(Usuario)
            Next x
            'listaractividadesxobjesp()
        End If
        If DataGridActividades.Columns(e.ColumnIndex).Name = "Feb" Then
            Dim row As DataGridViewRow = DataGridActividades.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim valor As Integer = 0
            Dim i As New dIndicadores
            id = row.Cells("Id").Value
            valor = row.Cells("Feb").Value
            For x = 2 To 12
                i.IDACTIVIDAD = id
                i.MES = x
                i.INDICADOR = valor
                i.modificar2(Usuario)
            Next x
            'listaractividadesxobjesp()
        End If
        If DataGridActividades.Columns(e.ColumnIndex).Name = "Mar" Then
            Dim row As DataGridViewRow = DataGridActividades.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim valor As Integer = 0
            Dim i As New dIndicadores
            id = row.Cells("Id").Value
            valor = row.Cells("Mar").Value
            For x = 3 To 12
                i.IDACTIVIDAD = id
                i.MES = x
                i.INDICADOR = valor
                i.modificar2(Usuario)
            Next x
            'listaractividadesxobjesp()
        End If
        If DataGridActividades.Columns(e.ColumnIndex).Name = "Abr" Then
            Dim row As DataGridViewRow = DataGridActividades.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim valor As Integer = 0
            Dim i As New dIndicadores
            id = row.Cells("Id").Value
            valor = row.Cells("Abr").Value
            For x = 4 To 12
                i.IDACTIVIDAD = id
                i.MES = x
                i.INDICADOR = valor
                i.modificar2(Usuario)
            Next x
            'listaractividadesxobjesp()
        End If
        If DataGridActividades.Columns(e.ColumnIndex).Name = "May" Then
            Dim row As DataGridViewRow = DataGridActividades.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim valor As Integer = 0
            Dim i As New dIndicadores
            id = row.Cells("Id").Value
            valor = row.Cells("May").Value
            For x = 5 To 12
                i.IDACTIVIDAD = id
                i.MES = x
                i.INDICADOR = valor
                i.modificar2(Usuario)
            Next x
            'listaractividadesxobjesp()
        End If
        If DataGridActividades.Columns(e.ColumnIndex).Name = "Jun" Then
            Dim row As DataGridViewRow = DataGridActividades.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim valor As Integer = 0
            Dim i As New dIndicadores
            id = row.Cells("Id").Value
            valor = row.Cells("Jun").Value
            For x = 6 To 12
                i.IDACTIVIDAD = id
                i.MES = x
                i.INDICADOR = valor
                i.modificar2(Usuario)
            Next x
            'listaractividadesxobjesp()
        End If
        If DataGridActividades.Columns(e.ColumnIndex).Name = "Jul" Then
            Dim row As DataGridViewRow = DataGridActividades.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim valor As Integer = 0
            Dim i As New dIndicadores
            id = row.Cells("Id").Value
            valor = row.Cells("Jul").Value
            For x = 7 To 12
                i.IDACTIVIDAD = id
                i.MES = x
                i.INDICADOR = valor
                i.modificar2(Usuario)
            Next x
            'listaractividadesxobjesp()
        End If
        If DataGridActividades.Columns(e.ColumnIndex).Name = "Ago" Then
            Dim row As DataGridViewRow = DataGridActividades.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim valor As Integer = 0
            Dim i As New dIndicadores
            id = row.Cells("Id").Value
            valor = row.Cells("Ago").Value
            For x = 8 To 12
                i.IDACTIVIDAD = id
                i.MES = x
                i.INDICADOR = valor
                i.modificar2(Usuario)
            Next x
            'listaractividadesxobjesp()
        End If
        If DataGridActividades.Columns(e.ColumnIndex).Name = "Set" Then
            Dim row As DataGridViewRow = DataGridActividades.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim valor As Integer = 0
            Dim i As New dIndicadores
            id = row.Cells("Id").Value
            valor = row.Cells("Set").Value
            For x = 9 To 12
                i.IDACTIVIDAD = id
                i.MES = x
                i.INDICADOR = valor
                i.modificar2(Usuario)
            Next x
            'listaractividadesxobjesp()
        End If
        If DataGridActividades.Columns(e.ColumnIndex).Name = "Oct" Then
            Dim row As DataGridViewRow = DataGridActividades.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim valor As Integer = 0
            Dim i As New dIndicadores
            id = row.Cells("Id").Value
            valor = row.Cells("Oct").Value
            For x = 10 To 12
                i.IDACTIVIDAD = id
                i.MES = x
                i.INDICADOR = valor
                i.modificar2(Usuario)
            Next x
            'listaractividadesxobjesp()
        End If
        If DataGridActividades.Columns(e.ColumnIndex).Name = "Nov" Then
            Dim row As DataGridViewRow = DataGridActividades.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim valor As Integer = 0
            Dim i As New dIndicadores
            id = row.Cells("Id").Value
            valor = row.Cells("Nov").Value
            For x = 11 To 12
                i.IDACTIVIDAD = id
                i.MES = x
                i.INDICADOR = valor
                i.modificar2(Usuario)
            Next x
            'listaractividadesxobjesp()
        End If
        If DataGridActividades.Columns(e.ColumnIndex).Name = "Dic" Then
            Dim row As DataGridViewRow = DataGridActividades.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim valor As Integer = 0
            Dim i As New dIndicadores
            id = row.Cells("Id").Value
            valor = row.Cells("Dic").Value
            For x = 12 To 12
                i.IDACTIVIDAD = id
                i.MES = x
                i.INDICADOR = valor
                i.modificar2(Usuario)
            Next x
            'listaractividadesxobjesp()
        End If
    End Sub

    Private Sub ObjetivosGeneralesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ObjetivosGeneralesToolStripMenuItem1.Click
        Dim v As New FormObjGral(Usuario)
        v.Show()
    End Sub

    Private Sub ObjetivosEspecíficosToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ObjetivosEspecíficosToolStripMenuItem1.Click
        Dim v As New FormObjEspecifico(Usuario)
        v.Show()
    End Sub

    Private Sub ActividadesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActividadesToolStripMenuItem1.Click
        Dim v As New FormActividades(Usuario)
        v.Show()
    End Sub

    Private Sub DataGridActividades_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridActividades.CellContentClick

    End Sub

    Private Sub ExportarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportarToolStripMenuItem.Click
        Dim v As New FormExportar
        v.ShowDialog()
    End Sub
End Class