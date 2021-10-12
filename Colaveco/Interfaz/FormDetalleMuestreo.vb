Public Class FormDetalle_Muestreo
    Private _usuario As dUsuario
    Private _ficha As Long
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property

#Region "Constructores"
    Public Sub New(ByVal u As dUsuario, ByVal id_ficha As Long)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        'Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        limpiar()
        _ficha = id_ficha
        Dim dm As New dDetalleMuestreo
        dm.FICHA = id_ficha
        dm = dm.buscar
        If Not dm Is Nothing Then
            TextId.Text = dm.ID
            TextFicha.Text = dm.FICHA
            DateFecha.Value = dm.FECHA
            TextObservaciones.Text = dm.OBSERVACIONES
        Else
            TextFicha.Text = _ficha
            TextObservaciones.Text = "Muestreo realizado según DOC.ADM.35" & vbCrLf _
                & "Condiciones ambientales que pueden afectar la interpretación del resultado..."
        End If
    End Sub
#End Region
    Private Sub limpiar()
        TextId.Text = ""
        TextFicha.Text = ""
        DateFecha.Value = Now()
        TextFicha.Text = ""
        TextObservaciones.Text = ""
        TextObservaciones.Focus()
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click

        Dim ficha As Long
        If TextFicha.Text.Trim.Length > 0 Then
            ficha = TextFicha.Text.Trim
        Else
            ficha = 0
        End If
        Dim dm2 As New dDetalleMuestreo
        Dim fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        Dim observaciones As String = TextObservaciones.Text.Trim
        If TextId.Text.Trim.Length > 0 Then
            Dim id As Long = TextId.Text.Trim
            Dim dm As New dDetalleMuestreo
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")
            dm.ID = id
            dm.FICHA = ficha
            dm.FECHA = fec
            dm.OBSERVACIONES = observaciones
            If (dm.modificar(Usuario)) Then
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim dm As New dDetalleMuestreo
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")
            dm.FICHA = ficha
            dm.FECHA = fec
            dm.OBSERVACIONES = observaciones
            If (dm.guardar(Usuario)) Then
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        Me.Close()
    End Sub
End Class