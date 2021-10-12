<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCargarPedidosAutomaticos
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
        Me.NumericAno = New System.Windows.Forms.NumericUpDown()
        Me.ComboMes = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ButtonCargar = New System.Windows.Forms.Button()
        CType(Me.NumericAno, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NumericAno
        '
        Me.NumericAno.Location = New System.Drawing.Point(171, 26)
        Me.NumericAno.Maximum = New Decimal(New Integer() {2030, 0, 0, 0})
        Me.NumericAno.Minimum = New Decimal(New Integer() {2019, 0, 0, 0})
        Me.NumericAno.Name = "NumericAno"
        Me.NumericAno.Size = New System.Drawing.Size(67, 20)
        Me.NumericAno.TabIndex = 0
        Me.NumericAno.Value = New Decimal(New Integer() {2019, 0, 0, 0})
        '
        'ComboMes
        '
        Me.ComboMes.FormattingEnabled = True
        Me.ComboMes.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.ComboMes.Location = New System.Drawing.Point(15, 25)
        Me.ComboMes.Name = "ComboMes"
        Me.ComboMes.Size = New System.Drawing.Size(150, 21)
        Me.ComboMes.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(135, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Seleccione el mes a cargar"
        '
        'ButtonCargar
        '
        Me.ButtonCargar.Location = New System.Drawing.Point(244, 25)
        Me.ButtonCargar.Name = "ButtonCargar"
        Me.ButtonCargar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonCargar.TabIndex = 3
        Me.ButtonCargar.Text = "Cargar"
        Me.ButtonCargar.UseVisualStyleBackColor = True
        '
        'FormCargarPedidosAutomaticos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(329, 67)
        Me.Controls.Add(Me.ButtonCargar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboMes)
        Me.Controls.Add(Me.NumericAno)
        Me.Name = "FormCargarPedidosAutomaticos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cargar pedidos automáticos"
        CType(Me.NumericAno, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents NumericAno As System.Windows.Forms.NumericUpDown
    Friend WithEvents ComboMes As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ButtonCargar As System.Windows.Forms.Button
End Class
