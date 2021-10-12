<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEnviarMensajes
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
        Me.ButtonSeleccionar = New System.Windows.Forms.Button
        Me.TextCliente = New System.Windows.Forms.TextBox
        Me.TextEmail = New System.Windows.Forms.TextBox
        Me.TextTexto = New System.Windows.Forms.TextBox
        Me.ButtonEnviar = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'ButtonSeleccionar
        '
        Me.ButtonSeleccionar.Location = New System.Drawing.Point(12, 12)
        Me.ButtonSeleccionar.Name = "ButtonSeleccionar"
        Me.ButtonSeleccionar.Size = New System.Drawing.Size(142, 23)
        Me.ButtonSeleccionar.TabIndex = 0
        Me.ButtonSeleccionar.Text = "Seleccionar destinatario"
        Me.ButtonSeleccionar.UseVisualStyleBackColor = True
        '
        'TextCliente
        '
        Me.TextCliente.Location = New System.Drawing.Point(160, 15)
        Me.TextCliente.Name = "TextCliente"
        Me.TextCliente.ReadOnly = True
        Me.TextCliente.Size = New System.Drawing.Size(291, 20)
        Me.TextCliente.TabIndex = 1
        '
        'TextEmail
        '
        Me.TextEmail.Location = New System.Drawing.Point(160, 41)
        Me.TextEmail.Name = "TextEmail"
        Me.TextEmail.ReadOnly = True
        Me.TextEmail.Size = New System.Drawing.Size(291, 20)
        Me.TextEmail.TabIndex = 2
        '
        'TextTexto
        '
        Me.TextTexto.Location = New System.Drawing.Point(160, 67)
        Me.TextTexto.Multiline = True
        Me.TextTexto.Name = "TextTexto"
        Me.TextTexto.Size = New System.Drawing.Size(291, 95)
        Me.TextTexto.TabIndex = 3
        '
        'ButtonEnviar
        '
        Me.ButtonEnviar.Location = New System.Drawing.Point(376, 168)
        Me.ButtonEnviar.Name = "ButtonEnviar"
        Me.ButtonEnviar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonEnviar.TabIndex = 4
        Me.ButtonEnviar.Text = "Enviar"
        Me.ButtonEnviar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(119, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "E-mail"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(119, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Texto"
        '
        'FormEnviarMensajes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(467, 207)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ButtonEnviar)
        Me.Controls.Add(Me.TextTexto)
        Me.Controls.Add(Me.TextEmail)
        Me.Controls.Add(Me.TextCliente)
        Me.Controls.Add(Me.ButtonSeleccionar)
        Me.Name = "FormEnviarMensajes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Enviar mensajes"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonSeleccionar As System.Windows.Forms.Button
    Friend WithEvents TextCliente As System.Windows.Forms.TextBox
    Friend WithEvents TextEmail As System.Windows.Forms.TextBox
    Friend WithEvents TextTexto As System.Windows.Forms.TextBox
    Friend WithEvents ButtonEnviar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
