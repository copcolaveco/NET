<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ControlInformes
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
        Me.cbxControladores = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbxTipoInfome = New System.Windows.Forms.ComboBox()
        Me.cbxSubTipoInforme = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DateDesde = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DateHasta = New System.Windows.Forms.DateTimePicker()
        Me.SuspendLayout()
        '
        'cbxControladores
        '
        Me.cbxControladores.FormattingEnabled = True
        Me.cbxControladores.Location = New System.Drawing.Point(28, 47)
        Me.cbxControladores.Name = "cbxControladores"
        Me.cbxControladores.Size = New System.Drawing.Size(263, 24)
        Me.cbxControladores.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Controladores"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(31, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Tipo de Informe"
        '
        'cbxTipoInfome
        '
        Me.cbxTipoInfome.FormattingEnabled = True
        Me.cbxTipoInfome.Location = New System.Drawing.Point(28, 113)
        Me.cbxTipoInfome.Name = "cbxTipoInfome"
        Me.cbxTipoInfome.Size = New System.Drawing.Size(263, 24)
        Me.cbxTipoInfome.TabIndex = 3
        '
        'cbxSubTipoInforme
        '
        Me.cbxSubTipoInforme.FormattingEnabled = True
        Me.cbxSubTipoInforme.Location = New System.Drawing.Point(31, 185)
        Me.cbxSubTipoInforme.Name = "cbxSubTipoInforme"
        Me.cbxSubTipoInforme.Size = New System.Drawing.Size(257, 24)
        Me.cbxSubTipoInforme.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(28, 164)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(136, 17)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Sub Tipo de Informe"
        '
        'DateDesde
        '
        Me.DateDesde.Location = New System.Drawing.Point(28, 247)
        Me.DateDesde.Name = "DateDesde"
        Me.DateDesde.Size = New System.Drawing.Size(260, 22)
        Me.DateDesde.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(28, 227)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 17)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Desde"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(28, 291)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 17)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Hasta"
        '
        'DateHasta
        '
        Me.DateHasta.Location = New System.Drawing.Point(28, 311)
        Me.DateHasta.Name = "DateHasta"
        Me.DateHasta.Size = New System.Drawing.Size(260, 22)
        Me.DateHasta.TabIndex = 8
        '
        'ControlInformes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1473, 488)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DateHasta)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.DateDesde)
        Me.Controls.Add(Me.cbxSubTipoInforme)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbxTipoInfome)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbxControladores)
        Me.Name = "ControlInformes"
        Me.Text = "ControlInformes"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbxControladores As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbxTipoInfome As System.Windows.Forms.ComboBox
    Friend WithEvents cbxSubTipoInforme As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DateDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DateHasta As System.Windows.Forms.DateTimePicker
End Class
