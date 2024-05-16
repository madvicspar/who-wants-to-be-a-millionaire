using System;
using NAudio.Wave;

public class AudioManager : IDisposable
{
    private WaveOutEvent outputDevice;
    private AudioFileReader audioFile;
    private bool isEnd = false;

    public AudioManager(string audioFilePath)
    {
        outputDevice = new WaveOutEvent();
        audioFile = new AudioFileReader(audioFilePath);
        isEnd = false;
        outputDevice.Init(audioFile);
        outputDevice.Volume = 0.01f;
        outputDevice.PlaybackStopped += OutputDevice_PlaybackStopped;
        outputDevice.Play();
    }

    private void OutputDevice_PlaybackStopped(object sender, StoppedEventArgs e)
    {
        if (e.Exception == null && !isEnd) // Проверка на завершение воспроизведения без ошибок
        {
            RestartPlayback();
        }
    }

    private void RestartPlayback()
    {
        audioFile.Position = 0; // Сброс позиции аудиофайла на начало
        outputDevice.Play(); // Начать воспроизведение заново
    }

    public void Stop()
    {
        isEnd = true;
        outputDevice.Stop();
        Dispose();
    }

    public void Dispose()
    {
        outputDevice.Dispose();
        audioFile.Dispose();
    }
}
