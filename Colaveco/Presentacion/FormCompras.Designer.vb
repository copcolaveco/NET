<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCompras
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
        Me.TextIdLinea = New System.Windows.Forms.TextBox
        Me.TextDetalle = New System.Windows.Forms.TextBox
        Me.ButtonBuscarCompra = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Producto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Detalle = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PrecioAnterior = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MonedaAnterior = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FechaAnterior = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Unidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Presentacion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Precio = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Moneda = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Subtotal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Editar = New System.Windows.Forms.DataGridViewButtonColumn
        Me.Eliminar = New System.Windows.Forms.DataGridViewButtonColumn
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ButtonGuardar = New System.Windows.Forms.Button
        Me.ButtonNueva = New System.Windows.Forms.Button
        Me.TextResponsable = New System.Windows.Forms.TextBox
        Me.ComboUnidad = New System.Windows.Forms.ComboBox
        Me.DateFecha = New System.Windows.Forms.DateTimePicker
        Me.TextCantidad = New System.Windows.Forms.TextBox
        Me.TextProveedor = New System.Windows.Forms.TextBox
        Me.ButtonBuscarProveedor = New System.Windows.Forms.Button
        Me.TextProducto = New System.Windows.Forms.TextBox
        Me.TextIdProveedor = New System.Windows.Forms.TextBox
        Me.ButtonBuscarProducto = New System.Windows.Forms.Button
        Me.TextId = New System.Windows.Forms.TextBox
        Me.ButtonAgregar = New System.Windows.Forms.Button
        Me.TextIdProducto = New System.Windows.Forms.TextBox
        Me.TextObservaciones = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.ComboEmail = New System.Windows.Forms.ComboBox
        Me.ButtonAsociar = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.DateUltimaCompra = New System.Windows.Forms.DateTimePicker
        Me.Label9 = New System.Windows.Forms.Label
        Me.ComboMonedaAnterior = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.TextPrecioAnterior = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.ComboMoneda = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.TextPrecio = New System.Windows.Forms.TextBox
        Me.ComboPresentacion = New System.Windows.Forms.ComboBox
        Me.Label14 = New System.Windows.Forms.Label
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextIdLinea
        '
        Me.TextIdLinea.Location = New System.Drawing.Point(280, 446)
        Me.TextIdLinea.Name = "TextIdLinea"
        Me.TextIdLinea.Size = New System.Drawing.Size(70, 20)
        Me.TextIdLinea.TabIndex = 47
        '
        'TextDetalle
        '
        Me.TextDetalle.Location = New System.Drawing.Point(120, 112)
        Me.TextDetalle.Multiline = True
        Me.TextDetalle.Name = "TextDetalle"
        Me.TextDetalle.ReadOnly = True
        Me.TextDetalle.Size = New System.Drawing.Size(265, 47)
        Me.TextDetalle.TabIndex = 46
        '
        'ButtonBuscarCompra
        '
        Me.ButtonBuscarCompra.Location = New System.Drawing.Point(183, 444)
        Me.ButtonBuscarCompra.Name = "ButtonBuscarCompra"
        Me.ButtonBuscarCompra.Size = New System.Drawing.Size(75, 23)
        Me.ButtonBuscarCompra.TabIndex = 45
        Me.ButtonBuscarCompra.Text = "Buscar"
        Me.ButtonBuscarCompra.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(461, 66)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 13)
        Me.Label6.TabIndex = 44
        Me.Label6.Text = "Unidad"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(388, 68)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 43
        Me.Label5.Text = "Cantidad"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(121, 70)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 42
        Me.Label4.Text = "Producto"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(16, 13)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "Id"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Producto, Me.Detalle, Me.PrecioAnterior, Me.MonedaAnterior, Me.FechaAnterior, Me.Cantidad, Me.Unidad, Me.Presentacion, Me.Precio, Me.Moneda, Me.Subtotal, Me.Editar, Me.Eliminar})
        Me.DataGridView1.Location = New System.Drawing.Point(21, 165)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(975, 206)
        Me.DataGridView1.TabIndex = 32
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Visible = False
        Me.Id.Width = 50
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
        'PrecioAnterior
        '
        Me.PrecioAnterior.HeaderText = "Precio últ. compra"
        Me.PrecioAnterior.Name = "PrecioAnterior"
        Me.PrecioAnterior.Width = 50
        '
        'MonedaAnterior
        '
        Me.MonedaAnterior.HeaderText = "Moneda últ. compra"
        Me.MonedaAnterior.Name = "MonedaAnterior"
        Me.MonedaAnterior.Width = 50
        '
        'FechaAnterior
        '
        Me.FechaAnterior.HeaderText = "Fecha últ. compra"
        Me.FechaAnterior.Name = "FechaAnterior"
        Me.FechaAnterior.Width = 80
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
        Me.Unidad.Width = 60
        '
        'Presentacion
        '
        Me.Presentacion.HeaderText = "Presentación"
        Me.Presentacion.Name = "Presentacion"
        '
        'Precio
        '
        Me.Precio.HeaderText = "Precio"
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
        'Editar
        '
        Me.Editar.HeaderText = ""
        Me.Editar.Name = "Editar"
        Me.Editar.Text = "Editar"
        Me.Editar.UseColumnTextForButtonValue = True
        '
        'Eliminar
        '
        Me.Eliminar.HeaderText = ""
        Me.Eliminar.Name = "Eliminar"
        Me.Eliminar.Text = "Eliminar"
        Me.Eliminar.UseColumnTextForButtonValue = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Proveedor"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Id"
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(102, 444)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 40
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'ButtonNueva
        '
        Me.ButtonNueva.Location = New System.Drawing.Point(21, 444)
        Me.ButtonNueva.Name = "ButtonNueva"
        Me.ButtonNueva.Size = New System.Drawing.Size(75, 23)
        Me.ButtonNueva.TabIndex = 39
        Me.ButtonNueva.Text = "Nueva"
        Me.ButtonNueva.UseVisualStyleBackColor = True
        '
        'TextResponsable
        '
        Me.TextResponsable.Location = New System.Drawing.Point(267, 13)
        Me.TextResponsable.Name = "TextResponsable"
        Me.TextResponsable.ReadOnly = True
        Me.TextResponsable.Size = New System.Drawing.Size(191, 20)
        Me.TextResponsable.TabIndex = 29
        '
        'ComboUnidad
        '
        Me.ComboUnidad.FormattingEnabled = True
        Me.ComboUnidad.Location = New System.Drawing.Point(464, 82)
        Me.ComboUnidad.Name = "ComboUnidad"
        Me.ComboUnidad.Size = New System.Drawing.Size(63, 21)
        Me.ComboUnidad.TabIndex = 37
        '
        'DateFecha
        '
        Me.DateFecha.Enabled = False
        Me.DateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFecha.Location = New System.Drawing.Point(153, 13)
        Me.DateFecha.Name = "DateFecha"
        Me.DateFecha.Size = New System.Drawing.Size(108, 20)
        Me.DateFecha.TabIndex = 28
        '
        'TextCantidad
        '
        Me.TextCantidad.Location = New System.Drawing.Point(391, 84)
        Me.TextCantidad.Name = "TextCantidad"
        Me.TextCantidad.Size = New System.Drawing.Size(67, 20)
        Me.TextCantidad.TabIndex = 36
        '
        'TextProveedor
        '
        Me.TextProveedor.Location = New System.Drawing.Point(176, 39)
        Me.TextProveedor.Name = "TextProveedor"
        Me.TextProveedor.ReadOnly = True
        Me.TextProveedor.Size = New System.Drawing.Size(282, 20)
        Me.TextProveedor.TabIndex = 27
        '
        'ButtonBuscarProveedor
        '
        Me.ButtonBuscarProveedor.Location = New System.Drawing.Point(143, 39)
        Me.ButtonBuscarProveedor.Name = "ButtonBuscarProveedor"
        Me.ButtonBuscarProveedor.Size = New System.Drawing.Size(27, 22)
        Me.ButtonBuscarProveedor.TabIndex = 26
        Me.ButtonBuscarProveedor.Text = "^"
        Me.ButtonBuscarProveedor.UseVisualStyleBackColor = True
        '
        'TextProducto
        '
        Me.TextProducto.Location = New System.Drawing.Point(120, 86)
        Me.TextProducto.Name = "TextProducto"
        Me.TextProducto.ReadOnly = True
        Me.TextProducto.Size = New System.Drawing.Size(265, 20)
        Me.TextProducto.TabIndex = 35
        '
        'TextIdProveedor
        '
        Me.TextIdProveedor.Location = New System.Drawing.Point(77, 39)
        Me.TextIdProveedor.Name = "TextIdProveedor"
        Me.TextIdProveedor.ReadOnly = True
        Me.TextIdProveedor.Size = New System.Drawing.Size(60, 20)
        Me.TextIdProveedor.TabIndex = 25
        '
        'ButtonBuscarProducto
        '
        Me.ButtonBuscarProducto.Location = New System.Drawing.Point(87, 86)
        Me.ButtonBuscarProducto.Name = "ButtonBuscarProducto"
        Me.ButtonBuscarProducto.Size = New System.Drawing.Size(27, 22)
        Me.ButtonBuscarProducto.TabIndex = 34
        Me.ButtonBuscarProducto.Text = "^"
        Me.ButtonBuscarProducto.UseVisualStyleBackColor = True
        '
        'TextId
        '
        Me.TextId.Enabled = False
        Me.TextId.Location = New System.Drawing.Point(77, 13)
        Me.TextId.Name = "TextId"
        Me.TextId.ReadOnly = True
        Me.TextId.Size = New System.Drawing.Size(60, 20)
        Me.TextId.TabIndex = 24
        '
        'ButtonAgregar
        '
        Me.ButtonAgregar.Location = New System.Drawing.Point(882, 80)
        Me.ButtonAgregar.Name = "ButtonAgregar"
        Me.ButtonAgregar.Size = New System.Drawing.Size(59, 23)
        Me.ButtonAgregar.TabIndex = 38
        Me.ButtonAgregar.Text = "Agregar"
        Me.ButtonAgregar.UseVisualStyleBackColor = True
        '
        'TextIdProducto
        '
        Me.TextIdProducto.Location = New System.Drawing.Point(21, 86)
        Me.TextIdProducto.Name = "TextIdProducto"
        Me.TextIdProducto.ReadOnly = True
        Me.TextIdProducto.Size = New System.Drawing.Size(60, 20)
        Me.TextIdProducto.TabIndex = 33
        '
        'TextObservaciones
        '
        Me.TextObservaciones.Location = New System.Drawing.Point(102, 377)
        Me.TextObservaciones.Multiline = True
        Me.TextObservaciones.Name = "TextObservaciones"
        Me.TextObservaciones.Size = New System.Drawing.Size(798, 47)
        Me.TextObservaciones.TabIndex = 48
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(18, 380)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 13)
        Me.Label7.TabIndex = 49
        Me.Label7.Text = "Observaciones"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(473, 20)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(241, 13)
        Me.Label8.TabIndex = 50
        Me.Label8.Text = "Seleccionar email para envio de orden de compra"
        '
        'ComboEmail
        '
        Me.ComboEmail.FormattingEnabled = True
        Me.ComboEmail.Location = New System.Drawing.Point(476, 38)
        Me.ComboEmail.Name = "ComboEmail"
        Me.ComboEmail.Size = New System.Drawing.Size(290, 21)
        Me.ComboEmail.TabIndex = 51
        '
        'ButtonAsociar
        '
        Me.ButtonAsociar.Location = New System.Drawing.Point(921, 13)
        Me.ButtonAsociar.Name = "ButtonAsociar"
        Me.ButtonAsociar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonAsociar.TabIndex = 52
        Me.ButtonAsociar.Text = "Asociar"
        Me.ButtonAsociar.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(536, 114)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(92, 13)
        Me.Label11.TabIndex = 92
        Me.Label11.Text = "Fecha últ. compra"
        '
        'DateUltimaCompra
        '
        Me.DateUltimaCompra.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateUltimaCompra.Location = New System.Drawing.Point(539, 130)
        Me.DateUltimaCompra.Name = "DateUltimaCompra"
        Me.DateUltimaCompra.Size = New System.Drawing.Size(95, 20)
        Me.DateUltimaCompra.TabIndex = 91
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(479, 116)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 13)
        Me.Label9.TabIndex = 90
        Me.Label9.Text = "Moneda"
        '
        'ComboMonedaAnterior
        '
        Me.ComboMonedaAnterior.FormattingEnabled = True
        Me.ComboMonedaAnterior.Location = New System.Drawing.Point(479, 129)
        Me.ComboMonedaAnterior.Name = "ComboMonedaAnterior"
        Me.ComboMonedaAnterior.Size = New System.Drawing.Size(54, 21)
        Me.ComboMonedaAnterior.TabIndex = 89
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(388, 116)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 13)
        Me.Label10.TabIndex = 88
        Me.Label10.Text = "Precio ant. s/IVA"
        '
        'TextPrecioAnterior
        '
        Me.TextPrecioAnterior.Location = New System.Drawing.Point(391, 130)
        Me.TextPrecioAnterior.Name = "TextPrecioAnterior"
        Me.TextPrecioAnterior.Size = New System.Drawing.Size(80, 20)
        Me.TextPrecioAnterior.TabIndex = 87
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(825, 68)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(46, 13)
        Me.Label12.TabIndex = 96
        Me.Label12.Text = "Moneda"
        '
        'ComboMoneda
        '
        Me.ComboMoneda.FormattingEnabled = True
        Me.ComboMoneda.Location = New System.Drawing.Point(822, 84)
        Me.ComboMoneda.Name = "ComboMoneda"
        Me.ComboMoneda.Size = New System.Drawing.Size(54, 21)
        Me.ComboMoneda.TabIndex = 95
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(731, 68)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(88, 13)
        Me.Label13.TabIndex = 94
        Me.Label13.Text = "Precio act. s/IVA"
        '
        'TextPrecio
        '
        Me.TextPrecio.Location = New System.Drawing.Point(734, 85)
        Me.TextPrecio.Name = "TextPrecio"
        Me.TextPrecio.Size = New System.Drawing.Size(80, 20)
        Me.TextPrecio.TabIndex = 93
        '
        'ComboPresentacion
        '
        Me.ComboPresentacion.FormattingEnabled = True
        Me.ComboPresentacion.Location = New System.Drawing.Point(533, 82)
        Me.ComboPresentacion.Name = "ComboPresentacion"
        Me.ComboPresentacion.Size = New System.Drawing.Size(195, 21)
        Me.ComboPresentacion.TabIndex = 97
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(536, 66)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(69, 13)
        Me.Label14.TabIndex = 98
        Me.Label14.Text = "Presentación"
        '
        'FormCompras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 482)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.ComboPresentacion)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.ComboMoneda)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TextPrecio)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.DateUltimaCompra)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.ComboMonedaAnterior)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TextPrecioAnterior)
        Me.Controls.Add(Me.ButtonAsociar)
        Me.Controls.Add(Me.ComboEmail)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TextObservaciones)
        Me.Controls.Add(Me.TextIdLinea)
        Me.Controls.Add(Me.TextDetalle)
        Me.Controls.Add(Me.ButtonBuscarCompra)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.ButtonNueva)
        Me.Controls.Add(Me.TextResponsable)
        Me.Controls.Add(Me.ComboUnidad)
        Me.Controls.Add(Me.DateFecha)
        Me.Controls.Add(Me.TextCantidad)
        Me.Controls.Add(Me.TextProveedor)
        Me.Controls.Add(Me.ButtonBuscarProveedor)
        Me.Controls.Add(Me.TextProducto)
        Me.Controls.Add(Me.TextIdProveedor)
        Me.Controls.Add(Me.ButtonBuscarProducto)
        Me.Controls.Add(Me.TextId)
        Me.Controls.Add(Me.ButtonAgregar)
        Me.Controls.Add(Me.TextIdProducto)
        Me.Name = "FormCompras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Compras"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextIdLinea As System.Windows.Forms.TextBox
    Friend WithEvents TextDetalle As System.Windows.Forms.TextBox
    Friend WithEvents ButtonBuscarCompra As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents ButtonNueva As System.Windows.Forms.Button
    Friend WithEvents TextResponsable As System.Windows.Forms.TextBox
    Friend WithEvents ComboUnidad As System.Windows.Forms.ComboBox
    Friend WithEvents DateFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextCantidad As System.Windows.Forms.TextBox
    Friend WithEvents TextProveedor As System.Windows.Forms.TextBox
    Friend WithEvents ButtonBuscarProveedor As System.Windows.Forms.Button
    Friend WithEvents TextProducto As System.Windows.Forms.TextBox
    Friend WithEvents TextIdProveedor As System.Windows.Forms.TextBox
    Friend WithEvents ButtonBuscarProducto As System.Windows.Forms.Button
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents ButtonAgregar As System.Windows.Forms.Button
    Friend WithEvents TextIdProducto As System.Windows.Forms.TextBox
    Friend WithEvents TextObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ComboEmail As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonAsociar As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents DateUltimaCompra As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ComboMonedaAnterior As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextPrecioAnterior As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ComboMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TextPrecio As System.Windows.Forms.TextBox
    Friend WithEvents ComboPresentacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Producto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Detalle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrecioAnterior As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MonedaAnterior As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaAnterior As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Unidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Presentacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Precio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Moneda As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Subtotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Editar As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Eliminar As System.Windows.Forms.DataGridViewButtonColumn
End Class
