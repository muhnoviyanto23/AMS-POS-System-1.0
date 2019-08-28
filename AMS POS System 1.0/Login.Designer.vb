<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.nama_pengguna = New System.Windows.Forms.TextBox()
        Me.kata_sandi = New System.Windows.Forms.TextBox()
        Me.btn_masuk = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'nama_pengguna
        '
        Me.nama_pengguna.BackColor = System.Drawing.Color.White
        Me.nama_pengguna.Font = New System.Drawing.Font("Berlin Sans FB", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nama_pengguna.ForeColor = System.Drawing.Color.Gray
        Me.nama_pengguna.Location = New System.Drawing.Point(29, 187)
        Me.nama_pengguna.Name = "nama_pengguna"
        Me.nama_pengguna.Size = New System.Drawing.Size(424, 29)
        Me.nama_pengguna.TabIndex = 1
        Me.nama_pengguna.Text = "Nama Pengguna"
        '
        'kata_sandi
        '
        Me.kata_sandi.BackColor = System.Drawing.Color.White
        Me.kata_sandi.Font = New System.Drawing.Font("Berlin Sans FB", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.kata_sandi.ForeColor = System.Drawing.Color.Gray
        Me.kata_sandi.Location = New System.Drawing.Point(29, 239)
        Me.kata_sandi.Name = "kata_sandi"
        Me.kata_sandi.Size = New System.Drawing.Size(424, 29)
        Me.kata_sandi.TabIndex = 2
        Me.kata_sandi.Text = "password"
        Me.kata_sandi.UseSystemPasswordChar = True
        '
        'btn_masuk
        '
        Me.btn_masuk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btn_masuk.Font = New System.Drawing.Font("Berlin Sans FB", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_masuk.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btn_masuk.Location = New System.Drawing.Point(29, 322)
        Me.btn_masuk.Name = "btn_masuk"
        Me.btn_masuk.Size = New System.Drawing.Size(210, 50)
        Me.btn_masuk.TabIndex = 3
        Me.btn_masuk.Text = "Masuk"
        Me.btn_masuk.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Button1.Font = New System.Drawing.Font("Berlin Sans FB", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Button1.Location = New System.Drawing.Point(245, 322)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(208, 50)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Batal"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox1.Font = New System.Drawing.Font("Imprint MT Shadow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.CheckBox1.Location = New System.Drawing.Point(29, 283)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(170, 22)
        Me.CheckBox1.TabIndex = 5
        Me.CheckBox1.Text = "Tampilkan kata sandi"
        Me.CheckBox1.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.AMS_POS_System_1._0.My.Resources.Resources.icon1
        Me.PictureBox1.InitialImage = Global.AMS_POS_System_1._0.My.Resources.Resources.icon
        Me.PictureBox1.Location = New System.Drawing.Point(55, 30)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(385, 133)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 442)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.StatusStrip1.Size = New System.Drawing.Size(488, 25)
        Me.StatusStrip1.TabIndex = 6
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.ToolStripStatusLabel1.ForeColor = System.Drawing.Color.Chocolate
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(257, 20)
        Me.ToolStripStatusLabel1.Text = "www.amsgroup.id - IT Department"
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.DarkOrange
        Me.BackgroundImage = Global.AMS_POS_System_1._0.My.Resources.Resources.iOS_Background_2
        Me.ClientSize = New System.Drawing.Size(488, 467)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btn_masuk)
        Me.Controls.Add(Me.kata_sandi)
        Me.Controls.Add(Me.nama_pengguna)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login POS"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents nama_pengguna As TextBox
    Friend WithEvents kata_sandi As TextBox
    Friend WithEvents btn_masuk As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
End Class
