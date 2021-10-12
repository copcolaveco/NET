<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBuscarCajas
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
        Me.TextCaja = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ButtonBuscar = New System.Windows.Forms.Button
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FechaEnvio = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Envio = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Agencia = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Caja = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Productor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FechaRecibo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Marcar = New System.Windows.Forms.DataGridViewButtonColumn
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextCaja
        '
        Me.TextCaja.Location = New System.Drawing.Point(12, 28)
        Me.TextCaja.Name = "TextCaja"
        Me.TextCaja.Size = New System.Drawing.Size(100, 20)
        Me.TextCaja.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Nº de caja"
        '
        'ButtonBuscar
        '
        Me.ButtonBuscar.Location = New System.Drawing.Point(118, 26)
        Me.ButtonBuscar.Name = "ButtonBuscar"
        Me.ButtonBuscar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonBuscar.TabIndex = 2
        Me.ButtonBuscar.Text = "Buscar"
        Me.ButtonBuscar.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.FechaEnvio, Me.Envio, Me.Agencia, Me.Caja, Me.Productor, Me.FechaRecibo, Me.Marcar})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 64)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(981, 419)
        Me.DataGridView1.TabIndex = 3
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Visible = False
        '
        'FechaEnvio
        '
        Me.FechaEnvio.HeaderText = "Fecha envío"
        Me.FechaEnvio.Name = "FechaEnvio"
        '
        'Envio
        '
        Me.Envio.HeaderText = "Envío"
        Me.Envio.Name = "Envio"
        '
        'Agencia
        '
        Me.Agencia.HeaderText = "Agencia"
        Me.Agencia.Name = "Agencia"
        '
        'Caja
        '
        Me.Caja.HeaderText = "Caja"
        Me.Caja.Name = "Caja"
        '
        'Productor
        '
        Me.Productor.HeaderText = "Productor"
        Me.Productor.Name = "Productor"
        Me.Productor.Width = 300
        '
        'FechaRecibo
        '
        Me.FechaRecibo.HeaderText = "Fecha recibida"
        Me.FechaRecibo.Name = "FechaRecibo"
        '
        'Marcar
        '
        Me.Marcar.HeaderText = ""
        Me.Marcar.Name = "Marcar"
        Me.Marcar.Text = "Matar"
        Me.Marcar.UseColumnTextForButtonValue = True
        '
        'FormBuscarCajas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1005, 494)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ButtonBuscar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextCaja)
        Me.Name = "FormBuscarCajas"
        Me.Text = "Buscar cajas"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextCaja As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ButtonBuscar As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaEnvio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Envio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Agencia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Caja As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Productor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaRecibo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Marcar As System.Windows.Forms.DataGridViewButtonColumn
End Class
