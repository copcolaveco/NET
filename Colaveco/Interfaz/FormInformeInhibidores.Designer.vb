<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormInformeInhibidores
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormInformeInhibidores))
        Me.TextFicha = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ButtonListar = New System.Windows.Forms.Button
        Me.ListInhibidores = New System.Windows.Forms.ListBox
        Me.SuspendLayout()
        '
        'TextFicha
        '
        Me.TextFicha.Location = New System.Drawing.Point(51, 12)
        Me.TextFicha.Name = "TextFicha"
        Me.TextFicha.Size = New System.Drawing.Size(100, 20)
        Me.TextFicha.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Ficha"
        '
        'ButtonListar
        '
        Me.ButtonListar.Location = New System.Drawing.Point(157, 10)
        Me.ButtonListar.Name = "ButtonListar"
        Me.ButtonListar.Size = New System.Drawing.Size(131, 23)
        Me.ButtonListar.TabIndex = 2
        Me.ButtonListar.Text = "Listar resultados"
        Me.ButtonListar.UseVisualStyleBackColor = True
        '
        'ListInhibidores
        '
        Me.ListInhibidores.BackColor = System.Drawing.SystemColors.Info
        Me.ListInhibidores.FormattingEnabled = True
        Me.ListInhibidores.Location = New System.Drawing.Point(15, 39)
        Me.ListInhibidores.Name = "ListInhibidores"
        Me.ListInhibidores.Size = New System.Drawing.Size(273, 446)
        Me.ListInhibidores.TabIndex = 3
        '
        'FormInformeInhibidores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(304, 499)
        Me.Controls.Add(Me.ListInhibidores)
        Me.Controls.Add(Me.ButtonListar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextFicha)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormInformeInhibidores"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informe Inhibidores"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextFicha As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ButtonListar As System.Windows.Forms.Button
    Friend WithEvents ListInhibidores As System.Windows.Forms.ListBox
End Class
