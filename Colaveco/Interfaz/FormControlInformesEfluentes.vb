Imports System.IO
Public Class FormControlInformesEfluentes
    Public check_resultado As Integer = 0
    Public check_coincide As Integer = 0
    Public check_om As Integer = 0
    Public check_nc As Integer = 0
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
        listarinformesefluentes()
    End Sub
#End Region
    Private Sub listarinformesefluentes()
        Dim ciefluentes As New dControlInformesEfluentes
        Dim lista As New ArrayList
        lista = ciefluentes.listar
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each ciefluentes In lista
                    Dim m As New dMuestras
                    Dim ti As New dTipoInforme
                    Dim si As New dSubInforme
                    Dim s As New dSinaveleFicha
                    DataGridView1(columna, fila).Value = ciefluentes.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ciefluentes.FECHACONTROL
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ciefluentes.FICHA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ciefluentes.FECHA
                    columna = columna + 1
                    ti.ID = ciefluentes.TIPO
                    ti = ti.buscar
                    DataGridView1(columna, fila).Value = ti.NOMBRE
                    columna = columna + 1
                    If ciefluentes.RESULTADO = 0 Then
                        DataGridView1(columna, fila).Value = False
                    Else
                        DataGridView1(columna, fila).Value = True
                    End If
                    columna = columna + 1
                    If ciefluentes.COINCIDE = 0 Then
                        DataGridView1(columna, fila).Value = False
                    Else
                        DataGridView1(columna, fila).Value = True
                    End If
                    columna = columna + 1
                    If ciefluentes.OM = 0 Then
                        DataGridView1(columna, fila).Value = False
                    Else
                        DataGridView1(columna, fila).Value = True
                    End If
                    columna = columna + 1
                    If ciefluentes.NC = 0 Then
                        DataGridView1(columna, fila).Value = False
                    Else
                        DataGridView1(columna, fila).Value = True
                    End If
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ciefluentes.OBSERVACIONES
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = Usuario.NOMBRE
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = "Ver informe"
                    columna = columna + 1
                    If ciefluentes.CONTROLADO = 0 Then
                        DataGridView1(columna, fila).Value = False
                    Else
                        DataGridView1(columna, fila).Value = True
                    End If
                    columna = 0
                    fila = fila + 1
                Next
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.ColumnIndex = DataGridView1.Columns(5).Index Then
            check_resultado = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            If check_resultado = 0 Then
                DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = True
            Else
                DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = False
            End If
        End If
        If e.ColumnIndex = DataGridView1.Columns(6).Index Then
            check_coincide = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            If check_coincide = 0 Then
                DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = True
            Else
                DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = False
            End If
        End If
        If e.ColumnIndex = DataGridView1.Columns(7).Index Then
            check_om = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            If check_om = 0 Then
                DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = True
            Else
                DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = False
            End If
        End If
        If e.ColumnIndex = DataGridView1.Columns(8).Index Then
            check_nc = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            If check_nc = 0 Then
                DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = True
            Else
                DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = False
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim Arch1 As String, Arch2 As String, Arch3 As String, Arch5 As String
        If DataGridView1.Columns(e.ColumnIndex).Name = "Resultado" Then
            If check_resultado = 0 Then
                Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
                Dim id As Long = 0
                Dim ci As New dControlInformesEfluentes
                id = row.Cells("Id").Value
                ci.ID = id
                ci.marcarresultado(Usuario)
                listarinformesefluentes()
            Else
                Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
                Dim id As Long = 0
                Dim ci As New dControlInformesEfluentes
                id = row.Cells("Id").Value
                ci.ID = id
                ci.desmarcarresultado(Usuario)
                listarinformesefluentes()
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Coincide" Then
            If check_coincide = 0 Then
                Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
                Dim id As Long = 0
                Dim ci As New dControlInformesEfluentes
                id = row.Cells("Id").Value
                ci.ID = id
                ci.marcarcoincide(Usuario)
                listarinformesefluentes()
            Else
                Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
                Dim id As Long = 0
                Dim ci As New dControlInformesEfluentes
                id = row.Cells("Id").Value
                ci.ID = id
                ci.desmarcarcoincide(Usuario)
                listarinformesefluentes()
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "OM" Then
            If check_om = 0 Then
                Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
                Dim id As Long = 0
                Dim ci As New dControlInformesEfluentes
                id = row.Cells("Id").Value
                ci.ID = id
                ci.marcarom(Usuario)
                listarinformesefluentes()
            Else
                Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
                Dim id As Long = 0
                Dim ci As New dControlInformesEfluentes
                id = row.Cells("Id").Value
                ci.ID = id
                ci.desmarcarom(Usuario)
                listarinformesefluentes()
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "NC" Then
            If check_nc = 0 Then
                Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
                Dim id As Long = 0
                Dim ci As New dControlInformesEfluentes
                id = row.Cells("Id").Value
                ci.ID = id
                ci.marcarnc(Usuario)
                listarinformesefluentes()
            Else
                Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
                Dim id As Long = 0
                Dim ci As New dControlInformesEfluentes
                id = row.Cells("Id").Value
                ci.ID = id
                ci.desmarcarnc(Usuario)
                listarinformesefluentes()
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Controlada" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim observaciones As String = ""
            Dim ci As New dControlInformesEfluentes
            id = row.Cells("Id").Value
            observaciones = row.Cells("Observaciones").Value
            ci.ID = id
            ci.marcarcontrolada(Usuario)
            ci.guardarobservaciones(Usuario, observaciones)
            listarinformesefluentes()
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "VerInforme" Then
            Dim sa1 As New dSolicitudAnalisis
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim ficha As Long = 0

            Dim ci As New dControlInformesEfluentes
            id = row.Cells("Id").Value
            ficha = row.Cells("Ficha").Value
            ci.ID = id
            ci = ci.buscar
            sa1.ID = ficha
            sa1 = sa1.buscar
            If Not sa1 Is Nothing Then
                If sa1.ELIMINADO = 1 Then
                    MsgBox("Esta solicitud fué eliminada!")
                End If
            End If
            If Not ci Is Nothing Then
                If ci.TIPO = 1 Then
                    Arch1 = "\\192.168.1.10\E\NET\SOLICITUDES\S" & ficha & ".xls"
                    Arch2 = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xls"
                    Arch3 = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".pdf"
                    If File.Exists(Arch1) Then
                        System.Diagnostics.Process.Start(Arch1)
                    End If
                    If File.Exists(Arch2) Then
                        System.Diagnostics.Process.Start(Arch2)
                    ElseIf File.Exists(Arch3) Then
                        System.Diagnostics.Process.Start(Arch3)
                    End If
                ElseIf ci.TIPO = 3 Then
                    Arch1 = "\\192.168.1.10\E\NET\SOLICITUDES\S" & ficha & ".xls"
                    Arch2 = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xls"
                    Arch3 = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".pdf"
                    If File.Exists(Arch1) Then
                        System.Diagnostics.Process.Start(Arch1)
                    End If
                    If File.Exists(Arch2) Then
                        System.Diagnostics.Process.Start(Arch2)
                    ElseIf File.Exists(Arch3) Then
                        System.Diagnostics.Process.Start(Arch3)
                    End If
                ElseIf ci.TIPO = 4 Then
                    Arch1 = "\\192.168.1.10\E\NET\SOLICITUDES\S" & ficha & ".xls"
                    Arch2 = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xls"
                    Arch3 = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".pdf"
                    If File.Exists(Arch1) Then
                        System.Diagnostics.Process.Start(Arch1)
                    End If
                    If File.Exists(Arch2) Then
                        System.Diagnostics.Process.Start(Arch2)
                    ElseIf File.Exists(Arch3) Then
                        System.Diagnostics.Process.Start(Arch3)
                    End If

                ElseIf ci.TIPO = 7 Then
                    Arch1 = "\\192.168.1.10\E\NET\SOLICITUDES\S" & ficha & ".xls"
                    Arch2 = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xls"
                    Arch3 = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".pdf"
                    If File.Exists(Arch1) Then
                        System.Diagnostics.Process.Start(Arch1)
                    End If
                    If File.Exists(Arch2) Then
                        System.Diagnostics.Process.Start(Arch2)
                    ElseIf File.Exists(Arch3) Then
                        System.Diagnostics.Process.Start(Arch3)
                    End If
                ElseIf ci.TIPO = 10 Then
                    Arch1 = "\\192.168.1.10\E\NET\SOLICITUDES\S" & ficha & ".xls"
                    Arch2 = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xls"
                    Arch3 = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".pdf"
                    If File.Exists(Arch1) Then
                        System.Diagnostics.Process.Start(Arch1)
                    End If
                    If File.Exists(Arch2) Then
                        System.Diagnostics.Process.Start(Arch2)
                    ElseIf File.Exists(Arch3) Then
                        System.Diagnostics.Process.Start(Arch3)
                    End If
                ElseIf ci.TIPO = 13 Then
                    Arch1 = "\\192.168.1.10\E\NET\SOLICITUDES\S" & ficha & ".xls"
                    Arch2 = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xls"
                    Arch3 = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".pdf"
                    Arch5 = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xlsx"
                    If File.Exists(Arch1) Then
                        System.Diagnostics.Process.Start(Arch1)
                    End If
                    If File.Exists(Arch2) Then
                        System.Diagnostics.Process.Start(Arch2)
                    ElseIf File.Exists(Arch3) Then
                        System.Diagnostics.Process.Start(Arch3)
                    ElseIf File.Exists(Arch5) Then
                        System.Diagnostics.Process.Start(Arch5)
                    End If
                ElseIf ci.TIPO = 14 Then
                    Arch1 = "\\192.168.1.10\E\NET\SOLICITUDES\S" & ficha & ".xls"
                    Arch2 = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xls"
                    Arch3 = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".pdf"
                    Arch5 = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xlsx"
                    If File.Exists(Arch1) Then
                        System.Diagnostics.Process.Start(Arch1)
                    End If
                    If File.Exists(Arch2) Then
                        System.Diagnostics.Process.Start(Arch2)
                    ElseIf File.Exists(Arch3) Then
                        System.Diagnostics.Process.Start(Arch3)
                    ElseIf File.Exists(Arch5) Then
                        System.Diagnostics.Process.Start(Arch5)
                    End If
                ElseIf ci.TIPO = 15 Then
                    Arch1 = "\\192.168.1.10\E\NET\SOLICITUDES\S" & ficha & ".xls"
                    Arch2 = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xls"
                    Arch3 = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".pdf"
                    Arch5 = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xlsx"
                    If File.Exists(Arch1) Then
                        System.Diagnostics.Process.Start(Arch1)
                    End If
                    If File.Exists(Arch2) Then
                        System.Diagnostics.Process.Start(Arch2)
                    ElseIf File.Exists(Arch3) Then
                        System.Diagnostics.Process.Start(Arch3)
                    ElseIf File.Exists(Arch5) Then
                        System.Diagnostics.Process.Start(Arch5)
                    End If
                ElseIf ci.TIPO = 16 Then
                    Arch1 = "\\192.168.1.10\E\NET\SOLICITUDES\S" & ficha & ".xls"
                    Arch2 = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xls"
                    Arch3 = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".pdf"
                    Arch5 = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xlsx"
                    If File.Exists(Arch1) Then
                        System.Diagnostics.Process.Start(Arch1)
                    End If
                    If File.Exists(Arch2) Then
                        System.Diagnostics.Process.Start(Arch2)
                    ElseIf File.Exists(Arch3) Then
                        System.Diagnostics.Process.Start(Arch3)
                    ElseIf File.Exists(Arch5) Then
                        System.Diagnostics.Process.Start(Arch5)
                    End If
                ElseIf ci.TIPO = 17 Then
                    Arch1 = "\\192.168.1.10\E\NET\SOLICITUDES\S" & ficha & ".xls"
                    Arch2 = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xls"
                    Arch3 = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".pdf"
                    Arch5 = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xlsx"
                    If File.Exists(Arch1) Then
                        System.Diagnostics.Process.Start(Arch1)
                    End If
                    If File.Exists(Arch2) Then
                        System.Diagnostics.Process.Start(Arch2)
                    ElseIf File.Exists(Arch3) Then
                        System.Diagnostics.Process.Start(Arch3)
                    ElseIf File.Exists(Arch5) Then
                        System.Diagnostics.Process.Start(Arch5)
                    End If
                ElseIf ci.TIPO = 18 Then
                    Arch1 = "\\192.168.1.10\E\NET\SOLICITUDES\S" & ficha & ".xls"
                    Arch2 = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xls"
                    Arch3 = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".pdf"
                    Arch5 = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xlsx"
                    If File.Exists(Arch1) Then
                        System.Diagnostics.Process.Start(Arch1)
                    End If
                    If File.Exists(Arch2) Then
                        System.Diagnostics.Process.Start(Arch2)
                    ElseIf File.Exists(Arch3) Then
                        System.Diagnostics.Process.Start(Arch3)
                    ElseIf File.Exists(Arch5) Then
                        System.Diagnostics.Process.Start(Arch5)
                    End If
                ElseIf ci.TIPO = 19 Then
                    Arch1 = "\\192.168.1.10\E\NET\SOLICITUDES\S" & ficha & ".xls"
                    Arch2 = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xls"
                    Arch3 = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".pdf"
                    Arch5 = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xlsx"
                    If File.Exists(Arch1) Then
                        System.Diagnostics.Process.Start(Arch1)
                    End If
                    If File.Exists(Arch2) Then
                        System.Diagnostics.Process.Start(Arch2)
                    ElseIf File.Exists(Arch3) Then
                        System.Diagnostics.Process.Start(Arch3)
                    ElseIf File.Exists(Arch5) Then
                        System.Diagnostics.Process.Start(Arch5)
                    End If
                ElseIf ci.TIPO = 20 Then
                    Arch1 = "\\192.168.1.10\E\NET\SOLICITUDES\S" & ficha & ".xls"
                    Arch2 = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xls"
                    Arch3 = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".pdf"
                    Arch5 = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xlsx"
                    If File.Exists(Arch1) Then
                        System.Diagnostics.Process.Start(Arch1)
                    End If
                    If File.Exists(Arch2) Then
                        System.Diagnostics.Process.Start(Arch2)
                    ElseIf File.Exists(Arch3) Then
                        System.Diagnostics.Process.Start(Arch3)
                    ElseIf File.Exists(Arch5) Then
                        System.Diagnostics.Process.Start(Arch5)
                    End If
                End If
            End If
        End If
    End Sub
End Class