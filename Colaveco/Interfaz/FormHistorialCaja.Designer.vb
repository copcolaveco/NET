<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormHistorialCaja
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
        Me.TextCaja = New System.Windows.Forms.TextBox()
        Me.ButtonBuscar = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Productor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Caja = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaEnvio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Observaciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Devuelta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaRecibo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ObsRecibo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboCajas = New System.Windows.Forms.ComboBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextCaja
        '
        Me.TextCaja.Location = New System.Drawing.Point(243, 24)
        Me.TextCaja.Name = "TextCaja"
        Me.TextCaja.Size = New System.Drawing.Size(76, 20)
        Me.TextCaja.TabIndex = 0
        Me.TextCaja.Visible = False
        '
        'ButtonBuscar
        '
        Me.ButtonBuscar.Location = New System.Drawing.Point(162, 22)
        Me.ButtonBuscar.Name = "ButtonBuscar"
        Me.ButtonBuscar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonBuscar.TabIndex = 1
        Me.ButtonBuscar.Text = "Buscar"
        Me.ButtonBuscar.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Productor, Me.Caja, Me.FechaEnvio, Me.Observaciones, Me.Devuelta, Me.FechaRecibo, Me.ObsRecibo})
        Me.DataGridView1.Location = New System.Drawing.Point(15, 51)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(898, 383)
        Me.DataGridView1.TabIndex = 2
        '
        'Productor
        '
        Me.Productor.HeaderText = "Productor"
        Me.Productor.Name = "Productor"
        Me.Productor.Width = 200
        '
        'Caja
        '
        Me.Caja.HeaderText = "Caja"
        Me.Caja.Name = "Caja"
        Me.Caja.Width = 50
        '
        'FechaEnvio
        '
        Me.FechaEnvio.HeaderText = "Fecha envío"
        Me.FechaEnvio.Name = "FechaEnvio"
        Me.FechaEnvio.Width = 80
        '
        'Observaciones
        '
        Me.Observaciones.HeaderText = "Observaciones"
        Me.Observaciones.Name = "Observaciones"
        Me.Observaciones.Width = 200
        '
        'Devuelta
        '
        Me.Devuelta.HeaderText = "Devuelta"
        Me.Devuelta.Name = "Devuelta"
        Me.Devuelta.Width = 60
        '
        'FechaRecibo
        '
        Me.FechaRecibo.HeaderText = "Fecha devuelta"
        Me.FechaRecibo.Name = "FechaRecibo"
        '
        'ObsRecibo
        '
        Me.ObsRecibo.HeaderText = "Obs. Recibo"
        Me.ObsRecibo.Name = "ObsRecibo"
        Me.ObsRecibo.Width = 200
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Nº de caja"
        '
        'ComboCajas
        '
        Me.ComboCajas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboCajas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboCajas.FormattingEnabled = True
        Me.ComboCajas.Location = New System.Drawing.Point(15, 25)
        Me.ComboCajas.Name = "ComboCajas"
        Me.ComboCajas.Size = New System.Drawing.Size(141, 21)
        Me.ComboCajas.TabIndex = 5
        '
        'FormHistorialCaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(926, 449)
        Me.Controls.Add(Me.ComboCajas)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ButtonBuscar)
        Me.Controls.Add(Me.TextCaja)
        Me.Name = "FormHistorialCaja"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Historial de cajas"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextCaja As System.Windows.Forms.TextBox
    Friend WithEvents ButtonBuscar As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Productor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Caja As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaEnvio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Observaciones As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Devuelta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaRecibo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ObsRecibo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ComboCajas As System.Windows.Forms.ComboBox
End Class
