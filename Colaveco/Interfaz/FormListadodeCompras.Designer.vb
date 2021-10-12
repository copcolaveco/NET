<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormListadodeCompras
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Proveedor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridView2 = New System.Windows.Forms.DataGridView
        Me.Id2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Proveedor2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Fecha2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.DataGridView3 = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Producto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Detalle = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PrecioAnt = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MonedaAnt = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FechaAnt = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Unidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Presentacion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Precio = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Moneda = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Subtotal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.TextProveedor = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TextResponsable = New System.Windows.Forms.TextBox
        Me.DateFecha = New System.Windows.Forms.DateTimePicker
        Me.TextIdCompra = New System.Windows.Forms.TextBox
        Me.TextObservaciones = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Proveedor, Me.Fecha})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 37)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(337, 393)
        Me.DataGridView1.TabIndex = 0
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Width = 50
        '
        'Proveedor
        '
        Me.Proveedor.HeaderText = "Proveedor"
        Me.Proveedor.Name = "Proveedor"
        Me.Proveedor.Width = 200
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Width = 80
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id2, Me.Proveedor2, Me.Fecha2})
        Me.DataGridView2.Location = New System.Drawing.Point(366, 37)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowHeadersVisible = False
        Me.DataGridView2.Size = New System.Drawing.Size(337, 393)
        Me.DataGridView2.TabIndex = 1
        '
        'Id2
        '
        Me.Id2.HeaderText = "Id"
        Me.Id2.Name = "Id2"
        Me.Id2.Width = 50
        '
        'Proveedor2
        '
        Me.Proveedor2.HeaderText = "Proveedor"
        Me.Proveedor2.Name = "Proveedor2"
        Me.Proveedor2.Width = 200
        '
        'Fecha2
        '
        Me.Fecha2.HeaderText = "Fecha"
        Me.Fecha2.Name = "Fecha2"
        Me.Fecha2.Width = 80
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Compras autorizadas"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(363, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Compras sin autorizar"
        '
        'DataGridView3
        '
        Me.DataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView3.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.Producto, Me.Detalle, Me.PrecioAnt, Me.MonedaAnt, Me.FechaAnt, Me.Cantidad, Me.Unidad, Me.Presentacion, Me.Precio, Me.Moneda, Me.Subtotal})
        Me.DataGridView3.Location = New System.Drawing.Point(12, 488)
        Me.DataGridView3.Name = "DataGridView3"
        Me.DataGridView3.RowHeadersVisible = False
        Me.DataGridView3.Size = New System.Drawing.Size(1059, 198)
        Me.DataGridView3.TabIndex = 32
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Id"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 50
        '
        'Producto
        '
        Me.Producto.HeaderText = "Producto"
        Me.Producto.Name = "Producto"
        Me.Producto.Width = 220
        '
        'Detalle
        '
        Me.Detalle.HeaderText = "Detalle"
        Me.Detalle.Name = "Detalle"
        Me.Detalle.Width = 220
        '
        'PrecioAnt
        '
        Me.PrecioAnt.HeaderText = "Precio anterior s/IVA"
        Me.PrecioAnt.Name = "PrecioAnt"
        Me.PrecioAnt.Width = 60
        '
        'MonedaAnt
        '
        Me.MonedaAnt.HeaderText = "Moneda"
        Me.MonedaAnt.Name = "MonedaAnt"
        Me.MonedaAnt.Width = 50
        '
        'FechaAnt
        '
        Me.FechaAnt.HeaderText = "Fecha últ. compra"
        Me.FechaAnt.Name = "FechaAnt"
        Me.FechaAnt.Width = 80
        '
        'Cantidad
        '
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.Width = 80
        '
        'Unidad
        '
        Me.Unidad.HeaderText = "Unidad"
        Me.Unidad.Name = "Unidad"
        Me.Unidad.Width = 50
        '
        'Presentacion
        '
        Me.Presentacion.HeaderText = "Presentación"
        Me.Presentacion.Name = "Presentacion"
        '
        'Precio
        '
        Me.Precio.HeaderText = "Precio actual s/IVA"
        Me.Precio.Name = "Precio"
        Me.Precio.Width = 80
        '
        'Moneda
        '
        Me.Moneda.HeaderText = "Moneda"
        Me.Moneda.Name = "Moneda"
        Me.Moneda.Width = 50
        '
        'Subtotal
        '
        Me.Subtotal.HeaderText = "Subtotal"
        Me.Subtotal.Name = "Subtotal"
        Me.Subtotal.Width = 60
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(199, 446)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(69, 13)
        Me.Label9.TabIndex = 39
        Me.Label9.Text = "Responsable"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(372, 446)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 13)
        Me.Label8.TabIndex = 38
        Me.Label8.Text = "Proveedor"
        '
        'TextProveedor
        '
        Me.TextProveedor.Location = New System.Drawing.Point(375, 462)
        Me.TextProveedor.Name = "TextProveedor"
        Me.TextProveedor.ReadOnly = True
        Me.TextProveedor.Size = New System.Drawing.Size(192, 20)
        Me.TextProveedor.TabIndex = 37
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(18, 446)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(16, 13)
        Me.Label7.TabIndex = 36
        Me.Label7.Text = "Id"
        '
        'TextResponsable
        '
        Me.TextResponsable.Location = New System.Drawing.Point(202, 462)
        Me.TextResponsable.Name = "TextResponsable"
        Me.TextResponsable.ReadOnly = True
        Me.TextResponsable.Size = New System.Drawing.Size(167, 20)
        Me.TextResponsable.TabIndex = 35
        '
        'DateFecha
        '
        Me.DateFecha.Enabled = False
        Me.DateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFecha.Location = New System.Drawing.Point(88, 462)
        Me.DateFecha.Name = "DateFecha"
        Me.DateFecha.Size = New System.Drawing.Size(108, 20)
        Me.DateFecha.TabIndex = 34
        '
        'TextIdCompra
        '
        Me.TextIdCompra.Enabled = False
        Me.TextIdCompra.Location = New System.Drawing.Point(12, 462)
        Me.TextIdCompra.Name = "TextIdCompra"
        Me.TextIdCompra.ReadOnly = True
        Me.TextIdCompra.Size = New System.Drawing.Size(60, 20)
        Me.TextIdCompra.TabIndex = 33
        '
        'TextObservaciones
        '
        Me.TextObservaciones.Location = New System.Drawing.Point(709, 37)
        Me.TextObservaciones.Multiline = True
        Me.TextObservaciones.Name = "TextObservaciones"
        Me.TextObservaciones.ReadOnly = True
        Me.TextObservaciones.Size = New System.Drawing.Size(300, 179)
        Me.TextObservaciones.TabIndex = 41
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(706, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "Observaciones"
        '
        'FormListadodeCompras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1078, 698)
        Me.Controls.Add(Me.TextObservaciones)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TextProveedor)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TextResponsable)
        Me.Controls.Add(Me.DateFecha)
        Me.Controls.Add(Me.TextIdCompra)
        Me.Controls.Add(Me.DataGridView3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "FormListadodeCompras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Listado de compras autorizadas / no autorizadas"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Proveedor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Id2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Proveedor2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridView3 As System.Windows.Forms.DataGridView
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextResponsable As System.Windows.Forms.TextBox
    Friend WithEvents DateFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextIdCompra As System.Windows.Forms.TextBox
    Friend WithEvents TextObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Producto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Detalle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrecioAnt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MonedaAnt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaAnt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Unidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Presentacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Precio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Moneda As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Subtotal As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
