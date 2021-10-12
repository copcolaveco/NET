<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSolucionTrabajo
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
        Me.TextId = New System.Windows.Forms.TextBox
        Me.TextNombre = New System.Windows.Forms.TextBox
        Me.ButtonNuevo = New System.Windows.Forms.Button
        Me.ButtonGuardar = New System.Windows.Forms.Button
        Me.ButtonEliminar = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.DataGridSoluciones = New System.Windows.Forms.DataGridView
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridReceta = New System.Windows.Forms.DataGridView
        Me.Id2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IdSt = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Producto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Unidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TextIdProducto = New System.Windows.Forms.TextBox
        Me.TextNombreProducto = New System.Windows.Forms.TextBox
        Me.ButtonBuscarProducto = New System.Windows.Forms.Button
        Me.TextCodigo = New System.Windows.Forms.TextBox
        Me.TextCantidad = New System.Windows.Forms.TextBox
        Me.ComboUnidad = New System.Windows.Forms.ComboBox
        Me.TextIdReceta = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.ButtonGuardarLinea = New System.Windows.Forms.Button
        Me.ButtonEliminarLinea = New System.Windows.Forms.Button
        Me.TextIdLinea = New System.Windows.Forms.TextBox
        Me.ButtonNuevaLinea = New System.Windows.Forms.Button
        CType(Me.DataGridSoluciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridReceta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextId
        '
        Me.TextId.Location = New System.Drawing.Point(66, 12)
        Me.TextId.Name = "TextId"
        Me.TextId.ReadOnly = True
        Me.TextId.Size = New System.Drawing.Size(56, 20)
        Me.TextId.TabIndex = 0
        '
        'TextNombre
        '
        Me.TextNombre.Location = New System.Drawing.Point(66, 38)
        Me.TextNombre.Name = "TextNombre"
        Me.TextNombre.Size = New System.Drawing.Size(217, 20)
        Me.TextNombre.TabIndex = 1
        '
        'ButtonNuevo
        '
        Me.ButtonNuevo.Location = New System.Drawing.Point(43, 64)
        Me.ButtonNuevo.Name = "ButtonNuevo"
        Me.ButtonNuevo.Size = New System.Drawing.Size(75, 23)
        Me.ButtonNuevo.TabIndex = 2
        Me.ButtonNuevo.Text = "Nuevo"
        Me.ButtonNuevo.UseVisualStyleBackColor = True
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(124, 64)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 3
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'ButtonEliminar
        '
        Me.ButtonEliminar.Location = New System.Drawing.Point(208, 64)
        Me.ButtonEliminar.Name = "ButtonEliminar"
        Me.ButtonEliminar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonEliminar.TabIndex = 4
        Me.ButtonEliminar.Text = "Eliminar"
        Me.ButtonEliminar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Id"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Nombre"
        '
        'DataGridSoluciones
        '
        Me.DataGridSoluciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridSoluciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Nombre})
        Me.DataGridSoluciones.Location = New System.Drawing.Point(29, 108)
        Me.DataGridSoluciones.Name = "DataGridSoluciones"
        Me.DataGridSoluciones.RowHeadersVisible = False
        Me.DataGridSoluciones.Size = New System.Drawing.Size(206, 490)
        Me.DataGridSoluciones.TabIndex = 7
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Visible = False
        '
        'Nombre
        '
        Me.Nombre.HeaderText = "Nombre"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Width = 200
        '
        'DataGridReceta
        '
        Me.DataGridReceta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridReceta.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id2, Me.IdSt, Me.Producto, Me.Cantidad, Me.Unidad})
        Me.DataGridReceta.Location = New System.Drawing.Point(255, 160)
        Me.DataGridReceta.Name = "DataGridReceta"
        Me.DataGridReceta.RowHeadersVisible = False
        Me.DataGridReceta.Size = New System.Drawing.Size(348, 438)
        Me.DataGridReceta.TabIndex = 8
        '
        'Id2
        '
        Me.Id2.HeaderText = "Id"
        Me.Id2.Name = "Id2"
        Me.Id2.Visible = False
        '
        'IdSt
        '
        Me.IdSt.HeaderText = "IdSt"
        Me.IdSt.Name = "IdSt"
        Me.IdSt.Visible = False
        '
        'Producto
        '
        Me.Producto.HeaderText = "Producto"
        Me.Producto.Name = "Producto"
        Me.Producto.Width = 200
        '
        'Cantidad
        '
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.Width = 60
        '
        'Unidad
        '
        Me.Unidad.HeaderText = "Unidad"
        Me.Unidad.Name = "Unidad"
        Me.Unidad.Width = 80
        '
        'TextIdProducto
        '
        Me.TextIdProducto.Location = New System.Drawing.Point(254, 108)
        Me.TextIdProducto.Name = "TextIdProducto"
        Me.TextIdProducto.Size = New System.Drawing.Size(59, 20)
        Me.TextIdProducto.TabIndex = 9
        '
        'TextNombreProducto
        '
        Me.TextNombreProducto.Location = New System.Drawing.Point(347, 108)
        Me.TextNombreProducto.Name = "TextNombreProducto"
        Me.TextNombreProducto.Size = New System.Drawing.Size(295, 20)
        Me.TextNombreProducto.TabIndex = 10
        '
        'ButtonBuscarProducto
        '
        Me.ButtonBuscarProducto.Location = New System.Drawing.Point(319, 108)
        Me.ButtonBuscarProducto.Name = "ButtonBuscarProducto"
        Me.ButtonBuscarProducto.Size = New System.Drawing.Size(22, 23)
        Me.ButtonBuscarProducto.TabIndex = 11
        Me.ButtonBuscarProducto.Text = "^"
        Me.ButtonBuscarProducto.UseVisualStyleBackColor = True
        '
        'TextCodigo
        '
        Me.TextCodigo.Location = New System.Drawing.Point(347, 134)
        Me.TextCodigo.Name = "TextCodigo"
        Me.TextCodigo.Size = New System.Drawing.Size(295, 20)
        Me.TextCodigo.TabIndex = 12
        '
        'TextCantidad
        '
        Me.TextCantidad.Location = New System.Drawing.Point(648, 108)
        Me.TextCantidad.Name = "TextCantidad"
        Me.TextCantidad.Size = New System.Drawing.Size(78, 20)
        Me.TextCantidad.TabIndex = 13
        '
        'ComboUnidad
        '
        Me.ComboUnidad.FormattingEnabled = True
        Me.ComboUnidad.Location = New System.Drawing.Point(732, 107)
        Me.ComboUnidad.Name = "ComboUnidad"
        Me.ComboUnidad.Size = New System.Drawing.Size(73, 21)
        Me.ComboUnidad.TabIndex = 14
        '
        'TextIdReceta
        '
        Me.TextIdReceta.Location = New System.Drawing.Point(254, 134)
        Me.TextIdReceta.Name = "TextIdReceta"
        Me.TextIdReceta.Size = New System.Drawing.Size(39, 20)
        Me.TextIdReceta.TabIndex = 15
        Me.TextIdReceta.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(252, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Id producto"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(344, 91)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Nombre"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(645, 92)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Cantidad"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(729, 91)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 13)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Unidad"
        '
        'ButtonGuardarLinea
        '
        Me.ButtonGuardarLinea.Location = New System.Drawing.Point(811, 106)
        Me.ButtonGuardarLinea.Name = "ButtonGuardarLinea"
        Me.ButtonGuardarLinea.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardarLinea.TabIndex = 20
        Me.ButtonGuardarLinea.Text = "Guardar"
        Me.ButtonGuardarLinea.UseVisualStyleBackColor = True
        '
        'ButtonEliminarLinea
        '
        Me.ButtonEliminarLinea.Location = New System.Drawing.Point(811, 164)
        Me.ButtonEliminarLinea.Name = "ButtonEliminarLinea"
        Me.ButtonEliminarLinea.Size = New System.Drawing.Size(75, 23)
        Me.ButtonEliminarLinea.TabIndex = 21
        Me.ButtonEliminarLinea.Text = "Eliminar"
        Me.ButtonEliminarLinea.UseVisualStyleBackColor = True
        '
        'TextIdLinea
        '
        Me.TextIdLinea.Location = New System.Drawing.Point(299, 134)
        Me.TextIdLinea.Name = "TextIdLinea"
        Me.TextIdLinea.Size = New System.Drawing.Size(38, 20)
        Me.TextIdLinea.TabIndex = 22
        Me.TextIdLinea.Visible = False
        '
        'ButtonNuevaLinea
        '
        Me.ButtonNuevaLinea.Location = New System.Drawing.Point(811, 135)
        Me.ButtonNuevaLinea.Name = "ButtonNuevaLinea"
        Me.ButtonNuevaLinea.Size = New System.Drawing.Size(75, 23)
        Me.ButtonNuevaLinea.TabIndex = 23
        Me.ButtonNuevaLinea.Text = "Agregar"
        Me.ButtonNuevaLinea.UseVisualStyleBackColor = True
        '
        'FormSolucionTrabajo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(896, 608)
        Me.Controls.Add(Me.ButtonNuevaLinea)
        Me.Controls.Add(Me.TextIdLinea)
        Me.Controls.Add(Me.ButtonEliminarLinea)
        Me.Controls.Add(Me.ButtonGuardarLinea)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextIdReceta)
        Me.Controls.Add(Me.ComboUnidad)
        Me.Controls.Add(Me.TextCantidad)
        Me.Controls.Add(Me.TextCodigo)
        Me.Controls.Add(Me.ButtonBuscarProducto)
        Me.Controls.Add(Me.TextNombreProducto)
        Me.Controls.Add(Me.TextIdProducto)
        Me.Controls.Add(Me.DataGridReceta)
        Me.Controls.Add(Me.DataGridSoluciones)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ButtonEliminar)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.ButtonNuevo)
        Me.Controls.Add(Me.TextNombre)
        Me.Controls.Add(Me.TextId)
        Me.Name = "FormSolucionTrabajo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Solución de Trabajo"
        CType(Me.DataGridSoluciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridReceta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents TextNombre As System.Windows.Forms.TextBox
    Friend WithEvents ButtonNuevo As System.Windows.Forms.Button
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents ButtonEliminar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DataGridSoluciones As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridReceta As System.Windows.Forms.DataGridView
    Friend WithEvents TextIdProducto As System.Windows.Forms.TextBox
    Friend WithEvents TextNombreProducto As System.Windows.Forms.TextBox
    Friend WithEvents ButtonBuscarProducto As System.Windows.Forms.Button
    Friend WithEvents TextCodigo As System.Windows.Forms.TextBox
    Friend WithEvents TextCantidad As System.Windows.Forms.TextBox
    Friend WithEvents ComboUnidad As System.Windows.Forms.ComboBox
    Friend WithEvents TextIdReceta As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ButtonGuardarLinea As System.Windows.Forms.Button
    Friend WithEvents ButtonEliminarLinea As System.Windows.Forms.Button
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TextIdLinea As System.Windows.Forms.TextBox
    Friend WithEvents Id2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdSt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Producto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Unidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ButtonNuevaLinea As System.Windows.Forms.Button
End Class
