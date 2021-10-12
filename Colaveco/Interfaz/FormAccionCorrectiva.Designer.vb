<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAccionCorrectiva
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TextId = New System.Windows.Forms.TextBox()
        Me.TextNumero = New System.Windows.Forms.TextBox()
        Me.TextCausa = New System.Windows.Forms.TextBox()
        Me.TextAccion = New System.Windows.Forms.TextBox()
        Me.ComboPlan = New System.Windows.Forms.ComboBox()
        Me.ButtonPlan = New System.Windows.Forms.Button()
        Me.DatePlazo = New System.Windows.Forms.DateTimePicker()
        Me.ComboResponsable = New System.Windows.Forms.ComboBox()
        Me.TextCriterios = New System.Windows.Forms.TextBox()
        Me.ComboEficaz = New System.Windows.Forms.ComboBox()
        Me.DateEvaluacion = New System.Windows.Forms.DateTimePicker()
        Me.ComboEstado = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Numero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Causa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Accion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ButtonNueva = New System.Windows.Forms.Button()
        Me.ButtonGuardar = New System.Windows.Forms.Button()
        Me.ButtonEliminar = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextId
        '
        Me.TextId.Location = New System.Drawing.Point(109, 12)
        Me.TextId.Name = "TextId"
        Me.TextId.ReadOnly = True
        Me.TextId.Size = New System.Drawing.Size(75, 20)
        Me.TextId.TabIndex = 0
        '
        'TextNumero
        '
        Me.TextNumero.Location = New System.Drawing.Point(109, 38)
        Me.TextNumero.Name = "TextNumero"
        Me.TextNumero.ReadOnly = True
        Me.TextNumero.Size = New System.Drawing.Size(100, 20)
        Me.TextNumero.TabIndex = 1
        '
        'TextCausa
        '
        Me.TextCausa.Location = New System.Drawing.Point(109, 64)
        Me.TextCausa.Multiline = True
        Me.TextCausa.Name = "TextCausa"
        Me.TextCausa.Size = New System.Drawing.Size(324, 68)
        Me.TextCausa.TabIndex = 2
        '
        'TextAccion
        '
        Me.TextAccion.Location = New System.Drawing.Point(109, 138)
        Me.TextAccion.Multiline = True
        Me.TextAccion.Name = "TextAccion"
        Me.TextAccion.Size = New System.Drawing.Size(324, 68)
        Me.TextAccion.TabIndex = 3
        '
        'ComboPlan
        '
        Me.ComboPlan.FormattingEnabled = True
        Me.ComboPlan.Items.AddRange(New Object() {"Si", "No"})
        Me.ComboPlan.Location = New System.Drawing.Point(109, 212)
        Me.ComboPlan.Name = "ComboPlan"
        Me.ComboPlan.Size = New System.Drawing.Size(121, 21)
        Me.ComboPlan.TabIndex = 4
        '
        'ButtonPlan
        '
        Me.ButtonPlan.Location = New System.Drawing.Point(236, 212)
        Me.ButtonPlan.Name = "ButtonPlan"
        Me.ButtonPlan.Size = New System.Drawing.Size(106, 21)
        Me.ButtonPlan.TabIndex = 5
        Me.ButtonPlan.Text = "Requiere plan"
        Me.ButtonPlan.UseVisualStyleBackColor = True
        '
        'DatePlazo
        '
        Me.DatePlazo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DatePlazo.Location = New System.Drawing.Point(109, 239)
        Me.DatePlazo.Name = "DatePlazo"
        Me.DatePlazo.Size = New System.Drawing.Size(100, 20)
        Me.DatePlazo.TabIndex = 6
        '
        'ComboResponsable
        '
        Me.ComboResponsable.FormattingEnabled = True
        Me.ComboResponsable.Location = New System.Drawing.Point(109, 265)
        Me.ComboResponsable.Name = "ComboResponsable"
        Me.ComboResponsable.Size = New System.Drawing.Size(200, 21)
        Me.ComboResponsable.TabIndex = 7
        '
        'TextCriterios
        '
        Me.TextCriterios.Location = New System.Drawing.Point(109, 292)
        Me.TextCriterios.Multiline = True
        Me.TextCriterios.Name = "TextCriterios"
        Me.TextCriterios.Size = New System.Drawing.Size(324, 68)
        Me.TextCriterios.TabIndex = 8
        '
        'ComboEficaz
        '
        Me.ComboEficaz.FormattingEnabled = True
        Me.ComboEficaz.Items.AddRange(New Object() {"Si", "No", "En proceso"})
        Me.ComboEficaz.Location = New System.Drawing.Point(109, 366)
        Me.ComboEficaz.Name = "ComboEficaz"
        Me.ComboEficaz.Size = New System.Drawing.Size(121, 21)
        Me.ComboEficaz.TabIndex = 9
        '
        'DateEvaluacion
        '
        Me.DateEvaluacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateEvaluacion.Location = New System.Drawing.Point(109, 393)
        Me.DateEvaluacion.Name = "DateEvaluacion"
        Me.DateEvaluacion.Size = New System.Drawing.Size(100, 20)
        Me.DateEvaluacion.TabIndex = 10
        '
        'ComboEstado
        '
        Me.ComboEstado.FormattingEnabled = True
        Me.ComboEstado.Items.AddRange(New Object() {"Abierta", "Cerrada"})
        Me.ComboEstado.Location = New System.Drawing.Point(109, 419)
        Me.ComboEstado.Name = "ComboEstado"
        Me.ComboEstado.Size = New System.Drawing.Size(121, 21)
        Me.ComboEstado.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Id"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Número"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Causa"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 150)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Acción"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 215)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(28, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Plan"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 245)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(33, 13)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Plazo"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 273)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 13)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Responsable"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 304)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 13)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Criterios"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 369)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(36, 13)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "Eficaz"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 400)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(92, 13)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "Fecha evaluación"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 427)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(40, 13)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "Estado"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Numero, Me.Causa, Me.Accion})
        Me.DataGridView1.Location = New System.Drawing.Point(453, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(476, 428)
        Me.DataGridView1.TabIndex = 23
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Visible = False
        '
        'Numero
        '
        Me.Numero.HeaderText = "Número"
        Me.Numero.Name = "Numero"
        Me.Numero.Width = 60
        '
        'Causa
        '
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Causa.DefaultCellStyle = DataGridViewCellStyle1
        Me.Causa.HeaderText = "Causa"
        Me.Causa.Name = "Causa"
        Me.Causa.Width = 200
        '
        'Accion
        '
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Accion.DefaultCellStyle = DataGridViewCellStyle2
        Me.Accion.HeaderText = "Acción"
        Me.Accion.Name = "Accion"
        Me.Accion.Width = 200
        '
        'ButtonNueva
        '
        Me.ButtonNueva.Location = New System.Drawing.Point(109, 463)
        Me.ButtonNueva.Name = "ButtonNueva"
        Me.ButtonNueva.Size = New System.Drawing.Size(75, 23)
        Me.ButtonNueva.TabIndex = 24
        Me.ButtonNueva.Text = "Nueva"
        Me.ButtonNueva.UseVisualStyleBackColor = True
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(190, 463)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 25
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'ButtonEliminar
        '
        Me.ButtonEliminar.Location = New System.Drawing.Point(271, 463)
        Me.ButtonEliminar.Name = "ButtonEliminar"
        Me.ButtonEliminar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonEliminar.TabIndex = 26
        Me.ButtonEliminar.Text = "Eliminar"
        Me.ButtonEliminar.UseVisualStyleBackColor = True
        '
        'FormAccionCorrectiva
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(942, 499)
        Me.Controls.Add(Me.ButtonEliminar)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.ButtonNueva)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboEstado)
        Me.Controls.Add(Me.DateEvaluacion)
        Me.Controls.Add(Me.ComboEficaz)
        Me.Controls.Add(Me.TextCriterios)
        Me.Controls.Add(Me.ComboResponsable)
        Me.Controls.Add(Me.DatePlazo)
        Me.Controls.Add(Me.ButtonPlan)
        Me.Controls.Add(Me.ComboPlan)
        Me.Controls.Add(Me.TextAccion)
        Me.Controls.Add(Me.TextCausa)
        Me.Controls.Add(Me.TextNumero)
        Me.Controls.Add(Me.TextId)
        Me.Name = "FormAccionCorrectiva"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Acción correctiva RG.CC57 V07 del 15/07/2019"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents TextNumero As System.Windows.Forms.TextBox
    Friend WithEvents TextCausa As System.Windows.Forms.TextBox
    Friend WithEvents TextAccion As System.Windows.Forms.TextBox
    Friend WithEvents ComboPlan As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonPlan As System.Windows.Forms.Button
    Friend WithEvents DatePlazo As System.Windows.Forms.DateTimePicker
    Friend WithEvents ComboResponsable As System.Windows.Forms.ComboBox
    Friend WithEvents TextCriterios As System.Windows.Forms.TextBox
    Friend WithEvents ComboEficaz As System.Windows.Forms.ComboBox
    Friend WithEvents DateEvaluacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents ComboEstado As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ButtonNueva As System.Windows.Forms.Button
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents ButtonEliminar As System.Windows.Forms.Button
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Numero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Causa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Accion As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
