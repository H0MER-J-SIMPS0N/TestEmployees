using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TestEmployees.Models;

namespace TestEmployees
{
    public partial class MainWindow : Form
    {
        private int _currentColumnIndex = 0;
        private bool _ascending;
        private string _connectionString;
        private Repository _repository;
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        public MainWindow()
        {
            _logger.Info("Запуск приложения.");
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbxSearchFlags.SelectedItem?.ToString()))
            {
                return;
            }
            if (cbxSearchFlags.SelectedItem?.ToString().Equals("Фамилия") ?? false)
            {
                dgvResult.DataSource = _repository.GetEmployeesByPartOfLastName(txbSearchText.Text);
            }
            else
            {
                if (cbxSearchValues.SelectedItem is null)
                {
                    return;
                }
                dgvResult.DataSource = _repository.GetEmployeesBy(cbxSearchValues.SelectedItem.GetType(), (cbxSearchValues.SelectedItem as ITestDbModel).Id);
            }
            GetStatistics();
        }

        private void dgvResult_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvResult.DataSource is null)
            {
                return;
            }
            if (_currentColumnIndex == e.ColumnIndex && _ascending)
            {
                switch (e.ColumnIndex)
                {
                    case 0:
                        dgvResult.DataSource = (dgvResult.DataSource as IEnumerable<ModifiedEmployee>).OrderByDescending(x => x.Fio).ToList();
                        break;
                    case 1:
                        dgvResult.DataSource = (dgvResult.DataSource as IEnumerable<ModifiedEmployee>).OrderByDescending(x => x.Status).ToList();
                        break;
                    case 2:
                        dgvResult.DataSource = (dgvResult.DataSource as IEnumerable<ModifiedEmployee>).OrderByDescending(x => x.Department).ToList();
                        break; 
                    case 3:
                        dgvResult.DataSource = (dgvResult.DataSource as IEnumerable<ModifiedEmployee>).OrderByDescending(x => x.Position).ToList();
                        break;
                    case 4:
                        dgvResult.DataSource = (dgvResult.DataSource as IEnumerable<ModifiedEmployee>).OrderByDescending(x => x.DateEmploy).ToList();
                        break;
                    case 5:
                        dgvResult.DataSource = (dgvResult.DataSource as IEnumerable<ModifiedEmployee>).OrderByDescending(x => x.DateUnemploy).ToList();
                        break;
                }
                _ascending = false;
            }
            else
            {
                switch (e.ColumnIndex)
                {
                    case 0:
                        dgvResult.DataSource = (dgvResult.DataSource as IEnumerable<ModifiedEmployee>).OrderBy(x => x.Fio).ToList();
                        break;
                    case 1:
                        dgvResult.DataSource = (dgvResult.DataSource as IEnumerable<ModifiedEmployee>).OrderBy(x => x.Status).ToList();
                        break;
                    case 2:
                        dgvResult.DataSource = (dgvResult.DataSource as IEnumerable<ModifiedEmployee>).OrderBy(x => x.Department).ToList();
                        break;
                    case 3:
                        dgvResult.DataSource = (dgvResult.DataSource as IEnumerable<ModifiedEmployee>).OrderBy(x => x.Position).ToList();
                        break;
                    case 4:
                        dgvResult.DataSource = (dgvResult.DataSource as IEnumerable<ModifiedEmployee>).OrderBy(x => x.DateEmploy).ToList();
                        break;
                    case 5:
                        dgvResult.DataSource = (dgvResult.DataSource as IEnumerable<ModifiedEmployee>).OrderBy(x => x.DateUnemploy).ToList();
                        break;
                }
                _ascending = true;
            }
            _currentColumnIndex = e.ColumnIndex;
        }

        private void cbxSearchFlags_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbxSearchFlags.SelectedItem?.ToString() ?? string.Empty)
            {
                case "Должность":
                    cbxSearchValues.DataSource = _repository.Positions;
                    cbxSearchValues.DisplayMember = "Name";
                    txbSearchText.Visible = !(cbxSearchValues.Visible = true);
                    break;
                case "Отдел":
                    cbxSearchValues.DataSource = _repository.Departments;
                    cbxSearchValues.DisplayMember = "Name";
                    txbSearchText.Visible = !(cbxSearchValues.Visible = true);
                    break;
                case "Статус":
                    cbxSearchValues.DataSource = _repository.Statuses;
                    cbxSearchValues.DisplayMember = "Name";
                    txbSearchText.Visible = !(cbxSearchValues.Visible = true);
                    break;
                case "Фамилия":
                    cbxSearchValues.Visible = !(txbSearchText.Visible = true);
                    break;
            }
        }

        private void GetStatistics()
        {
            var status = (cbxStatisticStatuses.SelectedItem as Status)?.Name;
            var startDate = dtpStartDate.Value;
            var endDate = dtpEndDate.Value;
            if (dgvResult.DataSource is null) return;
            if (startDate > endDate)
            {
                txbStatisticsOutput.Text = "Ошибка! Начальная дата больше конечной даты!";
                return;
            }
            IEnumerable<ModifiedEmployee> statisticsList;
            StringBuilder sb = new StringBuilder();
            if (chbIsUneployed.Checked)
            {
                statisticsList = (dgvResult.DataSource as IEnumerable<ModifiedEmployee>)
                                    .Where(x =>
                                        !string.IsNullOrEmpty(x.DateUnemploy)
                                        && x.Status == status
                                        && DateTime.Parse(x.DateUnemploy) >= startDate
                                        && DateTime.Parse(x.DateUnemploy) <= endDate);
                var groupedList = statisticsList.GroupBy(y => new { y.DateUnemploy });
                if (!groupedList.Any())
                {
                    txbStatisticsOutput.Text = "Записей не найдено!";
                    return;
                }
                sb.AppendLine($"Количество сотрудников со статусом {(cbxStatisticStatuses.SelectedItem as Status).Name}, уволенных в период с {startDate:dd-MM-yyyy} по {endDate:dd-MM-yyyy} - {statisticsList.Count()}.");
                sb.AppendLine("Статистика по дням:");
                foreach (var employees in groupedList)
                {
                    sb.Append(employees.Key.DateUnemploy).Append(" - уволено ").AppendLine(employees.Count().ToString());
                }
                txbStatisticsOutput.Text = sb.ToString();
            }
            else
            {
                statisticsList = (dgvResult.DataSource as IEnumerable<ModifiedEmployee>)
                                    .Where(x =>
                                        string.IsNullOrEmpty(x.DateUnemploy)
                                        && x.Status == status
                                        && DateTime.Parse(x.DateEmploy) >= startDate
                                        && DateTime.Parse(x.DateEmploy) <= endDate);
                var groupedList = statisticsList.GroupBy(y => new { y.DateEmploy });
                if (!groupedList.Any())
                {
                    txbStatisticsOutput.Text = "Записей не найдено!";
                    return;
                }                
                sb.AppendLine($"Количество сотрудников со статусом {(cbxStatisticStatuses.SelectedItem as Status).Name}, нанятых в период с {startDate:dd-MM-yyyy} по {endDate:dd-MM-yyyy}:   {statisticsList.Count()}.");
                sb.AppendLine("Статистика по дням:");
                foreach (var employees in groupedList)
                {
                    sb.Append(employees.Key.DateEmploy).Append(" - нанято ").AppendLine(employees.Count().ToString());
                }
                txbStatisticsOutput.Text = sb.ToString();
            }            
        }

        private void cbxStatisticStatuses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dtpStartDate.Value > dtpEndDate.Value)
            {
                dtpStartDate.Value = dtpEndDate.Value;
            }
            txbStatisticsOutput.Text = string.Empty;
            GetStatistics();
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpStartDate.Value > dtpEndDate.Value)
            {
                dtpStartDate.Value = dtpEndDate.Value;
            }
            txbStatisticsOutput.Text = string.Empty;
            GetStatistics();
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpEndDate.Value < dtpStartDate.Value)
            {
                dtpEndDate.Value = dtpStartDate.Value;
            }
            txbStatisticsOutput.Text = string.Empty;
            GetStatistics();
        }

        private void chbIsUneployed_CheckedChanged(object sender, EventArgs e)
        {
            if (dtpEndDate.Value < dtpStartDate.Value)
            {
                dtpEndDate.Value = dtpStartDate.Value;
            }
            txbStatisticsOutput.Text = string.Empty;
            GetStatistics();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            _repository = new Repository(string.IsNullOrEmpty(_connectionString) ? string.Empty : _connectionString, _logger);
            while (!_repository.IsConnection)
            {
                MessageBox.Show("Не удалось подключиться к базе данных с указанными данными!!!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logger.Error($"Не удалось подключиться к базе данных с указанными данными: connectionString={_connectionString}");
                var enterConnectionString = new ConnectionStringWindow();
                var dialogResult = enterConnectionString.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    _connectionString = enterConnectionString.ResultConnectionString;
                }
                else if (dialogResult == DialogResult.Cancel)
                {
                    _logger.Info("Выход из приложения: инициировано пользователем.");
                    Environment.Exit(0);
                }
                else
                {
                    continue;
                }
                _repository = new Repository(string.IsNullOrEmpty(_connectionString) ? string.Empty : _connectionString, _logger);
            }
            _logger.Info($"Строка подключения={_connectionString}");
            cbxSearchFlags.SelectedIndex = 0;
            dtpEndDate.Value = DateTime.Now;
            dtpStartDate.Value = dtpEndDate.Value.AddYears(-1);
            cbxStatisticStatuses.DataSource = _repository.Statuses;
            cbxStatisticStatuses.DisplayMember = "Name";
            cbxStatisticStatuses.SelectedIndex = (cbxStatisticStatuses.DataSource as IEnumerable<Status>)?.Count() > 0 ? 0 : -1;
            GetStatistics();
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            _logger.Info("Выход из приложения.");
        }
    }
}
