<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFrascosSangreSinFacturar
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
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Frascos = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Factura = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Facturado = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Marcar = New System.Windows.Forms.DataGridViewButtonColumn
        Me.ButtonExportar = New System.Windows.Forms.Button
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Fecha, Me.Cliente, Me.Frascos, Me.Factura, Me.Facturado, Me.Marcar})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(836, 468)
        Me.DataGridView1.TabIndex = 0
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Visible = False
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Width = 80
        '
        'Cliente
        '
        Me.Cliente.HeaderText = "Cliente"
        Me.Cliente.Name = "Cliente"
        Me.Cliente.Width = 250
        '
        'Frascos
        '
        Me.Frascos.HeaderText = "Frascos"
        Me.Frascos.Name = "Frascos"
        Me.Frascos.Width = 50
        '
        'Factura
        '
        Me.Factura.HeaderText = "Factura a:"
        Me.Factura.Name = "Factura"
        Me.Factura.Width = 250
        '
        'Facturado
        '
        Me.Facturado.HeaderText = "Facturado"
        Me.Facturado.Name = "Facturado"
        '
        'Marcar
        '
        Me.Marcar.HeaderText = ""
        Me.Marcar.Name = "Marcar"
        Me.Marcar.Text = "Marcar"
        Me.Marcar.UseColumnTextForButtonValue = True
        '
        'ButtonExportar
        '
        Me.ButtonExportar.Image = Global.Colaveco.My.Resources.Resources.excel
        Me.ButtonExportar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ButtonExportar.Location = New System.Drawing.Point(773, 486)
        Me.ButtonExportar.Name = "ButtonExportar"
        Me.ButtonExportar.Size = New System.Drawing.Size(75, 49)
        Me.ButtonExportar.TabIndex = 1
        Me.ButtonExportar.Text = "Exportar"
        Me.ButtonExportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ButtonExportar.UseVisualStyleBackColor = True
        '
        'FormFrascosSangreSinFacturar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(859, 546)
        Me.Controls.Add(Me.ButtonExportar)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "FormFrascosSangreSinFacturar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Frascos de sangre sin facturar"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Frascos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Factura As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Facturado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Marcar As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents ButtonExportar As System.Windows.Forms.Button
End Class
