<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCorreoMorosos
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
        Me.TextDestinatario = New System.Windows.Forms.TextBox()
        Me.TextAsunto = New System.Windows.Forms.TextBox()
        Me.TextDescripcion = New System.Windows.Forms.TextBox()
        Me.ButtonEnviar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.RadioCliente = New System.Windows.Forms.RadioButton()
        Me.RadioProlesa = New System.Windows.Forms.RadioButton()
        Me.ButtonAdjuntar = New System.Windows.Forms.Button()
        Me.TextAdjunto = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.RadioPersonalizado = New System.Windows.Forms.RadioButton()
        Me.ButtonNoEnviar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TextDestinatario
        '
        Me.TextDestinatario.Location = New System.Drawing.Point(81, 17)
        Me.TextDestinatario.Name = "TextDestinatario"
        Me.TextDestinatario.Size = New System.Drawing.Size(297, 20)
        Me.TextDestinatario.TabIndex = 0
        '
        'TextAsunto
        '
        Me.TextAsunto.Location = New System.Drawing.Point(81, 43)
        Me.TextAsunto.Name = "TextAsunto"
        Me.TextAsunto.Size = New System.Drawing.Size(297, 20)
        Me.TextAsunto.TabIndex = 1
        '
        'TextDescripcion
        '
        Me.TextDescripcion.Location = New System.Drawing.Point(81, 92)
        Me.TextDescripcion.Multiline = True
        Me.TextDescripcion.Name = "TextDescripcion"
        Me.TextDescripcion.Size = New System.Drawing.Size(409, 262)
        Me.TextDescripcion.TabIndex = 2
        '
        'ButtonEnviar
        '
        Me.ButtonEnviar.Location = New System.Drawing.Point(415, 389)
        Me.ButtonEnviar.Name = "ButtonEnviar"
        Me.ButtonEnviar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonEnviar.TabIndex = 3
        Me.ButtonEnviar.Text = "Enviar"
        Me.ButtonEnviar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Destinatario"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Asunto"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Descripción"
        '
        'RadioCliente
        '
        Me.RadioCliente.AutoSize = True
        Me.RadioCliente.Location = New System.Drawing.Point(81, 69)
        Me.RadioCliente.Name = "RadioCliente"
        Me.RadioCliente.Size = New System.Drawing.Size(57, 17)
        Me.RadioCliente.TabIndex = 7
        Me.RadioCliente.TabStop = True
        Me.RadioCliente.Text = "Cliente"
        Me.RadioCliente.UseVisualStyleBackColor = True
        '
        'RadioProlesa
        '
        Me.RadioProlesa.AutoSize = True
        Me.RadioProlesa.Location = New System.Drawing.Point(144, 69)
        Me.RadioProlesa.Name = "RadioProlesa"
        Me.RadioProlesa.Size = New System.Drawing.Size(60, 17)
        Me.RadioProlesa.TabIndex = 8
        Me.RadioProlesa.TabStop = True
        Me.RadioProlesa.Text = "Prolesa"
        Me.RadioProlesa.UseVisualStyleBackColor = True
        '
        'ButtonAdjuntar
        '
        Me.ButtonAdjuntar.Location = New System.Drawing.Point(81, 360)
        Me.ButtonAdjuntar.Name = "ButtonAdjuntar"
        Me.ButtonAdjuntar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonAdjuntar.TabIndex = 9
        Me.ButtonAdjuntar.Text = "Adjuntar"
        Me.ButtonAdjuntar.UseVisualStyleBackColor = True
        '
        'TextAdjunto
        '
        Me.TextAdjunto.Location = New System.Drawing.Point(162, 363)
        Me.TextAdjunto.Name = "TextAdjunto"
        Me.TextAdjunto.Size = New System.Drawing.Size(328, 20)
        Me.TextAdjunto.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(171, 1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(125, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "separados por "","" (coma)"
        '
        'RadioPersonalizado
        '
        Me.RadioPersonalizado.AutoSize = True
        Me.RadioPersonalizado.Location = New System.Drawing.Point(210, 69)
        Me.RadioPersonalizado.Name = "RadioPersonalizado"
        Me.RadioPersonalizado.Size = New System.Drawing.Size(91, 17)
        Me.RadioPersonalizado.TabIndex = 12
        Me.RadioPersonalizado.TabStop = True
        Me.RadioPersonalizado.Text = "Personalizado"
        Me.RadioPersonalizado.UseVisualStyleBackColor = True
        '
        'ButtonNoEnviar
        '
        Me.ButtonNoEnviar.Location = New System.Drawing.Point(334, 389)
        Me.ButtonNoEnviar.Name = "ButtonNoEnviar"
        Me.ButtonNoEnviar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonNoEnviar.TabIndex = 27
        Me.ButtonNoEnviar.Text = "No enviar"
        Me.ButtonNoEnviar.UseVisualStyleBackColor = True
        '
        'FormCorreoMorosos
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
        Me.Name = "FormCorreoMorosos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Envío de mail a moroso"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextDestinatario As System.Windows.Forms.TextBox
    Friend WithEvents TextAsunto As System.Windows.Forms.TextBox
    Friend WithEvents TextDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents ButtonEnviar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents RadioCliente As System.Windows.Forms.RadioButton
    Friend WithEvents RadioProlesa As System.Windows.Forms.RadioButton
    Friend WithEvents ButtonAdjuntar As System.Windows.Forms.Button
    Friend WithEvents TextAdjunto As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents RadioPersonalizado As System.Windows.Forms.RadioButton
    Friend WithEvents ButtonNoEnviar As System.Windows.Forms.Button
End Class
