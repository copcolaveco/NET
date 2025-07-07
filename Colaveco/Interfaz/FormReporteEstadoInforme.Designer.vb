<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormReporteEstadoInforme
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
        Me.tbxFicha = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.dtpHasta = New System.Windows.Forms.DateTimePicker()
        Me.dtpDesde = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.DataGridViewGestor = New System.Windows.Forms.DataGridView()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbEstadoGestor = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnExportar = New System.Windows.Forms.Button()
        CType(Me.DataGridViewGestor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbxFicha
        '
        Me.tbxFicha.Location = New System.Drawing.Point(91, 108)
        Me.tbxFicha.Name = "tbxFicha"
        Me.tbxFicha.Size = New System.Drawing.Size(234, 22)
        Me.tbxFicha.TabIndex = 63
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(15, 108)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 17)
        Me.Label10.TabIndex = 62
        Me.Label10.Text = "Ficha"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(352, 41)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(303, 23)
        Me.Button2.TabIndex = 61
        Me.Button2.Text = "Limpiar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(352, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(303, 23)
        Me.Button1.TabIndex = 59
        Me.Button1.Text = "Buscar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'dtpHasta
        '
        Me.dtpHasta.Location = New System.Drawing.Point(91, 72)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(234, 22)
        Me.dtpHasta.TabIndex = 58
        '
        'dtpDesde
        '
        Me.dtpDesde.Location = New System.Drawing.Point(91, 43)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(234, 22)
        Me.dtpDesde.TabIndex = 57
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(15, 72)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 17)
        Me.Label9.TabIndex = 56
        Me.Label9.Text = "Hasta"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(15, 43)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 17)
        Me.Label8.TabIndex = 55
        Me.Label8.Text = "Desde"
        '
        'DataGridViewGestor
        '
        Me.DataGridViewGestor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewGestor.Location = New System.Drawing.Point(15, 170)
        Me.DataGridViewGestor.Name = "DataGridViewGestor"
        Me.DataGridViewGestor.RowTemplate.Height = 24
        Me.DataGridViewGestor.Size = New System.Drawing.Size(1000, 230)
        Me.DataGridViewGestor.TabIndex = 54
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 17)
        Me.Label7.TabIndex = 53
        Me.Label7.Text = "Estado"
        '
        'cbEstadoGestor
        '
        Me.cbEstadoGestor.FormattingEnabled = True
        Me.cbEstadoGestor.Items.AddRange(New Object() {"SUBIDO", "PENDIENTE", "AMBOS"})
        Me.cbEstadoGestor.Location = New System.Drawing.Point(91, 8)
        Me.cbEstadoGestor.Name = "cbEstadoGestor"
        Me.cbEstadoGestor.Size = New System.Drawing.Size(234, 24)
        Me.cbEstadoGestor.TabIndex = 52
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 150)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(130, 17)
        Me.Label6.TabIndex = 51
        Me.Label6.Text = "Estado de informes"
        '
        'btnExportar
        '
        Me.btnExportar.Image = Global.Colaveco.My.Resources.Resources.excel
        Me.btnExportar.Location = New System.Drawing.Point(352, 70)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(303, 23)
        Me.btnExportar.TabIndex = 60
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'FormReporteEstadoInforme
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1027, 413)
        Me.Controls.Add(Me.tbxFicha)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btnExportar)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.dtpHasta)
        Me.Controls.Add(Me.dtpDesde)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.DataGridViewGestor)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cbEstadoGestor)
        Me.Controls.Add(Me.Label6)
        Me.Name = "FormReporteEstadoInforme"
        Me.Text = "FormReporteEstadoInforme"
        CType(Me.DataGridViewGestor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbxFicha As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents dtpHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewGestor As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbEstadoGestor As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
