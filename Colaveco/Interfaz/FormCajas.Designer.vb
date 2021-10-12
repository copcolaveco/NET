<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCajas
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextId = New System.Windows.Forms.TextBox()
        Me.TextCodigo = New System.Windows.Forms.TextBox()
        Me.ComboEstado = New System.Windows.Forms.ComboBox()
        Me.RadioCA = New System.Windows.Forms.RadioButton()
        Me.RadioCL = New System.Windows.Forms.RadioButton()
        Me.RadioCaja = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadioCajaFlorida = New System.Windows.Forms.RadioButton()
        Me.ButtonNueva = New System.Windows.Forms.Button()
        Me.ButtonGuardar = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TextBuscar = New System.Windows.Forms.TextBox()
        Me.ButtonExportar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(243, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Id"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(243, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Código"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(243, 87)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Estado"
        '
        'TextId
        '
        Me.TextId.Location = New System.Drawing.Point(292, 32)
        Me.TextId.Name = "TextId"
        Me.TextId.ReadOnly = True
        Me.TextId.Size = New System.Drawing.Size(58, 20)
        Me.TextId.TabIndex = 4
        '
        'TextCodigo
        '
        Me.TextCodigo.Location = New System.Drawing.Point(292, 58)
        Me.TextCodigo.Name = "TextCodigo"
        Me.TextCodigo.Size = New System.Drawing.Size(100, 20)
        Me.TextCodigo.TabIndex = 6
        '
        'ComboEstado
        '
        Me.ComboEstado.FormattingEnabled = True
        Me.ComboEstado.Items.AddRange(New Object() {"Laboratorio", "Cliente", "Florida", "Cardal", "Canelones", "Perdida"})
        Me.ComboEstado.Location = New System.Drawing.Point(292, 84)
        Me.ComboEstado.Name = "ComboEstado"
        Me.ComboEstado.Size = New System.Drawing.Size(100, 21)
        Me.ComboEstado.TabIndex = 7
        '
        'RadioCA
        '
        Me.RadioCA.AutoSize = True
        Me.RadioCA.Location = New System.Drawing.Point(15, 19)
        Me.RadioCA.Name = "RadioCA"
        Me.RadioCA.Size = New System.Drawing.Size(142, 17)
        Me.RadioCA.TabIndex = 8
        Me.RadioCA.TabStop = True
        Me.RadioCA.Text = "Conservadora para agua"
        Me.RadioCA.UseVisualStyleBackColor = True
        '
        'RadioCL
        '
        Me.RadioCL.AutoSize = True
        Me.RadioCL.Location = New System.Drawing.Point(15, 42)
        Me.RadioCL.Name = "RadioCL"
        Me.RadioCL.Size = New System.Drawing.Size(196, 17)
        Me.RadioCL.TabIndex = 12
        Me.RadioCL.TabStop = True
        Me.RadioCL.Text = "Conservadora para frascos de leche"
        Me.RadioCL.UseVisualStyleBackColor = True
        '
        'RadioCaja
        '
        Me.RadioCaja.AutoSize = True
        Me.RadioCaja.Location = New System.Drawing.Point(15, 65)
        Me.RadioCaja.Name = "RadioCaja"
        Me.RadioCaja.Size = New System.Drawing.Size(107, 17)
        Me.RadioCaja.TabIndex = 13
        Me.RadioCaja.TabStop = True
        Me.RadioCaja.Text = "Caja verde o azul"
        Me.RadioCaja.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioCajaFlorida)
        Me.GroupBox1.Controls.Add(Me.RadioCA)
        Me.GroupBox1.Controls.Add(Me.RadioCaja)
        Me.GroupBox1.Controls.Add(Me.RadioCL)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(225, 124)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        '
        'RadioCajaFlorida
        '
        Me.RadioCajaFlorida.AutoSize = True
        Me.RadioCajaFlorida.Location = New System.Drawing.Point(15, 88)
        Me.RadioCajaFlorida.Name = "RadioCajaFlorida"
        Me.RadioCajaFlorida.Size = New System.Drawing.Size(80, 17)
        Me.RadioCajaFlorida.TabIndex = 19
        Me.RadioCajaFlorida.TabStop = True
        Me.RadioCajaFlorida.Text = "Caja Florida"
        Me.RadioCajaFlorida.UseVisualStyleBackColor = True
        '
        'ButtonNueva
        '
        Me.ButtonNueva.Location = New System.Drawing.Point(247, 158)
        Me.ButtonNueva.Name = "ButtonNueva"
        Me.ButtonNueva.Size = New System.Drawing.Size(75, 23)
        Me.ButtonNueva.TabIndex = 15
        Me.ButtonNueva.Text = "Nueva"
        Me.ButtonNueva.UseVisualStyleBackColor = True
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(328, 158)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 16
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Codigo, Me.Estado})
        Me.DataGridView1.Location = New System.Drawing.Point(467, 32)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(216, 333)
        Me.DataGridView1.TabIndex = 17
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Visible = False
        '
        'Codigo
        '
        Me.Codigo.HeaderText = "Código"
        Me.Codigo.Name = "Codigo"
        '
        'Estado
        '
        Me.Estado.HeaderText = "Estado"
        Me.Estado.Name = "Estado"
        '
        'TextBuscar
        '
        Me.TextBuscar.Location = New System.Drawing.Point(467, 6)
        Me.TextBuscar.Name = "TextBuscar"
        Me.TextBuscar.Size = New System.Drawing.Size(216, 20)
        Me.TextBuscar.TabIndex = 18
        '
        'ButtonExportar
        '
        Me.ButtonExportar.Location = New System.Drawing.Point(608, 371)
        Me.ButtonExportar.Name = "ButtonExportar"
        Me.ButtonExportar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonExportar.TabIndex = 19
        Me.ButtonExportar.Text = "Exportar"
        Me.ButtonExportar.UseVisualStyleBackColor = True
        '
        'FormCajas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(697, 404)
        Me.Controls.Add(Me.ButtonExportar)
        Me.Controls.Add(Me.TextBuscar)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.ButtonNueva)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ComboEstado)
        Me.Controls.Add(Me.TextCodigo)
        Me.Controls.Add(Me.TextId)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FormCajas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cajas y conservadoras"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents TextCodigo As System.Windows.Forms.TextBox
    Friend WithEvents ComboEstado As System.Windows.Forms.ComboBox
    Friend WithEvents RadioCA As System.Windows.Forms.RadioButton
    Friend WithEvents RadioCL As System.Windows.Forms.RadioButton
    Friend WithEvents RadioCaja As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ButtonNueva As System.Windows.Forms.Button
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents TextBuscar As System.Windows.Forms.TextBox
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Estado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RadioCajaFlorida As System.Windows.Forms.RadioButton
    Friend WithEvents ButtonExportar As System.Windows.Forms.Button
End Class
