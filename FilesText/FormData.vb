' Mendefinisikan namespace IO untuk mengakses kelas file Input/Ouput   pada VB.NET
Imports System.IO
' Mendefinisikan kelas FormData
Public Class FormData
    ' Mendeklrasikan variabel path yang berisi alamat file untuk menyimpan data
    Private ReadOnly Path As String = "C:\Tugas\S2\Pemrogramanvisual\FilesText\FilesText\Files\Data.txt"
    Private ReadOnly Directory As String = "C:\Tugas\S2\Pemrogramanvisual\FilesText\FilesText\Files"
   ' Procedure
   Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
      ' Membuat folder direktori yang telah ditentukan
        My.Computer.FileSystem.CreateDirectory(Directory)

        Dim SaveData As StreamWriter

      ' Membuat objek StreamWriter untuk menulis file yang telah ditentukan
        SaveData = New StreamWriter(Path, True)
        Const firstName = "Dhimas "
        Const lastName = "Arista"
      ' Menulis data ke file
        SaveData.WriteAsync("Nama: " & firstName)
        SaveData.WriteLine(lastName)

      ' Menampilkan pesan bahwa data telah tersimpan
        MessageBox.Show("Data berhasil disimpan!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
      ' Menutupu file StreamWriter
        SaveData.Close()
    End Sub

   ' Mendefinisikan aksi ketika button2 di klik
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim DisplayData As StreamReader
        Dim data As String
      ' Memeriksa apakah file yang akan dihapus ada didalam direktori
        Try
      ' Percabangan
            If File.Exists(Path) Then
                ' Display data form a file
                DisplayData = New StreamReader(Path)
        ' Perulangan
                Do While Not DisplayData.EndOfStream
                    data = data & DisplayData.ReadLine & vbNewLine
                Loop
          ' Menampilkan pesan yang berisi data telah berhasil dibaca file
                MessageBox.Show(data, "Message", MessageBoxButtons.OK,MessageBoxIcon.Information)
            Else
          ' Menampilan pesan bahwa data harus disave terlebih dahulu
                MessageBox.Show("Simpan Data sebelum ditampilkan!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch
            DisplayData.Close()
        End Try
    End Sub
   ' Mendifinisikan button3
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
         ' Memeriksa apakah file yang akan dihapus ada di direktori
            If Not File.Exists(Path) Then
                MessageBox.Show("Tidak ditemukan!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                ' Delete file 
                File.Delete(Path)
          ' Menampilkan pesan, data berhasil di delete
                MessageBox.Show("Data berhasil dihapus!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch
         ' Menutup file
            FileClose()
        End Try
    End Sub
End Class