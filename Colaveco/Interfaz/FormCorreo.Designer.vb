<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCorreo
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
        Me.RadioPersonalizado = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextAdjunto = New System.Windows.Forms.TextBox()
        Me.ButtonAdjuntar = New System.Windows.Forms.Button()
        Me.RadioProlesa = New System.Windows.Forms.RadioButton()
        Me.RadioCliente = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ButtonEnviar = New System.Windows.Forms.Button()
        Me.TextDescripcion = New System.Windows.Forms.TextBox()
        Me.TextAsunto = New System.Windows.Forms.TextBox()
        Me.TextDestinatario = New System.Windows.Forms.TextBox()
        Me.ButtonNoEnviar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'RadioPersonalizado
        '
        Me.RadioPersonalizado.AutoSize = True
        Me.RadioPersonalizado.Location = New System.Drawing.Point(212, 75)
        Me.RadioPersonalizado.Name = "RadioPersonalizado"
        Me.RadioPersonalizado.Size = New System.Drawing.Size(91, 17)
        Me.RadioPersonalizado.TabIndex = 25
        Me.RadioPersonalizado.TabStop = True
        Me.RadioPersonalizado.Text = "Personalizado"
        Me.RadioPersonalizado.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(173, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(125, 13)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "separados por "","" (coma)"
        '
        'TextAdjunto
        '
        Me.TextAdjunto.Location = New System.Drawing.Point(164, 369)
        Me.TextAdjunto.Name = "TextAdjunto"
        Me.TextAdjunto.Size = New System.Drawing.Size(328, 20)
        Me.TextAdjunto.TabIndex = 23
        '
        'ButtonAdjuntar
        '
        Me.ButtonAdjuntar.Location = New System.Drawing.Point(83, 366)
        Me.ButtonAdjuntar.Name = "ButtonAdjuntar"
        Me.ButtonAdjuntar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonAdjuntar.TabIndex = 22
        Me.ButtonAdjuntar.Text = "Adjuntar"
        Me.ButtonAdjuntar.UseVisualStyleBackColor = True
        '
        'RadioProlesa
        '
        Me.RadioProlesa.AutoSize = True
        Me.RadioProlesa.Location = New System.Drawing.Point(146, 75)
        Me.RadioProlesa.Name = "RadioProlesa"
        Me.RadioProlesa.Size = New System.Drawing.Size(60, 17)
        Me.RadioProlesa.TabIndex = 21
        Me.RadioProlesa.TabStop = True
        Me.RadioProlesa.Text = "Prolesa"
        Me.RadioProlesa.UseVisualStyleBackColor = True
        '
        'RadioCliente
        '
        Me.RadioCliente.AutoSize = True
        Me.RadioCliente.Location = New System.Drawing.Point(83, 75)
        Me.RadioCliente.Name = "RadioCliente"
        Me.RadioCliente.Size = New System.Drawing.Size(57, 17)
        Me.RadioCliente.TabIndex = 20
        Me.RadioCliente.TabStop = True
        Me.RadioCliente.Text = "Cliente"
        Me.RadioCliente.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 98)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Descripción"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Asunto"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Destinatario"
        '
        'ButtonEnviar
        '
        Me.ButtonEnviar.Location = New System.Drawing.Point(417, 395)
        Me.ButtonEnviar.Name = "ButtonEnviar"
        Me.ButtonEnviar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonEnviar.TabIndex = 16
        Me.ButtonEnviar.Text = "Enviar"
        Me.ButtonEnviar.UseVisualStyleBackColor = True
        '
        'TextDescripcion
        '
        Me.TextDescripcion.Location = New System.Drawing.Point(83, 98)
        Me.TextDescripcion.Multiline = True
        Me.TextDescripcion.Name = "TextDescripcion"
        Me.TextDescripcion.Size = New System.Drawing.Size(409, 262)
        Me.TextDescripcion.TabIndex = 15
        '
        'TextAsunto
        '
        Me.TextAsunto.Location = New System.Drawing.Point(83, 49)
        Me.TextAsunto.Name = "TextAsunto"
        Me.TextAsunto.Size = New System.Drawing.Size(297, 20)
        Me.TextAsunto.TabIndex = 14
        '
        'TextDestinatario
        '
        Me.TextDestinatario.Location = New System.Drawing.Point(83, 23)
        Me.TextDestinatario.Name = "TextDestinatario"
        Me.TextDestinatario.Size = New System.Drawing.Size(297, 20)
        Me.TextDestinatario.TabIndex = 13
        '
        'ButtonNoEnviar
        '
        Me.ButtonNoEnviar.Location = New System.Drawing.Point(323, 395)
        Me.ButtonNoEnviar.Name = "ButtonNoEnviar"
        Me.ButtonNoEnviar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonNoEnviar.TabIndex = 26
        Me.ButtonNoEnviar.Text = "No enviar"
        Me.ButtonNoEnviar.UseVisualStyleBackColor = True
        '
        'FormCorreo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(506, 424)
        Me.Controls.Add(Me.ButtonNoEnviar)
        Me.Controls.Add(Me.RadioPersonalizado)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextAdjunto)
        Me.Controls.Add(Me.ButtonAdjuntar)
        Me.Controls.Add(Me.RadioProlesa)
        Me.Controls.Add(Me.RadioCliente)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ButtonEnviar)
        Me.Controls.Add(Me.TextDescripcion)
        Me.Controls.Add(Me.TextAsunto)
        Me.Controls.Add(Me.TextDestinatario)
        Me.Name = "FormCorreo"
        Me.Text = "Envío de mail"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RadioPersonalizado As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextAdjunto As System.Windows.Forms.TextBox
    Friend WithEvents ButtonAdjuntar As System.Windows.Forms.Button
    Friend WithEvents RadioProlesa As System.Windows.Forms.RadioButton
    Friend WithEvents RadioCliente As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ButtonEnviar As System.Windows.Forms.Button
    Friend WithEvents TextDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents TextAsunto As System.Windows.Forms.TextBox
    Friend WithEvents TextDestinatario As System.Windows.Forms.TextBox
    Friend WithEvents ButtonNoEnviar As System.Windows.Forms.Button
End Class
