Public Class FormCargarPedidosAutomaticos
    Private _usuario As dUsuario
    Private _anio As Integer
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

    End Sub
#End Region
    Private Sub calcularano()
        Dim hoy As Date = Now
        Dim ano As Integer = 0
        ano = hoy.Year
        _anio = hoy.Year
        NumericAno.Value = ano
    End Sub

    Private Sub ButtonCargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCargar.Click
        Dim mes As String = ""
        Dim anio As String = ""
        Dim dia As String = ""
        anio = NumericAno.Value
        If ComboMes.Text <> "" Then
            If ComboMes.Text = "ENERO" Then
                mes = "01"
            ElseIf ComboMes.Text = "FEBRERO" Then
                mes = "02"
            ElseIf ComboMes.Text = "MARZO" Then
                mes = "03"
            ElseIf ComboMes.Text = "ABRIL" Then
                mes = "04"
            ElseIf ComboMes.Text = "MAYO" Then
                mes = "05"
            ElseIf ComboMes.Text = "JUNIO" Then
                mes = "06"
            ElseIf ComboMes.Text = "JULIO" Then
                mes = "07"
            ElseIf ComboMes.Text = "AGOSTO" Then
                mes = "08"
            ElseIf ComboMes.Text = "SETIEMBRE" Then
                mes = "09"
            ElseIf ComboMes.Text = "OCTUBRE" Then
                mes = "10"
            ElseIf ComboMes.Text = "NOVIEMBRE" Then
                mes = "11"
            ElseIf ComboMes.Text = "DICIEMBRE" Then
                mes = "12"
            End If
            Dim pa As New dPedidosAuto
            Dim listapa As New ArrayList
            listapa = pa.listarsinmarcar
            If Not listapa Is Nothing Then
                Dim p As New dPedidos
                Dim fec As String = ""
                For Each pa In listapa
                    dia = pa.DIA
                    fec = anio & "-" & mes & "-" & dia
                    p.FECHA = fec
                    p.FECHAPOSENVIO = fec
                    p.IDPRODUCTOR = pa.IDPRODUCTOR
                    p.DIRECCION = pa.DIRECCION
                    p.TELEFONO = pa.TELEFONO
                    p.IDAGENCIA = pa.IDAGENCIA
                    p.IDTECNICO = pa.IDTECNICO
                    p.RC_COMPOS = pa.RC_COMPOS
                    p.AGUA = pa.AGUA
                    p.SANGRE = pa.SANGRE
                    p.ESTERILES = pa.ESTERILES
                    p.OTROS = pa.OTROS
                    p.OBSERVACIONES = pa.OBSERVACIONES
                    p.FACTURA1 = pa.FACTURA
                    If (p.guardar(Usuario)) Then
                        pa.marcarEnvio(pa.ID, Usuario)
                    Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                    End If
                Next
            End If
        Else
            MsgBox("Debe seleccionar un mes para cargar!")
        End If
    End Sub
End Class